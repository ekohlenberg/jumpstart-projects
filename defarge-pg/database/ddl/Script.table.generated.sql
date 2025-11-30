
create table core.script (
		id BIGINT PRIMARY KEY,
		name VARCHAR(255) ,
		source VARCHAR(4096) ,
		script_type_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
