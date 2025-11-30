-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for AlertRule (app.alert_rule)
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
    'app.alert_rule-select',
    'SELECT 
        app.alert_rule.id,
            alert_rule.metric_id,
            alert_rule.name,
            alert_rule.condition,
            alert_rule.threshold,
            alert_rule.recipients,
            alert_rule.is_active,
            alert_rule.created_by,
            alert_rule.last_updated,
            alert_rule.last_updated_by,
            alert_rule.version,
            metric.name AS metric_name,
            metric.category_id AS metric_category_id
    FROM app.alert_rule
        LEFT JOIN app.metric metric ON alert_rule.metric_id = metric.id
    ORDER BY app.alert_rule.id;',
    'Select all AlertRule records with related Metric information',
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
    'app.alert_rule-get',
    'SELECT 
        app.alert_rule.id,
            alert_rule.metric_id,
            alert_rule.name,
            alert_rule.condition,
            alert_rule.threshold,
            alert_rule.recipients,
            alert_rule.is_active,
            alert_rule.created_by,
            alert_rule.last_updated,
            alert_rule.last_updated_by,
            alert_rule.version,
            metric.name AS metric_name,
            metric.category_id AS metric_category_id
    FROM app.alert_rule
        LEFT JOIN app.metric metric ON alert_rule.metric_id = metric.id
    WHERE app.alert_rule.id = ^(id);',
    'Select single AlertRule record by ID with related Metric information',
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
    'app.alert_rule-get-by-rwk',
    'SELECT 
        app.alert_rule.id,
            alert_rule.metric_id,
            alert_rule.name,
            alert_rule.condition,
            alert_rule.threshold,
            alert_rule.recipients,
            alert_rule.is_active,
            alert_rule.created_by,
            alert_rule.last_updated,
            alert_rule.last_updated_by,
            alert_rule.version,
            metric.name AS metric_name,
            metric.category_id AS metric_category_id
    FROM app.alert_rule
        LEFT JOIN app.metric metric ON alert_rule.metric_id = metric.id
    WHERE alert_rule.metric_id = ^(metric_id) AND alert_rule.name = ^(name) AND alert_rule.condition = ^(condition);',
    'Select single AlertRule record by RWK columns with related Metric information',
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
    'app.alert_rule-get-history',
    'SELECT 
        history.app_alert_rule.alert_rule_id,
        history.app_alert_rule.id,
        history.app_alert_rule.is_active,
        history.app_alert_rule.created_by,
        history.app_alert_rule.last_updated,
        history.app_alert_rule.last_updated_by,
        history.app_alert_rule.version,
        history.app_alert_rule.alert_rule_id,
        history.app_alert_rule.metric_id,
        history.app_alert_rule.name,
        history.app_alert_rule.condition,
        history.app_alert_rule.threshold,
        history.app_alert_rule.recipients,
        history.app_alert_rule.is_active,
        history.app_alert_rule.created_by,
        history.app_alert_rule.last_updated,
        history.app_alert_rule.last_updated_by,
        history.app_alert_rule.version
    FROM history.app_alert_rule
    WHERE history.app_alert_rule.alert_rule_id = ^(id)
    ORDER BY history.app_alert_rule.last_updated DESC;',
    'Select all history records for AlertRule where alert_rule_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         