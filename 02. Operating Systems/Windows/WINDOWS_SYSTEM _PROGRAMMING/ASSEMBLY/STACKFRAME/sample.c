// sample.c
// cl sample.c /FAs
int add(int a, int b)
{
	int c = 0;
	int d = 0;

	c = a + b;
	return c;
}
int main()
{
	int n = add(1, 2);
	// return 0
}
// mainCRTStartup