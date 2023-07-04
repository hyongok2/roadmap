#include <stdio.h>
#include <windows.h>

int main()
{
	SYSTEM_INFO si = { 0 };
	
	GetSystemInfo(&si);
	printf("PAGE SIZE: %d\n", si.dwPageSize);
	printf("Max Addr : %p\n", si.lpMaximumApplicationAddress);
	printf("Min Addr : %p\n", si.lpMinimumApplicationAddress);


	MEMORYSTATUSEX mse = { 0 };
	mse.dwLength = sizeof(mse);
	GlobalMemoryStatusEx(&mse);

	printf("user mode total size : %lld\n", mse.ullTotalVirtual); // 2G - 128K
	printf("user mode avail size : %lld\n", mse.ullAvailVirtual);
}

	
	