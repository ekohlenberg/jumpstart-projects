
create table audit.app_org (
    id BIGINT PRIMARY KEY,
		org_id BIGINT  not null,
		name VARCHAR(255)  not null,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);