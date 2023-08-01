use market_db;

set @var1 = 5;
set @var2 = 4.25;

select @var1;
select @var1 + @var2;

set @txt = 'NAME ==>  ';
set @height = 166;

select @txt, mem_name from member where height > @height;

set @count = 3;
select mem_name, height from member order by height limit 3; #limit에 @count를 사용하지 못함.alter

set @count = 3;
prepare myTest from 'select mem_name, height from member order by height limit ?'; #위와 같이 사용이 안되고, 이렇게 써야하는데, 여기서 핵심은 ? 로 표기한다는 점
execute myTest using @count;
