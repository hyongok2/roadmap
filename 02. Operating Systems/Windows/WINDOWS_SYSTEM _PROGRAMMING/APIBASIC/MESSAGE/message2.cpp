// message2.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

#define WM_MYMESSAGE   WM_APP + 100

LRESULT __stdcall WndProc(HWND   hwnd,   UINT   message,
                          WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_MYMESSAGE:

        break;


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

    HWND hwnd = CreateWindowEx(0, _T("MyWindow"), _T("Hello"), WS_OVERLAPPEDWINDOW,
        0, 0, 500, 500, 0, 0, 0, 0);
    ShowWindow(hwnd, SW_SHOW);

    MSG msg;

    while (GetMessage(&msg, 0, 0, 0))
    {
        DispatchMessage(&msg);
    }
    return msg.wParam;
}

