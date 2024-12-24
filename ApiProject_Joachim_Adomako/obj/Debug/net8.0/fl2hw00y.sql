CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Matches` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Team 1` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `Team 2` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `Date` datetime(6) NOT NULL,
    `Location` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Outcome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Image` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Matches` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `players` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name Player` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `Age Player` int NOT NULL,
    `Team Id` int NOT NULL,
    `Picture Player` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_players` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Teams` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name Team` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `Sport Team` longtext CHARACTER SET utf8mb4 NOT NULL,
    `City Team` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Name Coach` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Image Team` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Teams` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241223160034_Initial', '8.0.10');

COMMIT;

