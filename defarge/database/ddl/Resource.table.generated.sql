USE [defarge];

create table app.resource (
		id BIGINT PRIMARY KEY not null,
		name VARCHAR(255)  not null,
		resource_type_id BIGINT  not null,
		ip_address VARCHAR(255)  not null,
		description VARCHAR(255)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
