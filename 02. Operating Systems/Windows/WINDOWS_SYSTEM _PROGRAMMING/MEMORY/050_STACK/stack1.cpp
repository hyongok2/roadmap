
void foo(int a, int b)
{
	int c = 0;
	
	foo(1, 2);	// 재귀 호출
}

int main()
{
	int n1 = 10;
	int n2 = 20;

	foo(1, 2);
}