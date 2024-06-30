

using AdaptePattern;
using MoreLinq;

List<VectorObject> vectorObjects = new List<VectorObject>
    {
      new VectorRectangle(1, 1, 10, 10),
      new VectorRectangle(3, 3, 6, 6)
    };

Draw();
Draw();


void Draw()
{
    foreach (var vo in vectorObjects)
    {
        foreach (var line in vo)
        {
            var adapter = new LineToPointAdapter(line);
            adapter.ForEach(DrawPoint);
        }
    }
}



void DrawPoint(Point p)
{
    Console.Write(".");
}
