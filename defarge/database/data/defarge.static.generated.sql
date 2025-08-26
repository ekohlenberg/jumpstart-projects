DECLARE @operation_id BIGINT;

		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Category', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Category', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Category', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Category', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Category', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Uom', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Uom', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Uom', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Uom', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Uom', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ResourceType', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ResourceType', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ResourceType', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ResourceType', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ResourceType', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Org', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Org', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Org', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Org', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Org', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Principal', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Principal', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Principal', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Principal', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Principal', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Script', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Script', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Script', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Script', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Script', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Operation', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Operation', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Operation', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Operation', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Operation', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRole', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRole', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRole', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRole', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRole', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Schedule', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Schedule', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Schedule', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Schedule', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Schedule', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Workflow', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Workflow', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Workflow', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Workflow', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Workflow', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Server', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Server', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Server', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Server', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Server', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Query', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Query', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Query', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Query', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Query', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Metric', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Metric', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Metric', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Metric', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Metric', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Resource', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Resource', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Resource', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Resource', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Resource', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalOrg', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalOrg', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalOrg', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalOrg', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalOrg', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalPassword', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalPassword', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalPassword', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalPassword', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'PrincipalPassword', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'EventService', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'EventService', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'EventService', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'EventService', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'EventService', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Process', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Process', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Process', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Process', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Process', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMap', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMap', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMap', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMap', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMap', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMember', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMember', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMember', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMember', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'OpRoleMember', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ScheduleWorkflow', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ScheduleWorkflow', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ScheduleWorkflow', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ScheduleWorkflow', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'ScheduleWorkflow', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricEvent', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricEvent', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricEvent', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricEvent', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricEvent', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'AlertRule', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'AlertRule', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'AlertRule', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'AlertRule', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'AlertRule', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricResourceMap', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricResourceMap', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricResourceMap', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricResourceMap', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'MetricResourceMap', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Execution', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Execution', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Execution', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Execution', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Execution', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'WorkflowProcess', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'WorkflowProcess', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'WorkflowProcess', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'WorkflowProcess', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'WorkflowProcess', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		

		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Alert', 'select', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Alert', 'get', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Alert', 'insert', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Alert', 'update', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		
		SELECT @operation_id = NEXT VALUE FOR sec.operation_identity;
		INSERT INTO sec.operation (id, objectname, methodname, is_active, last_updated, created_by, last_updated_by, version) VALUES (@operation_id,'Alert', 'delete', 1, GETDATE(), SYSTEM_USER, SYSTEM_USER,1);
		