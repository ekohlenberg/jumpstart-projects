-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Resource (app.resource)
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
    'app.resource-select',
    'SELECT 
        app.resource.id,
            resource.name,
            resource.resource_type_id,
            resource.internal_org_id,
            resource.external_org_id,
            resource.ip_address,
            resource.description,
            resource.is_active,
            resource.created_by,
            resource.last_updated,
            resource.last_updated_by,
            resource.version,
            resource_type.name AS resource_type_name,
            internal_org.name AS internal_org_name,
            external_org.name AS external_org_name
    FROM app.resource
        LEFT JOIN app.resource_type resource_type ON resource.resource_type_id = resource_type.id
        LEFT JOIN app.org internal_org ON resource.internal_org_id = internal_org.id
        LEFT JOIN app.org external_org ON resource.external_org_id = external_org.id
    ORDER BY app.resource.id;',
    'Select all Resource records with related ResourceType, Org, Org information',
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
    'app.resource-get',
    'SELECT 
        app.resource.id,
            resource.name,
            resource.resource_type_id,
            resource.internal_org_id,
            resource.external_org_id,
            resource.ip_address,
            resource.description,
            resource.is_active,
            resource.created_by,
            resource.last_updated,
            resource.last_updated_by,
            resource.version,
            resource_type.name AS resource_type_name,
            internal_org.name AS internal_org_name,
            external_org.name AS external_org_name
    FROM app.resource
        LEFT JOIN app.resource_type resource_type ON resource.resource_type_id = resource_type.id
        LEFT JOIN app.org internal_org ON resource.internal_org_id = internal_org.id
        LEFT JOIN app.org external_org ON resource.external_org_id = external_org.id
    WHERE app.resource.id = ^(id);',
    'Select single Resource record by ID with related ResourceType, Org, Org information',
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
    'app.resource-get-by-rwk',
    'SELECT 
        app.resource.id,
            resource.name,
            resource.resource_type_id,
            resource.internal_org_id,
            resource.external_org_id,
            resource.ip_address,
            resource.description,
            resource.is_active,
            resource.created_by,
            resource.last_updated,
            resource.last_updated_by,
            resource.version,
            resource_type.name AS resource_type_name,
            internal_org.name AS internal_org_name,
            external_org.name AS external_org_name
    FROM app.resource
        LEFT JOIN app.resource_type resource_type ON resource.resource_type_id = resource_type.id
        LEFT JOIN app.org internal_org ON resource.internal_org_id = internal_org.id
        LEFT JOIN app.org external_org ON resource.external_org_id = external_org.id
    WHERE resource.name = ^(name) AND resource.resource_type_id = ^(resource_type_id) AND resource.internal_org_id = ^(internal_org_id) AND resource.external_org_id = ^(external_org_id);',
    'Select single Resource record by RWK columns with related ResourceType, Org, Org information',
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
    'app.resource-get-history',
    'SELECT 
        history.app_resource.resource_id,
        history.app_resource.id,
        history.app_resource.is_active,
        history.app_resource.created_by,
        history.app_resource.last_updated,
        history.app_resource.last_updated_by,
        history.app_resource.version,
        history.app_resource.resource_id,
        history.app_resource.name,
        history.app_resource.resource_type_id,
        history.app_resource.internal_org_id,
        history.app_resource.external_org_id,
        history.app_resource.ip_address,
        history.app_resource.description,
        history.app_resource.is_active,
        history.app_resource.created_by,
        history.app_resource.last_updated,
        history.app_resource.last_updated_by,
        history.app_resource.version
    FROM history.app_resource
    WHERE history.app_resource.resource_id = ^(id)
    ORDER BY history.app_resource.last_updated DESC;',
    'Select all history records for Resource where resource_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         