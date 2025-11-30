-- =====================================
-- Generate SELECT queries for child records
-- =====================================


-- =====================================
-- Child queries for NavMenu (core.nav_menu)
-- =====================================

        
-- Child relationship: Parent Menu ID (parent)
INSERT INTO core.sql (
    id, 
    name, 
    sql_text, 
    description, 
    last_updated, 
    last_updated_by,
    is_active,
    version,
    data_source_id
) VALUES (
     nextval('core.sql_identity'),
    'core.nav_menu-children-navmenu-parent',
    'SELECT 
        core.nav_menu.id,
            nav_menu.parent_id,
            nav_menu.ordinal,
            nav_menu.name,
            nav_menu.link,
            nav_menu.is_active,
            nav_menu.created_by,
            nav_menu.last_updated,
            nav_menu.last_updated_by,
            nav_menu.version,
            parent.name AS parent_name
    FROM core.nav_menu
        LEFT JOIN core.nav_menu parent ON nav_menu.parent_id = parent.id
    WHERE core.nav_menu.parent_id = ^(id)
    ORDER BY core.nav_menu.id;',
    'Select all Parent Menu ID records for NavMenu with related NavMenu information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

            