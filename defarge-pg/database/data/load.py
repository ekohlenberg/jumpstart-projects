#!/usr/bin/env python3
"""
PostgreSQL Data Load Script
Reads configuration from .defarge.json or .defarge file
Loads data files into the database
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

def run_psql(config, sql_file):
    """Execute a SQL file using psql"""
    cmd = [
        'psql',
        f"--host={config['hostname']}",
        f"--port={config['port']}",
        f"--dbname={config['database']}",
        f"--username={config['username']}",
        f"--file={sql_file}"
    ]
    
    env = os.environ.copy()
    if config['password']:
        env['PGPASSWORD'] = config['password']
    
    print(f"Loading: {sql_file}")
    result = subprocess.run(cmd, env=env)
    
    if result.returncode != 0:
        print(f"Failed to load: {sql_file}", file=sys.stderr)
        sys.exit(result.returncode)

def main():
    """Main load script"""
    # Load configuration
    config = load_config()
    
    print(f"Connecting to PostgreSQL: {config['hostname']}:{config['port']}")
    print(f"Database: {config['database']}")
    print(f"Username: {config['username']}")
    
    # Load all data files
    data_files = [
        './defarge.static.generated.sql',
        './defarge.nav_menu.sql',
        './defarge.admin.generated.sql',
        './defarge.currentuser.generated.sql',
        './defarge.event.test.sql',
        './Category.query.generated.sql',
        './Category.children.generated.sql',
        './Uom.query.generated.sql',
        './Uom.children.generated.sql',
        './ResourceType.query.generated.sql',
        './ResourceType.children.generated.sql',
        './Org.query.generated.sql',
        './Org.children.generated.sql',
        './Principal.query.generated.sql',
        './Principal.children.generated.sql',
        './Operation.query.generated.sql',
        './Operation.children.generated.sql',
        './OpRole.query.generated.sql',
        './OpRole.children.generated.sql',
        './Schedule.query.generated.sql',
        './Schedule.children.generated.sql',
        './Workflow.query.generated.sql',
        './Workflow.children.generated.sql',
        './NavMenu.query.generated.sql',
        './NavMenu.children.generated.sql',
        './DataSource.query.generated.sql',
        './DataSource.children.generated.sql',
        './AgentStatus.query.generated.sql',
        './AgentStatus.children.generated.sql',
        './OnFailure.query.generated.sql',
        './OnFailure.children.generated.sql',
        './ExecStatus.query.generated.sql',
        './ExecStatus.children.generated.sql',
        './SchedulerStatus.query.generated.sql',
        './SchedulerStatus.children.generated.sql',
        './ScriptType.query.generated.sql',
        './ScriptType.children.generated.sql',
        './Metric.query.generated.sql',
        './Metric.children.generated.sql',
        './Resource.query.generated.sql',
        './Resource.children.generated.sql',
        './PrincipalOrg.query.generated.sql',
        './PrincipalOrg.children.generated.sql',
        './PrincipalPassword.query.generated.sql',
        './PrincipalPassword.children.generated.sql',
        './OpRoleMap.query.generated.sql',
        './OpRoleMap.children.generated.sql',
        './OpRoleMember.query.generated.sql',
        './OpRoleMember.children.generated.sql',
        './ScheduleWorkflow.query.generated.sql',
        './ScheduleWorkflow.children.generated.sql',
        './Sql.query.generated.sql',
        './Sql.children.generated.sql',
        './Agent.query.generated.sql',
        './Agent.children.generated.sql',
        './Scheduler.query.generated.sql',
        './Scheduler.children.generated.sql',
        './Script.query.generated.sql',
        './Script.children.generated.sql',
        './MetricEvent.query.generated.sql',
        './MetricEvent.children.generated.sql',
        './AlertRule.query.generated.sql',
        './AlertRule.children.generated.sql',
        './MetricResourceMap.query.generated.sql',
        './MetricResourceMap.children.generated.sql',
        './EventService.query.generated.sql',
        './EventService.children.generated.sql',
        './Process.query.generated.sql',
        './Process.children.generated.sql',
        './Alert.query.generated.sql',
        './Alert.children.generated.sql',
        './Execution.query.generated.sql',
        './Execution.children.generated.sql',
        './WorkflowProcess.query.generated.sql',
        './WorkflowProcess.children.generated.sql',
    ]
    
    if not data_files:
        print("No data files to load.")
        return
    
    print(f"\nLoading {len(data_files)} data files...")
    
    for sql_file in data_files:
        if not os.path.exists(sql_file):
            print(f"Warning: File not found, skipping: {sql_file}")
            continue
            
        run_psql(config, sql_file)
    
    print("\nData loading completed successfully!")

if __name__ == '__main__':
    main()