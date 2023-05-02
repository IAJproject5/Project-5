-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 02, 2023 at 09:31 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

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

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
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

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('299c2185-3b9e-43ad-8318-5dc37d8737bf', 'Student', 'STUDENT', NULL),
('a1d2b10f-e7de-11ed-9723-d050995a1991', 'Administrator', 'ADMINISTRATOR', NULL),
('b10d5ae7-e7de-11ed-9723-d050995a1991', 'Faculty', 'FACULTY', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
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

DROP TABLE IF EXISTS `aspnetuserlogins`;
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

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('012c3b14-429f-4c35-9808-70746c7aa23e', '299c2185-3b9e-43ad-8318-5dc37d8737bf'),
('2a2c4615-f722-4ca4-a9f9-c2735880e51d', '299c2185-3b9e-43ad-8318-5dc37d8737bf'),
('308bb8c1-d0b4-4544-992f-8d2c4500ee9c', 'b10d5ae7-e7de-11ed-9723-d050995a1991'),
('5aefe678-f049-463b-9de8-1c1d2fe0ceb5', 'b10d5ae7-e7de-11ed-9723-d050995a1991'),
('6eb0b6ca-7c72-43b5-bb84-ceaa7200fd4f', 'a1d2b10f-e7de-11ed-9723-d050995a1991'),
('7703870f-6c74-4b83-8f3c-a0a7df64429d', '299c2185-3b9e-43ad-8318-5dc37d8737bf'),
('afe2f275-43ed-40a1-b2ee-322b7ea34c9b', '299c2185-3b9e-43ad-8318-5dc37d8737bf'),
('afe2f275-43ed-40a1-b2ee-322b7ea34c9b', 'a1d2b10f-e7de-11ed-9723-d050995a1991'),
('afe2f275-43ed-40a1-b2ee-322b7ea34c9b', 'b10d5ae7-e7de-11ed-9723-d050995a1991'),
('fc8671da-2e5f-453a-812a-bfc08c4fb7f9', '299c2185-3b9e-43ad-8318-5dc37d8737bf');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
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
('308bb8c1-d0b4-4544-992f-8d2c4500ee9c', 'eknoerr@cedarville.edu', 'EKNOERR@CEDARVILLE.EDU', 'eknoerr@cedarville.edu', 'EKNOERR@CEDARVILLE.EDU', 1, 'AQAAAAIAAYagAAAAEBTv1smFpBId/bzxUrqYXNFMuQ9LPNNP1pd6PLeakSL0ZrFI6rYgXgZjWP+WCp/ENg==', 'CJYYWDI23CH5XANUS3J4E64FXHJITYZN', '55c1023d-20ea-4025-adbe-90b24529ce13', NULL, 0, 0, NULL, 1, 0),
('5aefe678-f049-463b-9de8-1c1d2fe0ceb5', 'profdude@cedarville.edu', 'PROFDUDE@CEDARVILLE.EDU', 'profdude@cedarville.edu', 'PROFDUDE@CEDARVILLE.EDU', 1, 'AQAAAAIAAYagAAAAEMJ/ZZUVpee+Xl6+LG0Rlh89K9nuhPjCMlTBMkfFDoJcgOOuTJwq+0x4Qh1R+nC18g==', 'KJYTFTOAIERIBLPLIAL3XR54UXX6RNCL', '424e9bad-3ca9-4ab6-b8f0-75a6011fbedf', NULL, 0, 0, NULL, 1, 0),
('6eb0b6ca-7c72-43b5-bb84-ceaa7200fd4f', 'admin@cedarville.edu', 'ADMIN@CEDARVILLE.EDU', 'admin@cedarville.edu', 'ADMIN@CEDARVILLE.EDU', 1, 'AQAAAAIAAYagAAAAEBhoHfgoWtWqY0bxL7jFGkRcyUL98tk+AdAJ+//62JQmTygDRm0DF/e+i63D6Uul6g==', 'XWU7PC3GF3LAX5SGC6P2APNEXKGRAAND', '80204b79-d504-40a2-b77e-33c6cdd9afab', NULL, 0, 0, NULL, 1, 0),
('7703870f-6c74-4b83-8f3c-a0a7df64429d', 'Bob@Builder.com', 'BOB@BUILDER.COM', 'Bob@Builder.com', 'BOB@BUILDER.COM', 1, 'AQAAAAIAAYagAAAAENT7J2YbX/uJUKccQrQ3TOVCaPy0vvftAzBt6fw6lZZaKFAgt4TiBAhAkJqMayuFXA==', 'RON7YFCEYVKDJCQMC27I5HNPF2ZW6UHQ', '30e5bfc0-468e-4415-b3ab-c53efe21cf9c', NULL, 0, 0, NULL, 1, 0),
('afe2f275-43ed-40a1-b2ee-322b7ea34c9b', 'jacksonisenhower@cedarville.edu', 'JACKSONISENHOWER@CEDARVILLE.EDU', 'jacksonisenhower@cedarville.edu', 'JACKSONISENHOWER@CEDARVILLE.EDU', 1, 'AQAAAAIAAYagAAAAEOwoVF8URDwgZiDleVNerSPZokKYGjZ3LeDoxheDTFaIUBRelA4J3Xz/9ZfnzO8FLw==', 'VWIE7YB2UDS6UVTC3YCXRZA753PK2X4Q', '90fb6bb4-488f-4614-a54c-76f4379b9707', NULL, 0, 0, NULL, 1, 0),
('fc8671da-2e5f-453a-812a-bfc08c4fb7f9', 'test3@gmail.com', 'TEST3@GMAIL.COM', 'test3@gmail.com', 'TEST3@GMAIL.COM', 1, 'AQAAAAIAAYagAAAAEN8SOp7y3nAI8Oy6wTOUDtYbfveH59ivrhplSOlcr8DbX4ZIBs7KOuC8poJjBqTSqQ==', 'BXOD7E5VNGVUZMKLZX577GRLDX33N636', '78e54d3b-fa67-49f7-ada3-da2da47b5898', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `iaj_advisor_advisee`
--

DROP TABLE IF EXISTS `iaj_advisor_advisee`;
CREATE TABLE `iaj_advisor_advisee` (
  `advisor_id` varchar(255) NOT NULL,
  `advisee_id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_advisor_advisee`
--

INSERT INTO `iaj_advisor_advisee` (`advisor_id`, `advisee_id`) VALUES
('308bb8c1-d0b4-4544-992f-8d2c4500ee9c', 'afe2f275-43ed-40a1-b2ee-322b7ea34c9b'),
('308bb8c1-d0b4-4544-992f-8d2c4500ee9c', 'fc8671da-2e5f-453a-812a-bfc08c4fb7f9'),
('5aefe678-f049-463b-9de8-1c1d2fe0ceb5', '012c3b14-429f-4c35-9808-70746c7aa23e'),
('5aefe678-f049-463b-9de8-1c1d2fe0ceb5', '2a2c4615-f722-4ca4-a9f9-c2735880e51d'),
('5aefe678-f049-463b-9de8-1c1d2fe0ceb5', '7703870f-6c74-4b83-8f3c-a0a7df64429d'),
('5aefe678-f049-463b-9de8-1c1d2fe0ceb5', 'afe2f275-43ed-40a1-b2ee-322b7ea34c9b'),
('5aefe678-f049-463b-9de8-1c1d2fe0ceb5', 'fc8671da-2e5f-453a-812a-bfc08c4fb7f9'),
('afe2f275-43ed-40a1-b2ee-322b7ea34c9b', 'fc8671da-2e5f-453a-812a-bfc08c4fb7f9');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_catalog`
--

DROP TABLE IF EXISTS `iaj_catalog`;
CREATE TABLE `iaj_catalog` (
  `year` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `iaj_course`
--

DROP TABLE IF EXISTS `iaj_course`;
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
('BTGE-102', 'Bible 2', 'The sequel', 6, NULL),
('BTGE-103', 'Bible 3', 'The New New Testament', 5, NULL),
('CS-1000', 'Programming Computers', 'The fundamentals', 3, 'CS-555'),
('CS-101', 'Basics of Programming', 'Learn how to C++, Java, Python, all just a little bit, but not too much.', 3, NULL),
('CS-1052', 'Video Games', 'To the good stuff', 3, 'CS-402'),
('CS-1200', 'Programming Servers', 'Cooler stuff', 3, 'CS-1000'),
('CS-2092', 'Good Video Games', 'Advanced Gaming', 3, 'CS-1052'),
('CS-300', 'Board Games', 'Walk before you can run', 3, NULL),
('CS-3000', 'Programming The Internet', 'The Future', 3, 'CS-1200'),
('CS-308', 'Intermediate Programming', 'More of everything.', 3, 'CS-101'),
('CS-402', 'Atari Games', 'Historical introduction', 3, 'CS-300'),
('CS-403', '65c816 Assembly for the Super Nintendo', 'How to program games for the Super Nintendo in assembly', 3, 'CS-402'),
('CS-404', 'Programming PlayStation in C', 'We can finally program things in C without huge performance penalties!', 4, 'CS-403'),
('CS-555', 'Advanced Programming', 'Now with pointers!', 6, 'CS-308'),
('MATH-101', 'Calculus I', 'Derivatives and Integrals.', 3, NULL),
('MATH-201', 'Calculus II', 'Series and other fun things.', 3, 'MATH-201'),
('MATH-301', 'Calculus III', 'Stuff that applies to physics III.', 3, 'MATH-301'),
('CTGP-103', 'Advanced Mechanics in Mario Kart Wii', 'New custom maps!', 2, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `iaj_plan`
--

DROP TABLE IF EXISTS `iaj_plan`;
CREATE TABLE `iaj_plan` (
  `plan_id` int(11) NOT NULL,
  `user_id` varchar(255) DEFAULT NULL,
  `plan_name` varchar(20) DEFAULT NULL,
  `catalog` decimal(4,0) DEFAULT NULL,
  `default_plan` varchar(20) DEFAULT NULL CHECK (`default_plan` in ('true','false'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_plan`
--

INSERT INTO `iaj_plan` (`plan_id`, `user_id`, `plan_name`, `catalog`, `default_plan`) VALUES
(1, '7703870f-6c74-4b83-8f3c-a0a7df64429d', 'Hammer Strategy', '2023', 'false'),
(2, '2a2c4615-f722-4ca4-a9f9-c2735880e51d', 'Building', '2023', 'false'),
(3, '012c3b14-429f-4c35-9808-70746c7aa23e', 'Puffing', '2023', 'false'),
(4, 'fc8671da-2e5f-453a-812a-bfc08c4fb7f9', 'Plan', '2023', 'false'),
(54321, 'afe2f275-43ed-40a1-b2ee-322b7ea34c9b', 'My Plan', '2023', 'true'),
(54555, 'fc8671da-2e5f-453a-812a-bfc08c4fb7f9', 'Bible Plan', '2023', 'false'),
(54613, 'f3fd33b3-7704-4f01-841f-005150467265', 'temp', '2023', 'false');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_plan_courses`
--

DROP TABLE IF EXISTS `iaj_plan_courses`;
CREATE TABLE `iaj_plan_courses` (
  `plan_id` int(11) DEFAULT NULL,
  `course_id` varchar(20) DEFAULT NULL,
  `year` int(11) DEFAULT NULL,
  `term` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_plan_courses`
--

INSERT INTO `iaj_plan_courses` (`plan_id`, `course_id`, `year`, `term`) VALUES
(54555, 'BIO-101', 2025, 'Spring'),
(54555, 'BTGE-101', 2023, 'Fall'),
(54555, 'BTGE-102', 2024, 'Summer'),
(54555, 'BTGE-103', 2024, 'Spring'),
(54555, 'CS-101', 2023, 'Fall'),
(54555, 'CS-308', 2024, 'Spring'),
(54555, 'CS-555', 2024, 'Fall'),
(54321, 'BIO-101', 2023, 'Fall'),
(54321, 'BIO-3011', 2024, 'Spring'),
(54321, 'BIO-9523', 2025, 'Summer'),
(54321, 'BTGE-101', 2024, 'Spring'),
(54321, 'BTGE-102', 2024, 'Summer'),
(54321, 'BTGE-103', 2025, 'Summer'),
(54321, 'CS-1000', 2024, 'Spring'),
(54321, 'CS-101', 2023, 'Fall'),
(54321, 'CS-1200', 2024, 'Fall'),
(54321, 'CS-3000', 2025, 'Spring'),
(54321, 'CS-403', 2024, 'Fall'),
(54321, 'CS-404', 2025, 'Spring'),
(54321, 'CS-555', 2024, 'Fall'),
(54321, 'CTGP-103', 2025, 'Spring'),
(3, '', 2023, 'Fall'),
(3, '', 2024, 'Fall'),
(3, 'BIO-101', 2023, 'Fall'),
(3, 'BIO-3011', 2024, 'Summer'),
(3, 'BIO-9523', 2024, 'Fall'),
(3, 'BTGE-101', 2023, 'Fall'),
(3, 'BTGE-102', 2024, 'Spring'),
(3, 'BTGE-103', 2024, 'Summer'),
(3, 'CTGP-103', 2025, 'Spring'),
(1, '', 2023, 'Fall'),
(1, '', 2024, 'Fall'),
(1, 'BIO-101', 2024, 'Spring'),
(1, 'BIO-3011', 2024, 'Fall'),
(1, 'BIO-9523', 2025, 'Spring'),
(1, 'BTGE-101', 2023, 'Fall'),
(1, 'BTGE-103', 2024, 'Fall'),
(2, 'BTGE-101', 2023, 'Fall'),
(2, 'BTGE-102', 2024, 'Summer'),
(2, 'BTGE-103', 2025, 'Spring'),
(2, 'CS-101', 2024, 'Fall'),
(2, 'CS-1052', 2025, 'Fall'),
(2, 'CS-308', 2025, 'Spring'),
(2, 'CTGP-103', 2024, 'Spring'),
(4, 'BIO-101', 2024, 'Fall'),
(4, 'BTGE-101', 2023, 'Fall'),
(4, 'BTGE-102', 2024, 'Spring'),
(4, 'BTGE-103', 2024, 'Summer'),
(4, 'CS-101', 2024, 'Spring');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_plan_subjects`
--

DROP TABLE IF EXISTS `iaj_plan_subjects`;
CREATE TABLE `iaj_plan_subjects` (
  `plan_id` int(11) DEFAULT NULL,
  `subject` varchar(50) DEFAULT NULL,
  `type` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `iaj_plan_subjects`
--

INSERT INTO `iaj_plan_subjects` (`plan_id`, `subject`, `type`) VALUES
(1, 'Civil Engineering', 'Major'),
(1, 'Bible', 'Minor'),
(2, 'Mechanical Engineering', 'Major'),
(2, 'Bible', 'Minor'),
(3, 'Biology', 'Major'),
(3, 'Bible', 'Minor'),
(4, 'Testing', 'Major'),
(4, 'Bible', 'Minor'),
(54321, 'Computer Science', 'Major'),
(54321, 'Bible', 'Minor'),
(54321, 'Math', 'Minor'),
(54555, 'Bible', 'Major'),
(54613, 'Math', 'Minor'),
(54613, 'Bible', 'Minor');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_requirements`
--

DROP TABLE IF EXISTS `iaj_requirements`;
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
('2023', 'Biology', 'Gen-Ed', 'Core', 'BIO-101'),
('2023', 'Bible', 'Major', 'Electives', 'BTGE-102'),
('2023', 'Bible', 'Major', 'Cognates', 'BTGE-103'),
('2023', 'Computer Science', 'Major', 'Core', 'CS-1000'),
('2023', 'Computer Science', 'Major', 'Core', 'CS-1200'),
('2023', 'Computer Science', 'Major', 'Core', 'CS-3000'),
('2023', 'Mechanical Engineering', 'Major', 'Core', 'CTGP-103'),
('2023', 'Computer Science', 'Major', 'Track', 'CS-300'),
('2023', 'Computer Science', 'Major', 'Track', 'CS-402'),
('2023', 'Computer Science', 'Major', 'Track', 'CS-403'),
('2023', 'Computer Science', 'Major', 'Track', 'CS-404'),
('2023', 'Computer Science', 'Major', 'Track', 'CS-1052'),
('2023', 'Math', 'Minor', 'Track', 'MATH-101'),
('2023', 'Math', 'Minor', 'Track', 'MATH-201'),
('2023', 'Math', 'Minor', 'Track', 'MATH-301'),
('2023', 'Computer Science', 'Major', 'Track', 'CS-2092');

-- --------------------------------------------------------

--
-- Table structure for table `iaj_subjects`
--

DROP TABLE IF EXISTS `iaj_subjects`;
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
('Civil Engineering', 'Major'),
('Computer Science', 'Major'),
('Math', 'Major'),
('Math', 'Minor'),
('Mechanical Engineering', 'Major'),
('Testing', 'Major');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
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
-- Indexes for table `iaj_advisor_advisee`
--
ALTER TABLE `iaj_advisor_advisee`
  ADD PRIMARY KEY (`advisor_id`,`advisee_id`),
  ADD KEY `advisee_id` (`advisee_id`);

--
-- Indexes for table `iaj_catalog`
--
ALTER TABLE `iaj_catalog`
  ADD PRIMARY KEY (`year`);

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

--
-- Constraints for table `iaj_advisor_advisee`
--
ALTER TABLE `iaj_advisor_advisee`
  ADD CONSTRAINT `iaj_advisor_advisee_ibfk_1` FOREIGN KEY (`advisor_id`) REFERENCES `aspnetusers` (`Id`),
  ADD CONSTRAINT `iaj_advisor_advisee_ibfk_2` FOREIGN KEY (`advisee_id`) REFERENCES `aspnetusers` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
