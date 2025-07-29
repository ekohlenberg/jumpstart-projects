USE [defarge];

create table core.schedule (
		id BIGINT PRIMARY KEY not null,
		cron_expression VARCHAR(255)  not null,
		next_run_time DATETIME2 ,
		last_run_time DATETIME2 ,
		status VARCHAR(50) ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
