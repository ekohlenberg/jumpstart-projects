CREATE SEQUENCE sec.user_password_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE sec.user_password_identity TO legr3;
