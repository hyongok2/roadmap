drop database if exists naver_db;
create database naver_db;

use naver_db;
drop table if exists member;


CREATE TABLE naver_db.member (
  mem_id CHAR(8) NOT NULL,
  mem_name VARCHAR(10) NOT NULL,
  mem_number TINYINT UNSIGNED NOT NULL,
  addr CHAR(2) NOT NULL,
  phone1 CHAR(3) NULL,
  phone2 CHAR(8) NULL,
  height TINYINT UNSIGNED NULL,
  debut_date DATE NULL,
  PRIMARY KEY (mem_id));
  
  CREATE TABLE naver_db.buy (
  num INT NOT NULL AUTO_INCREMENT,
  mem_id CHAR(8) NOT NULL,
  prod_name CHAR(6) NOT NULL,
  group_name CHAR(4) NULL,
  price INT UNSIGNED NOT NULL,
  amount SMALLINT UNSIGNED NOT NULL,
  PRIMARY KEY (num),
  FOREIGN KEY(mem_id) REFERENCES member(mem_id));
  
INSERT INTO naver_db.member (mem_id, mem_name, mem_number, addr, phone1, phone2, height, debut_date) VALUES ('TWC', '트와이스', '9', '서울', '02', '11111111', '167', '2015-10-19');
INSERT INTO naver_db.member (mem_id, mem_name, mem_number, addr, phone1, phone2, height, debut_date) VALUES ('BLK', '블랙핑크', '4', '경남', '055', '22222222', '163', '2016-08-08');
INSERT INTO naver_db.member (mem_id, mem_name, mem_number, addr, phone1, phone2, height, debut_date) VALUES ('WMN', '여자친구', '6', '경기', '031', '33333333', '166', '2015-01-15');
INSERT INTO naver_db.member (mem_id, mem_name, mem_number, addr, phone1, phone2, height, debut_date) VALUES ('APN', '에이핑크', '6', '경기', '031', '77777777', '164', '2011-02-10');

INSERT INTO naver_db.buy (mem_id, prod_name, price, amount) VALUES ('BLK', '지갑', '30', '2');
INSERT INTO naver_db.buy (mem_id, prod_name, group_name, price, amount) VALUES ('BLK', '맥북프로', '디지털', '1000', '1');
INSERT INTO naver_db.buy (mem_id, prod_name, group_name, price, amount) VALUES ('APN', '아이폰', '디지털', '200', '1');


