
create table audit.app_resource_type (
    id BIGINT PRIMARY KEY,
		resource_type_id BIGINT  not null,
		name VARCHAR(255)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);