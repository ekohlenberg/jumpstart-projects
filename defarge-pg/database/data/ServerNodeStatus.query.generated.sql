-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for ServerNodeStatus (core.server_node_status)
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
    'core.server_node_status-select',
    'SELECT 
        core.server_node_status.id,
            server_node_status.name,
            server_node_status.is_active,
            server_node_status.created_by,
            server_node_status.last_updated,
            server_node_status.last_updated_by,
            server_node_status.version
    FROM core.server_node_status
    ORDER BY core.server_node_status.id;',
    'Select all ServerNodeStatus records with related  information',
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
    'core.server_node_status-get',
    'SELECT 
        core.server_node_status.id,
            server_node_status.name,
            server_node_status.is_active,
            server_node_status.created_by,
            server_node_status.last_updated,
            server_node_status.last_updated_by,
            server_node_status.version
    FROM core.server_node_status
    WHERE core.server_node_status.id = ^(id);',
    'Select single ServerNodeStatus record by ID with related  information',
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
    'core.server_node_status-get-by-rwk',
    'SELECT 
        core.server_node_status.id,
            server_node_status.name,
            server_node_status.is_active,
            server_node_status.created_by,
            server_node_status.last_updated,
            server_node_status.last_updated_by,
            server_node_status.version
    FROM core.server_node_status
    WHERE server_node_status.name = ^(name);',
    'Select single ServerNodeStatus record by RWK columns with related  information',
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
    'core.server_node_status-get-history',
    'SELECT 
        history.core_server_node_status.server_node_status_id,
        history.core_server_node_status.id,
        history.core_server_node_status.is_active,
        history.core_server_node_status.created_by,
        history.core_server_node_status.last_updated,
        history.core_server_node_status.last_updated_by,
        history.core_server_node_status.version,
        history.core_server_node_status.server_node_status_id,
        history.core_server_node_status.name,
        history.core_server_node_status.is_active,
        history.core_server_node_status.created_by,
        history.core_server_node_status.last_updated,
        history.core_server_node_status.last_updated_by,
        history.core_server_node_status.version
    FROM history.core_server_node_status
    WHERE history.core_server_node_status.server_node_status_id = ^(id)
    ORDER BY history.core_server_node_status.last_updated DESC;',
    'Select all history records for ServerNodeStatus where server_node_status_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         