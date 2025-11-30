-- Insert parent and child navigation menu items

-- Insert parent menu item
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), 0, 0, 'Metrics', '', 1, current_user, now(), current_user, 1);

-- Insert child menu items for Metrics
    
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Metrics'), 0, 'Resource', '/resource', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Metrics'), 1, 'Metric', '/metric', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Metrics'), 2, 'Alert Rule', '/alertrule', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Metrics'), 3, 'Category', '/category', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Metrics'), 4, 'Resource Type', '/resourcetype', 1, current_user, now(), current_user, 1);
        
-- Insert parent menu item
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), 0, 1, 'Activity', '', 1, current_user, now(), current_user, 1);

-- Insert child menu items for Activity
    
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Activity'), 0, 'Metric Event', '/metricevent', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Activity'), 1, 'Alert', '/alert', 1, current_user, now(), current_user, 1);
        
-- Insert parent menu item
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), 0, 2, 'Admin', '', 1, current_user, now(), current_user, 1);

-- Insert child menu items for Admin
    
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Admin'), 0, 'Organization', '/org', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Admin'), 1, 'Principal', '/principal', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Admin'), 2, 'Password', '/principalpassword', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Admin'), 3, 'Operations', '/operation', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'Admin'), 4, 'Operation Role', '/oprole', 1, current_user, now(), current_user, 1);
        
-- Insert parent menu item
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), 0, 3, 'System', '', 1, current_user, now(), current_user, 1);

-- Insert child menu items for System
    
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 0, 'Scripts', '/script', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 1, 'Events', '/eventservice', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 2, 'Execution Log', '/execution', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 3, 'Process', '/process', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 4, 'Schedule', '/schedule', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 5, 'Workflow', '/workflow', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 6, 'Scheduler', '/scheduler', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 7, 'Agent', '/agent', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 8, 'Query', '/sql', 1, current_user, now(), current_user, 1);
        
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), (SELECT id FROM core.nav_menu WHERE parent_id = 0 AND name = 'System'), 9, 'Data Source', '/datasource', 1, current_user, now(), current_user, 1);
        