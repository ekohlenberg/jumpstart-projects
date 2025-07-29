USE [defarge];

create table core.event_service (
		id BIGINT PRIMARY KEY not null,
		event_type VARCHAR(255)  not null,
		objectname_filter VARCHAR(255)  not null,
		methodname_filter VARCHAR(255)  not null,
		script_id BIGINT  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
