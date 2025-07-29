
create table audit.app_metric_event (
    id BIGINT PRIMARY KEY,
		metric_event_id BIGINT  not null,
		metric_id BIGINT  not null,
		event_time DATETIME2  not null,
		value NUMERIC(18,4)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);