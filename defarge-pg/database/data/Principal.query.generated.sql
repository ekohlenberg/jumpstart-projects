-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Principal (app.principal)
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
    'app.principal-select',
    'SELECT 
        app.principal.id,
            principal.first_name,
            principal.last_name,
            principal.username,
            principal.email,
            principal.created_date,
            principal.last_login_date,
            principal.is_active,
            principal.created_by,
            principal.last_updated,
            principal.last_updated_by,
            principal.version
    FROM app.principal
    ORDER BY app.principal.id;',
    'Select all Principal records with related  information',
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
    'app.principal-get',
    'SELECT 
        app.principal.id,
            principal.first_name,
            principal.last_name,
            principal.username,
            principal.email,
            principal.created_date,
            principal.last_login_date,
            principal.is_active,
            principal.created_by,
            principal.last_updated,
            principal.last_updated_by,
            principal.version
    FROM app.principal
    WHERE app.principal.id = ^(id);',
    'Select single Principal record by ID with related  information',
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
    'app.principal-get-by-rwk',
    'SELECT 
        app.principal.id,
            principal.first_name,
            principal.last_name,
            principal.username,
            principal.email,
            principal.created_date,
            principal.last_login_date,
            principal.is_active,
            principal.created_by,
            principal.last_updated,
            principal.last_updated_by,
            principal.version
    FROM app.principal
    WHERE principal.email = ^(email);',
    'Select single Principal record by RWK columns with related  information',
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
    'app.principal-get-history',
    'SELECT 
        history.app_principal.principal_id,
        history.app_principal.id,
        history.app_principal.is_active,
        history.app_principal.created_by,
        history.app_principal.last_updated,
        history.app_principal.last_updated_by,
        history.app_principal.version,
        history.app_principal.principal_id,
        history.app_principal.first_name,
        history.app_principal.last_name,
        history.app_principal.username,
        history.app_principal.email,
        history.app_principal.created_date,
        history.app_principal.last_login_date,
        history.app_principal.is_active,
        history.app_principal.created_by,
        history.app_principal.last_updated,
        history.app_principal.last_updated_by,
        history.app_principal.version
    FROM history.app_principal
    WHERE history.app_principal.principal_id = ^(id)
    ORDER BY history.app_principal.last_updated DESC;',
    'Select all history records for Principal where principal_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         