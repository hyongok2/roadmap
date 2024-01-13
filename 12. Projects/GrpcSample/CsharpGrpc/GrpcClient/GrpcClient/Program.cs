// See https://aka.ms/new-console-template for more information
using Google.Protobuf;
using Grpc.Net.Client;
using GrpcClient;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

byte[] loadBitmap(string filename, int width, int height)
{
    byte[] data = new byte[width * height];
    BitmapData bmpData = null;
    Bitmap slice = new Bitmap(filename);

    Size resize = new Size(width, height);
    Bitmap resizeImage = new Bitmap(slice, resize);

    Rectangle rect = new Rectangle(0, 0, resizeImage.Width, resizeImage.Height);
    bmpData = resizeImage.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
    int size = bmpData.Height * bmpData.Stride;
    System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, size);
    resizeImage.UnlockBits(bmpData);
    return data;
}


Console.WriteLine("Machine Learning Test~!");

var channel = GrpcChannel.ForAddress("http://127.0.0.1:50051");

var mlClient = new GrpcClient.MachineLearning.MachineLearning.MachineLearningClient(channel);

string fileName = "Sample2.jpg";

byte[] imageByte = loadBitmap(fileName, 28, 28);

Stream imageStream = new MemoryStream(imageByte);
imageStream.Seek(0, SeekOrigin.Begin);// this is important
var sendMessage = new GrpcClient.MachineLearning.NumberImage();
sendMessage.DataArray = ByteString.FromStream(imageStream);
var prediction = mlClient.PredictNumberImage(sendMessage);

Console.WriteLine($"숫자 이미지의 예측 값은 {prediction.Value} 입니다.");

//while(true)
//{
//    Console.WriteLine("숫자를 입력해 주세요.");

//    var sendNumber = new GrpcClient.MachineLearning.IntNumber();

//    try
//    {
//        sendNumber.Value = int.Parse(Console.ReadLine()!);
//    }
//    catch (Exception)
//    {
//        break;
//    }

//    var returnMessage = mlClient.GetRandomNumberImage(sendNumber);

//    Stream streamImage = new MemoryStream(returnMessage.DataArray.ToByteArray());

//    Image imageReturn = Image.FromStream(streamImage);

//    string fileName = $"Number_{sendNumber.Value}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";

//    imageReturn.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);

//    Console.WriteLine("결과를 받아서 저장했어요. 받은 파일의 예측 결과를 확인합니다.");

//    byte[] imageByte = loadBitmap(fileName, 28, 28);

//    Stream imageStream = new MemoryStream(imageByte);
//    imageStream.Seek(0, SeekOrigin.Begin);// this is important

//    var sendMessage = new GrpcClient.MachineLearning.NumberImage();
//    sendMessage.DataArray = ByteString.FromStream(imageStream);

//    var prediction = mlClient.PredictNumberImage(sendMessage);

//    Console.WriteLine($"숫자 이미지의 예측 값은 {prediction.Value} 입니다.");
//}

return;

var calcClient = new GrpcClient.Calculator.Calculator.CalculatorClient(channel);

var number = new GrpcClient.Calculator.Number();

number.Value = 225;

var response = calcClient.SquareRoot(number);

Console.WriteLine(response.Value);

GrpcClient.Calculator.MyMessage message = new GrpcClient.Calculator.MyMessage();

message.SomeMessage = "Luca";
message.DataArray = ByteString.CopyFrom("e#>&*m16", Encoding.Unicode);


// Test no.1 just some numbers
//byte[] bytes = new byte[5];
//bytes[0] = 254;
//bytes[1] = 10;
//bytes[2] = 16;
//bytes[3] = 56;
//bytes[4] = 126;

//Stream stream = new MemoryStream(bytes);
//message.DataArray = ByteString.FromStream(stream);

//Test no2 Image Send and recv and save.
//Image _image = Image.FromFile("number6_2.jpg");

//byte[] imageByte = loadBitmap("number7.jpg", 28,28);

//Stream imageStream = new MemoryStream(imageByte);

//_image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
//imageStream.Seek(0, SeekOrigin.Begin);// this is important

//message.DataArray = ByteString.FromStream(imageStream);
//var response2 = calcClient.SaySomething(message);

//Stream streamImage = new MemoryStream(response2.DataArray.ToByteArray());

//Image imageReturn = Image.FromStream(streamImage);

//imageReturn.Save("returnPhoto.jpg", System.Drawing.Imaging.ImageFormat.Png);

//Console.WriteLine(response2.SomeMessage + "you've got number " + response2.Value.ToString());
//Console.WriteLine("your number is " + response2.Value.ToString());


