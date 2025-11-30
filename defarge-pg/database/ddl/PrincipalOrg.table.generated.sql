
create table app.principal_org (
		id BIGINT PRIMARY KEY,
		org_id BIGINT ,
		principal_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
