// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System.Linq.Expressions;

var someClass = new SomeClass
{
    Word = "Nice",
    Number = 999,
    FloatNumber = 3.14
};


string searchProperty = "FloatNumber";// <- just Use Property Name.. I think I can use this with configuration..


// 하드 코딩 방식 - 확장성이 없다.
if( searchProperty== "number" )
{
    Console.WriteLine(someClass.Number);
}
else if(searchProperty== "word" )
{
    Console.WriteLine(someClass.Word);
}

// Expression Tree를 사용하면 아래과 같이 할 수 있음.
// FloatNumber 가 Class가 있는 경우에 위와 같이 하드코딩 하지 않고, 사용 가능함!
ParameterExpression parameter = Expression.Parameter(typeof(SomeClass));
var accessor = Expression.PropertyOrField(parameter, searchProperty);

var lambda = Expression.Lambda(accessor, true, parameter);

Console.WriteLine(lambda.Compile().DynamicInvoke(someClass));

Console.ReadLine();

public class SomeClass
{
    public string Word { get; set; }
    public int Number { get; set; }
    public double FloatNumber { get; set; }
}