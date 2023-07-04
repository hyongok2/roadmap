#include <stdio.h>
#include <windows.h>

int main()
{
	//# PAGE 크기 구하기
	SYSTEM_INFO si = { 0 };
	GetSystemInfo(&si);
	printf("PAGE SIZE : %d\n", si.dwPageSize);


	//# 물리메모리 크기, Page File 크기 얻기
	MEMORYSTATUSEX mse = { 0 };
	mse.dwLength = sizeof(mse);

	GlobalMemoryStatusEx(&mse);

	printf("Total      Phy Mem : %lld\n", mse.ullTotalPhys);	//# 1. 설치된 물리메모리의 크기
	printf("Avalilable Phy Mem : %lld\n", mse.ullAvailPhys);	//# 2. 할당 가능한 물리 메모리의 크기
	printf("Total    Page File : %lld\n", mse.ullTotalPageFile);//# 3. Paging File의 최대 크기
	
}    