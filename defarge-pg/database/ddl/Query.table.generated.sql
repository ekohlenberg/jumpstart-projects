
create table core.query (
		id BIGINT PRIMARY KEY,
		name VARCHAR(255) ,
		sql_text VARCHAR(4096) ,
		description VARCHAR(1000) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
