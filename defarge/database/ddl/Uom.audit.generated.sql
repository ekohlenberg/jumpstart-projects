
create table audit.app_uom (
    id BIGINT PRIMARY KEY,
		uom_id BIGINT  not null,
		Name VARCHAR(255)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);