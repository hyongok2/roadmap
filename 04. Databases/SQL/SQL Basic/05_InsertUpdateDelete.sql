USE market_db;

create table hongong1(toy_id INT, toy_name CHAR(4), age INT);

insert into hongong1 values(1,'우디',25);

insert into hongong1(toy_id,toy_name) values (2,'버즈');

insert into hongong1(toy_name,age,toy_id) values ('제시',20,3);

select * from hongong1;

create table table2(
id int auto_increment primary key,
name char(4),
age int);

insert into table2 values(null,'a',1);
insert into table2 values(null,'b',2);
insert into table2 values(null,'c',3);

select * from table2;

select last_insert_id();

alter table table2 auto_increment=100;
insert into table2 values(null,'f',4);
insert into table2 values(null,'ff',4);
select * from table2;

create table table3(
id int auto_increment primary key,
name char(4),
age int);

alter table table3 auto_increment=1000;
set @@auto_increment_increment=3;

insert into table3 values(null,'a',1);
insert into table3 values(null,'b',2);
insert into table3 values(null,'c',3);

select * from table3;

select count(*) from world.city;

desc world.city;
select * from world.city limit 10;

create table city1(name_ char(35), population int);

insert into city1
	select name, population from world.city;
    
select * from city1 where name_='서을';    

use market_db;
update city1
	set name_ = '서을'
    where name_ = 'Seoul';
    
delete from city1 where name_ like 'New%'
 

