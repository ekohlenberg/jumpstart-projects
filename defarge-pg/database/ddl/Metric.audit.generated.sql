create table history.app_metric (
    id BIGINT PRIMARY KEY,
		metric_id BIGINT ,
		name VARCHAR(255)  not null,
		category_id BIGINT  not null,
		uom_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);