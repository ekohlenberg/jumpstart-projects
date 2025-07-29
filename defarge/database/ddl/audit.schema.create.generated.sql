USE [defarge];

CREATE SCHEMA audit; 

CREATE TABLE IF NOT EXISTS audit.log (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    timestamp DATETIME NOT NULL,
    level VARCHAR(50) NOT NULL,
    username VARCHAR(50) NOT NULL,
    program TEXT NOT NULL,
    filepath TEXT NOT NULL,
    linenumber INTEGER NOT NULL,
    membername TEXT NOT NULL,
    message TEXT NOT NULL
  
);