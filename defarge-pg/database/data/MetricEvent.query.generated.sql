-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for MetricEvent (app.metric_event)
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
    'app.metric_event-select',
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
    ORDER BY app.metric_event.id;',
    'Select all MetricEvent records with related Metric information',
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
    'app.metric_event-get',
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
    WHERE app.metric_event.id = ^(id);',
    'Select single MetricEvent record by ID with related Metric information',
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
    'app.metric_event-get-by-rwk',
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
    WHERE metric_event.metric_id = ^(metric_id) AND metric_event.event_time = ^(event_time);',
    'Select single MetricEvent record by RWK columns with related Metric information',
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
    'app.metric_event-get-history',
    'SELECT 
        history.app_metric_event.metric_event_id,
        history.app_metric_event.id,
        history.app_metric_event.is_active,
        history.app_metric_event.created_by,
        history.app_metric_event.last_updated,
        history.app_metric_event.last_updated_by,
        history.app_metric_event.version,
        history.app_metric_event.metric_event_id,
        history.app_metric_event.metric_id,
        history.app_metric_event.event_time,
        history.app_metric_event.value,
        history.app_metric_event.is_active,
        history.app_metric_event.created_by,
        history.app_metric_event.last_updated,
        history.app_metric_event.last_updated_by,
        history.app_metric_event.version
    FROM history.app_metric_event
    WHERE history.app_metric_event.metric_event_id = ^(id)
    ORDER BY history.app_metric_event.last_updated DESC;',
    'Select all history records for MetricEvent where metric_event_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         