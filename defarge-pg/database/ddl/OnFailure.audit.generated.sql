create table history.core_on_failure (
    id BIGINT PRIMARY KEY,
		on_failure_id BIGINT ,
		action VARCHAR(255)  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);