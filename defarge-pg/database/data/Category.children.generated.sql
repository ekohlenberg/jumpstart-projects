-- =====================================
-- Generate SELECT queries for child records
-- =====================================


-- =====================================
-- Child queries for Category (app.category)
-- =====================================

        
-- Child relationship: Parent Category (parent)
INSERT INTO core.sql (
    id, 
    name, 
    sql_text, 
    description, 
    last_updated, 
    last_updated_by,
    is_active,
    version,
    data_source_id
) VALUES (
     nextval('core.sql_identity'),
    'app.category-children-category-parent',
    'SELECT 
        app.category.id,
            category.parent_id,
            category.name,
            category.is_active,
            category.created_by,
            category.last_updated,
            category.last_updated_by,
            category.version,
            parent.parent_id AS parent_parent_id,
            parent.name AS parent_name
    FROM app.category
        LEFT JOIN app.category parent ON category.parent_id = parent.id
    WHERE app.category.parent_id = ^(id)
    ORDER BY app.category.id;',
    'Select all Parent Category records for Category with related Category information',
    NOW(),
    CURRENT_USER,
    1,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default')
);

            