
create table audit.sec_operation (
    id BIGINT PRIMARY KEY,
		operation_id BIGINT  not null,
		objectname VARCHAR(50) ,
		methodname VARCHAR(50) ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);