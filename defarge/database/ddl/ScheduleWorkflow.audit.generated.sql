
create table audit.core_schedule_workflow (
    id BIGINT PRIMARY KEY,
		schedule_workflow_id BIGINT  not null,
		schedule_id BIGINT ,
		workflow_id BIGINT ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);