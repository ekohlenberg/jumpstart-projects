CREATE SEQUENCE app.principal_org_identity AS BIGINT START WITH 1000 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.principal_org_identity TO defarge;
