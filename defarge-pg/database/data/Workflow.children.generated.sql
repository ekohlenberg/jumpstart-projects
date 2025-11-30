-- =====================================
-- Generate SELECT queries for child records
-- =====================================


-- =====================================
-- Child queries for Workflow (core.workflow)
-- =====================================

        
-- Child relationship:  (parent_workflow)
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
    'core.workflow-children-workflow-parent_workflow',
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
    WHERE core.workflow.parent_workflow_id = ^(id)
    ORDER BY core.workflow.id;',
    'Select all  records for Workflow with related Workflow information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

            