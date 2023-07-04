// Hello.c
#include <stdio.h>

char s[] = "abcdefg";

int main()
{
	void* p = malloc(sizeof(int) * 100);

	free(p);	// dll				

	printf("hello, world\n");
}

