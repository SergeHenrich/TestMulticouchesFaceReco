using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FaceRecognizeLogic
    {
       
            public EigenObjectRecognizer _recognizer;
        

            public void TrainModel(List<Image<Gray, byte>> images, List<string> labels)
            {
            //Vérifie si le model a été entrainer et que les etiquêtes ont bien été affecter aux eigen decomposer
            if (images == null || images.Count == 0)
            {
                throw new ArgumentException("Les images d'entraînement ne peuvent pas être null ou vides.");
            }
            if (labels == null || labels.Count == 0)
            {
                throw new ArgumentException("Les étiquettes ne peuvent pas être null ou vides.");
            }
            MCvTermCriteria termCrit = new MCvTermCriteria(images.Count, 0.001);
                _recognizer = new EigenObjectRecognizer();
                _recognizer.TrainModel(images.ToArray(), labels.ToArray(), 3000, ref termCrit);
            }

            public string RecognizeFace(Image<Gray, byte> image)
            {
            if (_recognizer == null)
            {
                throw new InvalidOperationException("Le modèle doit être entraîné avant la reconnaissance.");
            }
            if (image == null)
            {
                throw new ArgumentException("L'image fournie ne peut pas être null.");
            }
            return _recognizer.RecognizeFace(image);
            }       
    }
}
