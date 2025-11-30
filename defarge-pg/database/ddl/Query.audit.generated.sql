create table history.core_query (
    id BIGINT PRIMARY KEY,
		query_id BIGINT ,
		name VARCHAR(255)  not null,
		sql_text VARCHAR(4096) ,
		description VARCHAR(1000) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);