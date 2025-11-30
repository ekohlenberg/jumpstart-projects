-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for ExecStatus (core.exec_status)
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
    'core.exec_status-select',
    'SELECT 
        core.exec_status.id,
            exec_status.name,
            exec_status.is_active,
            exec_status.created_by,
            exec_status.last_updated,
            exec_status.last_updated_by,
            exec_status.version
    FROM core.exec_status
    ORDER BY core.exec_status.id;',
    'Select all ExecStatus records with related  information',
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
    'core.exec_status-get',
    'SELECT 
        core.exec_status.id,
            exec_status.name,
            exec_status.is_active,
            exec_status.created_by,
            exec_status.last_updated,
            exec_status.last_updated_by,
            exec_status.version
    FROM core.exec_status
    WHERE core.exec_status.id = ^(id);',
    'Select single ExecStatus record by ID with related  information',
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
    'core.exec_status-get-by-rwk',
    'SELECT 
        core.exec_status.id,
            exec_status.name,
            exec_status.is_active,
            exec_status.created_by,
            exec_status.last_updated,
            exec_status.last_updated_by,
            exec_status.version
    FROM core.exec_status
    WHERE exec_status.name = ^(name);',
    'Select single ExecStatus record by RWK columns with related  information',
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
    'core.exec_status-get-history',
    'SELECT 
        history.core_exec_status.exec_status_id,
        history.core_exec_status.id,
        history.core_exec_status.is_active,
        history.core_exec_status.created_by,
        history.core_exec_status.last_updated,
        history.core_exec_status.last_updated_by,
        history.core_exec_status.version,
        history.core_exec_status.exec_status_id,
        history.core_exec_status.name,
        history.core_exec_status.is_active,
        history.core_exec_status.created_by,
        history.core_exec_status.last_updated,
        history.core_exec_status.last_updated_by,
        history.core_exec_status.version
    FROM history.core_exec_status
    WHERE history.core_exec_status.exec_status_id = ^(id)
    ORDER BY history.core_exec_status.last_updated DESC;',
    'Select all history records for ExecStatus where exec_status_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         