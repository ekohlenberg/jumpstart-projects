-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for ServerNodeType (core.server_node_type)
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
    'core.server_node_type-select',
    'SELECT 
        core.server_node_type.id,
            server_node_type.name,
            server_node_type.is_active,
            server_node_type.created_by,
            server_node_type.last_updated,
            server_node_type.last_updated_by,
            server_node_type.version
    FROM core.server_node_type
    ORDER BY core.server_node_type.id;',
    'Select all ServerNodeType records with related  information',
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
    'core.server_node_type-get',
    'SELECT 
        core.server_node_type.id,
            server_node_type.name,
            server_node_type.is_active,
            server_node_type.created_by,
            server_node_type.last_updated,
            server_node_type.last_updated_by,
            server_node_type.version
    FROM core.server_node_type
    WHERE core.server_node_type.id = ^(id);',
    'Select single ServerNodeType record by ID with related  information',
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
    'core.server_node_type-get-by-rwk',
    'SELECT 
        core.server_node_type.id,
            server_node_type.name,
            server_node_type.is_active,
            server_node_type.created_by,
            server_node_type.last_updated,
            server_node_type.last_updated_by,
            server_node_type.version
    FROM core.server_node_type
    WHERE server_node_type.name = ^(name);',
    'Select single ServerNodeType record by RWK columns with related  information',
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
    'core.server_node_type-get-history',
    'SELECT 
        history.core_server_node_type.server_node_type_id,
        history.core_server_node_type.id,
        history.core_server_node_type.is_active,
        history.core_server_node_type.created_by,
        history.core_server_node_type.last_updated,
        history.core_server_node_type.last_updated_by,
        history.core_server_node_type.version,
        history.core_server_node_type.server_node_type_id,
        history.core_server_node_type.name,
        history.core_server_node_type.is_active,
        history.core_server_node_type.created_by,
        history.core_server_node_type.last_updated,
        history.core_server_node_type.last_updated_by,
        history.core_server_node_type.version
    FROM history.core_server_node_type
    WHERE history.core_server_node_type.server_node_type_id = ^(id)
    ORDER BY history.core_server_node_type.last_updated DESC;',
    'Select all history records for ServerNodeType where server_node_type_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         