use naver_db;
drop table if exists buy,member;
create table member
(mem_id char(8) not null primary key,
mem_name varchar(10) not null,
height tinyint unsigned null
);

describe member;

drop table if exists buy,member;

create table member
(mem_id char(8) not null,
mem_name varchar(10) not null,
height tinyint unsigned null,
 primary key (mem_id)
);

drop table if exists buy,member;

create table member
(mem_id char(8) not null,
mem_name varchar(10) not null,
height tinyint unsigned null
);

alter table member
add constraint
primary key (mem_id);

describe member;

drop table if exists buy,member;
create table member
(mem_id char(8) not null primary key,
mem_name varchar(10) not null,
height tinyint unsigned null
);

create table buy
(
num int auto_increment not null primary key,
mem_id char(8) not null,
prod_name char(8) not null,
foreign key (mem_id) references member(mem_id)
);

describe member;

drop table if exists buy;

create table buy(
num int auto_increment not null primary key,
mem_id char(8) not null,
prod_name char(8) not null
);

alter table buy
	add constraint
    foreign key(mem_id) references member(mem_id);

insert into member values('BLK','블랙핑크',163);
insert into buy values(null,'BLK','지갑');
insert into buy values(null,'BLK','맥북');

select M.mem_id, M.mem_name, B.prod_name
	from buy B
    inner join member M
    on B.mem_id = M.mem_id;
    
## update member set mem_id='PINK' where mem_id='BLK'; ## <- 외래키 제약으로 변경 불가!

## 외래키 제약관련 바꾸고자 할때는 아래와 같은 구문으로 전체 제약을 동시에 바꿀 수 있다.

## 1. on update cascade


drop table if exists buy;

create table buy(
num int auto_increment not null primary key,
mem_id char(8) not null,
prod_name char(8) not null
);

alter table buy
	add constraint
    foreign key(mem_id) references member(mem_id)
    on update cascade
    on delete cascade; ## <- 위의 두 구분이 아래를 가능하게 함. 

insert into buy values(null,'BLK','지갑');
insert into buy values(null,'BLK','맥북');

update member set mem_id='PINK' where mem_id='BLK'; ## 연결된 테이블의 항목까지 같이 Update 됨.

select * from buy;

delete from member where mem_id='PINK'; ## 연결된 테이블의 항목까지 같이 삭제됨.
select * from buy;


drop table if exists buy, member;

create table member(
mem_id char(8) not null,
mem_name varchar(10) not null,
height tinyint unsigned null,
email char(30) null unique ## 유니크 키
);

insert into member values('BLK','블랙핑크',163,'pink@gmail.com');
insert into member values('TWC','트와이스',167, null);
## insert into member values('APN','에이핑크',164,'pink@gmail.com'); ## 유니크 키 중복으로 입력 불가

select * from member;


drop table if exists buy, member;

create table member(
mem_id char(8) not null,
mem_name varchar(10) not null,
height tinyint unsigned null check (height > 100),  ##check 제약 조건 추가
phone1 char(3) null
);

insert into member values('BLK','블랙핑크',163, null);
# insert into member values('TWC','트와이스',99, null); # 100 이상만 입력 가능
select * from member;

alter table member
    add constraint
    check (phone1 in ('02','031','032','054')); # check 제약 조건 추가alter


insert into member values('TWC','트와이스',167, '02');
# insert into member values('OMY','오마이걸',167, '011'); # 위의 check 제약 조건으로 입력 불가


drop table if exists buy, member;

create table member(
mem_id char(8) not null,
mem_name varchar(10) not null,
height tinyint unsigned null default 160,  ## default로 입력하면 디폴트 값으로 입력됨.
phone1 char(3) null
);

alter table member
alter column phone1 set default '02';

insert into member values('BLK','블랙핑크',163, default);
insert into member values('TWC','트와이스', default, default); ## 이렇게 디폴트로 설정해야 디폴트로 입력되는 구나.
select * from member;


