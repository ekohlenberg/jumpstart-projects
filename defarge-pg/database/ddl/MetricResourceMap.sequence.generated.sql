CREATE SEQUENCE app.metric_resource_map_identity AS BIGINT START WITH 1000 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.metric_resource_map_identity TO defarge;
