// 32bit debug 모드
#include <Windows.h>
#include <stdio.h>

// MessageBoxA 를 후킹할 함수
// MessageBoxA 함수의 모양(signature)가 동일 해야 한다.
UINT __stdcall foo(HWND hwnd, const char* s1, const char* s2, UINT btn)
{
	printf("foo : %s, %s\n", s1, s2);

	return 0;
}
   
int main()
{
	// MessageBoxA 의 주소를 담은 IAT 항목을 덮어쓴다..
    DWORD old;
    VirtualProtect((void*)0x041B098, sizeof(void*), PAGE_READWRITE, &old);
     
    *((int*)0x041B098) = (int)&foo;

  	MessageBoxA(0, "API Hook", "AAA", 0); 
}
    
         