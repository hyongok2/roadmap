#include <Windows.h>
#include <stdio.h>

void print_module_address(const char* name)
{
	HANDLE hMod = GetModuleHandleA(name);

	if (name == 0) name = ".exe";

	printf("%15s : %p\n", name, hMod);
}   
             
int main()
{    
	print_module_address(0); 
	print_module_address("kernel32.dll");
	print_module_address("user32.dll");
	print_module_address("gdi32.dll");
	print_module_address("ntdll.dll");
}