CREATE SCHEMA history; 
GRANT USAGE ON SCHEMA history TO defarge; 
GRANT SELECT, UPDATE, INSERT, DELETE ON ALL TABLES IN SCHEMA history TO defarge;

CREATE TABLE history.log (
    id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    timestamp TIMESTAMPTZ NOT NULL,
    level TEXT NOT NULL,
    principalname  TEXT NOT NULL,
    program TEXT NOT NULL,
    filepath TEXT NOT NULL,
    linenumber INTEGER NOT NULL,
    membername TEXT NOT NULL,
    message TEXT NOT NULL
  
);