use market_db;

select mem_id, mem_name, addr from member;

create view v_member
as
select mem_id,mem_name,addr from member;

select * from v_member;

select mem_name,addr from v_member
where addr in ('서울','경기');

# 뷰를 사용하는 이유는 보안때문이다. 외부에서 접근 필요한 정보만 Open해서 사용할 수 있다.

create view v_memberbuy
as
select B.mem_id, M.mem_name, B.prod_name, M.addr,
       concat(M.phone1,M.phone2) 'contact'
       from buy B
       inner join member M
       on B.mem_id = M.mem_id;
       
select * from v_memberbuy;

select * from v_memberbuy where mem_name = '블랙핑크';

create view v_viewtest1
as
select B.mem_id 'Member ID', M.mem_name 'Member Name', B.prod_name 'Product Name', M.addr 'Address',
       concat(M.phone1,M.phone2) 'Office Phone'
       from buy B
       inner join member M
       on B.mem_id = M.mem_id;
       
select distinct `Member ID`,`Member Name` from v_viewtest1; ## 백틱(`) 을 사용해야 한다. 띄어쓰기 있는 경우 조회할때

select * from v_viewtest1;

alter view v_viewtest1
as
select B.mem_id '회원 아이디', M.mem_name as '회원 이름', B.prod_name '제품 이름', M.addr '주소',
       concat(M.phone1,M.phone2) '연락처'
       from buy B
       inner join member M
       on B.mem_id = M.mem_id;
       
select distinct `회원 아이디`,`회원 이름` from v_viewtest1;


create or replace view v_viewtest2
as
select mem_id,mem_name,addr from member;

describe v_viewtest2;

describe member;

show create view v_viewtest2;

select * from v_member;
update v_member set addr = '부산' where mem_id='BLK';  -- 정보 변경은 가능함.
select * from v_member;


-- insert는 안됨. : table의 모든 정보가 없기 때문에 (모든 정보가 다 있는 뷰라고 하면 될 수 있음. 다만 뷰를 통한 추가는 하지 않는 것이 좋음. )


CREATE VIEW v_height167
AS
    SELECT * FROM member WHERE height >= 167 ;
    
SELECT * FROM v_height167 ;

DELETE FROM v_height167 WHERE height < 167;

INSERT INTO v_height167 VALUES('TRA','티아라', 6, '서울', NULL, NULL, 159, '2005-01-01') ;

SELECT * FROM v_height167;

select * from member;

ALTER VIEW v_height167
AS
    SELECT * FROM member WHERE height >= 167
        WITH CHECK OPTION ;
        
# INSERT INTO v_height167 VALUES('TOB','텔레토비', 4, '영국', NULL, NULL, 140, '1995-01-01') ;  -- 위에 with check option 떄문에 추가가 안됨, 어치되었든 뷰에는 추가하지 않는 것이 좋음.

CREATE VIEW v_complex
AS
    SELECT B.mem_id, M.mem_name, B.prod_name, M.addr
        FROM buy B
            INNER JOIN member M
            ON B.mem_id = M.mem_id;

DROP TABLE IF EXISTS buy, member;

SELECT * FROM v_height167; -- 위에서 Drop 해서 조회가 안됨.

CHECK TABLE v_height167; -- 문제의 이유를 확인할 수 있음.
