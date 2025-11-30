-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Alert (app.alert)
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
    'app.alert-select',
    'SELECT 
        app.alert.id,
            alert.alert_rule_id,
            alert.metric_event_id,
            alert.triggered_at,
            alert.resolved_at,
            alert.status,
            alert.is_active,
            alert.created_by,
            alert.last_updated,
            alert.last_updated_by,
            alert.version,
            alert_rule.metric_id AS alert_rule_metric_id,
            alert_rule.name AS alert_rule_name,
            alert_rule.condition AS alert_rule_condition,
            metric_event.metric_id AS metric_event_metric_id,
            metric_event.event_time AS metric_event_event_time
    FROM app.alert
        LEFT JOIN app.alert_rule alert_rule ON alert.alert_rule_id = alert_rule.id
        LEFT JOIN app.metric_event metric_event ON alert.metric_event_id = metric_event.id
    ORDER BY app.alert.id;',
    'Select all Alert records with related AlertRule, MetricEvent information',
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
    'app.alert-get',
    'SELECT 
        app.alert.id,
            alert.alert_rule_id,
            alert.metric_event_id,
            alert.triggered_at,
            alert.resolved_at,
            alert.status,
            alert.is_active,
            alert.created_by,
            alert.last_updated,
            alert.last_updated_by,
            alert.version,
            alert_rule.metric_id AS alert_rule_metric_id,
            alert_rule.name AS alert_rule_name,
            alert_rule.condition AS alert_rule_condition,
            metric_event.metric_id AS metric_event_metric_id,
            metric_event.event_time AS metric_event_event_time
    FROM app.alert
        LEFT JOIN app.alert_rule alert_rule ON alert.alert_rule_id = alert_rule.id
        LEFT JOIN app.metric_event metric_event ON alert.metric_event_id = metric_event.id
    WHERE app.alert.id = ^(id);',
    'Select single Alert record by ID with related AlertRule, MetricEvent information',
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
    'app.alert-get-by-rwk',
    'SELECT 
        app.alert.id,
            alert.alert_rule_id,
            alert.metric_event_id,
            alert.triggered_at,
            alert.resolved_at,
            alert.status,
            alert.is_active,
            alert.created_by,
            alert.last_updated,
            alert.last_updated_by,
            alert.version,
            alert_rule.metric_id AS alert_rule_metric_id,
            alert_rule.name AS alert_rule_name,
            alert_rule.condition AS alert_rule_condition,
            metric_event.metric_id AS metric_event_metric_id,
            metric_event.event_time AS metric_event_event_time
    FROM app.alert
        LEFT JOIN app.alert_rule alert_rule ON alert.alert_rule_id = alert_rule.id
        LEFT JOIN app.metric_event metric_event ON alert.metric_event_id = metric_event.id
    WHERE alert.alert_rule_id = ^(alert_rule_id) AND alert.metric_event_id = ^(metric_event_id) AND alert.triggered_at = ^(triggered_at);',
    'Select single Alert record by RWK columns with related AlertRule, MetricEvent information',
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
    'app.alert-get-history',
    'SELECT 
        history.app_alert.alert_id,
        history.app_alert.id,
        history.app_alert.is_active,
        history.app_alert.created_by,
        history.app_alert.last_updated,
        history.app_alert.last_updated_by,
        history.app_alert.version,
        history.app_alert.alert_id,
        history.app_alert.alert_rule_id,
        history.app_alert.metric_event_id,
        history.app_alert.triggered_at,
        history.app_alert.resolved_at,
        history.app_alert.status,
        history.app_alert.is_active,
        history.app_alert.created_by,
        history.app_alert.last_updated,
        history.app_alert.last_updated_by,
        history.app_alert.version
    FROM history.app_alert
    WHERE history.app_alert.alert_id = ^(id)
    ORDER BY history.app_alert.last_updated DESC;',
    'Select all history records for Alert where alert_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         