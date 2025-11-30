-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Query (core.query)
-- =====================================


INSERT INTO core.query (
    id, 
    name, 
    sql_text, 
    description, 
    last_updated, 
    last_updated_by,
    is_active,
    version
) VALUES (
     nextval('core.query_identity'),
    'core.query-select',
    'SELECT 
        core.query.id,
            query.name,
            query.sql_text,
            query.description,
            query.is_active,
            query.created_by,
            query.last_updated,
            query.last_updated_by,
            query.version
    FROM core.query
    ORDER BY core.query.id;',
    'Select all Query records with related  information',
    NOW(),
    CURRENT_USER,
    1,
    1
);

         