-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Gép: localhost:3306
-- Létrehozás ideje: 2022. Okt 20. 02:40
-- Kiszolgáló verziója: 10.3.28-MariaDB-cll-lve
-- PHP verzió: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+02:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `zbccmner_kreta`
--
USE `kreta`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `schoolclass`
--


INSERT INTO `schoolclass` (`id`, `schoolYear`, `classType`, `teacherId`) VALUES
(1, 9, 'a', 1),
(2, 9, 'b', 3),
(3, 11, 'a', 2),
(4, 11, 'b', 5);

-- --------------------------------------------------------
--
-- A tábla adatainak kiíratása `subject`
--

INSERT INTO `subject` (`id`, `name`) VALUES
(1, 'Matematika'),
(2, 'Történelem');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
