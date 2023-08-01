use market_db;
create table datatest(
	tiny_int tinyint,
    small_ine smallint,
    normal_int int,
    big_int bigint);
    
insert into datatest values(127,32767,2100000000, 900000000000000);
insert into datatest values(127,32768,2200000000, 900000000000000); #out of range

alter table datatest modify small_ine smallint unsigned;

## char vs. varchar
## char는 속도가 빠른 대신에 메모리를 고정적으로 사용한다. (그래서 글자수가 고정인 경우에는 char를 사용하는 것이 유리하다)
## varchar는 메모리 활용이 가변적이다. 대신에 느리다는 단점이 있다.

create database netflix_db;
use netflix_db;
create table movie(
 movie_id int,
 movid_title varchar(30),
 movie_director varchar(20),
 movie_star varchar(20),
 movie_script longtext,
 movie_file longblob
);



