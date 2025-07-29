
create table audit.app_metric_resource_map (
    id BIGINT PRIMARY KEY,
		metric_resource_map_id BIGINT  not null,
		resource_id BIGINT  not null,
		metric_id BIGINT  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);