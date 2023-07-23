// i_SlidingWindow.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>

using namespace std;

int checkArr[4];
int myArr[4];
int checkSecret = 0;
void Add(char c);
void Remove(char c);

int main()
{
	int S, P;
	cin >> S >> P;

	int result = 0;

	string A;
	cin >> A;

	for (int i = 0; i < 4; i++)
	{
		cin >> checkArr[i];
		if (checkArr[i] == 0)
		{
			checkSecret++;
		}
	}

	for (int i = 0; i < P; i++)
	{
		Add(A[i]);
	}
	if (checkSecret == 4) result++;

	for (int i = P; i < S; i++)
	{
		int j = i - P;
		Add(A[i]);
		Remove(A[j]);

		if (checkSecret == 4)
		{
			result++;
		}
	}

	cout << result << "\n";
}

void Add(char c)
{
	switch (c)
	{
	case 'A':
		myArr[0]++;
		if (myArr[0] == checkArr[0]) checkSecret++;
		break;
	case 'C':
		myArr[1]++;
		if (myArr[1] == checkArr[1]) checkSecret++;
		break;
	case 'G':
		myArr[2]++;
		if (myArr[2] == checkArr[2]) checkSecret++;
		break;
	case 'T':
		myArr[3]++;
		if (myArr[3] == checkArr[3]) checkSecret++;
		break;
	default:
		break;
	}
}


void Remove(char c)
{
	switch (c)
	{
	case 'A':
		if (myArr[0] == checkArr[0]) checkSecret--;
		myArr[0]--;
		break;
	case 'C':
		if (myArr[1] == checkArr[1]) checkSecret--;
		myArr[1]--;
		break;
	case 'G':
		if (myArr[2] == checkArr[2]) checkSecret--;
		myArr[2]--;
		break;
	case 'T':
		if (myArr[3] == checkArr[3]) checkSecret--;
		myArr[3]--;
		break;
	default:
		break;
	}
}

// 프로그램 실행: <Ctrl+F5> 또는 [디버그] > [디버깅하지 않고 시작] 메뉴
// 프로그램 디버그: <F5> 키 또는 [디버그] > [디버깅 시작] 메뉴

// 시작을 위한 팁: 
//   1. [솔루션 탐색기] 창을 사용하여 파일을 추가/관리합니다.
//   2. [팀 탐색기] 창을 사용하여 소스 제어에 연결합니다.
//   3. [출력] 창을 사용하여 빌드 출력 및 기타 메시지를 확인합니다.
//   4. [오류 목록] 창을 사용하여 오류를 봅니다.
//   5. [프로젝트] > [새 항목 추가]로 이동하여 새 코드 파일을 만들거나, [프로젝트] > [기존 항목 추가]로 이동하여 기존 코드 파일을 프로젝트에 추가합니다.
//   6. 나중에 이 프로젝트를 다시 열려면 [파일] > [열기] > [프로젝트]로 이동하고 .sln 파일을 선택합니다.
