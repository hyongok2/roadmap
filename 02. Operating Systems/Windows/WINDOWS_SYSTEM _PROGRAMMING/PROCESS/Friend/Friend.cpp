// "콘솔 어플리케이션" - Friend.cpp(api_basic.cpp복사)
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

LRESULT __stdcall WndProc(HWND   hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_APP+100:
    {
        HANDLE hFile = (HANDLE)lParam;

        DWORD len;
        char data[256] = "hello";
        
        BOOL b = WriteFile(hFile, data, 256, &len, 0);

        printf("%s\n", b ? "성공" : "실패");

        CloseHandle(hFile);
    }
    return 0;



    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    }
    return DefWindowProc(hwnd, message, wParam, lParam);
}

int main()
{
    WNDCLASSEX wcex = { 0 };

    wcex.cbSize = sizeof(wcex);
    wcex.lpfnWndProc = WndProc;
    wcex.lpszClassName = _T("MyWindow");
    wcex.hbrBackground = CreateSolidBrush(RGB(255, 255, 255));
    wcex.hCursor = LoadCursor(0, IDC_ARROW);

    ATOM atom = RegisterClassEx(&wcex);

    HWND hwnd = CreateWindowEx(0, _T("MyWindow"),
        _T("Friend"), WS_OVERLAPPEDWINDOW,
        0, 0, 500, 500, 0, 0, 0, 0);

    ShowWindow(hwnd, SW_SHOW);

    MSG msg;

    while (GetMessage(&msg, 0, 0, 0))
    {
        DispatchMessage(&msg);
    }
    return msg.wParam;
}

