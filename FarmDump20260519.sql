CREATE DATABASE  IF NOT EXISTS `mydb` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `mydb`;
-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.45

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `materials`
--

DROP TABLE IF EXISTS `materials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materials` (
  `id` int NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `code` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `sellPrice` double DEFAULT NULL,
  `buyPrice` double DEFAULT NULL,
  `specification_id` int NOT NULL,
  `production_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_material_specification1_idx` (`specification_id`),
  KEY `fk_material_production1_idx` (`production_id`),
  CONSTRAINT `fk_material_production1` FOREIGN KEY (`production_id`) REFERENCES `productions` (`id`),
  CONSTRAINT `fk_material_specification1` FOREIGN KEY (`specification_id`) REFERENCES `specifications` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materials`
--

LOCK TABLES `materials` WRITE;
/*!40000 ALTER TABLE `materials` DISABLE KEYS */;
INSERT INTO `materials` VALUES (1,'Закваска','232','Шт',1,45,32,1,1),(2,'Бебе','322','Шт',1,45,32,1,1);
/*!40000 ALTER TABLE `materials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `id` int NOT NULL,
  `number` int DEFAULT NULL,
  `date` date DEFAULT NULL,
  `salesman` varchar(45) DEFAULT NULL,
  `buyer` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,3411,'2026-02-03','ООО Бебе','ООО биби');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders_has_сontractors`
--

DROP TABLE IF EXISTS `orders_has_сontractors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders_has_сontractors` (
  `orders_id` int NOT NULL,
  `сontractors_id` int NOT NULL,
  PRIMARY KEY (`orders_id`,`сontractors_id`),
  KEY `fk_orders_has_сontractors_сontractors1_idx` (`сontractors_id`),
  KEY `fk_orders_has_сontractors_orders1_idx` (`orders_id`),
  CONSTRAINT `fk_orders_has_сontractors_orders1` FOREIGN KEY (`orders_id`) REFERENCES `orders` (`id`),
  CONSTRAINT `fk_orders_has_сontractors_сontractors1` FOREIGN KEY (`сontractors_id`) REFERENCES `сontractors` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders_has_сontractors`
--

LOCK TABLES `orders_has_сontractors` WRITE;
/*!40000 ALTER TABLE `orders_has_сontractors` DISABLE KEYS */;
/*!40000 ALTER TABLE `orders_has_сontractors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productions`
--

DROP TABLE IF EXISTS `productions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productions` (
  `id` int NOT NULL,
  `number` int DEFAULT NULL,
  `date` date DEFAULT NULL,
  `order_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_production_order1_idx` (`order_id`),
  CONSTRAINT `fk_production_order1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productions`
--

LOCK TABLES `productions` WRITE;
/*!40000 ALTER TABLE `productions` DISABLE KEYS */;
INSERT INTO `productions` VALUES (1,3232,'2026-02-06',1);
/*!40000 ALTER TABLE `productions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `id` int NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `code` varchar(45) DEFAULT NULL,
  `price` double DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `specification_id` int NOT NULL,
  `production_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_product_specification1_idx` (`specification_id`),
  KEY `fk_product_production1_idx` (`production_id`),
  CONSTRAINT `fk_product_production1` FOREIGN KEY (`production_id`) REFERENCES `productions` (`id`),
  CONSTRAINT `fk_product_specification1` FOREIGN KEY (`specification_id`) REFERENCES `specifications` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Кефир','2432',45,12,1,1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `specifications`
--

DROP TABLE IF EXISTS `specifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `specifications` (
  `id` int NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `manufacturer` varchar(45) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specifications`
--

LOCK TABLES `specifications` WRITE;
/*!40000 ALTER TABLE `specifications` DISABLE KEYS */;
INSERT INTO `specifications` VALUES (1,'Кефир','ООО бебе',1);
/*!40000 ALTER TABLE `specifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `сontractors`
--

DROP TABLE IF EXISTS `сontractors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `сontractors` (
  `id` int NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `inn` varchar(45) DEFAULT NULL,
  `addres` varchar(45) DEFAULT NULL,
  `phone` varchar(45) DEFAULT NULL,
  `salesman` tinyint DEFAULT NULL,
  `buyer` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `сontractors`
--

LOCK TABLES `сontractors` WRITE;
/*!40000 ALTER TABLE `сontractors` DISABLE KEYS */;
INSERT INTO `сontractors` VALUES (1,'ООО \"Поставка\"','','г.Пятигорск','+79198634592',1,1),(2,'ООО \"Кинотеатр Квант\"','26320045123','г. Железноводск, ул. Мира, 123','+79884581555',1,0),(3,'ООО \"Ромашка\"','4140784214','г. Омск, ул. Строителей, 294','+79882584546',0,1),(8,'ООО \"Новый JDTO\"','26320045111','г. Железноводсу','+79884581555',1,0),(9,'ООО \"Ипподром\"','5874045632','г. Уфа, ул. Набережная,  37','+79627486389',1,1),(10,'ООО \"Ассоль\"','2629011278','г. Калуга, ул. Пушкина, 94','+79184572398',0,1);
/*!40000 ALTER TABLE `сontractors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `сontractors_has_specifications`
--

DROP TABLE IF EXISTS `сontractors_has_specifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `сontractors_has_specifications` (
  `сontractors_id` int NOT NULL,
  `specifications_id` int NOT NULL,
  PRIMARY KEY (`сontractors_id`,`specifications_id`),
  KEY `fk_сontractors_has_specifications_specifications1_idx` (`specifications_id`),
  KEY `fk_сontractors_has_specifications_сontractors1_idx` (`сontractors_id`),
  CONSTRAINT `fk_сontractors_has_specifications_specifications1` FOREIGN KEY (`specifications_id`) REFERENCES `specifications` (`id`),
  CONSTRAINT `fk_сontractors_has_specifications_сontractors1` FOREIGN KEY (`сontractors_id`) REFERENCES `сontractors` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `сontractors_has_specifications`
--

LOCK TABLES `сontractors_has_specifications` WRITE;
/*!40000 ALTER TABLE `сontractors_has_specifications` DISABLE KEYS */;
/*!40000 ALTER TABLE `сontractors_has_specifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'mydb'
--

--
-- Dumping routines for database 'mydb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-19 13:19:15
