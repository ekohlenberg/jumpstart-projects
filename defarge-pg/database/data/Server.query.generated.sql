-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Server (core.server)
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
    'core.server-select',
    'SELECT 
        core.server.id,
            server.name,
            server.type,
            server.address,
            server.port,
            server.is_default,
            server.is_active,
            server.created_by,
            server.last_updated,
            server.last_updated_by,
            server.version
    FROM core.server
    ORDER BY core.server.id;',
    'Select all Server records with related  information',
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
    'core.server-get',
    'SELECT 
        core.server.id,
            server.name,
            server.type,
            server.address,
            server.port,
            server.is_default,
            server.is_active,
            server.created_by,
            server.last_updated,
            server.last_updated_by,
            server.version
    FROM core.server
    WHERE core.server.id = ^(id);',
    'Select single Server record by ID with related  information',
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
    'core.server-get-by-rwk',
    'SELECT 
        core.server.id,
            server.name,
            server.type,
            server.address,
            server.port,
            server.is_default,
            server.is_active,
            server.created_by,
            server.last_updated,
            server.last_updated_by,
            server.version
    FROM core.server
    WHERE server.name = ^(name) AND server.type = ^(type) AND server.address = ^(address) AND server.port = ^(port);',
    'Select single Server record by RWK columns with related  information',
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
    'core.server-get-history',
    'SELECT 
        history.core_server.server_id,
        history.core_server.id,
        history.core_server.is_active,
        history.core_server.created_by,
        history.core_server.last_updated,
        history.core_server.last_updated_by,
        history.core_server.version,
        history.core_server.server_id,
        history.core_server.name,
        history.core_server.type,
        history.core_server.address,
        history.core_server.port,
        history.core_server.is_default,
        history.core_server.is_active,
        history.core_server.created_by,
        history.core_server.last_updated,
        history.core_server.last_updated_by,
        history.core_server.version
    FROM history.core_server
    WHERE history.core_server.server_id = ^(id)
    ORDER BY history.core_server.last_updated DESC;',
    'Select all history records for Server where server_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         