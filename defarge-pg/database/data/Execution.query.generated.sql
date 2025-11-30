-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Execution (core.execution)
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
    'core.execution-select',
    'SELECT 
        core.execution.id,
            execution.token,
            execution.workflow_process_id,
            execution.start_time,
            execution.end_time,
            execution.exec_status_id,
            execution.stdout,
            execution.stderr,
            execution.is_active,
            execution.created_by,
            execution.last_updated,
            execution.last_updated_by,
            execution.version,
            workflow_process.name AS workflow_process_name
    FROM core.execution
        LEFT JOIN core.process workflow_process ON execution.workflow_process_id = workflow_process.id
    ORDER BY core.execution.id;',
    'Select all Execution records with related Process information',
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
    'core.execution-get',
    'SELECT 
        core.execution.id,
            execution.token,
            execution.workflow_process_id,
            execution.start_time,
            execution.end_time,
            execution.exec_status_id,
            execution.stdout,
            execution.stderr,
            execution.is_active,
            execution.created_by,
            execution.last_updated,
            execution.last_updated_by,
            execution.version,
            workflow_process.name AS workflow_process_name
    FROM core.execution
        LEFT JOIN core.process workflow_process ON execution.workflow_process_id = workflow_process.id
    WHERE core.execution.id = ^(id);',
    'Select single Execution record by ID with related Process information',
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
    'core.execution-get-by-rwk',
    'SELECT 
        core.execution.id,
            execution.token,
            execution.workflow_process_id,
            execution.start_time,
            execution.end_time,
            execution.exec_status_id,
            execution.stdout,
            execution.stderr,
            execution.is_active,
            execution.created_by,
            execution.last_updated,
            execution.last_updated_by,
            execution.version,
            workflow_process.name AS workflow_process_name
    FROM core.execution
        LEFT JOIN core.process workflow_process ON execution.workflow_process_id = workflow_process.id
    WHERE execution.token = ^(token) AND execution.workflow_process_id = ^(workflow_process_id) AND execution.start_time = ^(start_time) AND execution.end_time = ^(end_time);',
    'Select single Execution record by RWK columns with related Process information',
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
    'core.execution-get-history',
    'SELECT 
        history.core_execution.execution_id,
        history.core_execution.id,
        history.core_execution.is_active,
        history.core_execution.created_by,
        history.core_execution.last_updated,
        history.core_execution.last_updated_by,
        history.core_execution.version,
        history.core_execution.execution_id,
        history.core_execution.token,
        history.core_execution.workflow_process_id,
        history.core_execution.start_time,
        history.core_execution.end_time,
        history.core_execution.exec_status_id,
        history.core_execution.stdout,
        history.core_execution.stderr,
        history.core_execution.is_active,
        history.core_execution.created_by,
        history.core_execution.last_updated,
        history.core_execution.last_updated_by,
        history.core_execution.version
    FROM history.core_execution
    WHERE history.core_execution.execution_id = ^(id)
    ORDER BY history.core_execution.last_updated DESC;',
    'Select all history records for Execution where execution_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         