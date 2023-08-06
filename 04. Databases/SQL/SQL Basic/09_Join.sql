use market_db;

select * 
from buy
inner join member
on buy.mem_id = member.mem_id
where buy.mem_id = 'GRL';

# 전체 항목 표시
select * 
from buy
inner join member
on buy.mem_id = member.mem_id;

# 선택 항목만 표시
select buy.mem_id, mem_name, prod_name, addr, concat(phone1,phone2) as '연락처'
 from buy
 inner join member
 on buy.mem_id = member.mem_id;
 
 # 별명 추가
 select B.mem_id, M.mem_name, B.prod_name, M.addr, concat(M.phone1,M.phone2) as '연락처'
 from buy B
 inner join member M
 on B.mem_id = M.mem_id;
 
 #아웃터 조인
 select M.mem_id,M.mem_name,B.prod_name, M.addr
 from member M  
 left outer join buy B   #테이블 위치 기준으로 left right를 구분.
 on M.mem_id = B.mem_id
 order by M.mem_id;
 
select M.mem_id,M.mem_name,B.prod_name, M.addr
 from buy B
 right outer join member M 
 on M.mem_id = B.mem_id
 order by M.mem_id;
 
 #크로스 조인 : 일반적으로 별 의미는 없음. 테스트용 대용량 데이터 만들기용.
 select *
  from buy
  cross join member;
  
 select count(*) '데이터 갯수'
  from sakila.inventory
  cross join world.city;
  
  # cross join을 이용한 Test용 Table 만들기
  create table cross_table
  select *
  from sakila.actor
  cross join world.country;
  
  select * from cross_table limit 5;

# 자체 조인 활용  
USE market_db;
CREATE TABLE emp_table (emp CHAR(4), manager CHAR(4), phone VARCHAR(8));

INSERT INTO emp_table VALUES('대표', NULL, '0000');
INSERT INTO emp_table VALUES('영업이사', '대표', '1111');
INSERT INTO emp_table VALUES('관리이사', '대표', '2222');
INSERT INTO emp_table VALUES('정보이사', '대표', '3333');
INSERT INTO emp_table VALUES('영업과장', '영업이사', '1111-1');
INSERT INTO emp_table VALUES('경리부장', '관리이사', '2222-1');
INSERT INTO emp_table VALUES('인사부장', '관리이사', '2222-2');
INSERT INTO emp_table VALUES('개발팀장', '정보이사', '3333-1');
INSERT INTO emp_table VALUES('개발주임', '정보이사', '3333-1-1');

SELECT A.emp "직원" , B.emp "직속상관", B.phone "직속상관연락처"
   FROM emp_table A
      INNER JOIN emp_table B
         ON A.manager = B.emp
   WHERE A.emp = '경리부장';
  
select A.emp, B.emp, B.phone
     FROM emp_table A
      INNER JOIN emp_table B
       on A.manager = B.emp;
	
  
  
  
  
 
 