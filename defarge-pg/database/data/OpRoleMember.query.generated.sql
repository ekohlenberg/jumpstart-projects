-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for OpRoleMember (sec.op_role_member)
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
    'sec.op_role_member-select',
    'SELECT 
        sec.op_role_member.id,
            op_role_member.principal_id,
            op_role_member.op_role_id,
            op_role_member.is_active,
            op_role_member.created_by,
            op_role_member.last_updated,
            op_role_member.last_updated_by,
            op_role_member.version,
            principal.email AS principal_email,
            op_role.name AS op_role_name
    FROM sec.op_role_member
        LEFT JOIN app.principal principal ON op_role_member.principal_id = principal.id
        LEFT JOIN sec.op_role op_role ON op_role_member.op_role_id = op_role.id
    ORDER BY sec.op_role_member.id;',
    'Select all OpRoleMember records with related Principal, OpRole information',
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
    'sec.op_role_member-get',
    'SELECT 
        sec.op_role_member.id,
            op_role_member.principal_id,
            op_role_member.op_role_id,
            op_role_member.is_active,
            op_role_member.created_by,
            op_role_member.last_updated,
            op_role_member.last_updated_by,
            op_role_member.version,
            principal.email AS principal_email,
            op_role.name AS op_role_name
    FROM sec.op_role_member
        LEFT JOIN app.principal principal ON op_role_member.principal_id = principal.id
        LEFT JOIN sec.op_role op_role ON op_role_member.op_role_id = op_role.id
    WHERE sec.op_role_member.id = ^(id);',
    'Select single OpRoleMember record by ID with related Principal, OpRole information',
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
    'sec.op_role_member-get-by-rwk',
    'SELECT 
        sec.op_role_member.id,
            op_role_member.principal_id,
            op_role_member.op_role_id,
            op_role_member.is_active,
            op_role_member.created_by,
            op_role_member.last_updated,
            op_role_member.last_updated_by,
            op_role_member.version,
            principal.email AS principal_email,
            op_role.name AS op_role_name
    FROM sec.op_role_member
        LEFT JOIN app.principal principal ON op_role_member.principal_id = principal.id
        LEFT JOIN sec.op_role op_role ON op_role_member.op_role_id = op_role.id
    WHERE op_role_member.principal_id = ^(principal_id) AND op_role_member.op_role_id = ^(op_role_id);',
    'Select single OpRoleMember record by RWK columns with related Principal, OpRole information',
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
    'sec.op_role_member-get-history',
    'SELECT 
        history.sec_op_role_member.op_role_member_id,
        history.sec_op_role_member.id,
        history.sec_op_role_member.is_active,
        history.sec_op_role_member.created_by,
        history.sec_op_role_member.last_updated,
        history.sec_op_role_member.last_updated_by,
        history.sec_op_role_member.version,
        history.sec_op_role_member.op_role_member_id,
        history.sec_op_role_member.principal_id,
        history.sec_op_role_member.op_role_id,
        history.sec_op_role_member.is_active,
        history.sec_op_role_member.created_by,
        history.sec_op_role_member.last_updated,
        history.sec_op_role_member.last_updated_by,
        history.sec_op_role_member.version
    FROM history.sec_op_role_member
    WHERE history.sec_op_role_member.op_role_member_id = ^(id)
    ORDER BY history.sec_op_role_member.last_updated DESC;',
    'Select all history records for OpRoleMember where op_role_member_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         