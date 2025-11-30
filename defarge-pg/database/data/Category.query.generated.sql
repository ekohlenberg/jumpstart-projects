-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Category (app.category)
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
    'app.category-select',
    'SELECT 
        app.category.id,
            category.parent_id,
            category.name,
            category.is_active,
            category.created_by,
            category.last_updated,
            category.last_updated_by,
            category.version,
            parent.parent_id AS parent_parent_id,
            parent.name AS parent_name
    FROM app.category
        LEFT JOIN app.category parent ON category.parent_id = parent.id
    ORDER BY app.category.id;',
    'Select all Category records with related Category information',
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
    'app.category-get',
    'SELECT 
        app.category.id,
            category.parent_id,
            category.name,
            category.is_active,
            category.created_by,
            category.last_updated,
            category.last_updated_by,
            category.version,
            parent.parent_id AS parent_parent_id,
            parent.name AS parent_name
    FROM app.category
        LEFT JOIN app.category parent ON category.parent_id = parent.id
    WHERE app.category.id = ^(id);',
    'Select single Category record by ID with related Category information',
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
    'app.category-get-by-rwk',
    'SELECT 
        app.category.id,
            category.parent_id,
            category.name,
            category.is_active,
            category.created_by,
            category.last_updated,
            category.last_updated_by,
            category.version,
            parent.parent_id AS parent_parent_id,
            parent.name AS parent_name
    FROM app.category
        LEFT JOIN app.category parent ON category.parent_id = parent.id
    WHERE category.parent_id = ^(parent_id) AND category.name = ^(name);',
    'Select single Category record by RWK columns with related Category information',
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
    'app.category-get-history',
    'SELECT 
        history.app_category.category_id,
        history.app_category.id,
        history.app_category.is_active,
        history.app_category.created_by,
        history.app_category.last_updated,
        history.app_category.last_updated_by,
        history.app_category.version,
        history.app_category.category_id,
        history.app_category.parent_id,
        history.app_category.name,
        history.app_category.is_active,
        history.app_category.created_by,
        history.app_category.last_updated,
        history.app_category.last_updated_by,
        history.app_category.version
    FROM history.app_category
    WHERE history.app_category.category_id = ^(id)
    ORDER BY history.app_category.last_updated DESC;',
    'Select all history records for Category where category_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         