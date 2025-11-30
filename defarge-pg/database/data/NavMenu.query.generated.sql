-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for NavMenu (core.nav_menu)
-- =====================================


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
    'core.nav_menu-select',
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
    ORDER BY core.nav_menu.id;',
    'Select all NavMenu records with related NavMenu information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

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
    'core.nav_menu-get',
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
    WHERE core.nav_menu.id = ^(id);',
    'Select single NavMenu record by ID with related NavMenu information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

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
    'core.nav_menu-get-by-rwk',
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
    WHERE nav_menu.name = ^(name);',
    'Select single NavMenu record by RWK columns with related NavMenu information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

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
    'core.nav_menu-get-history',
    'SELECT 
        history.core_nav_menu.nav_menu_id,
        history.core_nav_menu.id,
        history.core_nav_menu.is_active,
        history.core_nav_menu.created_by,
        history.core_nav_menu.last_updated,
        history.core_nav_menu.last_updated_by,
        history.core_nav_menu.version,
        history.core_nav_menu.nav_menu_id,
        history.core_nav_menu.parent_id,
        history.core_nav_menu.ordinal,
        history.core_nav_menu.name,
        history.core_nav_menu.link,
        history.core_nav_menu.is_active,
        history.core_nav_menu.created_by,
        history.core_nav_menu.last_updated,
        history.core_nav_menu.last_updated_by,
        history.core_nav_menu.version
    FROM history.core_nav_menu
    WHERE history.core_nav_menu.nav_menu_id = ^(id)
    ORDER BY history.core_nav_menu.last_updated DESC;',
    'Select all history records for NavMenu where nav_menu_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         