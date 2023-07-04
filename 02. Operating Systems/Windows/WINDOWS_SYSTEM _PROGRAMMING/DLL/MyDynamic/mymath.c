// mymath.c

__declspec(dllexport) int add(int a, int b)
{
	return a + b;
}

__declspec(dllexport) int __stdcall sub(int a, int b)
{ 
	return a - b;  
}
      
