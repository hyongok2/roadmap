// inherit_ko3.cpp
#undef UNICODE
#undef _UNICODE
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

LRESULT __stdcall WndProc(HWND   hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    static HWND hEdit;

    switch (message)
    {
    case WM_CREATE:
        hEdit = CreateWindowEx(0, _T("edit"), _T(""),
            ES_MULTILINE | WS_CHILD | WS_VISIBLE | WS_BORDER,
            10, 10, 300, 500, hwnd, (HMENU)1, 0, 0);
        break;


    case WM_LBUTTONDOWN:
    {
        HANDLE hRead, hWrite;

        CreatePipe(&hRead, &hWrite, 0, 1024);



        SetHandleInformation(hWrite, HANDLE_FLAG_INHERIT, HANDLE_FLAG_INHERIT);



        STARTUPINFO si = { 0 };
        si.cb = sizeof(si);

        si.hStdOutput = hWrite;
        si.dwFlags = STARTF_USESTDHANDLES;


        PROCESS_INFORMATION pi = { 0 };

        TCHAR name[] = _T("ping www.microsoft.com");

        BOOL b = CreateProcess(0, name, 0, 0, TRUE,
            CREATE_NO_WINDOW, 0, 0, &si, &pi);


        if (b)
        {
            CloseHandle(hWrite);

            while (1)
            {
                DWORD len;
                char buff[4096] = { 0 };

                BOOL b1 = ReadFile(hRead, buff, 4096, &len, 0);

                if (len <= 0) // 파이프가 끊어진 경우(ping 종료)
                    break;

                // buff의 내용을 edit 출력
                SendMessage(hEdit, EM_REPLACESEL, 0, (LPARAM)buff);
            }


            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
        }
    }
    return 0;






    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    }
    return DefWindowProc(hwnd, message, wParam, lParam);
}




int __stdcall _tWinMain(HINSTANCE, HINSTANCE, LPTSTR, int)
{
    WNDCLASSEX wcex = { 0 };

    wcex.cbSize = sizeof(wcex);
    wcex.lpfnWndProc = WndProc;
    wcex.lpszClassName = _T("MyWindow");
    wcex.hbrBackground = CreateSolidBrush(RGB(255, 255, 255));
    wcex.hCursor = LoadCursor(0, IDC_ARROW);

    ATOM atom = RegisterClassEx(&wcex);

    HWND hwnd = CreateWindowEx(0, _T("MyWindow"), _T("Hello"),
        WS_OVERLAPPEDWINDOW,
        0, 0, 500, 500, 0, 0, 0, 0);

    ShowWindow(hwnd, SW_SHOW);

    MSG msg;

    while (GetMessage(&msg, 0, 0, 0))
    {
        DispatchMessage(&msg);
    }
    return msg.wParam;
}



