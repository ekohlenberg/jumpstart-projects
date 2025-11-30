-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Schedule (core.schedule)
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
    'core.schedule-select',
    'SELECT 
        core.schedule.id,
            schedule.cron_expression,
            schedule.next_run_time,
            schedule.last_run_time,
            schedule.status,
            schedule.is_active,
            schedule.created_by,
            schedule.last_updated,
            schedule.last_updated_by,
            schedule.version
    FROM core.schedule
    ORDER BY core.schedule.id;',
    'Select all Schedule records with related  information',
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
    'core.schedule-get',
    'SELECT 
        core.schedule.id,
            schedule.cron_expression,
            schedule.next_run_time,
            schedule.last_run_time,
            schedule.status,
            schedule.is_active,
            schedule.created_by,
            schedule.last_updated,
            schedule.last_updated_by,
            schedule.version
    FROM core.schedule
    WHERE core.schedule.id = ^(id);',
    'Select single Schedule record by ID with related  information',
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
    'core.schedule-get-by-rwk',
    'SELECT 
        core.schedule.id,
            schedule.cron_expression,
            schedule.next_run_time,
            schedule.last_run_time,
            schedule.status,
            schedule.is_active,
            schedule.created_by,
            schedule.last_updated,
            schedule.last_updated_by,
            schedule.version
    FROM core.schedule
    WHERE schedule.cron_expression = ^(cron_expression);',
    'Select single Schedule record by RWK columns with related  information',
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
    'core.schedule-get-history',
    'SELECT 
        history.core_schedule.schedule_id,
        history.core_schedule.id,
        history.core_schedule.is_active,
        history.core_schedule.created_by,
        history.core_schedule.last_updated,
        history.core_schedule.last_updated_by,
        history.core_schedule.version,
        history.core_schedule.schedule_id,
        history.core_schedule.cron_expression,
        history.core_schedule.next_run_time,
        history.core_schedule.last_run_time,
        history.core_schedule.status,
        history.core_schedule.is_active,
        history.core_schedule.created_by,
        history.core_schedule.last_updated,
        history.core_schedule.last_updated_by,
        history.core_schedule.version
    FROM history.core_schedule
    WHERE history.core_schedule.schedule_id = ^(id)
    ORDER BY history.core_schedule.last_updated DESC;',
    'Select all history records for Schedule where schedule_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         