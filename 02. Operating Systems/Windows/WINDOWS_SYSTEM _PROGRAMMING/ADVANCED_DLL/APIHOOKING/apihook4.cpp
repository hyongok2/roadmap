#include <Windows.h>
#include <stdio.h>
#include <DbgHelp.h>  
#pragma comment( lib, "DbgHelp.lib") 

typedef UINT(__stdcall* FUNC)(HWND, const char*, const char*, UINT);

UINT __stdcall foo(HWND hwnd, const char* s1, const char* s2, UINT btn)
{
	printf("foo : %s, %s\n", s1, s2);
	HMODULE hDll = GetModuleHandleA("user32.dll");
	FUNC f = (FUNC)GetProcAddress(hDll, "MessageBoxA");
	return f(hwnd, s1, s2, btn);
}

void Replace(HMODULE hExe, const char* dllname, void* api, void* func)
{
	// 1. .exe에서 import 섹션의 주소를 얻어낸다.
	ULONG sz;
	IMAGE_IMPORT_DESCRIPTOR* pImage = 
		(IMAGE_IMPORT_DESCRIPTOR*)ImageDirectoryEntryToData(hExe,
			TRUE, IMAGE_DIRECTORY_ENTRY_IMPORT, &sz);

	printf("Address Import Directory : %p\n", pImage);


	    




	// 2. 해당 DLL의 정보를 가진 항목을 찾아낸다.
	for (; pImage->Name; pImage++)
	{
		char* s = ((char*)hExe + pImage->Name);

		if (_strcmpi(s, dllname) == 0) break;
	}
	if (pImage->Name == 0)
	{
		printf("can not found %s\n", dllname);
		return;
	}
	printf("%s import table : %p\n", dllname, pImage);






	// 3. 이제 함수주소를 담은 table을 조사합니다.
	IMAGE_THUNK_DATA* pThunk =
		(IMAGE_THUNK_DATA*)((char*)hExe + pImage->FirstThunk);

	for (; pThunk->u1.Function; pThunk++)
	{
		if (pThunk->u1.Function == (DWORD)api)
		{
			DWORD* addr = &(pThunk->u1.Function);

			DWORD old;
			VirtualProtect(addr, sizeof(DWORD), PAGE_READWRITE, &old);

			//*addr = (DWORD)func;

			// WriteProcessMemory()
			DWORD len;
			WriteProcessMemory(GetCurrentProcess(), addr, &func, sizeof(DWORD), &len);

			VirtualProtect(addr, sizeof(DWORD), old, &old);
			break;
		}
	}
}

int main()
{
	Replace(GetModuleHandle(0), //= API 함수를 사용하는 모듈(exe)의 주소
		"user32.dll",			//= 후킹할 함수가 있는 dll이름
		&MessageBoxA,			//= 후킹할 API 함수 주소
		&foo);					//= 사용자 함수


	MessageBoxA(0, "aaa", "bbb", 0); 
}

