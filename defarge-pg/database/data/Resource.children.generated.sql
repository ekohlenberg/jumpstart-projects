-- =====================================
-- Generate SELECT queries for child records
-- =====================================


-- =====================================
-- Child queries for Resource (app.resource)
-- =====================================

        
-- Child relationship: Resource (resource)
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
    'app.resource-children-metricresourcemap-resource',
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
    WHERE app.metric_resource_map.resource_id = ^(id)
    ORDER BY app.metric_resource_map.id;',
    'Select all Resource records for Resource with related Resource, Metric information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

            