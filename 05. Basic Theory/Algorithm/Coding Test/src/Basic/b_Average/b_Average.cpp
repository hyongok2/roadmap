// b_Average.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;

int main()
{
    int N = 0;
    int A[1000];
    cin >> N;

    for (int i = 0; i < N; i++)
    {
        cin >> A[i];
    }

    long sum = 0;
    long max = 0;

    for (int i = 0; i < N; i++)
    {
        if (A[i] > max)
        {
            max = A[i];
        }

        sum += A[i];
    }

    double result = sum * 100.0 / max / N;
    cout << result << "\n";
}
