
using System.Linq.Expressions;

List<Rule> rules = new List<Rule>()
{
    new Rule
    {
        PropertyName= "Name",
        Operation = Operation.Equal,
        Value = "gary"
    },
    new Rule
    {
        PropertyName= "HireDate",
        Operation = Operation.GreaterThan,
        Value = new DateTime(2016,1,1)
    },
};

var parameter = Expression.Parameter(typeof(Employee));
BinaryExpression binaryExpression = null;

foreach( var rule in rules)
{
    var prop = Expression.Property(parameter, rule.PropertyName!);
    var value = Expression.Constant(rule.Value);
    var newBinary = Expression.MakeBinary((ExpressionType)Enum.Parse(typeof(ExpressionType),rule.Operation.ToString()), prop, value);

    binaryExpression = binaryExpression == null ?
        newBinary : Expression.MakeBinary(ExpressionType.AndAlso, binaryExpression, newBinary); // 룰을 이어서 처리할 수 있음.
}

var lambda = Expression.Lambda<Func<Employee,bool>>(binaryExpression!, parameter).Compile();// 람다식으로 생성.

var emp = new Employee
{
    Name= "gary",
    HireDate= new DateTime(2004,1,1)
};

var result = lambda.Invoke(emp);

Console.WriteLine(result);

Console.ReadLine();
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime HireDate { get; set; }
}

public class Rule
{
    public string PropertyName { get; set; }
    public Operation Operation { get; set; }
    public object Value { get; set; }
}

public enum Operation
{
    GreaterThan,
    LessThan,
    Equal
}