-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Scheduler (core.scheduler)
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
    'core.scheduler-select',
    'SELECT 
        core.scheduler.id,
            scheduler.hostname,
            scheduler.ip_address,
            scheduler.port,
            scheduler.username,
            scheduler.url,
            scheduler.user_domain,
            scheduler.os_name,
            scheduler.os_version,
            scheduler.architecture,
            scheduler.registered_at,
            scheduler.scheduler_status_id,
            scheduler.is_active,
            scheduler.created_by,
            scheduler.last_updated,
            scheduler.last_updated_by,
            scheduler.version,
            scheduler_status.name AS scheduler_status_name
    FROM core.scheduler
        LEFT JOIN core.scheduler_status scheduler_status ON scheduler.scheduler_status_id = scheduler_status.id
    ORDER BY core.scheduler.id;',
    'Select all Scheduler records with related SchedulerStatus information',
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
    'core.scheduler-get',
    'SELECT 
        core.scheduler.id,
            scheduler.hostname,
            scheduler.ip_address,
            scheduler.port,
            scheduler.username,
            scheduler.url,
            scheduler.user_domain,
            scheduler.os_name,
            scheduler.os_version,
            scheduler.architecture,
            scheduler.registered_at,
            scheduler.scheduler_status_id,
            scheduler.is_active,
            scheduler.created_by,
            scheduler.last_updated,
            scheduler.last_updated_by,
            scheduler.version,
            scheduler_status.name AS scheduler_status_name
    FROM core.scheduler
        LEFT JOIN core.scheduler_status scheduler_status ON scheduler.scheduler_status_id = scheduler_status.id
    WHERE core.scheduler.id = ^(id);',
    'Select single Scheduler record by ID with related SchedulerStatus information',
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
    'core.scheduler-get-by-rwk',
    'SELECT 
        core.scheduler.id,
            scheduler.hostname,
            scheduler.ip_address,
            scheduler.port,
            scheduler.username,
            scheduler.url,
            scheduler.user_domain,
            scheduler.os_name,
            scheduler.os_version,
            scheduler.architecture,
            scheduler.registered_at,
            scheduler.scheduler_status_id,
            scheduler.is_active,
            scheduler.created_by,
            scheduler.last_updated,
            scheduler.last_updated_by,
            scheduler.version,
            scheduler_status.name AS scheduler_status_name
    FROM core.scheduler
        LEFT JOIN core.scheduler_status scheduler_status ON scheduler.scheduler_status_id = scheduler_status.id
    WHERE scheduler.hostname = ^(hostname) AND scheduler.ip_address = ^(ip_address) AND scheduler.port = ^(port);',
    'Select single Scheduler record by RWK columns with related SchedulerStatus information',
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
    'core.scheduler-get-history',
    'SELECT 
        history.core_scheduler.scheduler_id,
        history.core_scheduler.id,
        history.core_scheduler.is_active,
        history.core_scheduler.created_by,
        history.core_scheduler.last_updated,
        history.core_scheduler.last_updated_by,
        history.core_scheduler.version,
        history.core_scheduler.scheduler_id,
        history.core_scheduler.hostname,
        history.core_scheduler.ip_address,
        history.core_scheduler.port,
        history.core_scheduler.username,
        history.core_scheduler.url,
        history.core_scheduler.user_domain,
        history.core_scheduler.os_name,
        history.core_scheduler.os_version,
        history.core_scheduler.architecture,
        history.core_scheduler.registered_at,
        history.core_scheduler.scheduler_status_id,
        history.core_scheduler.is_active,
        history.core_scheduler.created_by,
        history.core_scheduler.last_updated,
        history.core_scheduler.last_updated_by,
        history.core_scheduler.version
    FROM history.core_scheduler
    WHERE history.core_scheduler.scheduler_id = ^(id)
    ORDER BY history.core_scheduler.last_updated DESC;',
    'Select all history records for Scheduler where scheduler_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         