// unicode1.cpp
#include <stdio.h>
#include <string.h>

int main()
{
	char s[] = "abcd�����ٶ�";

	printf("%d\n", sizeof(s));
	printf("%d\n", strlen(s));
}