USE [defarge];

create table app.category (
		id BIGINT PRIMARY KEY not null,
		parent_id BIGINT ,
		name VARCHAR(255)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
