-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for MetricResourceMap (app.metric_resource_map)
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
    'app.metric_resource_map-select',
    'SELECT 
        app.metric_resource_map.id,
            metric_resource_map.resource_id,
            metric_resource_map.metric_id,
            metric_resource_map.is_active,
            metric_resource_map.created_by,
            metric_resource_map.last_updated,
            metric_resource_map.last_updated_by,
            metric_resource_map.version,
            resource.name AS resource_name,
            resource.resource_type_id AS resource_resource_type_id,
            resource.internal_org_id AS resource_internal_org_id,
            resource.external_org_id AS resource_external_org_id,
            metric.name AS metric_name,
            metric.category_id AS metric_category_id
    FROM app.metric_resource_map
        LEFT JOIN app.resource resource ON metric_resource_map.resource_id = resource.id
        LEFT JOIN app.metric metric ON metric_resource_map.metric_id = metric.id
    ORDER BY app.metric_resource_map.id;',
    'Select all MetricResourceMap records with related Resource, Metric information',
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
    'app.metric_resource_map-get',
    'SELECT 
        app.metric_resource_map.id,
            metric_resource_map.resource_id,
            metric_resource_map.metric_id,
            metric_resource_map.is_active,
            metric_resource_map.created_by,
            metric_resource_map.last_updated,
            metric_resource_map.last_updated_by,
            metric_resource_map.version,
            resource.name AS resource_name,
            resource.resource_type_id AS resource_resource_type_id,
            resource.internal_org_id AS resource_internal_org_id,
            resource.external_org_id AS resource_external_org_id,
            metric.name AS metric_name,
            metric.category_id AS metric_category_id
    FROM app.metric_resource_map
        LEFT JOIN app.resource resource ON metric_resource_map.resource_id = resource.id
        LEFT JOIN app.metric metric ON metric_resource_map.metric_id = metric.id
    WHERE app.metric_resource_map.id = ^(id);',
    'Select single MetricResourceMap record by ID with related Resource, Metric information',
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
    'app.metric_resource_map-get-by-rwk',
    'SELECT 
        app.metric_resource_map.id,
            metric_resource_map.resource_id,
            metric_resource_map.metric_id,
            metric_resource_map.is_active,
            metric_resource_map.created_by,
            metric_resource_map.last_updated,
            metric_resource_map.last_updated_by,
            metric_resource_map.version,
            resource.name AS resource_name,
            resource.resource_type_id AS resource_resource_type_id,
            resource.internal_org_id AS resource_internal_org_id,
            resource.external_org_id AS resource_external_org_id,
            metric.name AS metric_name,
            metric.category_id AS metric_category_id
    FROM app.metric_resource_map
        LEFT JOIN app.resource resource ON metric_resource_map.resource_id = resource.id
        LEFT JOIN app.metric metric ON metric_resource_map.metric_id = metric.id
    WHERE metric_resource_map.resource_id = ^(resource_id) AND metric_resource_map.metric_id = ^(metric_id);',
    'Select single MetricResourceMap record by RWK columns with related Resource, Metric information',
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
    'app.metric_resource_map-get-history',
    'SELECT 
        history.app_metric_resource_map.metric_resource_map_id,
        history.app_metric_resource_map.id,
        history.app_metric_resource_map.is_active,
        history.app_metric_resource_map.created_by,
        history.app_metric_resource_map.last_updated,
        history.app_metric_resource_map.last_updated_by,
        history.app_metric_resource_map.version,
        history.app_metric_resource_map.metric_resource_map_id,
        history.app_metric_resource_map.resource_id,
        history.app_metric_resource_map.metric_id,
        history.app_metric_resource_map.is_active,
        history.app_metric_resource_map.created_by,
        history.app_metric_resource_map.last_updated,
        history.app_metric_resource_map.last_updated_by,
        history.app_metric_resource_map.version
    FROM history.app_metric_resource_map
    WHERE history.app_metric_resource_map.metric_resource_map_id = ^(id)
    ORDER BY history.app_metric_resource_map.last_updated DESC;',
    'Select all history records for MetricResourceMap where metric_resource_map_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         