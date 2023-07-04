#include <stdio.h>
#include <Windows.h>

class AAA
{
public:
	~AAA() {}
};
int main()
{
	AAA aaa;
	__try
	{		
		char* p = 0;
		*p = 0;
	}
	__except(EXCEPTION_EXECUTE_HANDLER)
	{
		printf("exception\n");
	}
}
