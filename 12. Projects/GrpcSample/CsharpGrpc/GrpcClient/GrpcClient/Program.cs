// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcClient;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("http://127.0.0.1:50051");

var client = new Calculator.CalculatorClient(channel);

Number number = new Number();

number.Value = 225;

var response = client.SquareRoot(number);

Console.WriteLine(response.Value); 
