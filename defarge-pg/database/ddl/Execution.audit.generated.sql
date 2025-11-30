create table history.core_execution (
    id BIGINT PRIMARY KEY,
		execution_id BIGINT ,
		token VARCHAR(255)  not null,
		workflow_process_id BIGINT  not null,
		start_time TIMESTAMP  not null,
		end_time TIMESTAMP  not null,
		exec_status_id BIGINT ,
		stdout VARCHAR(4096) ,
		stderr VARCHAR(4096) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);