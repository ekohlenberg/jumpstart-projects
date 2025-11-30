-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Uom (app.uom)
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
    'app.uom-select',
    'SELECT 
        app.uom.id,
            uom.name,
            uom.is_active,
            uom.created_by,
            uom.last_updated,
            uom.last_updated_by,
            uom.version
    FROM app.uom
    ORDER BY app.uom.id;',
    'Select all Uom records with related  information',
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
    'app.uom-get',
    'SELECT 
        app.uom.id,
            uom.name,
            uom.is_active,
            uom.created_by,
            uom.last_updated,
            uom.last_updated_by,
            uom.version
    FROM app.uom
    WHERE app.uom.id = ^(id);',
    'Select single Uom record by ID with related  information',
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
    'app.uom-get-by-rwk',
    'SELECT 
        app.uom.id,
            uom.name,
            uom.is_active,
            uom.created_by,
            uom.last_updated,
            uom.last_updated_by,
            uom.version
    FROM app.uom
    WHERE uom.name = ^(name);',
    'Select single Uom record by RWK columns with related  information',
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
    'app.uom-get-history',
    'SELECT 
        history.app_uom.uom_id,
        history.app_uom.id,
        history.app_uom.is_active,
        history.app_uom.created_by,
        history.app_uom.last_updated,
        history.app_uom.last_updated_by,
        history.app_uom.version,
        history.app_uom.uom_id,
        history.app_uom.name,
        history.app_uom.is_active,
        history.app_uom.created_by,
        history.app_uom.last_updated,
        history.app_uom.last_updated_by,
        history.app_uom.version
    FROM history.app_uom
    WHERE history.app_uom.uom_id = ^(id)
    ORDER BY history.app_uom.last_updated DESC;',
    'Select all history records for Uom where uom_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         