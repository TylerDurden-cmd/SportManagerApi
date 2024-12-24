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

START TRANSACTION;

ALTER TABLE `Matches` RENAME COLUMN `Team 2` TO `Team Id 2`;

ALTER TABLE `Matches` RENAME COLUMN `Team 1` TO `Team Id 1`;

CREATE INDEX `IX_players_Team Id` ON `players` (`Team Id`);

CREATE INDEX `IX_Matches_Team Id 1` ON `Matches` (`Team Id 1`);

CREATE INDEX `IX_Matches_Team Id 2` ON `Matches` (`Team Id 2`);

ALTER TABLE `Matches` ADD CONSTRAINT `FK_Matches_Teams_Team Id 1` FOREIGN KEY (`Team Id 1`) REFERENCES `Teams` (`Id`) ON DELETE CASCADE;

ALTER TABLE `Matches` ADD CONSTRAINT `FK_Matches_Teams_Team Id 2` FOREIGN KEY (`Team Id 2`) REFERENCES `Teams` (`Id`) ON DELETE CASCADE;

ALTER TABLE `players` ADD CONSTRAINT `FK_players_Teams_Team Id` FOREIGN KEY (`Team Id`) REFERENCES `Teams` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241224125739_secondMigration', '8.0.10');

COMMIT;

