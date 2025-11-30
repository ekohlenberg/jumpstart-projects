-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Org (app.org)
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
    'app.org-select',
    'SELECT 
        app.org.id,
            org.name,
            org.is_active,
            org.created_by,
            org.last_updated,
            org.last_updated_by,
            org.version
    FROM app.org
    ORDER BY app.org.id;',
    'Select all Org records with related  information',
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
    'app.org-get',
    'SELECT 
        app.org.id,
            org.name,
            org.is_active,
            org.created_by,
            org.last_updated,
            org.last_updated_by,
            org.version
    FROM app.org
    WHERE app.org.id = ^(id);',
    'Select single Org record by ID with related  information',
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
    'app.org-get-by-rwk',
    'SELECT 
        app.org.id,
            org.name,
            org.is_active,
            org.created_by,
            org.last_updated,
            org.last_updated_by,
            org.version
    FROM app.org
    WHERE org.name = ^(name);',
    'Select single Org record by RWK columns with related  information',
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
    'app.org-get-history',
    'SELECT 
        history.app_org.org_id,
        history.app_org.id,
        history.app_org.is_active,
        history.app_org.created_by,
        history.app_org.last_updated,
        history.app_org.last_updated_by,
        history.app_org.version,
        history.app_org.org_id,
        history.app_org.name,
        history.app_org.is_active,
        history.app_org.created_by,
        history.app_org.last_updated,
        history.app_org.last_updated_by,
        history.app_org.version
    FROM history.app_org
    WHERE history.app_org.org_id = ^(id)
    ORDER BY history.app_org.last_updated DESC;',
    'Select all history records for Org where org_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         