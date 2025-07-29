
create table audit.app_metric (
    id BIGINT PRIMARY KEY,
		metric_id BIGINT  not null,
		name VARCHAR(255)  not null,
		category_id BIGINT  not null,
		uom_id BIGINT  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);