
create table audit.app_user_org (
    id BIGINT PRIMARY KEY,
		user_org_id BIGINT ,
		org_id BIGINT ,
		user_id BIGINT ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);