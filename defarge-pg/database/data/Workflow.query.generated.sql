-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Workflow (core.workflow)
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
    'core.workflow-select',
    'SELECT 
        core.workflow.id,
            workflow.parent_workflow_id,
            workflow.name,
            workflow.description,
            workflow.is_active,
            workflow.created_by,
            workflow.last_updated,
            workflow.last_updated_by,
            workflow.version,
            parent_workflow.parent_workflow_id AS parent_workflow_parent_workflow_id,
            parent_workflow.name AS parent_workflow_name
    FROM core.workflow
        LEFT JOIN core.workflow parent_workflow ON workflow.parent_workflow_id = parent_workflow.id
    ORDER BY core.workflow.id;',
    'Select all Workflow records with related Workflow information',
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
    'core.workflow-get',
    'SELECT 
        core.workflow.id,
            workflow.parent_workflow_id,
            workflow.name,
            workflow.description,
            workflow.is_active,
            workflow.created_by,
            workflow.last_updated,
            workflow.last_updated_by,
            workflow.version,
            parent_workflow.parent_workflow_id AS parent_workflow_parent_workflow_id,
            parent_workflow.name AS parent_workflow_name
    FROM core.workflow
        LEFT JOIN core.workflow parent_workflow ON workflow.parent_workflow_id = parent_workflow.id
    WHERE core.workflow.id = ^(id);',
    'Select single Workflow record by ID with related Workflow information',
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
    'core.workflow-get-by-rwk',
    'SELECT 
        core.workflow.id,
            workflow.parent_workflow_id,
            workflow.name,
            workflow.description,
            workflow.is_active,
            workflow.created_by,
            workflow.last_updated,
            workflow.last_updated_by,
            workflow.version,
            parent_workflow.parent_workflow_id AS parent_workflow_parent_workflow_id,
            parent_workflow.name AS parent_workflow_name
    FROM core.workflow
        LEFT JOIN core.workflow parent_workflow ON workflow.parent_workflow_id = parent_workflow.id
    WHERE workflow.parent_workflow_id = ^(parent_workflow_id) AND workflow.name = ^(name);',
    'Select single Workflow record by RWK columns with related Workflow information',
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
    'core.workflow-get-history',
    'SELECT 
        history.core_workflow.workflow_id,
        history.core_workflow.id,
        history.core_workflow.is_active,
        history.core_workflow.created_by,
        history.core_workflow.last_updated,
        history.core_workflow.last_updated_by,
        history.core_workflow.version,
        history.core_workflow.workflow_id,
        history.core_workflow.parent_workflow_id,
        history.core_workflow.name,
        history.core_workflow.description,
        history.core_workflow.is_active,
        history.core_workflow.created_by,
        history.core_workflow.last_updated,
        history.core_workflow.last_updated_by,
        history.core_workflow.version
    FROM history.core_workflow
    WHERE history.core_workflow.workflow_id = ^(id)
    ORDER BY history.core_workflow.last_updated DESC;',
    'Select all history records for Workflow where workflow_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         