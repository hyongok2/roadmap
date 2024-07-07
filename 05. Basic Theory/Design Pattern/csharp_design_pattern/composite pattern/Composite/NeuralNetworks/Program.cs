using NeuralNetworks;


// 이 샘플 코드는 정상 동작하지 않음. Composite에 대한 기본 개념

var neuron1 = new Neuron();
var neuron2 = new Neuron();
var neuron3 = new Neuron();
var neuron4 = new Neuron();
var neuron5 = new Neuron();
var neuron6 = new Neuron();
var layer1 = new NeuronLayer();
var layer2 = new NeuronLayer();

neuron1.ConnectTo(neuron2);
layer1.ConnectTo(neuron1);
layer2.ConnectTo(neuron3);
layer2.ConnectTo(neuron4);
layer2.ConnectTo(neuron5);
layer2.ConnectTo(neuron6);
layer1.ConnectTo(layer2);

Console.WriteLine(layer2.Count);