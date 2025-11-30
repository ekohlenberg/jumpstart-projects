-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for AgentStatus (core.agent_status)
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
    'core.agent_status-select',
    'SELECT 
        core.agent_status.id,
            agent_status.name,
            agent_status.is_active,
            agent_status.created_by,
            agent_status.last_updated,
            agent_status.last_updated_by,
            agent_status.version
    FROM core.agent_status
    ORDER BY core.agent_status.id;',
    'Select all AgentStatus records with related  information',
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
    'core.agent_status-get',
    'SELECT 
        core.agent_status.id,
            agent_status.name,
            agent_status.is_active,
            agent_status.created_by,
            agent_status.last_updated,
            agent_status.last_updated_by,
            agent_status.version
    FROM core.agent_status
    WHERE core.agent_status.id = ^(id);',
    'Select single AgentStatus record by ID with related  information',
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
    'core.agent_status-get-by-rwk',
    'SELECT 
        core.agent_status.id,
            agent_status.name,
            agent_status.is_active,
            agent_status.created_by,
            agent_status.last_updated,
            agent_status.last_updated_by,
            agent_status.version
    FROM core.agent_status
    WHERE agent_status.name = ^(name);',
    'Select single AgentStatus record by RWK columns with related  information',
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
    'core.agent_status-get-history',
    'SELECT 
        history.core_agent_status.agent_status_id,
        history.core_agent_status.id,
        history.core_agent_status.is_active,
        history.core_agent_status.created_by,
        history.core_agent_status.last_updated,
        history.core_agent_status.last_updated_by,
        history.core_agent_status.version,
        history.core_agent_status.agent_status_id,
        history.core_agent_status.name,
        history.core_agent_status.is_active,
        history.core_agent_status.created_by,
        history.core_agent_status.last_updated,
        history.core_agent_status.last_updated_by,
        history.core_agent_status.version
    FROM history.core_agent_status
    WHERE history.core_agent_status.agent_status_id = ^(id)
    ORDER BY history.core_agent_status.last_updated DESC;',
    'Select all history records for AgentStatus where agent_status_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         