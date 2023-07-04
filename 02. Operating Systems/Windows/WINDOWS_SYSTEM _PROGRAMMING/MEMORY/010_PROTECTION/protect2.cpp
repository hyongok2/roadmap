#include <string>
#include <Windows.h>
#include <map>
using namespace std;

// m[4] = "PAGE_READWRITE"
std::map<DWORD, string> m = { {PAGE_NOACCESS, "PAGE_NOACCESS"},
							  {PAGE_READONLY, "PAGE_READONLY"},
							  {PAGE_READWRITE, "PAGE_READWRITE"},
							  {PAGE_WRITECOPY, "PAGE_WRITECOPY"},
							  {PAGE_EXECUTE, "PAGE_EXECUTE"},
							  {PAGE_EXECUTE_READ, "PAGE_EXECUTE_READ"},
							  {PAGE_EXECUTE_READWRITE, "PAGE_EXECUTE_READWRITE"},
							  {PAGE_EXECUTE_WRITECOPY, "PAGE_EXECUTE_WRITECOPY"},
						      {PAGE_GUARD,			"PAGE_GUARD"},
							  {PAGE_NOCACHE,		"PAGE_NOCACHE"},
							  {PAGE_WRITECOMBINE,	"PAGE_WRITECOMBINE"} };

// 0x04 => "PAGE_READWRITE" 
std::string protection_string(DWORD protect)
{
	std::string str;

	for (auto it : m)
	{
		if (protect & it.first)
			if (str.empty())
				str = it.second;
			else
				str = str + " | " + it.second;
	}

	return str;
}

void print_memory_info(void* addr)
{
	MEMORY_BASIC_INFORMATION mbi = { 0 };
	VirtualQuery(addr, &mbi, sizeof(mbi));

	printf("%p, %s\n",addr, protection_string(mbi.Protect).c_str() );
}




int x = 0;	
 
int main()
{
	int y = 0;

	void* p1 = &main;	// 함수 주소
	void* p2 = &x;		// 전역변수 주소
	void* p3 = &y;		// 지역변수 주소

	print_memory_info(p1);
	print_memory_info(p2);
	print_memory_info(p3);
}