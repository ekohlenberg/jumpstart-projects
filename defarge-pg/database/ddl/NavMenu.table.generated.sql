
create table core.nav_menu (
		id BIGINT PRIMARY KEY,
		parent_id BIGINT ,
		ordinal INTEGER ,
		name VARCHAR(1000) ,
		link VARCHAR(1000) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
