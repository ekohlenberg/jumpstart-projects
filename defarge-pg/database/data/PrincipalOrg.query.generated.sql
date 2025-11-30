-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for PrincipalOrg (app.principal_org)
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
    'app.principal_org-select',
    'SELECT 
        app.principal_org.id,
            principal_org.org_id,
            principal_org.principal_id,
            principal_org.is_active,
            principal_org.created_by,
            principal_org.last_updated,
            principal_org.last_updated_by,
            principal_org.version,
            org.name AS org_name,
            principal.email AS principal_email
    FROM app.principal_org
        LEFT JOIN app.org org ON principal_org.org_id = org.id
        LEFT JOIN app.principal principal ON principal_org.principal_id = principal.id
    ORDER BY app.principal_org.id;',
    'Select all PrincipalOrg records with related Org, Principal information',
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
    'app.principal_org-get',
    'SELECT 
        app.principal_org.id,
            principal_org.org_id,
            principal_org.principal_id,
            principal_org.is_active,
            principal_org.created_by,
            principal_org.last_updated,
            principal_org.last_updated_by,
            principal_org.version,
            org.name AS org_name,
            principal.email AS principal_email
    FROM app.principal_org
        LEFT JOIN app.org org ON principal_org.org_id = org.id
        LEFT JOIN app.principal principal ON principal_org.principal_id = principal.id
    WHERE app.principal_org.id = ^(id);',
    'Select single PrincipalOrg record by ID with related Org, Principal information',
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
    'app.principal_org-get-by-rwk',
    'SELECT 
        app.principal_org.id,
            principal_org.org_id,
            principal_org.principal_id,
            principal_org.is_active,
            principal_org.created_by,
            principal_org.last_updated,
            principal_org.last_updated_by,
            principal_org.version,
            org.name AS org_name,
            principal.email AS principal_email
    FROM app.principal_org
        LEFT JOIN app.org org ON principal_org.org_id = org.id
        LEFT JOIN app.principal principal ON principal_org.principal_id = principal.id
    WHERE principal_org.org_id = ^(org_id) AND principal_org.principal_id = ^(principal_id);',
    'Select single PrincipalOrg record by RWK columns with related Org, Principal information',
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
    'app.principal_org-get-history',
    'SELECT 
        history.app_principal_org.principal_org_id,
        history.app_principal_org.id,
        history.app_principal_org.is_active,
        history.app_principal_org.created_by,
        history.app_principal_org.last_updated,
        history.app_principal_org.last_updated_by,
        history.app_principal_org.version,
        history.app_principal_org.principal_org_id,
        history.app_principal_org.org_id,
        history.app_principal_org.principal_id,
        history.app_principal_org.is_active,
        history.app_principal_org.created_by,
        history.app_principal_org.last_updated,
        history.app_principal_org.last_updated_by,
        history.app_principal_org.version
    FROM history.app_principal_org
    WHERE history.app_principal_org.principal_org_id = ^(id)
    ORDER BY history.app_principal_org.last_updated DESC;',
    'Select all history records for PrincipalOrg where principal_org_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         