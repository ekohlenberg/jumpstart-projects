-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Script (core.script)
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
    'core.script-select',
    'SELECT 
        core.script.id,
            script.name,
            script.source,
            script.script_type_id,
            script.is_active,
            script.created_by,
            script.last_updated,
            script.last_updated_by,
            script.version,
            script_type.name AS script_type_name
    FROM core.script
        LEFT JOIN core.script_type script_type ON script.script_type_id = script_type.id
    ORDER BY core.script.id;',
    'Select all Script records with related ScriptType information',
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
    'core.script-get',
    'SELECT 
        core.script.id,
            script.name,
            script.source,
            script.script_type_id,
            script.is_active,
            script.created_by,
            script.last_updated,
            script.last_updated_by,
            script.version,
            script_type.name AS script_type_name
    FROM core.script
        LEFT JOIN core.script_type script_type ON script.script_type_id = script_type.id
    WHERE core.script.id = ^(id);',
    'Select single Script record by ID with related ScriptType information',
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
    'core.script-get-by-rwk',
    'SELECT 
        core.script.id,
            script.name,
            script.source,
            script.script_type_id,
            script.is_active,
            script.created_by,
            script.last_updated,
            script.last_updated_by,
            script.version,
            script_type.name AS script_type_name
    FROM core.script
        LEFT JOIN core.script_type script_type ON script.script_type_id = script_type.id
    WHERE script.name = ^(name) AND script.script_type_id = ^(script_type_id);',
    'Select single Script record by RWK columns with related ScriptType information',
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
    'core.script-get-history',
    'SELECT 
        history.core_script.script_id,
        history.core_script.id,
        history.core_script.is_active,
        history.core_script.created_by,
        history.core_script.last_updated,
        history.core_script.last_updated_by,
        history.core_script.version,
        history.core_script.script_id,
        history.core_script.name,
        history.core_script.source,
        history.core_script.script_type_id,
        history.core_script.is_active,
        history.core_script.created_by,
        history.core_script.last_updated,
        history.core_script.last_updated_by,
        history.core_script.version
    FROM history.core_script
    WHERE history.core_script.script_id = ^(id)
    ORDER BY history.core_script.last_updated DESC;',
    'Select all history records for Script where script_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         