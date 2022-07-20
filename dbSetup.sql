CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS artists (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'time created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'last update',
  name VARCHAR(255) NOT NULL,
  dateOfBirth INT NOT NULL,
  isAlive TINYINT DEFAULT 0 NOT NULL
  /* Tiny int is a boolean! */
) default charset utf8 COMMENT '';


/* Create */
/* ORDER MUST MATCH */
INSERT INTO *nameoftable*
(*columnname*, *columnname*, *columnname*)
VALUES
(value, value, value)



/* Get All*/
SELECT * FROM table;
/*   * =  all columns , could represent column name to get specific peices of info*/

/* Getbyid */
SELECT * FROM table Where id = 3 limit 1;
/* this is a more general query statement */

/* Search */
Select * from table where col Like "%partialString%"
 /* searches for similar */

/* Edit */

update table
  set 
  property = updatedValue,
  property2 = updatedValue
  where id = 4

/* Delete */

delete from table where id = someId limit 1



/* DANGER ZONE */

/* Nuke */
DELETE FROM ARTISTS

/* with no where statements, all values will be deleted.ADD */

/* Nuke 2, table is gone and so is the data */

DROP TABLE tableName;


/* NUKE */
/* DROP DATABASE; */
/* deletes entire db */

