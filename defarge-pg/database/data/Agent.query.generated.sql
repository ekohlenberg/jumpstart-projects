-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Agent (core.agent)
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
    'core.agent-select',
    'SELECT 
        core.agent.id,
            agent.hostname,
            agent.ip_address,
            agent.port,
            agent.username,
            agent.url,
            agent.user_domain,
            agent.os_name,
            agent.os_version,
            agent.architecture,
            agent.registered_at,
            agent.agent_status_id,
            agent.is_active,
            agent.created_by,
            agent.last_updated,
            agent.last_updated_by,
            agent.version,
            agent_status.name AS agent_status_name
    FROM core.agent
        LEFT JOIN core.agent_status agent_status ON agent.agent_status_id = agent_status.id
    ORDER BY core.agent.id;',
    'Select all Agent records with related AgentStatus information',
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
    'core.agent-get',
    'SELECT 
        core.agent.id,
            agent.hostname,
            agent.ip_address,
            agent.port,
            agent.username,
            agent.url,
            agent.user_domain,
            agent.os_name,
            agent.os_version,
            agent.architecture,
            agent.registered_at,
            agent.agent_status_id,
            agent.is_active,
            agent.created_by,
            agent.last_updated,
            agent.last_updated_by,
            agent.version,
            agent_status.name AS agent_status_name
    FROM core.agent
        LEFT JOIN core.agent_status agent_status ON agent.agent_status_id = agent_status.id
    WHERE core.agent.id = ^(id);',
    'Select single Agent record by ID with related AgentStatus information',
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
    'core.agent-get-by-rwk',
    'SELECT 
        core.agent.id,
            agent.hostname,
            agent.ip_address,
            agent.port,
            agent.username,
            agent.url,
            agent.user_domain,
            agent.os_name,
            agent.os_version,
            agent.architecture,
            agent.registered_at,
            agent.agent_status_id,
            agent.is_active,
            agent.created_by,
            agent.last_updated,
            agent.last_updated_by,
            agent.version,
            agent_status.name AS agent_status_name
    FROM core.agent
        LEFT JOIN core.agent_status agent_status ON agent.agent_status_id = agent_status.id
    WHERE agent.hostname = ^(hostname) AND agent.ip_address = ^(ip_address) AND agent.port = ^(port);',
    'Select single Agent record by RWK columns with related AgentStatus information',
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
    'core.agent-get-history',
    'SELECT 
        history.core_agent.agent_id,
        history.core_agent.id,
        history.core_agent.is_active,
        history.core_agent.created_by,
        history.core_agent.last_updated,
        history.core_agent.last_updated_by,
        history.core_agent.version,
        history.core_agent.agent_id,
        history.core_agent.hostname,
        history.core_agent.ip_address,
        history.core_agent.port,
        history.core_agent.username,
        history.core_agent.url,
        history.core_agent.user_domain,
        history.core_agent.os_name,
        history.core_agent.os_version,
        history.core_agent.architecture,
        history.core_agent.registered_at,
        history.core_agent.agent_status_id,
        history.core_agent.is_active,
        history.core_agent.created_by,
        history.core_agent.last_updated,
        history.core_agent.last_updated_by,
        history.core_agent.version
    FROM history.core_agent
    WHERE history.core_agent.agent_id = ^(id)
    ORDER BY history.core_agent.last_updated DESC;',
    'Select all history records for Agent where agent_id matches the provided id',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);


         