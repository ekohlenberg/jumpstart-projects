create table history.core_workflow_process (
    id BIGINT PRIMARY KEY,
		workflow_process_id BIGINT ,
		workflow_id BIGINT  not null,
		process_id BIGINT  not null,
		agent_id BIGINT ,
		seq INTEGER ,
		on_failure_action_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);