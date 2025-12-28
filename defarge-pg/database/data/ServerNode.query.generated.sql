-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for ServerNode (core.server_node)
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
    'core.server_node-select',
    'SELECT 
        core.server_node.id,
            server_node.server_node_type_id,
            server_node.hostname,
            server_node.ip_address,
            server_node.port,
            server_node.username,
            server_node.url,
            server_node.user_domain,
            server_node.os_name,
            server_node.os_version,
            server_node.architecture,
            server_node.registered_at,
            server_node.server_node_status_id,
            server_node.is_active,
            server_node.created_by,
            server_node.last_updated,
            server_node.last_updated_by,
            server_node.version,
            server_node_type.name AS server_node_type_name,
            server_node_status.name AS server_node_status_name
    FROM core.server_node
        LEFT JOIN core.server_node_type server_node_type ON server_node.server_node_type_id = server_node_type.id
        LEFT JOIN core.server_node_status server_node_status ON server_node.server_node_status_id = server_node_status.id
    ORDER BY core.server_node.id;',
    'Select all ServerNode records with related ServerNodeType, ServerNodeStatus information',
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
    'core.server_node-get',
    'SELECT 
        core.server_node.id,
            server_node.server_node_type_id,
            server_node.hostname,
            server_node.ip_address,
            server_node.port,
            server_node.username,
            server_node.url,
            server_node.user_domain,
            server_node.os_name,
            server_node.os_version,
            server_node.architecture,
            server_node.registered_at,
            server_node.server_node_status_id,
            server_node.is_active,
            server_node.created_by,
            server_node.last_updated,
            server_node.last_updated_by,
            server_node.version,
            server_node_type.name AS server_node_type_name,
            server_node_status.name AS server_node_status_name
    FROM core.server_node
        LEFT JOIN core.server_node_type server_node_type ON server_node.server_node_type_id = server_node_type.id
        LEFT JOIN core.server_node_status server_node_status ON server_node.server_node_status_id = server_node_status.id
    WHERE core.server_node.id = ^(id);',
    'Select single ServerNode record by ID with related ServerNodeType, ServerNodeStatus information',
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
    'core.server_node-get-by-rwk',
    'SELECT 
        core.server_node.id,
            server_node.server_node_type_id,
            server_node.hostname,
            server_node.ip_address,
            server_node.port,
            server_node.username,
            server_node.url,
            server_node.user_domain,
            server_node.os_name,
            server_node.os_version,
            server_node.architecture,
            server_node.registered_at,
            server_node.server_node_status_id,
            server_node.is_active,
            server_node.created_by,
            server_node.last_updated,
            server_node.last_updated_by,
            server_node.version,
            server_node_type.name AS server_node_type_name,
            server_node_status.name AS server_node_status_name
    FROM core.server_node
        LEFT JOIN core.server_node_type server_node_type ON server_node.server_node_type_id = server_node_type.id
        LEFT JOIN core.server_node_status server_node_status ON server_node.server_node_status_id = server_node_status.id
    WHERE server_node.hostname = ^(hostname) AND server_node.ip_address = ^(ip_address) AND server_node.port = ^(port);',
    'Select single ServerNode record by RWK columns with related ServerNodeType, ServerNodeStatus information',
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
    'core.server_node-get-history',
    'SELECT 
        history.core_server_node.server_node_id,
        history.core_server_node.id,
        history.core_server_node.is_active,
        history.core_server_node.created_by,
        history.core_server_node.last_updated,
        history.core_server_node.last_updated_by,
        history.core_server_node.version,
        history.core_server_node.server_node_id,
        history.core_server_node.server_node_type_id,
        history.core_server_node.hostname,
        history.core_server_node.ip_address,
        history.core_server_node.port,
        history.core_server_node.username,
        history.core_server_node.url,
        history.core_server_node.user_domain,
        history.core_server_node.os_name,
        history.core_server_node.os_version,
        history.core_server_node.architecture,
        history.core_server_node.registered_at,
        history.core_server_node.server_node_status_id,
        history.core_server_node.is_active,
        history.core_server_node.created_by,
        history.core_server_node.last_updated,
        history.core_server_node.last_updated_by,
        history.core_server_node.version
    FROM history.core_server_node
    WHERE history.core_server_node.server_node_id = ^(id)
    ORDER BY history.core_server_node.last_updated DESC;',
    'Select all history records for ServerNode where server_node_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         