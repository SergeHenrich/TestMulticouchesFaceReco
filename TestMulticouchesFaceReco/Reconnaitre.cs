using BL;
using BLL;
using DAL;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMulticouchesFaceReco
{
    public partial class Reconnaitre : Form
    {
        FaceRecognizeService service;
        #region Region Variables
        Image<Bgr, byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        List<string> NamePersons = new List<string>();
        string name, names = null;
        int t, contrain, NumLabels;
        #endregion
        #region Reconnaitre
        private void btnRV_Click(object sender, EventArgs e)
        {
            try
            {
                grabber = new Emgu.CV.Capture();
                if (grabber == null)
                {
                    MessageBox.Show("Erreur : impossible de se connecter à la camera.");
                    return;
                }
                grabber.QueryFrame();
                Application.Idle += new EventHandler(FrameGrabber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'initialisation de la camera : " + ex.Message);
            }
        }
        #endregion
        #region Arrêt
        private void btnAC_Click(object sender, EventArgs e)
        {
            Application.Idle -= FrameGrabber;
            if (grabber == null)
            {
                grabber.Dispose();
                grabber = null;
            }
        }

        private void Reconnaitre_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Boutton retour
        private void btnRE_Click(object sender, EventArgs e)
        {
            Démarrage d1 = new Démarrage();
            d1.Show();
            this.Hide();
        }
        #endregion
        public Reconnaitre()
        {
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            InitializeComponent();
            string dbPath = @"|DataDirectory|\FacialDdb.mdf";
            service = new FaceRecognizeService(dbPath);
            service.TrainModel();
            InitializeDatabase();
        }
        #region Méthode des événements
        void FrameGrabber(object sender, EventArgs e)
        {
            try
            {
                if (trainingImages.Count == 0 || labels.Count == 0)
                {
                    MessageBox.Show("Aucune image d'entraînement trouvée.");
                    return;
                }

                NamePersons.Add("");
                lblNV.Text = "0";
                //Capture une image dans la caméra
                currentFrame = grabber.QueryFrame()?.Resize(320, 240, INTER.CV_INTER_CUBIC);
                if (currentFrame == null)
                {
                    MessageBox.Show("Erreur : impossible de capturer un frame depuis la caméra");
                    return;
                }
                //redimmensionne la taille de l'image à partir du cadre formé. 
                gray = currentFrame.Convert<Gray, Byte>();
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t++;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                    currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);

                    if (trainingImages.Count > 0)
                    {
                        // Utiliser le recognizer déjà initialisé dans FaceRecognizeService
                        name = service.RecognizeFace(result);

                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                    }
                    NamePersons[t - 1] = name;
                    NamePersons.Add("");
                    lblNV.Text = facesDetected[0].Length.ToString();
                }
                t = 0;
                names = string.Join(", ", NamePersons.ToArray());
                CameraBox.Image = currentFrame;
                label2.Text = names;
                NamePersons.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du traitement de l'image : " + ex.Message);
            }
        }



        #endregion
        #region InitializeDataBase
        private void InitializeDatabase()
        {
            try
            {
                int count = 0;
                var trainingData = service.fdal.LoadTrainingData();
                if (trainingData == null || trainingData.Count == 0)
                {
                    throw new Exception("Aucune donnée de formation trouvée.");
                }
                foreach (var data in trainingData)
                {
                     trainingImages.Add(data.Item2); labels.Add(data.Item1);
                } contrain = trainingData.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pas d'image formée: " + ex.Message);
            }
        }
        #endregion
    }
}
