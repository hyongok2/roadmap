use market_db;

drop procedure if exists user_proc;

DELIMITER $$
create procedure user_proc()
begin
	select * from member;
end $$
DELIMITER ;

call user_proc();

drop procedure user_proc;

DELIMITER $$
create procedure user_proc1(IN userName varchar(10))
begin
	select * from member where mem_name = userName;
end $$
DELIMITER ;

call user_proc1('에이핑크');

DELIMITER $$
create procedure user_proc2(IN userNumber int, in userHeight int)
begin
	select * from member 
		where mem_number > userNumber and height > userHeight;
end $$
DELIMITER ;

call user_proc2(5,165);


DELIMITER $$
create procedure user_proc3(IN txtValue char(10), out outValue int)
begin
	insert into noTable values(null,txtValue);
    select Max(id) into outValue from noTable;
end $$
DELIMITER ;

desc noTable;

create table if not exists noTable(
	id int auto_increment primary key,
	txt char(10)
);

call user_proc3('테스트1',@myValue);

select concat('입력 값 =>', @myValue);

delimiter $$

drop procedure if exists ifelse_proc;
create procedure ifelse_proc(
in memName varchar(10)
)
begin
	declare debutYear int;
	select year(debut_date) into debutYear from member
	where mem_name = memName;
    if(debutYear >=2015) then
		select 'you are new to here' as 'message';
    else
		select 'you are old school' as 'message';
    end if;
end $$
delimiter ;


call ifelse_proc('오마이걸');

SELECT YEAR(CURDATE()), MONTH(CURDATE()), DAY(CURDATE());


DROP PROCEDURE IF EXISTS while_proc;
DELIMITER $$
CREATE PROCEDURE while_proc()
BEGIN
    DECLARE hap INT; -- 합계
    DECLARE num INT; -- 1부터 100까지 증가
    SET hap = 0; -- 합계 초기화
    SET num = 1; 
    
    WHILE (num <= 100) DO  -- 100까지 반복.
        SET hap = hap + num;
        SET num = num + 1; -- 숫자 증가
    END WHILE;
    SELECT hap AS '1~100 합계';
END $$
DELIMITER ;

CALL while_proc();

DROP PROCEDURE IF EXISTS dynamic_proc;
DELIMITER $$
CREATE PROCEDURE dynamic_proc(
    IN tableName VARCHAR(20)
)
BEGIN
  SET @sqlQuery = CONCAT('SELECT * FROM ', tableName);
  PREPARE myQuery FROM @sqlQuery;
  EXECUTE myQuery;
  DEALLOCATE PREPARE myQuery;
END $$
DELIMITER ;

CALL dynamic_proc ('member');
