using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy_Meli
{
    class Result
    {
        public List<Prediction> PredictionsList { get; set; }

        public Result()
        {
            PredictionsList = new List<Prediction>();
        }
    }
}
