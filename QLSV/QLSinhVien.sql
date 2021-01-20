USE [master]
GO

/****** Object:  Database [QLSinhVien]    Script Date: 1/12/2021 8:43:55 PM ******/
CREATE DATABASE [QLSinhVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLSinhVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLSinhVien.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLSinhVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLSinhVien_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [QLSinhVien] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLSinhVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [QLSinhVien] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [QLSinhVien] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [QLSinhVien] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [QLSinhVien] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [QLSinhVien] SET ARITHABORT OFF 
GO

ALTER DATABASE [QLSinhVien] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [QLSinhVien] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [QLSinhVien] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [QLSinhVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [QLSinhVien] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [QLSinhVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [QLSinhVien] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [QLSinhVien] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [QLSinhVien] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [QLSinhVien] SET  ENABLE_BROKER 
GO

ALTER DATABASE [QLSinhVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [QLSinhVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [QLSinhVien] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [QLSinhVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [QLSinhVien] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [QLSinhVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [QLSinhVien] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [QLSinhVien] SET RECOVERY FULL 
GO

ALTER DATABASE [QLSinhVien] SET  MULTI_USER 
GO

ALTER DATABASE [QLSinhVien] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [QLSinhVien] SET DB_CHAINING OFF 
GO

ALTER DATABASE [QLSinhVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [QLSinhVien] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [QLSinhVien] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [QLSinhVien] SET  READ_WRITE 
GO
