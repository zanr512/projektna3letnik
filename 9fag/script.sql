CREATE PROCEDURE insert_user(pass VARCHAR(100), email VARCHAR(50))
BEGIN
	IF NOT EXISTS(SELECT * FROM users WHERE (user = @email))
    THEN 
		INSERT INTO users(user,password) VALUES(email,pass);
	ELSE
		SELECT -1;
	END IF;
END
