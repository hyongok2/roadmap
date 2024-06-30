
using GenericAdapter;

var v = new Vector2i(1, 2);
v[0] = 0;

var vv = new Vector2i(3, 2);

VectorOfInt<Vector2i, Dimensions.Two> result = v + vv;

var vvv = Vector2i.Create(1, 2);

Vector3f u = Vector3f.Create(3.5f, 2.2f, 1);

var uu = new Vector3f(3.0f, 1.0f, 1);

Vector3f uuu = (Vector3f)(u + uu);

Console.WriteLine("");
