use market_db;

select AVG(price) '평균가격' from buy;

select CAST(avg(price) as signed) from buy;

select convert(avg(price), signed) from buy;

select cast('2023$08$01' as date);

select num, concat(cast(price as char), 'X', cast(amount as char), '=') '가격 X 수량', price*amount '구매액' from buy;

select concat(100,'200');
select '100' + '200';#정수로 변환됨.
select 1 > '2mega'; #문자가 정수로 변환되어 처리됨.
select 0 = 'mega2'; # 문자가 0으로 변환됨.
