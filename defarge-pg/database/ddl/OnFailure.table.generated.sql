
create table core.on_failure (
		id BIGINT PRIMARY KEY,
		action VARCHAR(255) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
