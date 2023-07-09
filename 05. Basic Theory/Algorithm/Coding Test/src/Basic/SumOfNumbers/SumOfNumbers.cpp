// SumOfNumbers.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>

using namespace std;

int main()
{
    int N = 0;
    string numbers;
    cin >> N;
    cin >> numbers;

    int sum = 0;

    for (int i = 0; i < numbers.length(); i++)
    {
        sum += numbers[i] - '0';
    }

    cout << sum << "\n";
    
}

#include <string>
void study()
{
    string sNum = "1234";
    string sNum_d = "1234.12";

    int iNum = stoi(sNum);
    long lNum = stol(sNum);
    double dNum = stod(sNum_d);
    float fNum = stof(sNum_d);

    string intToString = to_string(1234);
    string doubleToString = to_string(1234.12);
}