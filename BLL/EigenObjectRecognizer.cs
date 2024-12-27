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
    [Serializable]
    public class EigenObjectRecognizer
    {
        private Image<Gray, Single>[] _eigenImages;
        private Image<Gray, Single> _avgImage;
        private Matrix<float>[] _eigenValues;
        private string[] _labels;
        private double _eigenDistanceThreshold;

        public void TrainModel(Image<Gray, Byte>[] images, String[] labels, double eigenDistanceThreshold, ref MCvTermCriteria termCrit)
        {
            Debug.Assert(images.Length == labels.Length, "Le nombre d'images doit être égal au nombre d'étiquettes.");
            Debug.Assert(eigenDistanceThreshold >= 0.0, "Le seuil de distance Eigen doit être supérieur ou égal à 0.0.");

            // Calcul des Eigenfaces et de l'image moyenne
            CalcEigenObjects(images, ref termCrit, out _eigenImages, out _avgImage);

            // Décomposition des images de formation en valeurs Eigen
            _eigenValues = Array.ConvertAll(images, img => new Matrix<float>(EigenDecomposite(img, _eigenImages, _avgImage)));

            // Initialisation des labels et du seuil de distance Eigen
            _labels = labels;
            _eigenDistanceThreshold = eigenDistanceThreshold;
        }

        public String RecognizeFace(Image<Gray, Byte> image)
        {
            int index;
            float eigenDistance;
            String label;
            FindMostSimilarObject(image, out index, out eigenDistance, out label);
            return (_eigenDistanceThreshold <= 0 || eigenDistance < _eigenDistanceThreshold) ? _labels[index] : String.Empty;
        }

        private void FindMostSimilarObject(Image<Gray, Byte> image, out int index, out float eigenDistance, out String label)
        {
            float[] dist = GetEigenDistances(image);
            index = 0;
            eigenDistance = dist[0];
            for (int i = 1; i < dist.Length; i++)
            {
                if (dist[i] < eigenDistance)
                {
                    index = i;
                    eigenDistance = dist[i];
                }
            }
            label = _labels[index];
        }

        private float[] GetEigenDistances(Image<Gray, Byte> image)
        {
            using (Matrix<float> eigenValue = new Matrix<float>(EigenDecomposite(image, _eigenImages, _avgImage)))
            {
                return Array.ConvertAll(_eigenValues, eigenValueI =>
                    (float)CvInvoke.cvNorm(eigenValue.Ptr, eigenValueI.Ptr, Emgu.CV.CvEnum.NORM_TYPE.CV_L2, IntPtr.Zero));
            }
        }

        public static void CalcEigenObjects(Image<Gray, Byte>[] trainingImages, ref MCvTermCriteria termCrit, out Image<Gray, Single>[] eigenImages, out Image<Gray, Single> avg)
        {
            int width = trainingImages[0].Width;
            int height = trainingImages[0].Height;

            IntPtr[] inObjs = Array.ConvertAll<Image<Gray, Byte>, IntPtr>(trainingImages, delegate (Image<Gray, Byte> img) { return img.Ptr; });
            if (termCrit.max_iter <= 0 || termCrit.max_iter > trainingImages.Length)

                termCrit.max_iter = trainingImages.Length;

            int maxEigenObjs = termCrit.max_iter;

            #region initialize eigen images 
            eigenImages = new Image<Gray, float>[maxEigenObjs];
            for (int i = 0; i < eigenImages.Length; i++)
                eigenImages[i] = new Image<Gray, float>(width, height);
            IntPtr[] eigObjs = Array.ConvertAll<Image<Gray, Single>, IntPtr>(eigenImages, delegate (Image<Gray, Single> img) { return img.Ptr; });
            #endregion
            avg = new Image<Gray, Single>(width, height);

            CvInvoke.cvCalcEigenObjects(
                inObjs, ref termCrit, eigObjs, null, avg.Ptr);

        }



        public static float[] EigenDecomposite(Image<Gray, Byte> src, Image<Gray, Single>[] eigenImages, Image<Gray, Single> avg)
        {
            return CvInvoke.cvEigenDecomposite(src.Ptr, Array.ConvertAll<Image<Gray, Single>, IntPtr>(eigenImages, delegate (Image<Gray, Single> img) { return img.Ptr; }), avg.Ptr);
        }
    }
}
