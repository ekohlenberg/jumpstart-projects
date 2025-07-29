export SQLCMD="sqlcmd"
$SQLCMD config use-context sql_admin 
$SQLCMD query "$(cat  ./defarge.database.create.generated.sql)"

$SQLCMD config use-context defarge


$SQLCMD query "$(cat  ./audit.schema.create.generated.sql)"
