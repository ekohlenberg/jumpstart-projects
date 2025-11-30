-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Metric (app.metric)
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
    'app.metric-select',
    'SELECT 
        app.metric.id,
            metric.name,
            metric.category_id,
            metric.uom_id,
            metric.is_active,
            metric.created_by,
            metric.last_updated,
            metric.last_updated_by,
            metric.version,
            category.parent_id AS category_parent_id,
            category.name AS category_name,
            uom.name AS uom_name
    FROM app.metric
        LEFT JOIN app.category category ON metric.category_id = category.id
        LEFT JOIN app.uom uom ON metric.uom_id = uom.id
    ORDER BY app.metric.id;',
    'Select all Metric records with related Category, Uom information',
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
    'app.metric-get',
    'SELECT 
        app.metric.id,
            metric.name,
            metric.category_id,
            metric.uom_id,
            metric.is_active,
            metric.created_by,
            metric.last_updated,
            metric.last_updated_by,
            metric.version,
            category.parent_id AS category_parent_id,
            category.name AS category_name,
            uom.name AS uom_name
    FROM app.metric
        LEFT JOIN app.category category ON metric.category_id = category.id
        LEFT JOIN app.uom uom ON metric.uom_id = uom.id
    WHERE app.metric.id = ^(id);',
    'Select single Metric record by ID with related Category, Uom information',
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
    'app.metric-get-by-rwk',
    'SELECT 
        app.metric.id,
            metric.name,
            metric.category_id,
            metric.uom_id,
            metric.is_active,
            metric.created_by,
            metric.last_updated,
            metric.last_updated_by,
            metric.version,
            category.parent_id AS category_parent_id,
            category.name AS category_name,
            uom.name AS uom_name
    FROM app.metric
        LEFT JOIN app.category category ON metric.category_id = category.id
        LEFT JOIN app.uom uom ON metric.uom_id = uom.id
    WHERE metric.name = ^(name) AND metric.category_id = ^(category_id);',
    'Select single Metric record by RWK columns with related Category, Uom information',
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
    'app.metric-get-history',
    'SELECT 
        history.app_metric.metric_id,
        history.app_metric.id,
        history.app_metric.is_active,
        history.app_metric.created_by,
        history.app_metric.last_updated,
        history.app_metric.last_updated_by,
        history.app_metric.version,
        history.app_metric.metric_id,
        history.app_metric.name,
        history.app_metric.category_id,
        history.app_metric.uom_id,
        history.app_metric.is_active,
        history.app_metric.created_by,
        history.app_metric.last_updated,
        history.app_metric.last_updated_by,
        history.app_metric.version
    FROM history.app_metric
    WHERE history.app_metric.metric_id = ^(id)
    ORDER BY history.app_metric.last_updated DESC;',
    'Select all history records for Metric where metric_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         