
create table core.workflow_process (
		id BIGINT PRIMARY KEY,
		workflow_id BIGINT ,
		process_id BIGINT ,
		agent_id BIGINT ,
		seq INTEGER ,
		on_failure_action_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
