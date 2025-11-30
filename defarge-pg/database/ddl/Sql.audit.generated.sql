create table history.core_sql (
    id BIGINT PRIMARY KEY,
		sql_id BIGINT ,
		name VARCHAR(255)  not null,
		data_source_id BIGINT ,
		sql_text VARCHAR(4096) ,
		description VARCHAR(1000) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);