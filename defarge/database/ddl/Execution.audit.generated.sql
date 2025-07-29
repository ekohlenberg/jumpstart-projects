
create table audit.core_execution (
    id BIGINT PRIMARY KEY,
		execution_id BIGINT  not null,
		token VARCHAR(255)  not null,
		process_id BIGINT ,
		start_time DATETIME2  not null,
		end_time DATETIME2 ,
		status VARCHAR(50) ,
		log_output VARCHAR(4096) ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);