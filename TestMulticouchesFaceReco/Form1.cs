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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMulticouchesFaceReco
{
    public partial class Form1 : Form
    {
        FaceRecognizeService service;
        FaceBLL fbll = new FaceBLL();
       // FaceDAL _fdal;
        #region Variables
        Capture grabber; // partir de la caméra
        Image<Bgr, byte> currentFrame; //actuelle capturée
        // Bibliothèque pour les collections 
        // Bibliothèque pour l'interaction 
        // Bibliothèque pour la manipulation 
        // Bibliothèque pour la gestion des 
        // Bibliothèque pour les interfaces 
        // Capture d'image à 
        // Stocke l'image 
        Image<Gray, byte> gray, result, TrainedFace = null; // Images pour   HaarCascade face;                          // Cascade de Haar pour la détection de visages
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>(); // Liste des images d'entraînement 
        List<string> labels = new List<string>();  // Liste des étiquettes  associées aux images d'entraînement 
        int ContTrain = 0;                         // Compteur pour le  nombre d'images d'entraînement
        int t = 0;                                 // Compteur pour le nombre de visages détectés niveaux de gris, résultat et visage entraîné
        HaarCascade face = new HaarCascade("haarcascade_frontalface_default.xml");
        #endregion
        #region Boutton démarrer
        private void btnDemarrer_Click(object sender, EventArgs e)
        {
            try
            {
                grabber = new Capture();                    // Initialise la capture vidéo
                grabber.QueryFrame();                       // Capture un frame initial


                if (grabber == null)
                {
                    MessageBox.Show("Erreur : Impossible de se connecter à la caméra.");
                    return;
                }

                Application.Idle += FrameGrabber;           // Ajoute FrameGrabber pour traitement continu
                btnDF.Visible = true;                 // Rend le bouton "Détecter" visible
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        #endregion
        #region Détecter   
        private void btnDF_Click(object sender, EventArgs e)
        {
            label1.Visible = true;                      // Affiche le label pour entrer un nom
            txtNom.Visible = true;                      // Affiche la zone de texte pour entrer le nom
            btnArrêtModel.Visible = true;                // Rend le bouton "Entrainer" visible

            // Redimensionne le visage détecté pour l'entraînement et  l'affiche dans imageBox2 
            TrainedFace = result.Resize(100, 100, INTER.CV_INTER_CUBIC);
            pic2.Image = TrainedFace.Bitmap;
        }
        #endregion
        #region Entrainer Model     
        private void btnArrêtModel_Click(object sender, EventArgs e)
        {
            if(TrainedFace.Bitmap != null) { 
            fbll.nom = txtNom.Text;
            ContTrain++;
            // Conversion de l'image en tableau d'octets
            MemoryStream ms = new MemoryStream(); Bitmap bmp = new Bitmap(100, 100);
            pic2.DrawToBitmap(bmp, new Rectangle(0, 0, 100, 100)); bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            fbll.FaceID = ms.ToArray();
            // Enregistrement des données faciales dans la base de données
            service.fdal.SaveFaceData(fbll.FaceID, fbll.nom);
            service.TrainModel();
            MessageBox.Show(txtNom.Text + " ajouter et model entrainer avec succès !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(txtNom.Text + "n'a pas été ajouter et le model n'a pas été entrainer le model !");
            }
        }
        #endregion
        #region Arrêt  
        private void btnArrêt_Click(object sender, EventArgs e)
        {
            if (grabber != null)
            {
                Application.Idle -= FrameGrabber;  // Arrête l'événement FrameGrabber pour le traitement continu grabber.Dispose();
                // Libère la capture  pour arrêter la caméra
                grabber = null; //pour éviter toute réutilisation accidentelle
            }
        }
        #endregion
        #region Retour
        private void btnRetour_Click(object sender, EventArgs e)
        {
            Démarrage d1 = new Démarrage();
            d1.Show();
            this.Hide();
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            string dbPath = @"|DataDirectory|\FacialDdb.mdf";
            service = new FaceRecognizeService(dbPath);
        }

        #region RegionFrameGrabber
        void FrameGrabber(object sender, EventArgs e)
        {
            // Capture le frame actuel depuis la caméra et le redimensionne 
            currentFrame = grabber.QueryFrame().Resize(320, 240, INTER.CV_INTER_CUBIC);

            // Convertit l'image capturée en niveaux de gris 
            gray = currentFrame.Convert<Gray, Byte>();

            // Détecte les visages dans l'image en niveaux de gris 
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            // Pour chaque visage détecté, exécute l'action suivante 
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t++;  // Incrémente le compteur de visages détectés 
                      // Recadre et redimensionne le visage détecté pour créer  une image de résultat
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                // Dessine un rectangle rouge autour du visage détecté 
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
            }

            // Affiche l'image traitée dans imageBox1 
            pic1.Image = currentFrame.Bitmap;
        }


        #endregion

    }
}
