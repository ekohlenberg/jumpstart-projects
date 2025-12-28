-- Insert default data source record
insert into core.data_source (id, name) values ((SELECT nextval('core.data_source_identity')), 'default');

-- Insert server node type values
insert into core.server_node_type (id, name) values (1, 'Agent');
insert into core.server_node_type (id, name) values (2, 'Scheduler');
insert into core.server_node_type (id, name) values (3, 'ApiServer');

-- Insert server node status values
insert into core.server_node_status (id, name) values (1, 'Initializing');
insert into core.server_node_status (id, name) values (2, 'Online');
insert into core.server_node_status (id, name) values (3, 'Busy');
insert into core.server_node_status (id, name) values (4, 'Offline');



-- Insert on_failure action values
insert into core.on_failure (id, action) values (1, 'Stop');
insert into core.on_failure (id, action) values (2, 'Continue');

insert into core.exec_status (id, name) values (1, 'Dispatched');
insert into core.exec_status (id, name) values (2, 'Executing');
insert into core.exec_status (id, name) values (3, 'Completed');
insert into core.exec_status (id, name) values (4, 'Failed');
insert into core.exec_status (id, name) values (5, 'Cancelled');	
insert into core.exec_status (id, name) values (6, 'Timeout');
insert into core.exec_status (id, name) values (7, 'Interrupted');
insert into core.exec_status (id, name) values (8, 'Suspended');

-- Insert script type values
insert into core.script_type (id, name) values (1, 'CSharp');
insert into core.script_type (id, name) values (2, 'PowerShell');
insert into core.script_type (id, name) values (3, 'Python');

-- Insert AgentLogic method operations
-- Process Management Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'start', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'stop', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'kill', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'restart', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'pause', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'resume', 1, current_timestamp, current_user, current_user, 1);

-- Status & Reporting Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'status', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'heartbeat', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'report', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'log', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'metrics', 1, current_timestamp, current_user, current_user, 1);

-- Resource Management Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'register', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'unregister', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'capabilities', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'allocate', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'release', 1, current_timestamp, current_user, current_user, 1);

-- Job Execution Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'execute', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'validate', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'prepare', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'cleanup', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'retry', 1, current_timestamp, current_user, current_user, 1);

-- Communication Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'ping', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'acknowledge', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'notify', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'request', 1, current_timestamp, current_user, current_user, 1);

-- System Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'shutdown', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'reload', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'update', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'diagnose', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'health', 1, current_timestamp, current_user, current_user, 1);

-- Security Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'authenticate', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'authorize', 1, current_timestamp, current_user, current_user, 1);

-- Standard Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'select', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'get', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'getAgentInfo', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'insert', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'update', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Agent', 'delete', 1, current_timestamp, current_user, current_user, 1);

-- Scheduler Operations
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Scheduler', 'execute', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Scheduler', 'validate', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Scheduler', 'configure', 1, current_timestamp, current_user, current_user, 1);
insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ((SELECT nextval('sec.operation_identity')), 'Scheduler', 'health', 1, current_timestamp, current_user, current_user, 1);


		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Category', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Category', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Category', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Category', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Category', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Category', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Category', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Category', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Uom', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Uom', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Uom', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Uom', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Uom', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Uom', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Uom', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Uom', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ResourceType', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ResourceType', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ResourceType', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ResourceType', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ResourceType', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ResourceType', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ResourceType', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ResourceType', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Org', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Org', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Org', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Org', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Org', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Org', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Org', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Org', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Principal', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Principal', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Principal', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Principal', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Principal', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Principal', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Principal', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Principal', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Operation', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Operation', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Operation', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Operation', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Operation', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Operation', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Operation', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Operation', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRole', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRole', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRole', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRole', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRole', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRole', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRole', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRole', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Schedule', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Schedule', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Schedule', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Schedule', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Schedule', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Schedule', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Schedule', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Schedule', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Workflow', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Workflow', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Workflow', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Workflow', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Workflow', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Workflow', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Workflow', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Workflow', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'NavMenu', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'NavMenu', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'NavMenu', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'NavMenu', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'NavMenu', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'NavMenu', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'NavMenu', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'NavMenu', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'DataSource', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'DataSource', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'DataSource', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'DataSource', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'DataSource', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'DataSource', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'DataSource', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'DataSource', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AgentStatus', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AgentStatus', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AgentStatus', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AgentStatus', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AgentStatus', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AgentStatus', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AgentStatus', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AgentStatus', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OnFailure', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OnFailure', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OnFailure', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OnFailure', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OnFailure', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OnFailure', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OnFailure', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OnFailure', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ExecStatus', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ExecStatus', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ExecStatus', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ExecStatus', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ExecStatus', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ExecStatus', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ExecStatus', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ExecStatus', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeStatus', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeStatus', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeStatus', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeStatus', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeStatus', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeStatus', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeStatus', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeStatus', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScriptType', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScriptType', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScriptType', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScriptType', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScriptType', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScriptType', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScriptType', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScriptType', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeType', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeType', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeType', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeType', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeType', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeType', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeType', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNodeType', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Metric', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Metric', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Metric', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Metric', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Metric', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Metric', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Metric', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Metric', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Resource', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Resource', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Resource', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Resource', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Resource', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Resource', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Resource', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Resource', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalOrg', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalOrg', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalOrg', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalOrg', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalOrg', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalOrg', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalOrg', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalOrg', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalPassword', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalPassword', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalPassword', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalPassword', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalPassword', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalPassword', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalPassword', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'PrincipalPassword', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMap', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMap', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMap', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMap', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMap', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMap', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMap', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMap', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMember', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMember', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMember', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMember', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMember', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMember', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMember', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'OpRoleMember', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScheduleWorkflow', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScheduleWorkflow', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScheduleWorkflow', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScheduleWorkflow', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScheduleWorkflow', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScheduleWorkflow', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScheduleWorkflow', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ScheduleWorkflow', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Sql', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Sql', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Sql', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Sql', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Sql', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Sql', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Sql', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Sql', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Script', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Script', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Script', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Script', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Script', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Script', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Script', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Script', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNode', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNode', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNode', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNode', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNode', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNode', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNode', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'ServerNode', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricEvent', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricEvent', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricEvent', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricEvent', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricEvent', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricEvent', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricEvent', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricEvent', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AlertRule', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AlertRule', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AlertRule', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AlertRule', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AlertRule', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AlertRule', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AlertRule', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'AlertRule', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricResourceMap', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricResourceMap', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricResourceMap', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricResourceMap', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricResourceMap', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricResourceMap', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricResourceMap', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'MetricResourceMap', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'EventService', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'EventService', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'EventService', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'EventService', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'EventService', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'EventService', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'EventService', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'EventService', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Process', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Process', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Process', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Process', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Process', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Process', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Process', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Process', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Alert', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Alert', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Alert', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Alert', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Alert', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Alert', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Alert', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Alert', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Execution', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Execution', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Execution', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Execution', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Execution', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Execution', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Execution', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'Execution', 'children', 1, current_timestamp, current_user, current_user,1);
		
		
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'WorkflowProcess', 'select', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'WorkflowProcess', 'get', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'WorkflowProcess', 'insert', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'WorkflowProcess', 'put', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'WorkflowProcess', 'update', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'WorkflowProcess', 'delete', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'WorkflowProcess', 'history', 1, current_timestamp, current_user, current_user,1);
		insert into sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) values ( (SELECT nextval('sec.operation_identity')),'WorkflowProcess', 'children', 1, current_timestamp, current_user, current_user,1);
		
		