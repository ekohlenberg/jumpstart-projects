-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for EventService (core.event_service)
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
    'core.event_service-select',
    'SELECT 
        core.event_service.id,
            event_service.event_type,
            event_service.objectname_filter,
            event_service.methodname_filter,
            event_service.script_id,
            event_service.is_active,
            event_service.created_by,
            event_service.last_updated,
            event_service.last_updated_by,
            event_service.version,
            script.name AS script_name,
            script.script_type_id AS script_script_type_id
    FROM core.event_service
        LEFT JOIN core.script script ON event_service.script_id = script.id
    ORDER BY core.event_service.id;',
    'Select all EventService records with related Script information',
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
    'core.event_service-get',
    'SELECT 
        core.event_service.id,
            event_service.event_type,
            event_service.objectname_filter,
            event_service.methodname_filter,
            event_service.script_id,
            event_service.is_active,
            event_service.created_by,
            event_service.last_updated,
            event_service.last_updated_by,
            event_service.version,
            script.name AS script_name,
            script.script_type_id AS script_script_type_id
    FROM core.event_service
        LEFT JOIN core.script script ON event_service.script_id = script.id
    WHERE core.event_service.id = ^(id);',
    'Select single EventService record by ID with related Script information',
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
    'core.event_service-get-by-rwk',
    'SELECT 
        core.event_service.id,
            event_service.event_type,
            event_service.objectname_filter,
            event_service.methodname_filter,
            event_service.script_id,
            event_service.is_active,
            event_service.created_by,
            event_service.last_updated,
            event_service.last_updated_by,
            event_service.version,
            script.name AS script_name,
            script.script_type_id AS script_script_type_id
    FROM core.event_service
        LEFT JOIN core.script script ON event_service.script_id = script.id
    WHERE event_service.event_type = ^(event_type) AND event_service.objectname_filter = ^(objectname_filter) AND event_service.methodname_filter = ^(methodname_filter) AND event_service.script_id = ^(script_id);',
    'Select single EventService record by RWK columns with related Script information',
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
    'core.event_service-get-history',
    'SELECT 
        history.core_event_service.event_service_id,
        history.core_event_service.id,
        history.core_event_service.is_active,
        history.core_event_service.created_by,
        history.core_event_service.last_updated,
        history.core_event_service.last_updated_by,
        history.core_event_service.version,
        history.core_event_service.event_service_id,
        history.core_event_service.event_type,
        history.core_event_service.objectname_filter,
        history.core_event_service.methodname_filter,
        history.core_event_service.script_id,
        history.core_event_service.is_active,
        history.core_event_service.created_by,
        history.core_event_service.last_updated,
        history.core_event_service.last_updated_by,
        history.core_event_service.version
    FROM history.core_event_service
    WHERE history.core_event_service.event_service_id = ^(id)
    ORDER BY history.core_event_service.last_updated DESC;',
    'Select all history records for EventService where event_service_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         