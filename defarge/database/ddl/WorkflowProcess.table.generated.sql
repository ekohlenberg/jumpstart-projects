USE [defarge];

create table core.workflow_process (
		id BIGINT PRIMARY KEY not null,
		workflow_id BIGINT ,
		process_id BIGINT ,
		execution_sequence INT ,
		server_id BIGINT ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
