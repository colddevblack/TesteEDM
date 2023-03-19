CREATE TABLE tbl_persons (
 ID SMALLINT,
 FirstName VARCHAR(40) NOT NULL,
 Lastname VARCHAR(60),
 RepostsTo VARCHAR(60),
 Position VARCHAR(60),
 Age INT
 );

 INSERT INTO tbl_persons (ID, FirstName, Lastname, RepostsTo, Position, Age )
VALUES
(1, 'Daniel', 'Smith', 'Bob Boss', 'Enginner', 25),
(2, 'Mike', 'White', 'Bob Boss', 'Contractor', 22),
(3, 'Jenny', 'Richards', ' ', 'CEO', 45),
(4, 'Robert', 'Black', 'Daniel Smith', 'Sales', 22),
(5, 'Noah', 'Fritz', 'Jenny Richards', 'Assistant', 30),
(6, 'David', 'S', 'Jenny Richards', 'Director', 32),
(7, 'Ashley', 'Wells', 'David S', 'Assistant', 25),
(8, 'Ashley', 'Jonhson', ' ', 'Intern', 25);

select * from tbl_persons

SELECT AVG(Age) AS MediaIdade
FROM tbl_persons
WHERE RepostsTo = 'Bob Boss';
SELECT COUNT(ID) AS quantidadefuncionarios
FROM tbl_persons
WHERE RepostsTo = 'Bob Boss';
SELECT AVG(Age) AS MediaIdade
FROM tbl_persons
WHERE RepostsTo = 'Jenny Richards' ;
SELECT COUNT(ID) AS quantidadefuncionarios
FROM tbl_persons
WHERE RepostsTo = 'Jenny Richards'

SELECT AVG(Age) AS MediaIdade
FROM tbl_persons

select *
from tbl_persons
order by FirstName asc