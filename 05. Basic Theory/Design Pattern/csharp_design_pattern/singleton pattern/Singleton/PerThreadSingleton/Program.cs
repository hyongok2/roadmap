using PerThread;

var t1 = Task.Factory.StartNew(() =>
{
    Console.WriteLine($"t1: " + PerThreadSingleton.Instance.Id);
});
var t2 = Task.Factory.StartNew(() =>
{
    Console.WriteLine($"t2: " + PerThreadSingleton.Instance.Id);
    Console.WriteLine($"t2 again: " + PerThreadSingleton.Instance.Id);
});
Task.WaitAll(t1, t2);