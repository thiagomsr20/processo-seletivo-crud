CREATE TABLE FAMILIA (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FAMILIA NVARCHAR(50) NOT NULL
);

INSERT INTO FAMILIA (FAMILIA) VALUES ('Chapa');
INSERT INTO FAMILIA (FAMILIA) VALUES ('Tubo');
INSERT INTO FAMILIA (FAMILIA) VALUES ('Plástico');