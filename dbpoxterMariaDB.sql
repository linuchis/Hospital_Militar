-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         11.5.2-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para dbpoxter
CREATE DATABASE IF NOT EXISTS `dbpoxter` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci */;
USE `dbpoxter`;

-- Volcando estructura para tabla dbpoxter.patients_poxter
CREATE TABLE IF NOT EXISTS `patients_poxter` (
  `id_p` bigint(20) NOT NULL,
  `name_p` varchar(100) NOT NULL,
  `lastname_p` varchar(100) NOT NULL,
  `height_p` bigint(20) NOT NULL,
  `weight_p` bigint(20) NOT NULL,
  `gender_p` varchar(100) NOT NULL,
  PRIMARY KEY (`id_p`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Volcando datos para la tabla dbpoxter.patients_poxter: ~8 rows (aproximadamente)
INSERT INTO `patients_poxter` (`id_p`, `name_p`, `lastname_p`, `height_p`, `weight_p`, `gender_p`) VALUES
	(1, 'Juan Diego', 'Reyes Martínez', 180, 75, 'Masculino'),
	(2, 'Lauren', 'Parra', 160, 68, 'Femenino'),
	(3, 'Mercedez', 'Campuzano', 165, 69, 'Femenino'),
	(4, 'Aaron', 'Gil', 158, 49, 'Masculino'),
	(11212322, 'Juan Esteban', 'Rincón Bejarano', 158, 69, 'Masculino'),
	(32545151, 'Ricardo ', 'Molina Martínez', 190, 75, 'Masculino'),
	(121456894, 'Lisa María', 'Cortéz', 162, 48, 'Femenino'),
	(1121756320, 'Stella María', 'Rosas Garzón', 172, 65, 'Famenino');

-- Volcando estructura para tabla dbpoxter.surveys_patients
CREATE TABLE IF NOT EXISTS `surveys_patients` (
  `id_survey` char(1) NOT NULL,
  `hour_survey` date NOT NULL,
  `1_survey` varchar(255) DEFAULT NULL,
  `2_survey` varchar(255) DEFAULT NULL,
  `3_survey` varchar(255) DEFAULT NULL,
  `4_survey` varchar(255) DEFAULT NULL,
  `5_survey` varchar(255) DEFAULT NULL,
  `6_survey` varchar(255) DEFAULT NULL,
  `7_survey` varchar(255) DEFAULT NULL,
  `8_survey` varchar(255) DEFAULT NULL,
  `9_survey` varchar(255) DEFAULT NULL,
  `10_survey` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_survey`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Volcando datos para la tabla dbpoxter.surveys_patients: ~1 rows (aproximadamente)
INSERT INTO `surveys_patients` (`id_survey`, `hour_survey`, `1_survey`, `2_survey`, `3_survey`, `4_survey`, `5_survey`, `6_survey`, `7_survey`, `8_survey`, `9_survey`, `10_survey`) VALUES
	('1', '2024-09-21', 'prueba de encuesta', 'prueba de encuesta', 'prueba de encuesta', 'prueba de encuesta', 'prueba de encuesta', 'prueba de encuesta', 'prueba de encuesta', 'prueba de encuesta', 'prueba de encuesta', 'prueba de encuesta');

-- Volcando estructura para tabla dbpoxter.users_poxter
CREATE TABLE IF NOT EXISTS `users_poxter` (
  `id_u` bigint(20) NOT NULL,
  `name_u` varchar(100) NOT NULL,
  `lastname_u` varchar(100) NOT NULL,
  `email_u` varchar(100) NOT NULL,
  `area_u` varchar(100) NOT NULL,
  `password_u` varchar(100) NOT NULL,
  `username_u` varchar(255) NOT NULL,
  `telephone_u` varchar(255) NOT NULL,
  PRIMARY KEY (`id_u`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Volcando datos para la tabla dbpoxter.users_poxter: ~2 rows (aproximadamente)
INSERT INTO `users_poxter` (`id_u`, `name_u`, `lastname_u`, `email_u`, `area_u`, `password_u`, `username_u`, `telephone_u`) VALUES
	(1, 'Juan Pablo', 'Castro', 'juan.castro@hospmil.com.co', 'Médico', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'jpcastro', '30000000000'),
	(2, 'Annuar', 'De la Barrera', 'annuar.delabarrera@hospmil.com.com', 'Soporte', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin', '30000000000');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
