-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Operation (sec.operation)
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
    'sec.operation-select',
    'SELECT 
        sec.operation.id,
            operation.objectname,
            operation.methodname,
            operation.is_active,
            operation.created_by,
            operation.last_updated,
            operation.last_updated_by,
            operation.version
    FROM sec.operation
    ORDER BY sec.operation.id;',
    'Select all Operation records with related  information',
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
    'sec.operation-get',
    'SELECT 
        sec.operation.id,
            operation.objectname,
            operation.methodname,
            operation.is_active,
            operation.created_by,
            operation.last_updated,
            operation.last_updated_by,
            operation.version
    FROM sec.operation
    WHERE sec.operation.id = ^(id);',
    'Select single Operation record by ID with related  information',
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
    'sec.operation-get-by-rwk',
    'SELECT 
        sec.operation.id,
            operation.objectname,
            operation.methodname,
            operation.is_active,
            operation.created_by,
            operation.last_updated,
            operation.last_updated_by,
            operation.version
    FROM sec.operation
    WHERE operation.objectname = ^(objectname) AND operation.methodname = ^(methodname);',
    'Select single Operation record by RWK columns with related  information',
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
    'sec.operation-get-history',
    'SELECT 
        history.sec_operation.operation_id,
        history.sec_operation.id,
        history.sec_operation.is_active,
        history.sec_operation.created_by,
        history.sec_operation.last_updated,
        history.sec_operation.last_updated_by,
        history.sec_operation.version,
        history.sec_operation.operation_id,
        history.sec_operation.objectname,
        history.sec_operation.methodname,
        history.sec_operation.is_active,
        history.sec_operation.created_by,
        history.sec_operation.last_updated,
        history.sec_operation.last_updated_by,
        history.sec_operation.version
    FROM history.sec_operation
    WHERE history.sec_operation.operation_id = ^(id)
    ORDER BY history.sec_operation.last_updated DESC;',
    'Select all history records for Operation where operation_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         