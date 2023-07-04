// call.c
int add()
{
	return 300;
}
void __fastcall foo(int a, int b, int c, int d)
{

}
int main()
{
	foo(1, 2, 3, 4);
	add();
}