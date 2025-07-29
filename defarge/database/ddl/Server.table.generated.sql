USE [defarge];

create table core.server (
		id BIGINT PRIMARY KEY not null,
		name VARCHAR(50)  not null,
		type VARCHAR(50)  not null,
		address VARCHAR(255)  not null,
		port INT ,
		is_default INT ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
