#include <stdio.h>
#include <windows.h>

int main()
{
	int n = 0;
		
	__try
	{
		int s = 10 / n;

		//....
	}
	__except (1)
	{
		printf("excepion : %x\n", GetExceptionCode());
	}
	printf("main continue\n");
}

