
create table audit.core_workflow (
    id BIGINT PRIMARY KEY,
		workflow_id BIGINT  not null,
		parent_workflow_id BIGINT ,
		name VARCHAR(255)  not null,
		description VARCHAR(255) ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);