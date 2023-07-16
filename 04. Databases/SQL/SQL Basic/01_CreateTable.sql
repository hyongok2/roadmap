CREATE TABLE `shop_db`.`member` (
  `member_id` CHAR(8) NOT NULL,
  `member_name` CHAR(5) NOT NULL,
  `member_addr` CHAR(20) NULL,
  PRIMARY KEY (`member_id`));
  
  CREATE TABLE `shop_db`.`product` (
  `product_name` CHAR(4) NOT NULL,
  `cost` INT NOT NULL,
  `make_date` DATE NULL,
  `company` CHAR(5) NULL,
  `amount` INT NOT NULL,
  PRIMARY KEY (`product_name`));
  
INSERT INTO `shop_db`.`member` (`member_id`, `member_name`, `member_addr`) VALUES ('tess', '나훈아', '경기 부천시 중동');
INSERT INTO `shop_db`.`member` (`member_id`, `member_name`, `member_addr`) VALUES ('hero', '임영운', '서울시 은평구 중산동');
INSERT INTO `shop_db`.`member` (`member_id`, `member_name`, `member_addr`) VALUES ('iyou', '아이유', '인천시 남구 주안동');
INSERT INTO `shop_db`.`member` (`member_id`, `member_name`, `member_addr`) VALUES ('jyp', '박진영', '경기 고양시 장항동');
INSERT INTO `shop_db`.`member` (`member_id`, `member_name`, `member_addr`) VALUES ('carry', '머라이어', '미국 텍사스');

INSERT INTO `shop_db`.`product` (`product_name`, `cost`, `make_date`, `company`, `amount`) VALUES ('바나나', '1500', '2021-07-01', '델몬튼', '17');
INSERT INTO `shop_db`.`product` (`product_name`, `cost`, `make_date`, `company`, `amount`) VALUES ('카스', '2500', '2022-03-01', 'OB', '3');
INSERT INTO `shop_db`.`product` (`product_name`, `cost`, `make_date`, `company`, `amount`) VALUES ('삼각김밥', '800', '2023-09-01', 'CJ', '22');


UPDATE `shop_db`.`member` SET `member_addr` = '영국 런던' WHERE (`member_id` = 'carry');
DELETE FROM `shop_db`.`member` WHERE (`member_id` = 'carry');

select * from shop_db.member;
select * from product;

select member_name,member_addr from shop_db.member;

select * from shop_db.member where member_name='아이유';