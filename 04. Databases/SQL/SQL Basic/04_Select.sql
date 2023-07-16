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