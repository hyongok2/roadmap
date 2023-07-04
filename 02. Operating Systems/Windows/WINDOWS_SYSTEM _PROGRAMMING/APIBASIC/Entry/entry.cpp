// entry.cpp ( api_basic.cpp บนป็ )
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

//#pragma comment(linker, "/subsystem:console")


LRESULT __stdcall WndProc(HWND   hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_LBUTTONDOWN:
        printf("LBUTTONDOWN\n");
        break;

    case WM_KEYDOWN:
        printf("WM_KEYDOWN\n");
        break;

    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    }
    return DefWindowProc(hwnd, message, wParam, lParam);
}

int main()
//int __stdcall WinMain(HINSTANCE h1, HINSTANCE h2,
//                        LPSTR cmd, int showCmd)
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



