
create table app.user_org (
		id BIGINT PRIMARY KEY,
		org_id BIGINT  not null,
		user_id BIGINT  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);