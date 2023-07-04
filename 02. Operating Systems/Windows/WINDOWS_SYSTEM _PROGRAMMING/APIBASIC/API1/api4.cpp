// api4.cpp
#include <Windows.h>
#include <tchar.h>

int main()
{
	MessageBoxA(0, "Hello",       "API", MB_OK);
	MessageBoxW(0, L"Hello",     L"API", MB_OK);
	MessageBox (0, _T("Hello"), _T("API"), MB_OK);
}
