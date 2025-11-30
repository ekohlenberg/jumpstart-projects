create table history.sec_principal_password (
    id BIGINT PRIMARY KEY,
		principal_password_id BIGINT ,
		principal_id BIGINT  not null,
		password_hash VARCHAR(255) ,
		expiry TIMESTAMP ,
		needs_reset INTEGER ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);