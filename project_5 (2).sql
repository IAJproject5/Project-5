-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 11, 2023 at 03:17 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.0.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project 5`
--
CREATE DATABASE IF NOT EXISTS `project 5` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `project 5`;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('012c3b14-429f-4c35-9808-70746c7aa23e', 'Puff@Magic.com', 'PUFF@MAGIC.COM', 'Puff@Magic.com', 'PUFF@MAGIC.COM', 1, 'AQAAAAIAAYagAAAAEOifv2PQ5Q8y9vk/QeEHrHyns4FjCrS82ZogL9nXqbr8QfXXOEJlp/ZUjf/d1yxMBQ==', '67DXZ43WWPGTXM4AWNHNE72DNBHKMREA', '75430a20-16d5-466f-9624-d0d8e244ad71', NULL, 0, 0, NULL, 1, 0),
('2a2c4615-f722-4ca4-a9f9-c2735880e51d', 'Steve@Craft.com', 'STEVE@CRAFT.COM', 'Steve@Craft.com', 'STEVE@CRAFT.COM', 1, 'AQAAAAIAAYagAAAAEMmrCm4TslP3gDOuV1/SrKnshPIQBlME02oo2R3abOEYXAxUm86BYoggALXc4+Jqhw==', 'PZBDJXTIJ645QCO2UW5QENJSSZOOXNTQ', 'a9990907-0334-4ebe-a0da-f2fe1e71e953', NULL, 0, 0, NULL, 1, 0),
('7703870f-6c74-4b83-8f3c-a0a7df64429d', 'Bob@Builder.com', 'BOB@BUILDER.COM', 'Bob@Builder.com', 'BOB@BUILDER.COM', 1, 'AQAAAAIAAYagAAAAENT7J2YbX/uJUKccQrQ3TOVCaPy0vvftAzBt6fw6lZZaKFAgt4TiBAhAkJqMayuFXA==', 'RON7YFCEYVKDJCQMC27I5HNPF2ZW6UHQ', '30e5bfc0-468e-4415-b3ab-c53efe21cf9c', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `iaj_catalog`
--

CREATE TABLE `iaj_catalog` (
  `year` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `iaj_course`
--

CREATE TABLE `iaj_course` (
  `course_id` varchar(20) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  `credits` int(11) DEFAULT NULL,
  `prereq_id` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_course`
--

INSERT INTO `iaj_course` (`course_id`, `name`, `description`, `credits`, `prereq_id`) VALUES
('BIO-101', 'How to Exist', 'You ever wonder how to be an organism? Here we share our secrets!', 3, NULL),
('BIO-3011', 'Advanced Existing', 'Take life to the next level.', 5, 'BIO-101'),
('BIO-9523', 'Ascension', 'Tastes like grape', 9, 'BIO-3011'),
('BTGE-101', 'Bible Class', 'The Bible. What is it? Come to class and find out.', 3, NULL),
('BTGE-102', 'Bible 2', 'The sequel', 6, 'NULL'),
('BTGE-103', 'Bible 3', 'The New New Testament', 5, 'NULL'),
('CS-101', 'Basics of Programming', 'Learn how to C++, Java, Python, all just a little bit, but not too much.', 3, NULL),
('CS-308', 'Intermediate Programming', 'More of everything.', 3, 'CS-101'),
('CS-555', 'Advanced Programming', 'Now with pointers!', 6, 'CS-308');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_plan`
--

CREATE TABLE `iaj_plan` (
  `plan_id` varchar(20) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `plan_name` varchar(20) DEFAULT NULL,
  `catalog` decimal(4,0) DEFAULT NULL,
  `default_plan` varchar(20) DEFAULT NULL CHECK (`default_plan` in ('true','false'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_plan`
--

INSERT INTO `iaj_plan` (`plan_id`, `user_id`, `plan_name`, `catalog`, `default_plan`) VALUES
('54321', 12, 'My Plan', '2023', 'true'),
('54555', 12, 'My 2nd Plan', '2023', 'false');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_plan_courses`
--

CREATE TABLE `iaj_plan_courses` (
  `plan_id` varchar(20) DEFAULT NULL,
  `course_id` varchar(20) DEFAULT NULL,
  `year` int(11) DEFAULT NULL,
  `term` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_plan_courses`
--

INSERT INTO `iaj_plan_courses` (`plan_id`, `course_id`, `year`, `term`) VALUES
('54321', 'BIO-101', 2023, 'fall'),
('54321', 'BTGE-101', 2024, 'spring'),
('54321', 'BIO-3011', 2024, 'fall'),
('54321', 'BIO-9523', 2025, 'spring'),
('54555', 'CS-101', 2023, 'fall'),
('54555', 'CS-308', 2024, 'spring'),
('54555', 'CS-555', 2024, 'fall'),
('54555', 'BIO-101', 2025, 'spring');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_plan_subjects`
--

CREATE TABLE `iaj_plan_subjects` (
  `plan_id` int(11) DEFAULT NULL,
  `subject` varchar(50) DEFAULT NULL,
  `type` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_plan_subjects`
--

INSERT INTO `iaj_plan_subjects` (`plan_id`, `subject`, `type`) VALUES
(54321, 'Computer Science', 'Major'),
(54321, 'Bible', 'Minor'),
(54321, 'Math', 'Minor'),
(54555, 'Bible', 'Major');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_requirements`
--

CREATE TABLE `iaj_requirements` (
  `year` decimal(4,0) DEFAULT NULL,
  `subject` varchar(50) DEFAULT NULL,
  `type` varchar(10) DEFAULT NULL,
  `category` varchar(20) DEFAULT NULL,
  `course_id` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_requirements`
--

INSERT INTO `iaj_requirements` (`year`, `subject`, `type`, `category`, `course_id`) VALUES
('2023', 'Computer Science', 'Major', 'Core', 'CS-101'),
('2023', 'Computer Science', 'Major', 'Track', 'CS-308'),
('2023', 'Computer Science', 'Major', 'Electives', 'CS-555'),
('2023', 'Biology', 'Gen-Ed', 'Electives', 'BIO-3011'),
('2023', 'Biology', 'Gen-Ed', 'Cognates', 'BIO-9523'),
('2023', 'Bible', 'Minor', 'GenEds', 'BTGE-101'),
('2023', 'Bible', 'Major', 'Core', 'BTGE-101'),
('2023', 'Bible', 'Major', 'Electives', 'BTGE-102'),
('2023', 'Bible', 'Major', 'Cognates', 'BTGE-103');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_subjects`
--

CREATE TABLE `iaj_subjects` (
  `subject` varchar(50) NOT NULL,
  `type` varchar(10) NOT NULL CHECK (`type` in ('Major','Minor','Gen-Ed'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_subjects`
--

INSERT INTO `iaj_subjects` (`subject`, `type`) VALUES
('Bible', 'Major'),
('Bible', 'Minor'),
('Computer Science', 'Major'),
('Math', 'Minor');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20230410150506_init', '7.0.4');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `iaj_catalog`
--
ALTER TABLE `iaj_catalog`
  ADD PRIMARY KEY (`year`);

--
-- Indexes for table `iaj_course`
--
ALTER TABLE `iaj_course`
  ADD PRIMARY KEY (`course_id`);

--
-- Indexes for table `iaj_plan`
--
ALTER TABLE `iaj_plan`
  ADD PRIMARY KEY (`plan_id`);

--
-- Indexes for table `iaj_subjects`
--
ALTER TABLE `iaj_subjects`
  ADD PRIMARY KEY (`subject`,`type`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
