-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for PrincipalPassword (sec.principal_password)
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
    'sec.principal_password-select',
    'SELECT 
        sec.principal_password.id,
            principal_password.principal_id,
            principal_password.password_hash,
            principal_password.expiry,
            principal_password.needs_reset,
            principal_password.is_active,
            principal_password.created_by,
            principal_password.last_updated,
            principal_password.last_updated_by,
            principal_password.version,
            principal.email AS principal_email
    FROM sec.principal_password
        LEFT JOIN app.principal principal ON principal_password.principal_id = principal.id
    ORDER BY sec.principal_password.id;',
    'Select all PrincipalPassword records with related Principal information',
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
    'sec.principal_password-get',
    'SELECT 
        sec.principal_password.id,
            principal_password.principal_id,
            principal_password.password_hash,
            principal_password.expiry,
            principal_password.needs_reset,
            principal_password.is_active,
            principal_password.created_by,
            principal_password.last_updated,
            principal_password.last_updated_by,
            principal_password.version,
            principal.email AS principal_email
    FROM sec.principal_password
        LEFT JOIN app.principal principal ON principal_password.principal_id = principal.id
    WHERE sec.principal_password.id = ^(id);',
    'Select single PrincipalPassword record by ID with related Principal information',
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
    'sec.principal_password-get-by-rwk',
    'SELECT 
        sec.principal_password.id,
            principal_password.principal_id,
            principal_password.password_hash,
            principal_password.expiry,
            principal_password.needs_reset,
            principal_password.is_active,
            principal_password.created_by,
            principal_password.last_updated,
            principal_password.last_updated_by,
            principal_password.version,
            principal.email AS principal_email
    FROM sec.principal_password
        LEFT JOIN app.principal principal ON principal_password.principal_id = principal.id
    WHERE principal_password.principal_id = ^(principal_id);',
    'Select single PrincipalPassword record by RWK columns with related Principal information',
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
    'sec.principal_password-get-history',
    'SELECT 
        history.sec_principal_password.principal_password_id,
        history.sec_principal_password.id,
        history.sec_principal_password.is_active,
        history.sec_principal_password.created_by,
        history.sec_principal_password.last_updated,
        history.sec_principal_password.last_updated_by,
        history.sec_principal_password.version,
        history.sec_principal_password.principal_password_id,
        history.sec_principal_password.principal_id,
        history.sec_principal_password.password_hash,
        history.sec_principal_password.expiry,
        history.sec_principal_password.needs_reset,
        history.sec_principal_password.is_active,
        history.sec_principal_password.created_by,
        history.sec_principal_password.last_updated,
        history.sec_principal_password.last_updated_by,
        history.sec_principal_password.version
    FROM history.sec_principal_password
    WHERE history.sec_principal_password.principal_password_id = ^(id)
    ORDER BY history.sec_principal_password.last_updated DESC;',
    'Select all history records for PrincipalPassword where principal_password_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         