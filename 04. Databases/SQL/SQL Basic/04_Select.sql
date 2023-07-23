USE market_db;

select mem_name 이름, debut_date 데뷔, mem_number
from member 
where mem_number NOT BETWEEN 5 AND 7;

select mem_name 이름, debut_date 데뷔, mem_number
from member 
where addr IN('경기','경북') ;

select mem_name 이름, debut_date 데뷔, mem_number
from member 
where mem_name LIKE '%소녀%' ;

select mem_name 이름, debut_date 데뷔, mem_number
from member 
where mem_name LIKE '소녀__' ;

select mem_name, mem_number,debut_date
from member
where mem_number > 5
order by mem_number desc, debut_date asc
limit 6;

select mem_name, mem_number,debut_date
from member
where mem_number > 5
order by mem_number desc, debut_date asc
limit 3,2; #3번쨰 다음부터 2개 항목 즉(4,5)

select addr from member;

select addr from member order by addr;

select distinct addr from member;

select mem_id, amount
from buy
order by mem_id;

select mem_id, sum(amount)
from buy
group by mem_id;


select mem_id, sum(amount*price)
from buy
group by mem_id;

select avg(amount) from buy group by mem_id;

select mem_number, count(*) from member group by mem_number order by mem_number;

select count(phone1) from member;

select mem_id, sum(price*amount) 
from buy
group by mem_id
having sum(price*amount) > 1000
order by sum(price*amount) desc;





