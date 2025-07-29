USE [defarge];

create table app.alert (
		id BIGINT PRIMARY KEY not null,
		alert_rule_id BIGINT  not null,
		metric_event_id BIGINT  not null,
		triggered_at DATETIME2  not null,
		resolved_at DATETIME2  not null,
		status VARCHAR  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);
