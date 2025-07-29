
create table audit.sec_op_role (
    id BIGINT PRIMARY KEY,
		op_role_id BIGINT  not null,
		name VARCHAR(255)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);