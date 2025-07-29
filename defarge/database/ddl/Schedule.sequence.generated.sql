USE [defarge];

CREATE SEQUENCE core.schedule_identity 
    AS BIGINT 
    START WITH 1 
    INCREMENT BY 1
    NO CYCLE
    CACHE 10;

