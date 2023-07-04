// window_object.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain()
{
	HWND hwnd = FindWindow(_T("Notepad"), 0);

	getchar();

	LONG style = GetWindowLongPtr(hwnd, GWL_STYLE);

	//style = style | WS_XXX; // ��Ÿ�� �߰�

	style = style & ~WS_CAPTION;
	style = style & ~WS_THICKFRAME;

	SetWindowLongPtr(hwnd, GWL_STYLE, style);

	// ��Ÿ���� ������ ��� ������ �ٽ� �׸��� �Ѵ�.
	SetWindowPos(hwnd, 0, 0, 0, 0, 0,
		SWP_NOZORDER | SWP_NOMOVE | SWP_NOSIZE |
		SWP_DRAWFRAME);


}
















