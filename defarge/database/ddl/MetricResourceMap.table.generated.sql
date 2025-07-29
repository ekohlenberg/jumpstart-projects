USE [defarge];

create table app.metric_resource_map (
		id BIGINT PRIMARY KEY not null,
		resource_id BIGINT  not null,
		metric_id BIGINT  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
