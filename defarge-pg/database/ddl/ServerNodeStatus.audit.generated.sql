create table history.core_server_node_status (
    id BIGINT PRIMARY KEY,
		server_node_status_id BIGINT ,
		name VARCHAR(255)  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);