
create table audit.app_alert_rule (
    id BIGINT PRIMARY KEY,
		alert_rule_id BIGINT  not null,
		metric_id BIGINT  not null,
		name VARCHAR(255)  not null,
		condition VARCHAR(255)  not null,
		threshold NUMERIC(18,4)  not null,
		recipients VARCHAR(255)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);