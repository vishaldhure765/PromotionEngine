# PromotionEngine


1. I have created this project in ASP.Net MVC and used entity framework for databse connection.

2. Before Run Project Execute following database script and update connection string according to that.


-- Database script ---

USE [master]
GO
/****** Object:  Database [PromotionEngine]    Script Date: 11/5/2020 11:27:11 AM ******/
CREATE DATABASE [PromotionEngine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PromotionEngine', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PromotionEngine.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PromotionEngine_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PromotionEngine_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PromotionEngine] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PromotionEngine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PromotionEngine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PromotionEngine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PromotionEngine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PromotionEngine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PromotionEngine] SET ARITHABORT OFF 
GO
ALTER DATABASE [PromotionEngine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PromotionEngine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PromotionEngine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PromotionEngine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PromotionEngine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PromotionEngine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PromotionEngine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PromotionEngine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PromotionEngine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PromotionEngine] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PromotionEngine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PromotionEngine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PromotionEngine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PromotionEngine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PromotionEngine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PromotionEngine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PromotionEngine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PromotionEngine] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PromotionEngine] SET  MULTI_USER 
GO
ALTER DATABASE [PromotionEngine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PromotionEngine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PromotionEngine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PromotionEngine] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PromotionEngine]
GO
/****** Object:  Table [dbo].[ProductMaster]    Script Date: 11/5/2020 11:27:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Prize] [decimal](18, 2) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ProductMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PromotionMaster]    Script Date: 11/5/2020 11:27:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromotionMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[ProductPrize] [decimal](18, 2) NULL,
	[PromotionPrize] [decimal](18, 2) NULL,
 CONSTRAINT [PK_PromotionMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ProductMaster] ON 
GO
INSERT [dbo].[ProductMaster] ([Id], [Code], [Name], [Prize], [IsDeleted]) VALUES (1, N'A', N'A', CAST(50.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[ProductMaster] ([Id], [Code], [Name], [Prize], [IsDeleted]) VALUES (2, N'B', N'B', CAST(30.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[ProductMaster] ([Id], [Code], [Name], [Prize], [IsDeleted]) VALUES (3, N'C', N'C', CAST(20.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[ProductMaster] ([Id], [Code], [Name], [Prize], [IsDeleted]) VALUES (4, N'D', N'D', CAST(15.00 AS Decimal(18, 2)), 0)
GO
SET IDENTITY_INSERT [dbo].[ProductMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[PromotionMaster] ON 
GO
INSERT [dbo].[PromotionMaster] ([Id], [ProductId], [Quantity], [Discount], [ProductPrize], [PromotionPrize]) VALUES (1, 1, 3, CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(130.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PromotionMaster] ([Id], [ProductId], [Quantity], [Discount], [ProductPrize], [PromotionPrize]) VALUES (2, 2, 2, CAST(0.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[PromotionMaster] OFF
GO
ALTER TABLE [dbo].[ProductMaster] ADD  CONSTRAINT [DF_ProductMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PromotionMaster]  WITH CHECK ADD  CONSTRAINT [FK_PromotionMaster_ProductMaster] FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductMaster] ([Id])
GO
ALTER TABLE [dbo].[PromotionMaster] CHECK CONSTRAINT [FK_PromotionMaster_ProductMaster]
GO
USE [master]
GO
ALTER DATABASE [PromotionEngine] SET  READ_WRITE 
GO



