// See https://aka.ms/new-console-template for more information

using Intro;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

var pipeline = new LearningPipeline();

pipeline.Add(new TextLoader("SampleData.csv").CreateFrom<SampleData>(useHeader:true, separator:','));
pipeline.Add(new ColumnConcatenator("Features","INPUT1"));
pipeline.Add(new GeneralizedAdditiveModelRegressor());

var model = pipeline.Train<SampleData, SampleDataPrediction>();

var prediction = model.Predict(new SampleData { INPUT1 = 3000 });

Console.WriteLine(prediction.PredictedOutput);

// 1일차 학습 관련 
// 먼저 ML.NET의 최신버전과 위의 내용은 호환이 되지 않는다.
// 최신 버전에 대한 학습이 필요하겠다.

// 그리고 일단 위의 로직은 생각보다 형편 없다.
// 간단한 연산 모델조차 쉽게 찾지 못한다.
// 최근의 라이브러리는 좀 나아졌는지 확인이 필요하겠다.
