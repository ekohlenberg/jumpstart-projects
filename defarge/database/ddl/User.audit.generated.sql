
create table audit.app_user (
    id BIGINT PRIMARY KEY,
		user_id BIGINT  not null,
		first_name VARCHAR(50) ,
		last_name VARCHAR(50) ,
		username VARCHAR(50)  not null,
		email VARCHAR(100)  not null,
		created_date DATETIME2 ,
		last_login_date DATETIME2 ,
		is_active   not null,
		created_by (50)  not null,
		last_updated   not null,
		last_updated_by (50)  not null,
		version   not null
);