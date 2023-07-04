#include <Windows.h>
#include <stdio.h>

typedef UINT(__stdcall* F)(HWND, const char*, const char*, UINT);


UINT __stdcall foo(HWND hwnd, const char* s1, const char* s2, UINT btn)
{
    printf("foo : %s, %s\n", s1, s2);
    
    //return MessageBoxA(hwnd, s1, s2, btn); // 재귀 호출

    HMODULE hDll = GetModuleHandleA("user32.dll");
    F f = (F)GetProcAddress(hDll, "MessageBoxA");

    return f(hwnd, s2, s1, btn);
}

int main()
{
    DWORD old;
    VirtualProtect((void*)0x041B09C, sizeof(void*), PAGE_READWRITE, &old);
    *((int*)0x041B09C) = (int)&foo;

    MessageBoxA(0, "API Hook", "AAA", 0);
}

