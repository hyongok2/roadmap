// api2.cpp
#include <Windows.h>

int main()
{
	int    n = 0;
	double d = 3.4;

	DWORD  n1 = 10;
	UINT   n2 = 10; 
	
	POINT pt;

	PINT p1; // int*
	PSTR p2; // char*
	PCSTR p3;// const char*

	MessageBoxA(0, "AA", "BB", MB_RETRYCANCEL);
}