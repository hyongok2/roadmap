// See https://aka.ms/new-console-template for more information
using Google.Protobuf;
using Grpc.Net.Client;
using GrpcClient;
using System.Collections;
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

byte[] bytes = new byte[5];
bytes[0] = 254;
bytes[1] = 10;
bytes[2] = 16;
bytes[3] = 56;
bytes[4] = 126;

Stream stream = new MemoryStream(bytes);

message.DataArray = ByteString.FromStream(stream);

var response2 = client.SaySomething(message);

Console.WriteLine(response2.SomeMessage);

