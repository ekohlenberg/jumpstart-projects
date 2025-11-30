-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for DataSource (core.data_source)
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
    'core.data_source-select',
    'SELECT 
        core.data_source.id,
            data_source.name,
            data_source.is_active,
            data_source.created_by,
            data_source.last_updated,
            data_source.last_updated_by,
            data_source.version
    FROM core.data_source
    ORDER BY core.data_source.id;',
    'Select all DataSource records with related  information',
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
    'core.data_source-get',
    'SELECT 
        core.data_source.id,
            data_source.name,
            data_source.is_active,
            data_source.created_by,
            data_source.last_updated,
            data_source.last_updated_by,
            data_source.version
    FROM core.data_source
    WHERE core.data_source.id = ^(id);',
    'Select single DataSource record by ID with related  information',
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
    'core.data_source-get-by-rwk',
    'SELECT 
        core.data_source.id,
            data_source.name,
            data_source.is_active,
            data_source.created_by,
            data_source.last_updated,
            data_source.last_updated_by,
            data_source.version
    FROM core.data_source
    WHERE data_source.name = ^(name);',
    'Select single DataSource record by RWK columns with related  information',
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
    'core.data_source-get-history',
    'SELECT 
        history.core_data_source.data_source_id,
        history.core_data_source.id,
        history.core_data_source.is_active,
        history.core_data_source.created_by,
        history.core_data_source.last_updated,
        history.core_data_source.last_updated_by,
        history.core_data_source.version,
        history.core_data_source.data_source_id,
        history.core_data_source.name,
        history.core_data_source.is_active,
        history.core_data_source.created_by,
        history.core_data_source.last_updated,
        history.core_data_source.last_updated_by,
        history.core_data_source.version
    FROM history.core_data_source
    WHERE history.core_data_source.data_source_id = ^(id)
    ORDER BY history.core_data_source.last_updated DESC;',
    'Select all history records for DataSource where data_source_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         