-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for OnFailure (core.on_failure)
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
    'core.on_failure-select',
    'SELECT 
        core.on_failure.id,
            on_failure.action,
            on_failure.is_active,
            on_failure.created_by,
            on_failure.last_updated,
            on_failure.last_updated_by,
            on_failure.version
    FROM core.on_failure
    ORDER BY core.on_failure.id;',
    'Select all OnFailure records with related  information',
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
    'core.on_failure-get',
    'SELECT 
        core.on_failure.id,
            on_failure.action,
            on_failure.is_active,
            on_failure.created_by,
            on_failure.last_updated,
            on_failure.last_updated_by,
            on_failure.version
    FROM core.on_failure
    WHERE core.on_failure.id = ^(id);',
    'Select single OnFailure record by ID with related  information',
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
    'core.on_failure-get-by-rwk',
    'SELECT 
        core.on_failure.id,
            on_failure.action,
            on_failure.is_active,
            on_failure.created_by,
            on_failure.last_updated,
            on_failure.last_updated_by,
            on_failure.version
    FROM core.on_failure
    WHERE on_failure.action = ^(action);',
    'Select single OnFailure record by RWK columns with related  information',
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
    'core.on_failure-get-history',
    'SELECT 
        history.core_on_failure.on_failure_id,
        history.core_on_failure.id,
        history.core_on_failure.is_active,
        history.core_on_failure.created_by,
        history.core_on_failure.last_updated,
        history.core_on_failure.last_updated_by,
        history.core_on_failure.version,
        history.core_on_failure.on_failure_id,
        history.core_on_failure.action,
        history.core_on_failure.is_active,
        history.core_on_failure.created_by,
        history.core_on_failure.last_updated,
        history.core_on_failure.last_updated_by,
        history.core_on_failure.version
    FROM history.core_on_failure
    WHERE history.core_on_failure.on_failure_id = ^(id)
    ORDER BY history.core_on_failure.last_updated DESC;',
    'Select all history records for OnFailure where on_failure_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         