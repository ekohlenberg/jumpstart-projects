-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for WorkflowProcess (core.workflow_process)
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
    'core.workflow_process-select',
    'SELECT 
        core.workflow_process.id,
            workflow_process.workflow_id,
            workflow_process.process_id,
            workflow_process.agent_id,
            workflow_process.seq,
            workflow_process.on_failure_action_id,
            workflow_process.is_active,
            workflow_process.created_by,
            workflow_process.last_updated,
            workflow_process.last_updated_by,
            workflow_process.version,
            workflow.parent_workflow_id AS workflow_parent_workflow_id,
            workflow.name AS workflow_name,
            process.name AS process_name,
            on_failure_action.action AS on_failure_action_action
    FROM core.workflow_process
        LEFT JOIN core.workflow workflow ON workflow_process.workflow_id = workflow.id
        LEFT JOIN core.process process ON workflow_process.process_id = process.id
        LEFT JOIN core.on_failure on_failure_action ON workflow_process.on_failure_action_id = on_failure_action.id
    ORDER BY core.workflow_process.id;',
    'Select all WorkflowProcess records with related Workflow, Process, Server, OnFailure information',
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
    'core.workflow_process-get',
    'SELECT 
        core.workflow_process.id,
            workflow_process.workflow_id,
            workflow_process.process_id,
            workflow_process.agent_id,
            workflow_process.seq,
            workflow_process.on_failure_action_id,
            workflow_process.is_active,
            workflow_process.created_by,
            workflow_process.last_updated,
            workflow_process.last_updated_by,
            workflow_process.version,
            workflow.parent_workflow_id AS workflow_parent_workflow_id,
            workflow.name AS workflow_name,
            process.name AS process_name,
            on_failure_action.action AS on_failure_action_action
    FROM core.workflow_process
        LEFT JOIN core.workflow workflow ON workflow_process.workflow_id = workflow.id
        LEFT JOIN core.process process ON workflow_process.process_id = process.id
        LEFT JOIN core.on_failure on_failure_action ON workflow_process.on_failure_action_id = on_failure_action.id
    WHERE core.workflow_process.id = ^(id);',
    'Select single WorkflowProcess record by ID with related Workflow, Process, Server, OnFailure information',
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
    'core.workflow_process-get-by-rwk',
    'SELECT 
        core.workflow_process.id,
            workflow_process.workflow_id,
            workflow_process.process_id,
            workflow_process.agent_id,
            workflow_process.seq,
            workflow_process.on_failure_action_id,
            workflow_process.is_active,
            workflow_process.created_by,
            workflow_process.last_updated,
            workflow_process.last_updated_by,
            workflow_process.version,
            workflow.parent_workflow_id AS workflow_parent_workflow_id,
            workflow.name AS workflow_name,
            process.name AS process_name,
            on_failure_action.action AS on_failure_action_action
    FROM core.workflow_process
        LEFT JOIN core.workflow workflow ON workflow_process.workflow_id = workflow.id
        LEFT JOIN core.process process ON workflow_process.process_id = process.id
        LEFT JOIN core.on_failure on_failure_action ON workflow_process.on_failure_action_id = on_failure_action.id
    WHERE workflow_process.workflow_id = ^(workflow_id) AND workflow_process.process_id = ^(process_id);',
    'Select single WorkflowProcess record by RWK columns with related Workflow, Process, Server, OnFailure information',
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
    'core.workflow_process-get-history',
    'SELECT 
        history.core_workflow_process.workflow_process_id,
        history.core_workflow_process.id,
        history.core_workflow_process.is_active,
        history.core_workflow_process.created_by,
        history.core_workflow_process.last_updated,
        history.core_workflow_process.last_updated_by,
        history.core_workflow_process.version,
        history.core_workflow_process.workflow_process_id,
        history.core_workflow_process.workflow_id,
        history.core_workflow_process.process_id,
        history.core_workflow_process.agent_id,
        history.core_workflow_process.seq,
        history.core_workflow_process.on_failure_action_id,
        history.core_workflow_process.is_active,
        history.core_workflow_process.created_by,
        history.core_workflow_process.last_updated,
        history.core_workflow_process.last_updated_by,
        history.core_workflow_process.version
    FROM history.core_workflow_process
    WHERE history.core_workflow_process.workflow_process_id = ^(id)
    ORDER BY history.core_workflow_process.last_updated DESC;',
    'Select all history records for WorkflowProcess where workflow_process_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         