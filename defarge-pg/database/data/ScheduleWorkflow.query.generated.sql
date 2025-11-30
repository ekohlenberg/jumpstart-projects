-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for ScheduleWorkflow (core.schedule_workflow)
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
    'core.schedule_workflow-select',
    'SELECT 
        core.schedule_workflow.id,
            schedule_workflow.schedule_id,
            schedule_workflow.workflow_id,
            schedule_workflow.is_active,
            schedule_workflow.created_by,
            schedule_workflow.last_updated,
            schedule_workflow.last_updated_by,
            schedule_workflow.version,
            schedule.cron_expression AS schedule_cron_expression,
            workflow.parent_workflow_id AS workflow_parent_workflow_id,
            workflow.name AS workflow_name
    FROM core.schedule_workflow
        LEFT JOIN core.schedule schedule ON schedule_workflow.schedule_id = schedule.id
        LEFT JOIN core.workflow workflow ON schedule_workflow.workflow_id = workflow.id
    ORDER BY core.schedule_workflow.id;',
    'Select all ScheduleWorkflow records with related Schedule, Workflow information',
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
    'core.schedule_workflow-get',
    'SELECT 
        core.schedule_workflow.id,
            schedule_workflow.schedule_id,
            schedule_workflow.workflow_id,
            schedule_workflow.is_active,
            schedule_workflow.created_by,
            schedule_workflow.last_updated,
            schedule_workflow.last_updated_by,
            schedule_workflow.version,
            schedule.cron_expression AS schedule_cron_expression,
            workflow.parent_workflow_id AS workflow_parent_workflow_id,
            workflow.name AS workflow_name
    FROM core.schedule_workflow
        LEFT JOIN core.schedule schedule ON schedule_workflow.schedule_id = schedule.id
        LEFT JOIN core.workflow workflow ON schedule_workflow.workflow_id = workflow.id
    WHERE core.schedule_workflow.id = ^(id);',
    'Select single ScheduleWorkflow record by ID with related Schedule, Workflow information',
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
    'core.schedule_workflow-get-by-rwk',
    'SELECT 
        core.schedule_workflow.id,
            schedule_workflow.schedule_id,
            schedule_workflow.workflow_id,
            schedule_workflow.is_active,
            schedule_workflow.created_by,
            schedule_workflow.last_updated,
            schedule_workflow.last_updated_by,
            schedule_workflow.version,
            schedule.cron_expression AS schedule_cron_expression,
            workflow.parent_workflow_id AS workflow_parent_workflow_id,
            workflow.name AS workflow_name
    FROM core.schedule_workflow
        LEFT JOIN core.schedule schedule ON schedule_workflow.schedule_id = schedule.id
        LEFT JOIN core.workflow workflow ON schedule_workflow.workflow_id = workflow.id
    WHERE ;',
    'Select single ScheduleWorkflow record by RWK columns with related Schedule, Workflow information',
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
    'core.schedule_workflow-get-history',
    'SELECT 
        history.core_schedule_workflow.schedule_workflow_id,
        history.core_schedule_workflow.id,
        history.core_schedule_workflow.is_active,
        history.core_schedule_workflow.created_by,
        history.core_schedule_workflow.last_updated,
        history.core_schedule_workflow.last_updated_by,
        history.core_schedule_workflow.version,
        history.core_schedule_workflow.schedule_workflow_id,
        history.core_schedule_workflow.schedule_id,
        history.core_schedule_workflow.workflow_id,
        history.core_schedule_workflow.is_active,
        history.core_schedule_workflow.created_by,
        history.core_schedule_workflow.last_updated,
        history.core_schedule_workflow.last_updated_by,
        history.core_schedule_workflow.version
    FROM history.core_schedule_workflow
    WHERE history.core_schedule_workflow.schedule_workflow_id = ^(id)
    ORDER BY history.core_schedule_workflow.last_updated DESC;',
    'Select all history records for ScheduleWorkflow where schedule_workflow_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         