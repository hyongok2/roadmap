// calling_convention2.c
void __cdecl    f1(int a, int b) {  }
void __stdcall  f2(int a, int b) {  }
void __fastcall f3(int a, int b) {  }
void __fastcall f4(int a, int b, int c, int d) {  } 

int main()
{
	f1(1, 2);
	f2(1, 2);
	f3(1, 2);
	f4(1, 2, 3, 4);
}