-- MySQL dump 10.13  Distrib 8.0.33, for Linux (x86_64)
--
-- Host: localhost    Database: Biblioteca
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Emprestimos`
--

DROP TABLE IF EXISTS `Emprestimos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Emprestimos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DataEmprestimo` datetime NOT NULL,
  `DataDevolucao` datetime NOT NULL,
  `NomeUsuario` varchar(255) NOT NULL,
  `Telefone` varchar(255) NOT NULL,
  `Devolvido` bit(1) NOT NULL,
  `LivroId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `LivroId` (`LivroId`),
  CONSTRAINT `Emprestimos_ibfk_1` FOREIGN KEY (`LivroId`) REFERENCES `Livros` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Emprestimos`
--

LOCK TABLES `Emprestimos` WRITE;
/*!40000 ALTER TABLE `Emprestimos` DISABLE KEYS */;
INSERT INTO `Emprestimos` VALUES (1,'2023-10-30 00:00:00','2023-06-01 00:00:00','jhonata','82982136275',_binary '\0',1),(2,'2023-06-27 00:00:00','2025-06-27 00:00:00','jhonata','82982136275',_binary '\0',1);
/*!40000 ALTER TABLE `Emprestimos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `FiltrosLivros`
--

DROP TABLE IF EXISTS `FiltrosLivros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `FiltrosLivros` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TipoFiltro` varchar(255) NOT NULL,
  `Filtro` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `FiltrosLivros`
--

LOCK TABLES `FiltrosLivros` WRITE;
/*!40000 ALTER TABLE `FiltrosLivros` DISABLE KEYS */;
/*!40000 ALTER TABLE `FiltrosLivros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Livros`
--

DROP TABLE IF EXISTS `Livros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Livros` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(255) NOT NULL,
  `Autor` varchar(255) NOT NULL,
  `Ano` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Livros`
--

LOCK TABLES `Livros` WRITE;
/*!40000 ALTER TABLE `Livros` DISABLE KEYS */;
INSERT INTO `Livros` VALUES (1,'2099','Joao da',2000),(2,'o rato roeu a roupa do rei de roma','Joao da Silva',1),(3,'2099','Joao da Silva',1),(4,'o rato roeu a roupa do rei de roma','cleiton',1234);
/*!40000 ALTER TABLE `Livros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Usuarios`
--

DROP TABLE IF EXISTS `Usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Usuarios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Senha` varchar(300) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Usuarios`
--

LOCK TABLES `Usuarios` WRITE;
/*!40000 ALTER TABLE `Usuarios` DISABLE KEYS */;
INSERT INTO `Usuarios` VALUES (1,'admin','123'),(2,'admin','202cb962ac59075b964b07152d234b70');
/*!40000 ALTER TABLE `Usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-30 13:36:26
