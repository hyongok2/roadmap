// k_Stack.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include <vector>
#include <stack>

using namespace std;

// 이 문제는 Stack을 활용한 오른쪽 큰수 찾기 문제이다.
// Stack 을 활용하여 시간 복잡도를 줄이는 점이 포인트이다.
// 이 문제의 핵심은 현재의 비교되는 값을 기준으로 한다는 점이다. 
// 만약 수열을 기준으로 오른쪽 큰수를 찾으려고 한다면, 우측의 모든 수열을 확인해야 한다. 큰 값이 나올때까지..
// 하지만, 반대로 비교되는 값을 기준으로 아래와 같이 처리하면, 비교 횟수를 줄일 수 있다.
// 기본적인 예제 같지만, 사실 Idea를 이해하기는 쉽지 않다고 생각한다.
// 결국 이런류의 해결방법을 암기해 버리는게 좋겠다.
// 89Page

int main()
{
	int N;
	cin >> N;

	vector<int> A(N, 0);
	vector<int> ans(N, 0);

	for (int i = 0; i < N; i++)
	{
		cin >> A[i];
	}

	stack<int> myStack;
	myStack.push(0);

	for (int i = 0; i < N; i++)
	{
		while (!myStack.empty() && A[myStack.top()] < A[i]) {
			ans[myStack.top()] = A[i];
			myStack.pop();
		}
		myStack.push(i);
	}
	while (!myStack.empty())
	{
		ans[myStack.top()] = -1;
		myStack.pop();
	}

	for (int i = 0; i < N; i++)
	{
		cout << ans[i] << " ";
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
