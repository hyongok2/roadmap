use market_db;
create table table1(
col1 int primary key,
col2 int,
col3 int
);

show index from table1;

create table table2(
col1 int primary key, -- 자동으로 인덱스로 지정됨. (클러스터형 인덱스 : 영어 사전같은.. 자동 정렬)
col2 int unique,
col3 int unique
);

show index from table2;

drop table if exists buy, member;

create table member(
mem_id char(8),
mem_name varchar(10),
mem_number int,
addr char(2)
);

insert into member values('TWC','트와이스',9,'서울');
insert into member values('BLK','블랙핑크',4,'경기');
insert into member values('WMN','여자친구',7,'경기');
insert into member values('OMY','오마이걸',6,'서울');

select * from member; -- 여기서는 정렬이 안되고 입력한 순서대로 나오는 것을 확인할 수 있음.

alter table member
add constraint
primary key (mem_id); --  PK 지정하면 아래 구문으로 정렬이 됨을 확인할 수 있음.
select * from member; 

alter table member drop primary key; -- 위에 PK 제거
alter table member
add constraint
primary key (mem_name); --  PK 다시 지정하면 아래 구문으로 정렬이 됨을 확인할 수 있음.
select * from member; -- 이름 순서로 정렬됨 확인.


insert into member values('GRL','소녀시대',8,'서울');
select * from member; -- 추가 입력된 자료는 클러스터 인덱스 기준으로 정렬되어 삽입된다.  -- 이 때문에 삽입 삭제하는 경우에 더 시간이 오래걸리는 것 같다.

-- 보조인덱스의 경우에는 Unique  로 지정하면 된다.
-- 다만 보조 인덱스로 지정한다고 해서,  데이터가 정렬되는 것은 아니다. 책에 찾아보기 같은 구성이 추가된다고 생각하면 됨.

drop table if exists buy, member;

create table member(
mem_id char(8),
mem_name varchar(10),
mem_number int,
addr char(2)
);

insert into member values('TWC','트와이스',9,'서울');
insert into member values('BLK','블랙핑크',4,'경기');
insert into member values('WMN','여자친구',7,'경기');
insert into member values('OMY','오마이걸',6,'서울');
select * from member; 

alter table member
add constraint
unique (mem_id);

select * from member; -- 위에 유니크를 추가했지만, 확인해 보면 정렬이 바뀌지 않는 것을 알 수 있다.

alter table member
add constraint
unique (mem_name);
select * from member; 

show index from member;