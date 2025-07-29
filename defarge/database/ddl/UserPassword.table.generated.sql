USE [defarge];

create table sec.user_password (
		id BIGINT PRIMARY KEY not null,
		user_id BIGINT ,
		password_hash VARCHAR(255)  not null,
		expiry DATETIME2 ,
		needs_reset INT ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
