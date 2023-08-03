// j_SlidingWindow2.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include<deque>

using namespace std;

typedef pair<int, int> Node;

//77page 문제
int main()
{
	int N, L;
	cin >> N >> L;

	deque<Node> mydeque;

	for (int i = 0; i < N; i++) {
		int now;
		cin >> now;
		// 덱의 마지막 값이 추가하려는 값보다 크면 덱에서 삭제할 수 있다.
		while (mydeque.size() && mydeque.back().first > now)
		{
			mydeque.pop_back();
		}
		//그리고 추가한다.
		mydeque.push_back(Node(now, i));

		if (mydeque.front().second <= i - L)
		{
			mydeque.pop_front();
		}

		cout << mydeque.front().first << ' ';
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
