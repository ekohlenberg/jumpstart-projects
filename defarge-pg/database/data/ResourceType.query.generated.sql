-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for ResourceType (app.resource_type)
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
    'app.resource_type-select',
    'SELECT 
        app.resource_type.id,
            resource_type.name,
            resource_type.is_active,
            resource_type.created_by,
            resource_type.last_updated,
            resource_type.last_updated_by,
            resource_type.version
    FROM app.resource_type
    ORDER BY app.resource_type.id;',
    'Select all ResourceType records with related  information',
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
    'app.resource_type-get',
    'SELECT 
        app.resource_type.id,
            resource_type.name,
            resource_type.is_active,
            resource_type.created_by,
            resource_type.last_updated,
            resource_type.last_updated_by,
            resource_type.version
    FROM app.resource_type
    WHERE app.resource_type.id = ^(id);',
    'Select single ResourceType record by ID with related  information',
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
    'app.resource_type-get-by-rwk',
    'SELECT 
        app.resource_type.id,
            resource_type.name,
            resource_type.is_active,
            resource_type.created_by,
            resource_type.last_updated,
            resource_type.last_updated_by,
            resource_type.version
    FROM app.resource_type
    WHERE resource_type.name = ^(name);',
    'Select single ResourceType record by RWK columns with related  information',
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
    'app.resource_type-get-history',
    'SELECT 
        history.app_resource_type.resource_type_id,
        history.app_resource_type.id,
        history.app_resource_type.is_active,
        history.app_resource_type.created_by,
        history.app_resource_type.last_updated,
        history.app_resource_type.last_updated_by,
        history.app_resource_type.version,
        history.app_resource_type.resource_type_id,
        history.app_resource_type.name,
        history.app_resource_type.is_active,
        history.app_resource_type.created_by,
        history.app_resource_type.last_updated,
        history.app_resource_type.last_updated_by,
        history.app_resource_type.version
    FROM history.app_resource_type
    WHERE history.app_resource_type.resource_type_id = ^(id)
    ORDER BY history.app_resource_type.last_updated DESC;',
    'Select all history records for ResourceType where resource_type_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         