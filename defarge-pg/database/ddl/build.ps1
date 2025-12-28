# PowerShell script to build the PostgreSQL database
# Reads server information from .namespace.json or .namespace file in user's home directory
# 
# Prerequisites:
# 1. PostgreSQL client tools (psql) must be installed and in PATH
# 2. If execution policy blocks scripts: Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

# Check if psql is available
if (-not (Get-Command psql -ErrorAction SilentlyContinue)) {
    Write-Error "psql command not found. Please ensure PostgreSQL client tools are installed and in your PATH."
    Write-Error "Download from: https://www.postgresql.org/download/windows/"
    exit 1
}

# Get the user's home directory
$jsonFile = Join-Path $env:USERPROFILE ".defarge.json"
$legacyFile = Join-Path $env:USERPROFILE ".defarge"

# Initialize variables with defaults
$dbType = "postgresql"
$server = "localhost"
$port = "5432"
$database = "defarge"
$username = "postgres"
$password = ""

# Try to read JSON format first
if (Test-Path $jsonFile) {
    Write-Host "Reading configuration from: $jsonFile"
    $jsonContent = Get-Content $jsonFile -Raw | ConvertFrom-Json
    
    # Get the default datasource
    if ($jsonContent.datasources.default) {
        $defaultDs = $jsonContent.datasources.default
        
        if ($defaultDs.dbtype) { $dbType = $defaultDs.dbtype }
        if ($defaultDs.hostname) { $server = $defaultDs.hostname }
        if ($defaultDs.port) { $port = $defaultDs.port }
        if ($defaultDs.database) { $database = $defaultDs.database }
        if ($defaultDs.username) { $username = $defaultDs.username }
        if ($defaultDs.password) { $password = $defaultDs.password }
    }
}
# Fall back to legacy format
elseif (Test-Path $legacyFile) {
    Write-Host "Reading configuration from legacy file: $legacyFile"
    $namespaceContent = Get-Content $legacyFile -Raw
    $namespaceParts = $namespaceContent.Trim().Split(':')
    
    if ($namespaceParts.Count -lt 4) {
        Write-Error "Invalid namespace file format. Expected: dbtype:server:port:database[:username:password]"
        Write-Error "Found: $namespaceContent"
        exit 1
    }
    
    $dbType = $namespaceParts[0]
    $server = $namespaceParts[1]
    $port = $namespaceParts[2]
    $database = $namespaceParts[3]
    
    if ($namespaceParts.Count -ge 5) {
        $username = $namespaceParts[4]
    }
    if ($namespaceParts.Count -ge 6) {
        $password = $namespaceParts[5]
    }
}
else {
    Write-Error "Configuration file not found. Looking for:"
    Write-Error "  - $jsonFile"
    Write-Error "  - $legacyFile"
    Write-Error "Please create a .defarge.json file in your home directory"
    exit 1
}

# Validate that this is for PostgreSQL
if ($dbType -ne "postgresql" -and $dbType -ne "pgsql") {
    Write-Error "This script is for PostgreSQL databases. Namespace file specifies: $dbType"
    exit 1
}

Write-Host "Connecting to PostgreSQL: $server`:$port"
Write-Host "Database: $database"
Write-Host "Username: $username"

# Set PGPASSWORD environment variable if password is provided
if ($password) {
    $env:PGPASSWORD = $password
    Write-Host "Using PostgreSQL authentication with username: $username"
}
else {
    Write-Host "Using PostgreSQL default authentication"
}

# Execute the database creation script
Write-Host "Executing database creation script..."
$dbCreateScript = ".\defarge.database.create.generated.sql"
if (-not (Test-Path $dbCreateScript)) {
    Write-Error "Database creation script not found: $dbCreateScript"
    exit 1
}

psql --host=$server --port=$port --dbname=postgres --username=$username --file="$dbCreateScript"

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute database creation script: $dbCreateScript"
    Write-Error "Check your PostgreSQL connection settings and ensure the server is running."
    exit $LASTEXITCODE
}

# Execute all other SQL files

Write-Host "Executing: audit.schema.create.generated.sql"
$sqlFile = ".\audit.schema.create.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: app.schema.create.generated.sql"
$sqlFile = ".\app.schema.create.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: core.schema.create.generated.sql"
$sqlFile = ".\core.schema.create.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: sec.schema.create.generated.sql"
$sqlFile = ".\sec.schema.create.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Category.table.generated.sql"
$sqlFile = ".\Category.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Category.audit.generated.sql"
$sqlFile = ".\Category.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Category.sequence.generated.sql"
$sqlFile = ".\Category.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Category.rwkindex.generated.sql"
$sqlFile = ".\Category.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Uom.table.generated.sql"
$sqlFile = ".\Uom.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Uom.audit.generated.sql"
$sqlFile = ".\Uom.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Uom.sequence.generated.sql"
$sqlFile = ".\Uom.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Uom.rwkindex.generated.sql"
$sqlFile = ".\Uom.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ResourceType.table.generated.sql"
$sqlFile = ".\ResourceType.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ResourceType.audit.generated.sql"
$sqlFile = ".\ResourceType.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ResourceType.sequence.generated.sql"
$sqlFile = ".\ResourceType.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ResourceType.rwkindex.generated.sql"
$sqlFile = ".\ResourceType.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Org.table.generated.sql"
$sqlFile = ".\Org.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Org.audit.generated.sql"
$sqlFile = ".\Org.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Org.sequence.generated.sql"
$sqlFile = ".\Org.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Org.rwkindex.generated.sql"
$sqlFile = ".\Org.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Principal.table.generated.sql"
$sqlFile = ".\Principal.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Principal.audit.generated.sql"
$sqlFile = ".\Principal.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Principal.sequence.generated.sql"
$sqlFile = ".\Principal.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Principal.rwkindex.generated.sql"
$sqlFile = ".\Principal.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Operation.table.generated.sql"
$sqlFile = ".\Operation.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Operation.audit.generated.sql"
$sqlFile = ".\Operation.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Operation.sequence.generated.sql"
$sqlFile = ".\Operation.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Operation.rwkindex.generated.sql"
$sqlFile = ".\Operation.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRole.table.generated.sql"
$sqlFile = ".\OpRole.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRole.audit.generated.sql"
$sqlFile = ".\OpRole.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRole.sequence.generated.sql"
$sqlFile = ".\OpRole.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRole.rwkindex.generated.sql"
$sqlFile = ".\OpRole.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Schedule.table.generated.sql"
$sqlFile = ".\Schedule.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Schedule.audit.generated.sql"
$sqlFile = ".\Schedule.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Schedule.sequence.generated.sql"
$sqlFile = ".\Schedule.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Schedule.rwkindex.generated.sql"
$sqlFile = ".\Schedule.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Workflow.table.generated.sql"
$sqlFile = ".\Workflow.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Workflow.audit.generated.sql"
$sqlFile = ".\Workflow.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Workflow.sequence.generated.sql"
$sqlFile = ".\Workflow.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Workflow.rwkindex.generated.sql"
$sqlFile = ".\Workflow.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: NavMenu.table.generated.sql"
$sqlFile = ".\NavMenu.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: NavMenu.audit.generated.sql"
$sqlFile = ".\NavMenu.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: NavMenu.sequence.generated.sql"
$sqlFile = ".\NavMenu.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: NavMenu.rwkindex.generated.sql"
$sqlFile = ".\NavMenu.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: DataSource.table.generated.sql"
$sqlFile = ".\DataSource.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: DataSource.audit.generated.sql"
$sqlFile = ".\DataSource.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: DataSource.sequence.generated.sql"
$sqlFile = ".\DataSource.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: DataSource.rwkindex.generated.sql"
$sqlFile = ".\DataSource.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: AgentStatus.table.generated.sql"
$sqlFile = ".\AgentStatus.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: AgentStatus.audit.generated.sql"
$sqlFile = ".\AgentStatus.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: AgentStatus.sequence.generated.sql"
$sqlFile = ".\AgentStatus.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: AgentStatus.rwkindex.generated.sql"
$sqlFile = ".\AgentStatus.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OnFailure.table.generated.sql"
$sqlFile = ".\OnFailure.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OnFailure.audit.generated.sql"
$sqlFile = ".\OnFailure.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OnFailure.sequence.generated.sql"
$sqlFile = ".\OnFailure.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OnFailure.rwkindex.generated.sql"
$sqlFile = ".\OnFailure.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ExecStatus.table.generated.sql"
$sqlFile = ".\ExecStatus.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ExecStatus.audit.generated.sql"
$sqlFile = ".\ExecStatus.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ExecStatus.sequence.generated.sql"
$sqlFile = ".\ExecStatus.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ExecStatus.rwkindex.generated.sql"
$sqlFile = ".\ExecStatus.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNodeStatus.table.generated.sql"
$sqlFile = ".\ServerNodeStatus.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNodeStatus.audit.generated.sql"
$sqlFile = ".\ServerNodeStatus.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNodeStatus.sequence.generated.sql"
$sqlFile = ".\ServerNodeStatus.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNodeStatus.rwkindex.generated.sql"
$sqlFile = ".\ServerNodeStatus.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ScriptType.table.generated.sql"
$sqlFile = ".\ScriptType.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ScriptType.audit.generated.sql"
$sqlFile = ".\ScriptType.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ScriptType.sequence.generated.sql"
$sqlFile = ".\ScriptType.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ScriptType.rwkindex.generated.sql"
$sqlFile = ".\ScriptType.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNodeType.table.generated.sql"
$sqlFile = ".\ServerNodeType.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNodeType.audit.generated.sql"
$sqlFile = ".\ServerNodeType.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNodeType.sequence.generated.sql"
$sqlFile = ".\ServerNodeType.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNodeType.rwkindex.generated.sql"
$sqlFile = ".\ServerNodeType.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Metric.table.generated.sql"
$sqlFile = ".\Metric.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Metric.audit.generated.sql"
$sqlFile = ".\Metric.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Metric.sequence.generated.sql"
$sqlFile = ".\Metric.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Metric.rwkindex.generated.sql"
$sqlFile = ".\Metric.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Resource.table.generated.sql"
$sqlFile = ".\Resource.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Resource.audit.generated.sql"
$sqlFile = ".\Resource.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Resource.sequence.generated.sql"
$sqlFile = ".\Resource.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Resource.rwkindex.generated.sql"
$sqlFile = ".\Resource.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: PrincipalOrg.table.generated.sql"
$sqlFile = ".\PrincipalOrg.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: PrincipalOrg.audit.generated.sql"
$sqlFile = ".\PrincipalOrg.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: PrincipalOrg.sequence.generated.sql"
$sqlFile = ".\PrincipalOrg.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: PrincipalOrg.rwkindex.generated.sql"
$sqlFile = ".\PrincipalOrg.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: PrincipalPassword.table.generated.sql"
$sqlFile = ".\PrincipalPassword.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: PrincipalPassword.audit.generated.sql"
$sqlFile = ".\PrincipalPassword.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: PrincipalPassword.sequence.generated.sql"
$sqlFile = ".\PrincipalPassword.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: PrincipalPassword.rwkindex.generated.sql"
$sqlFile = ".\PrincipalPassword.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRoleMap.table.generated.sql"
$sqlFile = ".\OpRoleMap.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRoleMap.audit.generated.sql"
$sqlFile = ".\OpRoleMap.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRoleMap.sequence.generated.sql"
$sqlFile = ".\OpRoleMap.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRoleMap.rwkindex.generated.sql"
$sqlFile = ".\OpRoleMap.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRoleMember.table.generated.sql"
$sqlFile = ".\OpRoleMember.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRoleMember.audit.generated.sql"
$sqlFile = ".\OpRoleMember.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRoleMember.sequence.generated.sql"
$sqlFile = ".\OpRoleMember.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: OpRoleMember.rwkindex.generated.sql"
$sqlFile = ".\OpRoleMember.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ScheduleWorkflow.table.generated.sql"
$sqlFile = ".\ScheduleWorkflow.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ScheduleWorkflow.audit.generated.sql"
$sqlFile = ".\ScheduleWorkflow.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ScheduleWorkflow.sequence.generated.sql"
$sqlFile = ".\ScheduleWorkflow.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ScheduleWorkflow.rwkindex.generated.sql"
$sqlFile = ".\ScheduleWorkflow.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Sql.table.generated.sql"
$sqlFile = ".\Sql.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Sql.audit.generated.sql"
$sqlFile = ".\Sql.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Sql.sequence.generated.sql"
$sqlFile = ".\Sql.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Sql.rwkindex.generated.sql"
$sqlFile = ".\Sql.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Script.table.generated.sql"
$sqlFile = ".\Script.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Script.audit.generated.sql"
$sqlFile = ".\Script.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Script.sequence.generated.sql"
$sqlFile = ".\Script.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Script.rwkindex.generated.sql"
$sqlFile = ".\Script.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNode.table.generated.sql"
$sqlFile = ".\ServerNode.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNode.audit.generated.sql"
$sqlFile = ".\ServerNode.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNode.sequence.generated.sql"
$sqlFile = ".\ServerNode.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: ServerNode.rwkindex.generated.sql"
$sqlFile = ".\ServerNode.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: MetricEvent.table.generated.sql"
$sqlFile = ".\MetricEvent.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: MetricEvent.audit.generated.sql"
$sqlFile = ".\MetricEvent.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: MetricEvent.sequence.generated.sql"
$sqlFile = ".\MetricEvent.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: MetricEvent.rwkindex.generated.sql"
$sqlFile = ".\MetricEvent.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: AlertRule.table.generated.sql"
$sqlFile = ".\AlertRule.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: AlertRule.audit.generated.sql"
$sqlFile = ".\AlertRule.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: AlertRule.sequence.generated.sql"
$sqlFile = ".\AlertRule.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: AlertRule.rwkindex.generated.sql"
$sqlFile = ".\AlertRule.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: MetricResourceMap.table.generated.sql"
$sqlFile = ".\MetricResourceMap.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: MetricResourceMap.audit.generated.sql"
$sqlFile = ".\MetricResourceMap.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: MetricResourceMap.sequence.generated.sql"
$sqlFile = ".\MetricResourceMap.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: MetricResourceMap.rwkindex.generated.sql"
$sqlFile = ".\MetricResourceMap.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: EventService.table.generated.sql"
$sqlFile = ".\EventService.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: EventService.audit.generated.sql"
$sqlFile = ".\EventService.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: EventService.sequence.generated.sql"
$sqlFile = ".\EventService.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: EventService.rwkindex.generated.sql"
$sqlFile = ".\EventService.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Process.table.generated.sql"
$sqlFile = ".\Process.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Process.audit.generated.sql"
$sqlFile = ".\Process.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Process.sequence.generated.sql"
$sqlFile = ".\Process.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Process.rwkindex.generated.sql"
$sqlFile = ".\Process.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Alert.table.generated.sql"
$sqlFile = ".\Alert.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Alert.audit.generated.sql"
$sqlFile = ".\Alert.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Alert.sequence.generated.sql"
$sqlFile = ".\Alert.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Alert.rwkindex.generated.sql"
$sqlFile = ".\Alert.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Execution.table.generated.sql"
$sqlFile = ".\Execution.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Execution.audit.generated.sql"
$sqlFile = ".\Execution.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Execution.sequence.generated.sql"
$sqlFile = ".\Execution.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: Execution.rwkindex.generated.sql"
$sqlFile = ".\Execution.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: WorkflowProcess.table.generated.sql"
$sqlFile = ".\WorkflowProcess.table.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: WorkflowProcess.audit.generated.sql"
$sqlFile = ".\WorkflowProcess.audit.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: WorkflowProcess.sequence.generated.sql"
$sqlFile = ".\WorkflowProcess.sequence.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Executing: WorkflowProcess.rwkindex.generated.sql"
$sqlFile = ".\WorkflowProcess.rwkindex.generated.sql"
if (-not (Test-Path $sqlFile)) {
    Write-Warning "SQL file not found, skipping: $sqlFile"
    continue
}

psql --host=$server --port=$port --dbname=$database --username=$username --file="$sqlFile"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to execute: $sqlFile"
    Write-Error "Check the SQL file for syntax errors and ensure the database connection is working."
    exit $LASTEXITCODE
}
        
Write-Host "Database build completed successfully!"