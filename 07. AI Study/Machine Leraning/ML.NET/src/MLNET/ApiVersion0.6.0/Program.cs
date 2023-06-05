// See https://aka.ms/new-console-template for more information



using ApiVersion0._6._0;
using Microsoft.ML;
using Microsoft.ML.Runtime.Data;
using Microsoft.ML.Trainers;

var env = new LocalEnvironment();

var reader = TextLoader.CreateReader(env, ctx =>(
    INPUT1: ctx.LoadFloat(0),
    OUTPUT: ctx.LoadFloat(1)
    ),hasHeader:true,separator:',');

var data = reader.Read(new MultiFileSource("SampleData.csv"));

var regression = new RegressionContext(env);

var pipeline = reader.MakeNewEstimator()
    .Append(r => (
    r.OUTPUT,
    Prediction: regression.Trainers.FastTree(label: r.OUTPUT, features: r.INPUT1.AsVector())
    ));

var model = pipeline.Fit(data).AsDynamic;

var predictionFunction = model.MakePredictionFunction<SampleData, SampleDataPrediction>(env);

while(true)
{
    var prediction = predictionFunction.Predict(new SampleData { INPUT1 = int.Parse(Console.ReadLine()!) });
    Console.WriteLine($"예측 결과값 : {prediction.PredictedOutput}");
}
