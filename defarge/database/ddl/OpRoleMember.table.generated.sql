USE [defarge];

create table sec.op_role_member (
		id BIGINT PRIMARY KEY not null,
		user_id BIGINT  not null,
		op_role_id BIGINT  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
