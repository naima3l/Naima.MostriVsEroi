--CREATE TABLE Utente(
--Id int NOT NULL ,
--Nickname VARCHAR(50) NOT NULL,
--Pass VARCHAR(6) NOT NULL,
--UserDiscriminator BIT NOT NULL,
--PRIMARY KEY(Id)
--);

--CREATE TABLE Category(
--IdCategory INT NOT NULL,
--Nome VARCHAR(50) NOT NULL,
--Discriminator INT NOT NULL,
--PRIMARY KEY (IdCategory)
--);

--CREATE TABLE Weapon(
--IdWeapon INT NOT NULL,
--Nome VARCHAR(50) NOT NULL,
--IdCategory INT NOT NULL,
--DamagePoints INT NOT NULL,
--PRIMARY KEY(IdWeapon),
--CONSTRAINT FK_Weapon FOREIGN KEY (IdCategory) REFERENCES Category(IdCategory)
--);

--CREATE TABLE Hero(
--Id INT NOT NULL,
--Nome VARCHAR(50) NOT NULL,
--Livello INT NOT NULL,
--LifePoints INT NOT NULL,
--IdCategory INT NOT NULL,
--IdWeapon INT NOT NULL,
--AccumulatedPoints INT NOT NULL,
--IdPlayer INT NOT NULL,
--PRIMARY KEY(Id),
--CONSTRAINT Fk_HeroCategory FOREIGN KEY (IdCategory) REFERENCES Category(IdCategory),
--CONSTRAINT Fk_HeroWeapon FOREIGN KEY (IdWeapon) REFERENCES Weapon(IdWeapon)

--);

--CREATE TABLE Monster(
--Id INT NOT NULL,
--Nome VARCHAR(50) NOT NULL,
--Livello INT NOT NULL,
--LifePoints INT NOT NULL,
--IdCategory INT NOT NULL,
--IdWeapon INT NOT NULL,
--PRIMARY KEY(Id),
--CONSTRAINT Fk_MonsterCategory FOREIGN KEY (IdCategory) REFERENCES Category(IdCategory),
--CONSTRAINT Fk_MonsterWeapon FOREIGN KEY (IdWeapon) REFERENCES Weapon(IdWeapon)

--);

