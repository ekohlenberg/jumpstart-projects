#!/usr/bin/env python3
"""
PostgreSQL Database Build Script
Reads configuration from .defarge.json or .defarge file
"""

import json
import os
import sys
import subprocess
from pathlib import Path

def load_config():
    """Load database configuration from JSON or legacy file"""
    home_dir = Path.home()
    json_file = home_dir / ".defarge.json"
    legacy_file = home_dir / ".defarge"
    
    # Default values
    config = {
        'hostname': 'localhost',
        'port': '5432',
        'database': 'defarge',
        'username': 'postgres',
        'password': '',
        'dbtype': 'postgresql'
    }
    
    # Try JSON format first
    if json_file.exists():
        print(f"Reading configuration from: {json_file}")
        try:
            with open(json_file, 'r') as f:
                data = json.load(f)
                
            # Get the default datasource
            if 'datasources' in data and 'default' in data['datasources']:
                ds = data['datasources']['default']
                config.update({
                    'hostname': ds.get('hostname', config['hostname']),
                    'port': ds.get('port', config['port']),
                    'database': ds.get('database', config['database']),
                    'username': ds.get('username', config['username']),
                    'password': ds.get('password', config['password']),
                    'dbtype': ds.get('dbtype', config['dbtype'])
                })
        except json.JSONDecodeError as e:
            print(f"Error parsing JSON file: {e}", file=sys.stderr)
            sys.exit(1)
    
    # Fall back to legacy format
    elif legacy_file.exists():
        print(f"Reading configuration from legacy file: {legacy_file}")
        try:
            with open(legacy_file, 'r') as f:
                content = f.read().strip()
            
            parts = content.split(':')
            if len(parts) < 4:
                print(f"Invalid legacy file format. Expected: dbtype:server:port:database[:username:password]", file=sys.stderr)
                sys.exit(1)
            
            config['dbtype'] = parts[0].lower().strip()
            config['hostname'] = parts[1].strip()
            config['port'] = parts[2].strip()
            config['database'] = parts[3].strip()
            
            if len(parts) >= 5:
                config['username'] = parts[4].strip()
            if len(parts) >= 6:
                config['password'] = parts[5].strip()
                
        except Exception as e:
            print(f"Error reading legacy file: {e}", file=sys.stderr)
            sys.exit(1)
    else:
        print(f"Configuration file not found. Looking for:", file=sys.stderr)
        print(f"  - {json_file}", file=sys.stderr)
        print(f"  - {legacy_file}", file=sys.stderr)
        sys.exit(1)
    
    return config

def run_psql(config, database, sql_file):
    """Execute a SQL file using psql"""
    cmd = [
        'psql',
        f"--host={config['hostname']}",
        f"--port={config['port']}",
        f"--dbname={database}",
        f"--username={config['username']}",
        f"--file={sql_file}"
    ]
    
    env = os.environ.copy()
    if config['password']:
        env['PGPASSWORD'] = config['password']
    
    print(f"Executing: {sql_file}")
    result = subprocess.run(cmd, env=env)
    
    if result.returncode != 0:
        print(f"Failed to execute: {sql_file}", file=sys.stderr)
        sys.exit(result.returncode)

def main():
    """Main build script"""
    # Load configuration
    config = load_config()
    
    print(f"Connecting to PostgreSQL: {config['hostname']}:{config['port']}")
    print(f"Database: {config['database']}")
    print(f"Username: {config['username']}")
    
    # Execute database creation script
    print("\nExecuting database creation script...")
    run_psql(config, 'postgres', './defarge.database.create.generated.sql')
    
    # Execute all other SQL files
    sql_files = [
        './audit.schema.create.generated.sql',
        './app.schema.create.generated.sql',
        './core.schema.create.generated.sql',
        './sec.schema.create.generated.sql',
        './Category.table.generated.sql',
        './Category.audit.generated.sql',
        './Category.sequence.generated.sql',
        './Category.rwkindex.generated.sql',
        './Uom.table.generated.sql',
        './Uom.audit.generated.sql',
        './Uom.sequence.generated.sql',
        './Uom.rwkindex.generated.sql',
        './ResourceType.table.generated.sql',
        './ResourceType.audit.generated.sql',
        './ResourceType.sequence.generated.sql',
        './ResourceType.rwkindex.generated.sql',
        './Org.table.generated.sql',
        './Org.audit.generated.sql',
        './Org.sequence.generated.sql',
        './Org.rwkindex.generated.sql',
        './Principal.table.generated.sql',
        './Principal.audit.generated.sql',
        './Principal.sequence.generated.sql',
        './Principal.rwkindex.generated.sql',
        './Operation.table.generated.sql',
        './Operation.audit.generated.sql',
        './Operation.sequence.generated.sql',
        './Operation.rwkindex.generated.sql',
        './OpRole.table.generated.sql',
        './OpRole.audit.generated.sql',
        './OpRole.sequence.generated.sql',
        './OpRole.rwkindex.generated.sql',
        './Schedule.table.generated.sql',
        './Schedule.audit.generated.sql',
        './Schedule.sequence.generated.sql',
        './Schedule.rwkindex.generated.sql',
        './Workflow.table.generated.sql',
        './Workflow.audit.generated.sql',
        './Workflow.sequence.generated.sql',
        './Workflow.rwkindex.generated.sql',
        './NavMenu.table.generated.sql',
        './NavMenu.audit.generated.sql',
        './NavMenu.sequence.generated.sql',
        './NavMenu.rwkindex.generated.sql',
        './DataSource.table.generated.sql',
        './DataSource.audit.generated.sql',
        './DataSource.sequence.generated.sql',
        './DataSource.rwkindex.generated.sql',
        './AgentStatus.table.generated.sql',
        './AgentStatus.audit.generated.sql',
        './AgentStatus.sequence.generated.sql',
        './AgentStatus.rwkindex.generated.sql',
        './OnFailure.table.generated.sql',
        './OnFailure.audit.generated.sql',
        './OnFailure.sequence.generated.sql',
        './OnFailure.rwkindex.generated.sql',
        './ExecStatus.table.generated.sql',
        './ExecStatus.audit.generated.sql',
        './ExecStatus.sequence.generated.sql',
        './ExecStatus.rwkindex.generated.sql',
        './SchedulerStatus.table.generated.sql',
        './SchedulerStatus.audit.generated.sql',
        './SchedulerStatus.sequence.generated.sql',
        './SchedulerStatus.rwkindex.generated.sql',
        './ScriptType.table.generated.sql',
        './ScriptType.audit.generated.sql',
        './ScriptType.sequence.generated.sql',
        './ScriptType.rwkindex.generated.sql',
        './Metric.table.generated.sql',
        './Metric.audit.generated.sql',
        './Metric.sequence.generated.sql',
        './Metric.rwkindex.generated.sql',
        './Resource.table.generated.sql',
        './Resource.audit.generated.sql',
        './Resource.sequence.generated.sql',
        './Resource.rwkindex.generated.sql',
        './PrincipalOrg.table.generated.sql',
        './PrincipalOrg.audit.generated.sql',
        './PrincipalOrg.sequence.generated.sql',
        './PrincipalOrg.rwkindex.generated.sql',
        './PrincipalPassword.table.generated.sql',
        './PrincipalPassword.audit.generated.sql',
        './PrincipalPassword.sequence.generated.sql',
        './PrincipalPassword.rwkindex.generated.sql',
        './OpRoleMap.table.generated.sql',
        './OpRoleMap.audit.generated.sql',
        './OpRoleMap.sequence.generated.sql',
        './OpRoleMap.rwkindex.generated.sql',
        './OpRoleMember.table.generated.sql',
        './OpRoleMember.audit.generated.sql',
        './OpRoleMember.sequence.generated.sql',
        './OpRoleMember.rwkindex.generated.sql',
        './ScheduleWorkflow.table.generated.sql',
        './ScheduleWorkflow.audit.generated.sql',
        './ScheduleWorkflow.sequence.generated.sql',
        './ScheduleWorkflow.rwkindex.generated.sql',
        './Sql.table.generated.sql',
        './Sql.audit.generated.sql',
        './Sql.sequence.generated.sql',
        './Sql.rwkindex.generated.sql',
        './Agent.table.generated.sql',
        './Agent.audit.generated.sql',
        './Agent.sequence.generated.sql',
        './Agent.rwkindex.generated.sql',
        './Scheduler.table.generated.sql',
        './Scheduler.audit.generated.sql',
        './Scheduler.sequence.generated.sql',
        './Scheduler.rwkindex.generated.sql',
        './Script.table.generated.sql',
        './Script.audit.generated.sql',
        './Script.sequence.generated.sql',
        './Script.rwkindex.generated.sql',
        './MetricEvent.table.generated.sql',
        './MetricEvent.audit.generated.sql',
        './MetricEvent.sequence.generated.sql',
        './MetricEvent.rwkindex.generated.sql',
        './AlertRule.table.generated.sql',
        './AlertRule.audit.generated.sql',
        './AlertRule.sequence.generated.sql',
        './AlertRule.rwkindex.generated.sql',
        './MetricResourceMap.table.generated.sql',
        './MetricResourceMap.audit.generated.sql',
        './MetricResourceMap.sequence.generated.sql',
        './MetricResourceMap.rwkindex.generated.sql',
        './EventService.table.generated.sql',
        './EventService.audit.generated.sql',
        './EventService.sequence.generated.sql',
        './EventService.rwkindex.generated.sql',
        './Process.table.generated.sql',
        './Process.audit.generated.sql',
        './Process.sequence.generated.sql',
        './Process.rwkindex.generated.sql',
        './Alert.table.generated.sql',
        './Alert.audit.generated.sql',
        './Alert.sequence.generated.sql',
        './Alert.rwkindex.generated.sql',
        './Execution.table.generated.sql',
        './Execution.audit.generated.sql',
        './Execution.sequence.generated.sql',
        './Execution.rwkindex.generated.sql',
        './WorkflowProcess.table.generated.sql',
        './WorkflowProcess.audit.generated.sql',
        './WorkflowProcess.sequence.generated.sql',
        './WorkflowProcess.rwkindex.generated.sql',
    ]
    
    for sql_file in sql_files:
        run_psql(config, config['database'], sql_file)
    
    print("\nDatabase build completed successfully!")

if __name__ == '__main__':
    main()