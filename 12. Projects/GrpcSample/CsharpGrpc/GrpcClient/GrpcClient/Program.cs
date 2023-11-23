// See https://aka.ms/new-console-template for more information
using Google.Protobuf;
using Grpc.Net.Client;
using GrpcClient;
using System.Collections;
using System.Drawing;
using System.Text;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("http://127.0.0.1:50051");

var client = new Calculator.CalculatorClient(channel);

Number number = new Number();

number.Value = 225;

var response = client.SquareRoot(number);

Console.WriteLine(response.Value);

MyMessage message = new MyMessage();

message.SomeMessage = "Luca";
//message.DataArray = ByteString.CopyFrom("e#>&*m16", Encoding.Unicode);


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
Image _image = Image.FromFile("photo.jpg");

Stream imageStream = new MemoryStream();

_image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
imageStream.Seek(0, SeekOrigin.Begin);// this is important

message.DataArray = ByteString.FromStream(imageStream);

var response2 = client.SaySomething(message);

Stream streamImage = new MemoryStream(response2.DataArray.ToByteArray());

Image imageReturn = Image.FromStream(streamImage);

imageReturn.Save("returnPhoto.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

Console.WriteLine(response2.SomeMessage);



