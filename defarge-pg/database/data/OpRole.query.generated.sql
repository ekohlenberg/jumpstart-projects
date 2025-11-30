-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for OpRole (sec.op_role)
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
    'sec.op_role-select',
    'SELECT 
        sec.op_role.id,
            op_role.name,
            op_role.is_active,
            op_role.created_by,
            op_role.last_updated,
            op_role.last_updated_by,
            op_role.version
    FROM sec.op_role
    ORDER BY sec.op_role.id;',
    'Select all OpRole records with related  information',
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
    'sec.op_role-get',
    'SELECT 
        sec.op_role.id,
            op_role.name,
            op_role.is_active,
            op_role.created_by,
            op_role.last_updated,
            op_role.last_updated_by,
            op_role.version
    FROM sec.op_role
    WHERE sec.op_role.id = ^(id);',
    'Select single OpRole record by ID with related  information',
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
    'sec.op_role-get-by-rwk',
    'SELECT 
        sec.op_role.id,
            op_role.name,
            op_role.is_active,
            op_role.created_by,
            op_role.last_updated,
            op_role.last_updated_by,
            op_role.version
    FROM sec.op_role
    WHERE op_role.name = ^(name);',
    'Select single OpRole record by RWK columns with related  information',
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
    'sec.op_role-get-history',
    'SELECT 
        history.sec_op_role.op_role_id,
        history.sec_op_role.id,
        history.sec_op_role.is_active,
        history.sec_op_role.created_by,
        history.sec_op_role.last_updated,
        history.sec_op_role.last_updated_by,
        history.sec_op_role.version,
        history.sec_op_role.op_role_id,
        history.sec_op_role.name,
        history.sec_op_role.is_active,
        history.sec_op_role.created_by,
        history.sec_op_role.last_updated,
        history.sec_op_role.last_updated_by,
        history.sec_op_role.version
    FROM history.sec_op_role
    WHERE history.sec_op_role.op_role_id = ^(id)
    ORDER BY history.sec_op_role.last_updated DESC;',
    'Select all history records for OpRole where op_role_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         