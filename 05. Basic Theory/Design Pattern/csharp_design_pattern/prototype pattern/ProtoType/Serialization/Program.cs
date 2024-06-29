
using Serialization;

Foo foo = new Foo { Stuff = 42, Whatever = "abc" };

// 둘다 사용 가능함..
// 물론 이것의 성능에 대한 부분은 다른 ProtoType 방식과 어떤 차이가 있는지에 대하여 비교해보고 상황에 맞게 사용되어야 한다.

//Foo foo2 = foo.DeepCopy();
Foo foo2 = foo.DeepCopyXml();

foo2.Whatever = "xyz";
Console.WriteLine(foo);
Console.WriteLine(foo2);

public class Foo
{
    public uint Stuff;
    public string Whatever;

    public override string ToString()
    {
        return $"{nameof(Stuff)}: {Stuff}, {nameof(Whatever)}: {Whatever}";
    }
}
