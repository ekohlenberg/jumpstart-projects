USE [defarge];

create table app.metric_event (
		id BIGINT PRIMARY KEY not null,
		metric_id BIGINT  not null,
		event_time DATETIME2  not null,
		value NUMERIC(18,4)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
