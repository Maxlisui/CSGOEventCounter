-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Erstellungszeit: 20. Feb 2017 um 19:19
-- Server-Version: 5.7.16-log
-- PHP-Version: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `csgo`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `event`
--

CREATE DATABASE IF NOT EXISTS csgo;

USE 'csgo';

CREATE TABLE `event` (
  `ID` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Date` date NOT NULL,
  `Venue` varchar(45) NOT NULL,
  `Organizer` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `event`
--

INSERT INTO `event` (`ID`, `Name`, `Date`, `Venue`, `Organizer`) VALUES
(1, 'ELeague Major', '2017-01-22', 'Fox Theatre, Atlanta', 2),
(2, 'Dreamhack Las Vegas', '2017-02-16', 'MGM Grand, Las Vegas', 3),
(3, 'ESL One Cologne', '2016-07-06', 'Lanxess Arena, Cologne', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `map`
--

CREATE TABLE `map` (
  `ID` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `map`
--

INSERT INTO `map` (`ID`, `Name`) VALUES
(1, 'Nuke'),
(2, 'Inferno'),
(3, 'Mirage'),
(4, 'Overpass'),
(5, 'Train'),
(6, 'Cobblestone'),
(7, 'Cache');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `match`
--

CREATE TABLE `match` (
  `ID` int(11) NOT NULL,
  `Map` int(11) NOT NULL,
  `Team1` int(11) NOT NULL,
  `Team2` int(11) NOT NULL,
  `Team1_Score` int(11) NOT NULL,
  `Team2_Score` int(11) NOT NULL,
  `Team1_Attacked_A` int(11) NOT NULL,
  `Team1_Attacked_B` int(11) NOT NULL,
  `Team1_Attacked_A_Success` int(11) NOT NULL,
  `Team1_Attacked_B_Success` int(11) NOT NULL,
  `Team2_Attacked_A` int(11) NOT NULL,
  `Team2_Attacked_B` int(11) NOT NULL,
  `Team2_Attacked_A_Success` int(11) NOT NULL,
  `Team2_Attacked_B_Success` int(11) NOT NULL,
  `Team1_Retake_A_Success` int(11) NOT NULL,
  `Team1_Retake_B_Success` int(11) NOT NULL,
  `Team2_Retake_A_Success` int(11) NOT NULL,
  `Team2_Retake_B_Success` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `match`
--

INSERT INTO `match` (`ID`, `Map`, `Team1`, `Team2`, `Team1_Score`, `Team2_Score`, `Team1_Attacked_A`, `Team1_Attacked_B`, `Team1_Attacked_A_Success`, `Team1_Attacked_B_Success`, `Team2_Attacked_A`, `Team2_Attacked_B`, `Team2_Attacked_A_Success`, `Team2_Attacked_B_Success`, `Team1_Retake_A_Success`, `Team1_Retake_B_Success`, `Team2_Retake_A_Success`, `Team2_Retake_B_Success`) VALUES
(1, 1, 1, 2, 16, 14, 12, 6, 3, 2, 6, 3, 5, 4, 12, 6, 4, 5),
(2, 2, 2, 3, 4, 16, 2, 1, 3, 1, 5, 6, 7, 8, 9, 9, 7, 3),
(3, 3, 5, 5, 16, 13, 4, 2, 4, 7, 13, 6, 8, 4, 8, 6, 3, 4);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `match_on_event`
--

CREATE TABLE `match_on_event` (
  `EventID` int(11) NOT NULL,
  `MatchID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `match_on_event`
--

INSERT INTO `match_on_event` (`EventID`, `MatchID`) VALUES
(1, 1),
(2, 2),
(3, 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `organizer`
--

CREATE TABLE `organizer` (
  `ID` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Logo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `organizer`
--

INSERT INTO `organizer` (`ID`, `Name`, `Logo`) VALUES
(1, 'ESL', 'http://emblemsbf.com/img/43680.jpg'),
(2, 'ELeague', 'https://upload.wikimedia.org/wikipedia/en/c/c7/ELeague_logo.jpg'),
(3, 'Dreamahck', 'https://upload.wikimedia.org/wikipedia/en/e/e1/DreamHack_logo.png');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `team`
--

CREATE TABLE `team` (
  `ID` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Logo` varchar(255) NOT NULL,
  `Country` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='	';

--
-- Daten für Tabelle `team`
--

INSERT INTO `team` (`ID`, `Name`, `Logo`, `Country`) VALUES
(1, 'Fnatic', 'http://fontmeme.com/images/fnatic-logo-font.png', 'Sweden'),
(2, 'Virtus Pro', 'https://upload.wikimedia.org/wikipedia/en/archive/e/eb/20170209000917!Virtus_pro_logo.png', 'Poland'),
(3, 'SK Gaming', 'https://rocket-league.com/content/media/proteams/sk.png', 'Brazil'),
(4, 'Ninjas in Pyjamas', 'https://hydra-media.cursecdn.com/lol.gamepedia.com/a/ae/NiP_Logo.png?version=06a76b736f3379d1c402ace7306b67b4', 'Sweden'),
(5, 'Astralis', 'https://upload.wikimedia.org/wikipedia/en/thumb/7/7d/Astralis_logo.svg/843px-Astralis_logo.svg.png', 'Denmark');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `team_on_event`
--

CREATE TABLE `team_on_event` (
  `TeamID` int(11) NOT NULL,
  `EventID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `team_on_event`
--

INSERT INTO `team_on_event` (`TeamID`, `EventID`) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(1, 2),
(2, 2),
(3, 2),
(4, 2),
(5, 2),
(1, 3),
(2, 3),
(3, 3),
(4, 3),
(5, 3);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `event`
--
ALTER TABLE `event`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Event_Organizer_idx` (`Organizer`);

--
-- Indizes für die Tabelle `map`
--
ALTER TABLE `map`
  ADD PRIMARY KEY (`ID`);

--
-- Indizes für die Tabelle `match`
--
ALTER TABLE `match`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Match_Event_idx` (`Map`),
  ADD KEY `Match_Team1_idx` (`Team1`),
  ADD KEY `Match_Team2_idx` (`Team2`);

--
-- Indizes für die Tabelle `match_on_event`
--
ALTER TABLE `match_on_event`
  ADD PRIMARY KEY (`EventID`),
  ADD KEY `Match_MatchOnEvent_idx` (`MatchID`);

--
-- Indizes für die Tabelle `organizer`
--
ALTER TABLE `organizer`
  ADD PRIMARY KEY (`ID`);

--
-- Indizes für die Tabelle `team`
--
ALTER TABLE `team`
  ADD PRIMARY KEY (`ID`);

--
-- Indizes für die Tabelle `team_on_event`
--
ALTER TABLE `team_on_event`
  ADD PRIMARY KEY (`TeamID`,`EventID`),
  ADD KEY `Event_TeamPlaysOnEvent_idx` (`EventID`);

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `event`
--
ALTER TABLE `event`
  ADD CONSTRAINT `Event_Organizer` FOREIGN KEY (`Organizer`) REFERENCES `organizer` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints der Tabelle `match`
--
ALTER TABLE `match`
  ADD CONSTRAINT `Match_Event` FOREIGN KEY (`Map`) REFERENCES `map` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Match_Team1` FOREIGN KEY (`Team1`) REFERENCES `team` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Match_Team2` FOREIGN KEY (`Team2`) REFERENCES `team` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints der Tabelle `match_on_event`
--
ALTER TABLE `match_on_event`
  ADD CONSTRAINT `Event_MatchOnEbvent` FOREIGN KEY (`EventID`) REFERENCES `event` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Match_MatchOnEvent` FOREIGN KEY (`MatchID`) REFERENCES `match` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints der Tabelle `team_on_event`
--
ALTER TABLE `team_on_event`
  ADD CONSTRAINT `Event_TeamPlaysOnEvent` FOREIGN KEY (`EventID`) REFERENCES `event` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Team_TeamPlaysOnEvent` FOREIGN KEY (`TeamID`) REFERENCES `team` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
