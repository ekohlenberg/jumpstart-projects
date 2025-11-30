create table history.app_principal_org (
    id BIGINT PRIMARY KEY,
		principal_org_id BIGINT ,
		org_id BIGINT  not null,
		principal_id BIGINT  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);