-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for SchedulerStatus (core.scheduler_status)
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
    'core.scheduler_status-select',
    'SELECT 
        core.scheduler_status.id,
            scheduler_status.name,
            scheduler_status.is_active,
            scheduler_status.created_by,
            scheduler_status.last_updated,
            scheduler_status.last_updated_by,
            scheduler_status.version
    FROM core.scheduler_status
    ORDER BY core.scheduler_status.id;',
    'Select all SchedulerStatus records with related  information',
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
    'core.scheduler_status-get',
    'SELECT 
        core.scheduler_status.id,
            scheduler_status.name,
            scheduler_status.is_active,
            scheduler_status.created_by,
            scheduler_status.last_updated,
            scheduler_status.last_updated_by,
            scheduler_status.version
    FROM core.scheduler_status
    WHERE core.scheduler_status.id = ^(id);',
    'Select single SchedulerStatus record by ID with related  information',
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
    'core.scheduler_status-get-by-rwk',
    'SELECT 
        core.scheduler_status.id,
            scheduler_status.name,
            scheduler_status.is_active,
            scheduler_status.created_by,
            scheduler_status.last_updated,
            scheduler_status.last_updated_by,
            scheduler_status.version
    FROM core.scheduler_status
    WHERE scheduler_status.name = ^(name);',
    'Select single SchedulerStatus record by RWK columns with related  information',
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
    'core.scheduler_status-get-history',
    'SELECT 
        history.core_scheduler_status.scheduler_status_id,
        history.core_scheduler_status.id,
        history.core_scheduler_status.is_active,
        history.core_scheduler_status.created_by,
        history.core_scheduler_status.last_updated,
        history.core_scheduler_status.last_updated_by,
        history.core_scheduler_status.version,
        history.core_scheduler_status.scheduler_status_id,
        history.core_scheduler_status.name,
        history.core_scheduler_status.is_active,
        history.core_scheduler_status.created_by,
        history.core_scheduler_status.last_updated,
        history.core_scheduler_status.last_updated_by,
        history.core_scheduler_status.version
    FROM history.core_scheduler_status
    WHERE history.core_scheduler_status.scheduler_status_id = ^(id)
    ORDER BY history.core_scheduler_status.last_updated DESC;',
    'Select all history records for SchedulerStatus where scheduler_status_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         