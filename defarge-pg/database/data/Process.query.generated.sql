-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Process (core.process)
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
    'core.process-select',
    'SELECT 
        core.process.id,
            process.name,
            process.script_id,
            process.is_active,
            process.created_by,
            process.last_updated,
            process.last_updated_by,
            process.version,
            script.name AS script_name,
            script.script_type_id AS script_script_type_id
    FROM core.process
        LEFT JOIN core.script script ON process.script_id = script.id
    ORDER BY core.process.id;',
    'Select all Process records with related Script information',
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
    'core.process-get',
    'SELECT 
        core.process.id,
            process.name,
            process.script_id,
            process.is_active,
            process.created_by,
            process.last_updated,
            process.last_updated_by,
            process.version,
            script.name AS script_name,
            script.script_type_id AS script_script_type_id
    FROM core.process
        LEFT JOIN core.script script ON process.script_id = script.id
    WHERE core.process.id = ^(id);',
    'Select single Process record by ID with related Script information',
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
    'core.process-get-by-rwk',
    'SELECT 
        core.process.id,
            process.name,
            process.script_id,
            process.is_active,
            process.created_by,
            process.last_updated,
            process.last_updated_by,
            process.version,
            script.name AS script_name,
            script.script_type_id AS script_script_type_id
    FROM core.process
        LEFT JOIN core.script script ON process.script_id = script.id
    WHERE process.name = ^(name);',
    'Select single Process record by RWK columns with related Script information',
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
    'core.process-get-history',
    'SELECT 
        history.core_process.process_id,
        history.core_process.id,
        history.core_process.is_active,
        history.core_process.created_by,
        history.core_process.last_updated,
        history.core_process.last_updated_by,
        history.core_process.version,
        history.core_process.process_id,
        history.core_process.name,
        history.core_process.script_id,
        history.core_process.is_active,
        history.core_process.created_by,
        history.core_process.last_updated,
        history.core_process.last_updated_by,
        history.core_process.version
    FROM history.core_process
    WHERE history.core_process.process_id = ^(id)
    ORDER BY history.core_process.last_updated DESC;',
    'Select all history records for Process where process_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         