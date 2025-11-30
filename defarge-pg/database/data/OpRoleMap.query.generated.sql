-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for OpRoleMap (sec.op_role_map)
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
    'sec.op_role_map-select',
    'SELECT 
        sec.op_role_map.id,
            op_role_map.op_id,
            op_role_map.op_role_id,
            op_role_map.is_active,
            op_role_map.created_by,
            op_role_map.last_updated,
            op_role_map.last_updated_by,
            op_role_map.version,
            op.objectname AS op_objectname,
            op.methodname AS op_methodname,
            op_role.name AS op_role_name
    FROM sec.op_role_map
        LEFT JOIN sec.operation op ON op_role_map.op_id = op.id
        LEFT JOIN sec.op_role op_role ON op_role_map.op_role_id = op_role.id
    ORDER BY sec.op_role_map.id;',
    'Select all OpRoleMap records with related Operation, OpRole information',
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
    'sec.op_role_map-get',
    'SELECT 
        sec.op_role_map.id,
            op_role_map.op_id,
            op_role_map.op_role_id,
            op_role_map.is_active,
            op_role_map.created_by,
            op_role_map.last_updated,
            op_role_map.last_updated_by,
            op_role_map.version,
            op.objectname AS op_objectname,
            op.methodname AS op_methodname,
            op_role.name AS op_role_name
    FROM sec.op_role_map
        LEFT JOIN sec.operation op ON op_role_map.op_id = op.id
        LEFT JOIN sec.op_role op_role ON op_role_map.op_role_id = op_role.id
    WHERE sec.op_role_map.id = ^(id);',
    'Select single OpRoleMap record by ID with related Operation, OpRole information',
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
    'sec.op_role_map-get-by-rwk',
    'SELECT 
        sec.op_role_map.id,
            op_role_map.op_id,
            op_role_map.op_role_id,
            op_role_map.is_active,
            op_role_map.created_by,
            op_role_map.last_updated,
            op_role_map.last_updated_by,
            op_role_map.version,
            op.objectname AS op_objectname,
            op.methodname AS op_methodname,
            op_role.name AS op_role_name
    FROM sec.op_role_map
        LEFT JOIN sec.operation op ON op_role_map.op_id = op.id
        LEFT JOIN sec.op_role op_role ON op_role_map.op_role_id = op_role.id
    WHERE op_role_map.op_id = ^(op_id) AND op_role_map.op_role_id = ^(op_role_id);',
    'Select single OpRoleMap record by RWK columns with related Operation, OpRole information',
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
    'sec.op_role_map-get-history',
    'SELECT 
        history.sec_op_role_map.op_role_map_id,
        history.sec_op_role_map.id,
        history.sec_op_role_map.is_active,
        history.sec_op_role_map.created_by,
        history.sec_op_role_map.last_updated,
        history.sec_op_role_map.last_updated_by,
        history.sec_op_role_map.version,
        history.sec_op_role_map.op_role_map_id,
        history.sec_op_role_map.op_id,
        history.sec_op_role_map.op_role_id,
        history.sec_op_role_map.is_active,
        history.sec_op_role_map.created_by,
        history.sec_op_role_map.last_updated,
        history.sec_op_role_map.last_updated_by,
        history.sec_op_role_map.version
    FROM history.sec_op_role_map
    WHERE history.sec_op_role_map.op_role_map_id = ^(id)
    ORDER BY history.sec_op_role_map.last_updated DESC;',
    'Select all history records for OpRoleMap where op_role_map_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         