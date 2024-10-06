using BitFragging;

var numbers = new[] { 1, 3, 5, 7 };
int numberOfOps = numbers.Length - 1;

for (int result = 0; result <= 10; ++result)
{
    for (var key = 0UL; key < (1UL << 2 * numberOfOps); ++key)
    {
        var tbs = new TwoBitSet(key);
        var ops = Enumerable.Range(0, numberOfOps)
          .Select(i => tbs[i]).Cast<Op>().ToArray();
        var problem = new Problem(numbers, ops);
        if (problem.Eval() == result)
        {
            Console.WriteLine($"{new Problem(numbers, ops)} = {result}");
            break;
        }
    }
}

Console.ReadKey();