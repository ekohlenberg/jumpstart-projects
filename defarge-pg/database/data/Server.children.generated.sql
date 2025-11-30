-- =====================================
-- Generate SELECT queries for child records
-- =====================================


-- =====================================
-- Child queries for Server (core.server)
-- =====================================

        
-- Child relationship:  (server)
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
    'core.server-children-workflowprocess-server',
    'SELECT 
        core.workflow_process.id,
            workflow_process.workflow_id,
            workflow_process.process_id,
            workflow_process.execution_sequence,
            workflow_process.server_id,
            workflow_process.is_active,
            workflow_process.created_by,
            workflow_process.last_updated,
            workflow_process.last_updated_by,
            workflow_process.version,
            workflow.parent_workflow_id AS workflow_parent_workflow_id,
            workflow.name AS workflow_name,
            process.name AS process_name,
            server.name AS server_name,
            server.type AS server_type,
            server.address AS server_address,
            server.port AS server_port
    FROM core.workflow_process
        LEFT JOIN core.workflow workflow ON workflow_process.workflow_id = workflow.id
        LEFT JOIN core.process process ON workflow_process.process_id = process.id
        LEFT JOIN core.server server ON workflow_process.server_id = server.id
    WHERE core.workflow_process.server_id = ^(id)
    ORDER BY core.workflow_process.id;',
    'Select all  records for Server with related Workflow, Process, Server information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

            