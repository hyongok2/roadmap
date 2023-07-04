// handle2.cpp
#include <windows.h>

//typedef int HWND;
//typedef int HICON;
/*
struct HWND__
{
};
typedef struct HWND__* HWND;

struct HICON__
{
};
typedef struct HICON__* HICON;
*/
struct HWND__
{ 
	int unused; 
}; 

typedef struct HWND__* HWND;


void MoveWindow(HWND hwnd, int x, int y)
{
}

HICON CreateIcon() { return 0; }

int main()
{
	HANDLE h = CreateIcon();

	HICON hIcon = CreateIcon();

	MoveWindow(hIcon, 10, 10);
}





