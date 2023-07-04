// main.c
#include <stdio.h>

#include "mydynamic.h"

#pragma comment(lib, "mydynamic.lib")
    

int main()     
{
	int ret = add(1, 2);
	     
	printf("result : %d\n", ret);
}
