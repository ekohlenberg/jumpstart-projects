-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for ScriptType (core.script_type)
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
    'core.script_type-select',
    'SELECT 
        core.script_type.id,
            script_type.name,
            script_type.is_active,
            script_type.created_by,
            script_type.last_updated,
            script_type.last_updated_by,
            script_type.version
    FROM core.script_type
    ORDER BY core.script_type.id;',
    'Select all ScriptType records with related  information',
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
    'core.script_type-get',
    'SELECT 
        core.script_type.id,
            script_type.name,
            script_type.is_active,
            script_type.created_by,
            script_type.last_updated,
            script_type.last_updated_by,
            script_type.version
    FROM core.script_type
    WHERE core.script_type.id = ^(id);',
    'Select single ScriptType record by ID with related  information',
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
    'core.script_type-get-by-rwk',
    'SELECT 
        core.script_type.id,
            script_type.name,
            script_type.is_active,
            script_type.created_by,
            script_type.last_updated,
            script_type.last_updated_by,
            script_type.version
    FROM core.script_type
    WHERE script_type.name = ^(name);',
    'Select single ScriptType record by RWK columns with related  information',
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
    'core.script_type-get-history',
    'SELECT 
        history.core_script_type.script_type_id,
        history.core_script_type.id,
        history.core_script_type.is_active,
        history.core_script_type.created_by,
        history.core_script_type.last_updated,
        history.core_script_type.last_updated_by,
        history.core_script_type.version,
        history.core_script_type.script_type_id,
        history.core_script_type.name,
        history.core_script_type.is_active,
        history.core_script_type.created_by,
        history.core_script_type.last_updated,
        history.core_script_type.last_updated_by,
        history.core_script_type.version
    FROM history.core_script_type
    WHERE history.core_script_type.script_type_id = ^(id)
    ORDER BY history.core_script_type.last_updated DESC;',
    'Select all history records for ScriptType where script_type_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         