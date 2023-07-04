// MyDynamic.h
#pragma once

#ifdef __cplusplus
extern "C" {
#endif

	__declspec(dllimport) int add(int a, int b);
	__declspec(dllimport) int __stdcall sub(int a, int b);

#ifdef __cplusplus
}
#endif
