-- Insert parent navigation menu items

INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), 0, 0, 'Metrics', '', 1, current_user, now(), current_user, 1);
    
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), 0, 1, 'Activity', '', 1, current_user, now(), current_user, 1);
    
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), 0, 2, 'Admin', '', 1, current_user, now(), current_user, 1);
    
INSERT INTO core.nav_menu(
	id, parent_id, ordinal, name, link, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.nav_menu_identity'), 0, 3, 'System', '', 1, current_user, now(), current_user, 1);
    