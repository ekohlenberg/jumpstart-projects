create table history.core_nav_menu (
    id BIGINT PRIMARY KEY,
		nav_menu_id BIGINT ,
		parent_id BIGINT ,
		ordinal INTEGER ,
		name VARCHAR(1000)  not null,
		link VARCHAR(1000) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);