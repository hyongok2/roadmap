using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace Intro
{
    public static class Day2_CrossValidation
    {
        public static void Run()
        {
            var pipeline = new LearningPipeline();

            pipeline.Add(new TextLoader("SampleData.csv").CreateFrom<SampleData>(useHeader: true, separator: ','));
            pipeline.Add(new ColumnConcatenator("Features", "INPUT1"));
            pipeline.Add(new GeneralizedAdditiveModelRegressor());

            var crossValidator = new CrossValidator { Kind = MacroUtilsTrainerKinds.SignatureRegressorTrainer, NumFolds = 5 };

            var crossValidatorOutput = crossValidator.CrossValidate<SampleData, SampleDataPrediction>(pipeline);

            crossValidatorOutput.RegressionMetrics.ForEach(m => Console.WriteLine(m.Rms));

            var rmsSum = crossValidatorOutput.RegressionMetrics.Sum(m => m.Rms);
            var r2Sum = crossValidatorOutput.RegressionMetrics.Sum(m => m.RSquared);

            Console.WriteLine($"average rms - {rmsSum / crossValidatorOutput.RegressionMetrics.Count}");
            Console.WriteLine($"average r^2 - {r2Sum / crossValidatorOutput.RegressionMetrics.Count}");

            foreach (var model in crossValidatorOutput.PredictorModels)
            {
                var prediction = model.Predict(new SampleData { INPUT1 = int.Parse(Console.ReadLine()!) });
                Console.WriteLine(prediction.PredictedOutput);
                Console.WriteLine("################################################");

            }

        }
    }
}
