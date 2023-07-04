// window2.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int main()
{
    WNDCLASSEX wcex = { 0 };
    wcex.cbSize         = sizeof(wcex);
    wcex.lpfnWndProc    = DefWindowProc;
    wcex.lpszClassName  = _T("MyWindow");
    wcex.hbrBackground  =
        CreateSolidBrush(RGB(255, 255, 255));
    wcex.hCursor        = LoadCursor(0, IDC_ARROW);

    ATOM atom = RegisterClassEx(&wcex);

    if (atom == 0)
    {
        printf("등록 실패 : %d\n", GetLastError());
    }


    HWND hwnd = CreateWindowEx(WS_EX_TOPMOST, 
                    _T("MyWindow"),
                    _T("Hello"), 
                    
        WS_OVERLAPPEDWINDOW & ~WS_MINIMIZEBOX,
                            //& ~WS_SYSMENU,
        
        0, 0, 500, 500,
                    0, 0, 0, 0);




    ShowWindow(hwnd, SW_SHOW);

    MessageBox(0, _T(""), _T(""), MB_OK);
}
