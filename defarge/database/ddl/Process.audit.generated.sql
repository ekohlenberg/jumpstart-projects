
create table audit.core_process (
    id BIGINT PRIMARY KEY,
		process_id BIGINT  not null,
		name VARCHAR(255)  not null,
		script_id BIGINT ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);