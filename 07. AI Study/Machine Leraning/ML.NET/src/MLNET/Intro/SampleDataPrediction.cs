using Microsoft.ML.Data;
using Microsoft.ML.Runtime.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    internal class SampleDataPrediction
    {
        [ColumnName("Score")]
        public float PredictedOutput;
    }
}
