USE [defarge];

CREATE SEQUENCE sec.user_password_identity 
    AS BIGINT 
    START WITH 1 
    INCREMENT BY 1
    NO CYCLE
    CACHE 10;

