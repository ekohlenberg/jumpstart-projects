
create table core.scheduler (
		id BIGINT PRIMARY KEY,
		hostname VARCHAR(255) ,
		ip_address VARCHAR(255) ,
		port INTEGER ,
		username VARCHAR(255) ,
		url VARCHAR(255) ,
		user_domain VARCHAR(255) ,
		os_name VARCHAR(255) ,
		os_version VARCHAR(255) ,
		architecture VARCHAR(255) ,
		registered_at TIMESTAMP ,
		scheduler_status_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
