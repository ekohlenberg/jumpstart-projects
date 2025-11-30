-- =====================================
-- Generate SELECT queries for child records
-- =====================================


-- =====================================
-- Child queries for Metric (app.metric)
-- =====================================

        
-- Child relationship: Metric (metric)
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
    'app.metric-children-metricevent-metric',
    'SELECT 
        app.metric_event.id,
            metric_event.metric_id,
            metric_event.event_time,
            metric_event.value,
            metric_event.is_active,
            metric_event.created_by,
            metric_event.last_updated,
            metric_event.last_updated_by,
            metric_event.version,
            metric.name AS metric_name,
            metric.category_id AS metric_category_id
    FROM app.metric_event
        LEFT JOIN app.metric metric ON metric_event.metric_id = metric.id
    WHERE app.metric_event.metric_id = ^(id)
    ORDER BY app.metric_event.id;',
    'Select all Metric records for Metric with related Metric information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

            
-- Child relationship: Metric (metric)
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
    'app.metric-children-alertrule-metric',
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
    WHERE app.alert_rule.metric_id = ^(id)
    ORDER BY app.alert_rule.id;',
    'Select all Metric records for Metric with related Metric information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

            