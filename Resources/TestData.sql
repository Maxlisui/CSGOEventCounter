USE 'csgo'

INSERT INTO `csgo`.`map` (`ID`, `Name`) VALUES ('1', 'Nuke');
INSERT INTO `csgo`.`map` (`ID`, `Name`) VALUES ('2', 'Inferno');
INSERT INTO `csgo`.`map` (`ID`, `Name`) VALUES ('3', 'Mirage');
INSERT INTO `csgo`.`map` (`ID`, `Name`) VALUES ('4', 'Overpass');
INSERT INTO `csgo`.`map` (`ID`, `Name`) VALUES ('5', 'Train');
INSERT INTO `csgo`.`map` (`ID`, `Name`) VALUES ('6', 'Cobblestone');
INSERT INTO `csgo`.`map` (`ID`, `Name`) VALUES ('7', 'Cache');

INSERT INTO `csgo`.`team` (`ID`, `Name`, `Logo`, `Country`) VALUES ('1', 'Fnatic', 'http://fontmeme.com/images/fnatic-logo-font.png', 'Sweden');
INSERT INTO `csgo`.`team` (`ID`, `Name`, `Logo`, `Country`) VALUES ('2', 'Virtus Pro', 'https://upload.wikimedia.org/wikipedia/en/archive/e/eb/20170209000917!Virtus_pro_logo.png', 'Poland');
INSERT INTO `csgo`.`team` (`ID`, `Name`, `Logo`, `Country`) VALUES ('3', 'SK Gaming', 'https://rocket-league.com/content/media/proteams/sk.png', 'Brazil');
INSERT INTO `csgo`.`team` (`ID`, `Name`, `Logo`, `Country`) VALUES ('4', 'Ninjas in Pyjamas', 'https://hydra-media.cursecdn.com/lol.gamepedia.com/a/ae/NiP_Logo.png?version=06a76b736f3379d1c402ace7306b67b4', 'Sweden');
INSERT INTO `csgo`.`team` (`ID`, `Name`, `Logo`, `Country`) VALUES ('5', 'Astralis', 'https://upload.wikimedia.org/wikipedia/en/thumb/7/7d/Astralis_logo.svg/843px-Astralis_logo.svg.png', 'Denmark');

INSERT INTO `csgo`.`organizer` (`ID`, `Name`, `Logo`) VALUES ('1', 'ESL', 'http://emblemsbf.com/img/43680.jpg');
INSERT INTO `csgo`.`organizer` (`ID`, `Name`, `Logo`) VALUES ('2', 'ELeague', 'https://upload.wikimedia.org/wikipedia/en/c/c7/ELeague_logo.jpg');
INSERT INTO `csgo`.`organizer` (`ID`, `Name`, `Logo`) VALUES ('3', 'Dreamahck', 'https://upload.wikimedia.org/wikipedia/en/e/e1/DreamHack_logo.png');

INSERT INTO `csgo`.`event` (`ID`, `Name`, `Date`, `Venue`, `Organizer`) VALUES ('1', 'Eleague Major', '2017-01-11'>, 'Fox Theatre, Atlanta', '2');
INSERT INTO `csgo`.`event` (`ID`, `Name`, `Date`, `Venue`, `Organizer`) VALUES ('2', 'Dreamhack Las Vegas', '2017-02-16'>, 'MGM Grand, Las Vegas', '3');
INSERT INTO `csgo`.`event` (`ID`, `Name`, `Date`, `Venue`, `Organizer`) VALUES ('3', 'ESL One Cologne', '2016-07-06'>, 'Lanxess Arena, Cologne', '1');

INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('1', '1');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('2', '1');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('3', '1');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('4', '1');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('5', '1');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('1', '2');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('2', '2');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('3', '2');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('4', '2');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('5', '2');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('1', '3');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('2', '3');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('3', '3');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('4', '3');
INSERT INTO `csgo`.`team_on_event` (`TeamID`, `EventID`) VALUES ('5', '3');

INSERT INTO `csgo`.`match` (`ID`, `Map`, `Team1`, `Team2`, `Team1_Score`, `Team2_Score`, `Team1_Attacked_A`, `Team1_Attacked_B`, `Team1_Attacked_A_Success`, `Team1_Attacked_B_Success`, `Team2_Attacked_A`, `Team2_Attacked_B`, `Team2_Attacked_A_Success`, `Team2_Attacked_B_Success`, `Team1_Retake_A_Success`, `Team1_Retake_B_Success`, `Team2_Retake_A_Success`, `Team2_Retake_B_Success`) VALUES ('1', '1', '1', '2', '16', '14', '12', '6', '3', '2', '6', '3', '5', '4', '12', '6', '4', '5');
INSERT INTO `csgo`.`match` (`ID`, `Map`, `Team1`, `Team2`, `Team1_Score`, `Team2_Score`, `Team1_Attacked_A`, `Team1_Attacked_B`, `Team1_Attacked_A_Success`, `Team1_Attacked_B_Success`, `Team2_Attacked_A`, `Team2_Attacked_B`, `Team2_Attacked_A_Success`, `Team2_Attacked_B_Success`, `Team1_Retake_A_Success`, `Team1_Retake_B_Success`, `Team2_Retake_A_Success`, `Team2_Retake_B_Success`) VALUES ('2', '2', '2', '3', '4', '16', '2', '1', '3', '1', '5', '6', '7', '8', '9', '9', '7', '3');
INSERT INTO `csgo`.`match` (`ID`, `Map`, `Team1`, `Team2`, `Team1_Score`, `Team2_Score`, `Team1_Attacked_A`, `Team1_Attacked_B`, `Team1_Attacked_A_Success`, `Team1_Attacked_B_Success`, `Team2_Attacked_A`, `Team2_Attacked_B`, `Team2_Attacked_A_Success`, `Team2_Attacked_B_Success`, `Team1_Retake_A_Success`, `Team1_Retake_B_Success`, `Team2_Retake_A_Success`, `Team2_Retake_B_Success`) VALUES ('3', '3', '5', '5', '16', '13', '4', '2', '4', '7', '13', '6', '8', '4', '8', '6', '3', '4');

INSERT INTO `csgo`.`match_on_event` (`EventID`, `MatchID`) VALUES ('1', '1');
INSERT INTO `csgo`.`match_on_event` (`EventID`, `MatchID`) VALUES ('2', '2');
INSERT INTO `csgo`.`match_on_event` (`EventID`, `MatchID`) VALUES ('3', '3');