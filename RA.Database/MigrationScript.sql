CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Artists` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(1500) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Artists` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Categories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(1000) CHARACTER SET utf8mb4 NULL,
    `ParentId` int NULL,
    `Color` varchar(7) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Categories` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Categories_Categories_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `Categories` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Clocks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Clocks` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Playlists` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AirDate` date NOT NULL,
    `DateAdded` datetime(6) NOT NULL,
    `DateModified` datetime(6) NULL,
    CONSTRAINT `PK_Playlists` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `SchedulesDefault` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `StartDate` datetime(6) NOT NULL,
    `EndDate` datetime(6) NOT NULL,
    `Name` varchar(300) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_SchedulesDefault` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TagCategories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `IsBuiltIn` tinyint(1) NOT NULL,
    CONSTRAINT `PK_TagCategories` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Templates` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Templates` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Tracks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Type` int NOT NULL,
    `Status` int NOT NULL,
    `Title` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Duration` double(11,5) NOT NULL,
    `StartCue` double(11,5) NULL,
    `NextCue` double(11,5) NULL,
    `EndCue` double(11,5) NULL,
    `ReleaseDate` datetime(6) NULL,
    `Album` varchar(200) CHARACTER SET utf8mb4 NULL,
    `Comments` longtext CHARACTER SET utf8mb4 NULL,
    `FilePath` varchar(500) CHARACTER SET utf8mb4 NOT NULL,
    `ImageName` varchar(50) CHARACTER SET utf8mb4 NULL,
    `Bpm` int NULL,
    `ISRC` varchar(55) CHARACTER SET utf8mb4 NULL,
    `DateAdded` datetime(6) NOT NULL,
    `DateModified` datetime(6) NULL,
    `DateDeleted` datetime(6) NULL,
    CONSTRAINT `PK_Tracks` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `UserGroups` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `IsBuiltIn` tinyint(1) NOT NULL,
    CONSTRAINT `PK_UserGroups` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TagValues` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `TagCategoryId` int NOT NULL,
    CONSTRAINT `PK_TagValues` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TagValues_TagCategories_TagCategoryId` FOREIGN KEY (`TagCategoryId`) REFERENCES `TagCategories` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Clocks_Templates` (
    `ClockId` int NOT NULL,
    `TemplateId` int NOT NULL,
    `StartTime` time(6) NOT NULL,
    `ClockSpan` int NOT NULL,
    CONSTRAINT `PK_Clocks_Templates` PRIMARY KEY (`ClockId`, `TemplateId`, `StartTime`),
    CONSTRAINT `FK_Clocks_Templates_Clocks_ClockId` FOREIGN KEY (`ClockId`) REFERENCES `Clocks` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Clocks_Templates_Templates_TemplateId` FOREIGN KEY (`TemplateId`) REFERENCES `Templates` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `ScheduleDefaultItems` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ScheduleId` int NOT NULL,
    `DayOfWeek` int NOT NULL,
    `TemplateId` int NOT NULL,
    CONSTRAINT `PK_ScheduleDefaultItems` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ScheduleDefaultItems_SchedulesDefault_ScheduleId` FOREIGN KEY (`ScheduleId`) REFERENCES `SchedulesDefault` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ScheduleDefaultItems_Templates_TemplateId` FOREIGN KEY (`TemplateId`) REFERENCES `Templates` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `SchedulesPlanned` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `StartDate` datetime(6) NOT NULL,
    `EndDate` datetime(6) NULL,
    `Type` int NOT NULL,
    `Frequency` int NULL,
    `TemplateId` int NOT NULL,
    `IsMonday` tinyint(1) NULL,
    `IsTuesday` tinyint(1) NULL,
    `IsWednesday` tinyint(1) NULL,
    `IsThursday` tinyint(1) NULL,
    `IsFriday` tinyint(1) NULL,
    `IsSaturday` tinyint(1) NULL,
    `IsSunday` tinyint(1) NULL,
    `Name` varchar(300) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_SchedulesPlanned` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SchedulesPlanned_Templates_TemplateId` FOREIGN KEY (`TemplateId`) REFERENCES `Templates` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Artists_Tracks` (
    `ArtistId` int NOT NULL,
    `TrackId` int NOT NULL,
    `OrderIndex` int NOT NULL,
    CONSTRAINT `PK_Artists_Tracks` PRIMARY KEY (`ArtistId`, `TrackId`),
    CONSTRAINT `FK_Artists_Tracks_Artists_ArtistId` FOREIGN KEY (`ArtistId`) REFERENCES `Artists` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Artists_Tracks_Tracks_TrackId` FOREIGN KEY (`TrackId`) REFERENCES `Tracks` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Categories_Tracks` (
    `CategoryId` int NOT NULL,
    `TrackId` int NOT NULL,
    CONSTRAINT `PK_Categories_Tracks` PRIMARY KEY (`CategoryId`, `TrackId`),
    CONSTRAINT `FK_TrackCategories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TrackCategories_TrackId` FOREIGN KEY (`TrackId`) REFERENCES `Tracks` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `ClockItems` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `OrderIndex` int NOT NULL,
    `ClockId` int NOT NULL,
    `ClockItemEventId` int NULL,
    `EventOrderIndex` int NULL,
    `ClockItemType` int NOT NULL,
    `CategoryId` int NULL,
    `MinDuration` time(6) NULL,
    `MaxDuration` time(6) NULL,
    `ArtistSeparation` int NULL,
    `TitleSeparation` int NULL,
    `TrackSeparation` int NULL,
    `MinReleaseDate` datetime(6) NULL,
    `MaxReleaseDate` datetime(6) NULL,
    `IsFiller` tinyint(1) NULL,
    `EventType` int NULL,
    `EventLabel` longtext CHARACTER SET utf8mb4 NULL,
    `EstimatedEventStart` time(6) NULL,
    `EstimatedEventDuration` time(6) NULL,
    `TrackId` int NULL,
    CONSTRAINT `PK_ClockItems` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClockItems_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`),
    CONSTRAINT `FK_ClockItems_ClockItems_ClockItemEventId` FOREIGN KEY (`ClockItemEventId`) REFERENCES `ClockItems` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ClockItems_Clocks_ClockId` FOREIGN KEY (`ClockId`) REFERENCES `Clocks` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ClockItems_Tracks_TrackId` FOREIGN KEY (`TrackId`) REFERENCES `Tracks` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `TrackHistory` (
    `DatePlayed` datetime(6) NOT NULL,
    `TrackType` int NOT NULL,
    `TrackId` int NULL,
    CONSTRAINT `PK_TrackHistory` PRIMARY KEY (`DatePlayed`),
    CONSTRAINT `FK_TrackHistory_Tracks_TrackId` FOREIGN KEY (`TrackId`) REFERENCES `Tracks` (`Id`) ON DELETE SET NULL
) CHARACTER SET=utf8mb4;

CREATE TABLE `UserGroupRules` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RuleValue` int NOT NULL,
    `UserGroupId` int NOT NULL,
    CONSTRAINT `PK_UserGroupRules` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserGroupRules_UserGroups_UserGroupId` FOREIGN KEY (`UserGroupId`) REFERENCES `UserGroups` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Username` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Password` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `FullName` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `UserGroupId` int NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Users_UserGroups_UserGroupId` FOREIGN KEY (`UserGroupId`) REFERENCES `UserGroups` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Track_Tags` (
    `TrackId` int NOT NULL,
    `TagValueId` int NOT NULL,
    CONSTRAINT `PK_Track_Tags` PRIMARY KEY (`TrackId`, `TagValueId`),
    CONSTRAINT `FK_Track_Tags_TagValues_TagValueId` FOREIGN KEY (`TagValueId`) REFERENCES `TagValues` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Track_Tags_Tracks_TrackId` FOREIGN KEY (`TrackId`) REFERENCES `Tracks` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `ClockItemsCategory_Tags` (
    `ClockItemCategoryId` int NOT NULL,
    `TagValueId` int NOT NULL,
    CONSTRAINT `PK_ClockItemsCategory_Tags` PRIMARY KEY (`ClockItemCategoryId`, `TagValueId`),
    CONSTRAINT `FK_ClockItemsCategory_Tags_ClockItems_ClockItemCategoryId` FOREIGN KEY (`ClockItemCategoryId`) REFERENCES `ClockItems` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ClockItemsCategory_Tags_TagValues_TagValueId` FOREIGN KEY (`TagValueId`) REFERENCES `TagValues` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `PlaylistItems` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ETA` datetime(6) NOT NULL,
    `Length` double(11,5) NOT NULL,
    `TrackId` int NULL,
    `EventType` int NULL,
    `Label` varchar(400) CHARACTER SET utf8mb4 NULL,
    `PlaylistId` int NOT NULL,
    `BaseClockItemId` int NULL,
    `BaseTemplateId` int NULL,
    `ParentPlaylistItemId` int NULL,
    CONSTRAINT `PK_PlaylistItems` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PlaylistItems_ClockItems_BaseClockItemId` FOREIGN KEY (`BaseClockItemId`) REFERENCES `ClockItems` (`Id`) ON DELETE SET NULL,
    CONSTRAINT `FK_PlaylistItems_PlaylistItems_ParentPlaylistItemId` FOREIGN KEY (`ParentPlaylistItemId`) REFERENCES `PlaylistItems` (`Id`) ON DELETE SET NULL,
    CONSTRAINT `FK_PlaylistItems_Playlists_PlaylistId` FOREIGN KEY (`PlaylistId`) REFERENCES `Playlists` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_PlaylistItems_Templates_BaseTemplateId` FOREIGN KEY (`BaseTemplateId`) REFERENCES `Templates` (`Id`) ON DELETE SET NULL,
    CONSTRAINT `FK_PlaylistItems_Tracks_TrackId` FOREIGN KEY (`TrackId`) REFERENCES `Tracks` (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `Categories` (`Id`, `Color`, `Description`, `Name`, `ParentId`)
VALUES (1, '#292928', NULL, 'Music', NULL),
(2, '#f91212', NULL, 'Station ID', NULL),
(3, '#0ac720', NULL, 'Commercials', NULL),
(4, '#d016f5', NULL, 'Shows', NULL),
(5, '#001dd9', NULL, 'News', NULL);

INSERT INTO `TagCategories` (`Id`, `IsBuiltIn`, `Name`)
VALUES (1, TRUE, 'Genre'),
(2, TRUE, 'Language'),
(3, TRUE, 'Mood');

INSERT INTO `UserGroups` (`Id`, `IsBuiltIn`, `Name`)
VALUES (1, TRUE, 'Administrators');

INSERT INTO `TagValues` (`Id`, `Name`, `TagCategoryId`)
VALUES (1, 'English', 2),
(2, 'French', 2),
(3, 'Romanian', 2),
(4, 'Happy', 3),
(5, 'Sad', 3),
(6, 'Energetic', 3),
(7, 'Rock', 1),
(8, 'Pop', 1),
(9, 'Dance', 1);

INSERT INTO `UserGroupRules` (`Id`, `RuleValue`, `UserGroupId`)
VALUES (1, 0, 1),
(2, 1, 1),
(3, 2, 1),
(4, 3, 1),
(5, 4, 1);

INSERT INTO `Users` (`Id`, `FullName`, `Password`, `UserGroupId`, `Username`)
VALUES (1, 'Administrator', 'admin', 1, 'admin');

CREATE INDEX `IX_Artists_Tracks_TrackId` ON `Artists_Tracks` (`TrackId`);

CREATE INDEX `IX_Categories_ParentId` ON `Categories` (`ParentId`);

CREATE INDEX `IX_Categories_Tracks_TrackId` ON `Categories_Tracks` (`TrackId`);

CREATE INDEX `IX_ClockItems_CategoryId` ON `ClockItems` (`CategoryId`);

CREATE INDEX `IX_ClockItems_ClockId` ON `ClockItems` (`ClockId`);

CREATE INDEX `IX_ClockItems_ClockItemEventId` ON `ClockItems` (`ClockItemEventId`);

CREATE INDEX `IX_ClockItems_TrackId` ON `ClockItems` (`TrackId`);

CREATE INDEX `IX_ClockItemsCategory_Tags_TagValueId` ON `ClockItemsCategory_Tags` (`TagValueId`);

CREATE INDEX `IX_Clocks_Templates_TemplateId` ON `Clocks_Templates` (`TemplateId`);

CREATE INDEX `IX_PlaylistItems_BaseClockItemId` ON `PlaylistItems` (`BaseClockItemId`);

CREATE INDEX `IX_PlaylistItems_BaseTemplateId` ON `PlaylistItems` (`BaseTemplateId`);

CREATE INDEX `IX_PlaylistItems_ParentPlaylistItemId` ON `PlaylistItems` (`ParentPlaylistItemId`);

CREATE INDEX `IX_PlaylistItems_PlaylistId` ON `PlaylistItems` (`PlaylistId`);

CREATE INDEX `IX_PlaylistItems_TrackId` ON `PlaylistItems` (`TrackId`);

CREATE UNIQUE INDEX `IX_Playlists_AirDate` ON `Playlists` (`AirDate`);

CREATE INDEX `IX_ScheduleDefaultItems_ScheduleId` ON `ScheduleDefaultItems` (`ScheduleId`);

CREATE INDEX `IX_ScheduleDefaultItems_TemplateId` ON `ScheduleDefaultItems` (`TemplateId`);

CREATE INDEX `IX_SchedulesPlanned_TemplateId` ON `SchedulesPlanned` (`TemplateId`);

CREATE INDEX `IX_TagValues_TagCategoryId` ON `TagValues` (`TagCategoryId`);

CREATE INDEX `IX_Track_Tags_TagValueId` ON `Track_Tags` (`TagValueId`);

CREATE INDEX `IX_TrackHistory_TrackId` ON `TrackHistory` (`TrackId`);

CREATE INDEX `IX_Tracks_FilePath` ON `Tracks` (`FilePath`);

CREATE INDEX `IX_UserGroupRules_UserGroupId` ON `UserGroupRules` (`UserGroupId`);

CREATE INDEX `IX_Users_UserGroupId` ON `Users` (`UserGroupId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230717165745_Initial', '7.0.5');

COMMIT;

START TRANSACTION;

CREATE VIEW CategoriesHierarchy AS 
                                  WITH RECURSIVE CategoryHierarchy AS
                                  (
                                      SELECT Id, NAME, ParentId, CAST(Name AS CHAR(500)) AS PathName, 0 AS LEVEL
                                      FROM Categories
                                      WHERE ParentId IS NULL 
                                      UNION ALL
                                      SELECT c.Id, c.NAME, c.ParentId, CONCAT(ch.PathName, ' > ', c.Name), ch.Level + 1
                                      FROM Categories c
                                      INNER JOIN CategoryHierarchy ch 
                                      ON c.ParentId = ch.Id
                                  )
                                  
                                  SELECT Id, Name, ParentId, Level, PathName
                                  FROM CategoryHierarchy ch;
                                

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230717165804_View_CategoryHierarchy', '7.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE `SchedulesPlanned` MODIFY COLUMN `StartDate` date NOT NULL;

ALTER TABLE `SchedulesPlanned` MODIFY COLUMN `EndDate` date NULL;

ALTER TABLE `SchedulesDefault` MODIFY COLUMN `StartDate` date NOT NULL;

ALTER TABLE `SchedulesDefault` MODIFY COLUMN `EndDate` date NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230718085219_Updated_Date', '7.0.5');

COMMIT;

