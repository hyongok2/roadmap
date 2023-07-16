select * from member where member_name='아이유';

create index idx_member_name ON member(member_name);

create view member_view
AS
	select * from member;
    
select * from member_view;


