
create table audit.sec_op_role_map (
    id BIGINT PRIMARY KEY,
		op_role_map_id BIGINT  not null,
		op_id BIGINT  not null,
		op_role_id BIGINT  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);