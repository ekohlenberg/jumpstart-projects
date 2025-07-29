USE [defarge];

CREATE SEQUENCE core.event_service_identity 
    AS BIGINT 
    START WITH 1 
    INCREMENT BY 1
    NO CYCLE
    CACHE 10;

