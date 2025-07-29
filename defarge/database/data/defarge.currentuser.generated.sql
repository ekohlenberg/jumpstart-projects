-- =====================================
-- 1) Create Account for Current OS User
-- e.g.
-- \set afile `echo "$outputdir/a.csv"`
-- COPY (SELECT * FROM a) TO :'afile';
-- =====================================
\set os_user `echo $LOGNAME`

INSERT INTO app."user"(
    id,
    first_name,
    last_name,
    username,
    email,
    created_date,
    last_login_date,
    is_active,
    created_by,
    last_updated,
    last_updated_by,
    version
)
VALUES (
    nextval('app.user_identity'),          -- Use next value from user_identity sequence
    'Current',
    'User',
    :'os_user',                               -- Unique username
    :'os_user'  || '@mydomain.com',
    now(),
    null,
    1,
    'system',
    now(),
    'system',
    1
);

WITH os_user_user_id AS (
    SELECT id
    FROM app."user"
    WHERE username = :'os_user'
)
INSERT INTO sec.user_password(
    id, user_id, password_hash, expiry, needs_reset, is_active, created_by, last_updated, last_updated_by, version)
SELECT  nextval('sec.user_password_identity'),
    os_user_user_id.id,
     (floor(random() * 100000 + 1))::int::varchar,  
     current_timestamp,
     1,
     1,
     current_user,
     current_timestamp,
     current_user,
     1
FROM
    os_user_user_id;



-- =====================================
-- 2) Map os_user User to os_user Role
--    Using sub-selects on sec."user" (by username)
--    and sec.op_role (by name)
-- =====================================
WITH os_user_user_id AS (
    SELECT id
    FROM app."user"
    WHERE username = :'os_user'
),
os_user_role_id AS (
    SELECT id
    FROM sec.op_role
    WHERE name = 'Administrator'
)
INSERT INTO sec.op_role_member(
    id,
    user_id,
    op_role_id,
    is_active,
    created_by,
    last_updated,
    last_updated_by,
    version
)
SELECT
    nextval('sec.op_role_member_identity'),  -- PK for op_role_member
    os_user_user_id.id,
    os_user_role_id.id,
    1,
    'system',
    now(),
    'system',
    1
FROM os_user_user_id
CROSS JOIN os_user_role_id;

-- =====================================
-- Done!
-- =====================================
