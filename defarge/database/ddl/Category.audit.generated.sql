
SET NOCOUNT ON;
SET ANSI_WARNINGS OFF;
SET ANSI_PADDING OFF;
SET QUOTED_IDENTIFIER OFF;
USE [defarge];
GO
create table history.app_category (
    id BIGINT PRIMARY KEY,
		category_id BIGINT  not null,
		parent_id BIGINT ,
		name VARCHAR(255)  not null,
		is_active INT  not null,
		created_by VARCHAR(50)  not null,
		last_updated DATETIME2  not null,
		last_updated_by VARCHAR(50)  not null,
		version INT  not null
);