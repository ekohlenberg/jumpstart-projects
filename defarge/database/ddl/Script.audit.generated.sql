
create table audit.core_script (
    id BIGINT PRIMARY KEY,
		script_id BIGINT  not null,
		name VARCHAR(255)  not null,
		source VARCHAR(4096)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);