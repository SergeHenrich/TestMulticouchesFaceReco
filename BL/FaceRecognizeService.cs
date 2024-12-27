using BLL;
using DAL;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    public class FaceRecognizeService
    {
        public readonly FaceDAL fdal;
        public readonly FaceRecognizeLogic logic;

        public FaceRecognizeService(string dbPath)
        {
            fdal = new FaceDAL(dbPath);
            logic = new FaceRecognizeLogic();
        }
       
        public void TrainModel()
        {
            var trainingData = fdal.LoadTrainingData();
            List<Image<Gray, byte>> images = trainingData.Select(t => t.Item2).ToList();
            List<string> labels = trainingData.Select(t => t.Item1).ToList();
            logic.TrainModel(images, labels);
        }

        public string RecognizeFace(Image<Gray, byte> image)
        {
            return logic.RecognizeFace(image);
        }

    }
}
