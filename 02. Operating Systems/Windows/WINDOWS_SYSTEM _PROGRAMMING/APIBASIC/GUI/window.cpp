// window.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>
  
int main()
{
    // 1. ������ Ŭ���� �����
    WNDCLASSEX wcex = { 0 };
    wcex.cbSize      = sizeof(wcex);
    wcex.lpfnWndProc = DefWindowProc;
    wcex.lpszClassName = _T("MyWindow");

    // 2. ������ Ŭ������ �ý��ۿ� ���
    ATOM atom = RegisterClassEx(&wcex);

    if (atom == 0)
    {
        printf("��� ���� : %d\n", GetLastError());
    }


    // 3. ��ϵ� Ŭ������ ����ؼ� ������ ����

    HWND hwnd = CreateWindowEx(0,
                    _T("MyWindow"),
                    _T("Hello"),
                    WS_OVERLAPPEDWINDOW,
                    0, 0, 500, 500,
                    0, 0, 0, 0);


    // 4. ������ ��Ÿ����
    ShowWindow(hwnd, SW_SHOW);

    MessageBox(0, _T(""), _T(""), MB_OK);
}
