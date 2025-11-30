CREATE SEQUENCE sec.principal_password_identity AS BIGINT START WITH 1000 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE sec.principal_password_identity TO defarge;
