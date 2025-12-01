CREATE DATABASE labact2;
USE labact2;

CREATE TABLE user_tbl
(
	id INT PRIMARY KEY NOT NULL AUTO_INCREMENT UNIQUE,
    username VARCHAR(100) NOT NULL,
    password LONGTEXT NOT NULL,
    status ENUM('Pending', 'Authorized', 'Unauthorized') DEFAULT 'Pending',
    role ENUM('Staff', 'Admin') DEFAULT 'Staff'
);

CREATE TABLE component_inventory_tbl
(
	PartNumber VARCHAR(255) PRIMARY KEY NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Manufacturer VARCHAR(255) NOT NULL,
    Quantity INT NOT NULL,
    
    Typeofvehicle  VARCHAR(255)
);

INSERT INTO component_inventory_tbl
(PartNumber, Name, Manufacturer, Quantity, Typeofvehicle) VALUES
('JC3Z6049A','Cylinder Head', 'Yamaha', 20, 'Scrambler'),
('BC3Z6500B', 'Cylinde Block', 'Honda', 9, 'Sports');

