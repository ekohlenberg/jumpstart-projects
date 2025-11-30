-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Sql (core.sql)
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
    'core.sql-select',
    'SELECT 
        core.sql.id,
            sql.name,
            sql.data_source_id,
            sql.sql_text,
            sql.description,
            sql.is_active,
            sql.created_by,
            sql.last_updated,
            sql.last_updated_by,
            sql.version,
            data_source.name AS data_source_name
    FROM core.sql
        LEFT JOIN core.data_source data_source ON sql.data_source_id = data_source.id
    ORDER BY core.sql.id;',
    'Select all Sql records with related DataSource information',
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
    'core.sql-get',
    'SELECT 
        core.sql.id,
            sql.name,
            sql.data_source_id,
            sql.sql_text,
            sql.description,
            sql.is_active,
            sql.created_by,
            sql.last_updated,
            sql.last_updated_by,
            sql.version,
            data_source.name AS data_source_name
    FROM core.sql
        LEFT JOIN core.data_source data_source ON sql.data_source_id = data_source.id
    WHERE core.sql.id = ^(id);',
    'Select single Sql record by ID with related DataSource information',
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
    'core.sql-get-by-rwk',
    'SELECT 
        core.sql.id,
            sql.name,
            sql.data_source_id,
            sql.sql_text,
            sql.description,
            sql.is_active,
            sql.created_by,
            sql.last_updated,
            sql.last_updated_by,
            sql.version,
            data_source.name AS data_source_name
    FROM core.sql
        LEFT JOIN core.data_source data_source ON sql.data_source_id = data_source.id
    WHERE sql.name = ^(name);',
    'Select single Sql record by RWK columns with related DataSource information',
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
    'core.sql-get-history',
    'SELECT 
        history.core_sql.sql_id,
        history.core_sql.id,
        history.core_sql.is_active,
        history.core_sql.created_by,
        history.core_sql.last_updated,
        history.core_sql.last_updated_by,
        history.core_sql.version,
        history.core_sql.sql_id,
        history.core_sql.name,
        history.core_sql.data_source_id,
        history.core_sql.sql_text,
        history.core_sql.description,
        history.core_sql.is_active,
        history.core_sql.created_by,
        history.core_sql.last_updated,
        history.core_sql.last_updated_by,
        history.core_sql.version
    FROM history.core_sql
    WHERE history.core_sql.sql_id = ^(id)
    ORDER BY history.core_sql.last_updated DESC;',
    'Select all history records for Sql where sql_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         