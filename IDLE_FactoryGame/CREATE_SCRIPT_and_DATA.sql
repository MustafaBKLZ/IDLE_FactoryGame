USE [master]
GO
/****** Object:  Database [data]    Script Date: 09.04.2022 14:28:02 ******/
CREATE DATABASE [data]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQL2017\MSSQL\DATA\data.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'data_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQL2017\MSSQL\DATA\data_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [data] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [data] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [data] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [data] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [data] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [data] SET ARITHABORT OFF 
GO
ALTER DATABASE [data] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [data] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [data] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [data] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [data] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [data] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [data] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [data] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [data] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [data] SET  DISABLE_BROKER 
GO
ALTER DATABASE [data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [data] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [data] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [data] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [data] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [data] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [data] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [data] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [data] SET  MULTI_USER 
GO
ALTER DATABASE [data] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [data] SET DB_CHAINING OFF 
GO
ALTER DATABASE [data] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [data] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [data] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [data] SET QUERY_STORE = OFF
GO
USE [data]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [data]
GO
/****** Object:  Table [dbo].[ACTIVE_MACHINES]    Script Date: 09.04.2022 14:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTIVE_MACHINES](
	[amac_RECno] [int] IDENTITY(1,1) NOT NULL,
	[amac_MachineType] [nvarchar](50) NULL,
	[amac_MachineMK] [int] NULL,
	[amac_MachineCount] [int] NULL,
	[amac_Recipe] [nvarchar](50) NULL,
 CONSTRAINT [PK_ACTIVE_MACHINES] PRIMARY KEY CLUSTERED 
(
	[amac_RECno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACTIVE_RESOURCES]    Script Date: 09.04.2022 14:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTIVE_RESOURCES](
	[res_REcno] [int] IDENTITY(1,1) NOT NULL,
	[res_Material] [nvarchar](50) NULL,
	[res_Quantitiy] [float] NULL,
 CONSTRAINT [PK_ACTIVE_RESOURCES] PRIMARY KEY CLUSTERED 
(
	[res_REcno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONSTRUCTION_RECIPES]    Script Date: 09.04.2022 14:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONSTRUCTION_RECIPES](
	[com_RECno] [int] IDENTITY(1,1) NOT NULL,
	[com_Code] [nvarchar](50) NULL,
	[com_MaterialName] [nvarchar](50) NULL,
	[com_MaterialQuantity] [float] NULL,
 CONSTRAINT [PK_CONSTRUCTION_RECIPES] PRIMARY KEY CLUSTERED 
(
	[com_RECno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MACHINES]    Script Date: 09.04.2022 14:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MACHINES](
	[mac_RECno] [int] IDENTITY(1,1) NOT NULL,
	[mac_BuildCategory] [nvarchar](50) NULL,
	[mac_Type] [nvarchar](50) NULL,
	[mac_Mark] [int] NULL,
	[mac_Name] [nvarchar](max) NULL,
	[mac_ProductType] [nvarchar](50) NOT NULL,
	[mac_PowerConsumption] [float] NULL,
	[mac_PowerType] [nvarchar](50) NULL,
	[mac_ConstructionRecipe] [nvarchar](50) NULL,
	[mac_IsActive] [bit] NULL,
	[mac_ProductPerMin] [float] NULL,
	[mac_Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_MACHINES] PRIMARY KEY CLUSTERED 
(
	[mac_RECno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATERIALS]    Script Date: 09.04.2022 14:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATERIALS](
	[mat_RECno] [int] IDENTITY(1,1) NOT NULL,
	[mat_Code] [nvarchar](50) NULL,
	[mat_Name] [nvarchar](50) NULL,
	[mat_Description] [nvarchar](1500) NULL,
	[mat_level] [int] NULL,
	[mat_HowProduct] [nvarchar](50) NULL,
	[mat_IsActive] [bit] NULL,
	[mat_DontShow] [bit] NULL,
 CONSTRAINT [PK_MATERIALS] PRIMARY KEY CLUSTERED 
(
	[mat_RECno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RECIPES]    Script Date: 09.04.2022 14:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RECIPES](
	[rec_RECno] [int] IDENTITY(1,1) NOT NULL,
	[rec_Code] [nvarchar](50) NULL,
	[rec_IOType] [nvarchar](50) NULL,
	[rec_Material] [nvarchar](50) NULL,
	[rec_Quantity] [float] NULL,
	[rec_IsActive] [bit] NULL,
	[rec_Productivite] [bit] NULL,
 CONSTRAINT [PK_RECIPES] PRIMARY KEY CLUSTERED 
(
	[rec_RECno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ACTIVE_MACHINES] ON 

INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (46, N'MINER', 1, 100, N'IRON_ORE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (47, N'WIND_TURBINE', 1, 609, N'WIND_POWER')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (48, N'MINER', 1, 100, N'COPPER_ORE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (49, N'MINER', 1, 100, N'STONE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (50, N'SMELTER', 1, 7, N'IRON_INGOT')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (51, N'SMELTER', 1, 7, N'COPPER_INGOT')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (52, N'SMELTER', 1, 7, N'STONE_BLOCK')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (53, N'SMELTER', 2, 17, N'IRON_INGOT')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (54, N'SMELTER', 2, 14, N'COPPER_INGOT')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (55, N'SMELTER', 2, 12, N'STONE_BLOCK')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (56, N'MINER', 2, 100, N'IRON_ORE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (57, N'MINER', 2, 100, N'COPPER_ORE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (58, N'MINER', 2, 100, N'STONE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (59, N'PRODUCTER', 1, 2, N'IRON_PLATE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (60, N'PRODUCTER', 1, 2, N'IRON_BEAM')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (61, N'PRODUCTER', 1, 2, N'CONDUCTING_WIRE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (62, N'PRODUCTER', 1, 2, N'COPPER_ROD')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (63, N'PRODUCTER', 1, 2, N'IRON_ROD')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (64, N'PRODUCTER', 1, 2, N'IRON_SCREW')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (65, N'PRODUCTER', 1, 6, N'COPPER_PLATE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (66, N'PRODUCTER', 2, 1, N'IRON_PLATE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (67, N'PRODUCTER', 2, 1, N'IRON_BEAM')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (68, N'PRODUCTER', 2, 1, N'CONDUCTING_WIRE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (69, N'PRODUCTER', 2, 4, N'COPPER_ROD')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (70, N'PRODUCTER', 2, 1, N'IRON_ROD')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (71, N'PRODUCTER', 2, 1, N'IRON_SCREW')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (72, N'PRODUCTER', 2, 1, N'COPPER_PLATE')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (73, N'PRODUCTER', 1, 10, N'COIL')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (74, N'PRODUCTER', 1, 1, N'MAGNET')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (75, N'WIND_TURBINE', 2, 78, N'WIND_POWER')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (76, N'MINER', 1, 14, N'COAL')
INSERT [dbo].[ACTIVE_MACHINES] ([amac_RECno], [amac_MachineType], [amac_MachineMK], [amac_MachineCount], [amac_Recipe]) VALUES (77, N'MINER', 2, 16, N'COAL')
SET IDENTITY_INSERT [dbo].[ACTIVE_MACHINES] OFF
SET IDENTITY_INSERT [dbo].[ACTIVE_RESOURCES] ON 

INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (587, N'POWER', 10797)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (588, N'STONE', 370)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (589, N'IRON_ORE', 146905)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (590, N'COPPER_ORE', 207725)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (591, N'COPPER_INGOT', 61146)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (592, N'IRON_INGOT', 77124)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (593, N'STONE_BLOCK', 47600)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (594, N'MAGNET', 7)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (595, N'IRON_PLATE', 5085)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (596, N'IRON_BEAM', 3162)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (597, N'CONDUCTING_WIRE', 19675)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (598, N'COPPER_ROD', 34708)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (599, N'IRON_ROD', 9069)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (600, N'IRON_SCREW', 29510)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (601, N'COPPER_PLATE', 14654)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (602, N'COIL', 32)
INSERT [dbo].[ACTIVE_RESOURCES] ([res_REcno], [res_Material], [res_Quantitiy]) VALUES (603, N'COAL', 9269)
SET IDENTITY_INSERT [dbo].[ACTIVE_RESOURCES] OFF
SET IDENTITY_INSERT [dbo].[CONSTRUCTION_RECIPES] ON 

INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (1, N'MINER_MK_1_CM', N'IRON_PLATE', 10)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (2, N'MINER_MK_1_CM', N'IRON_BEAM', 10)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (3, N'MINER_MK_1_CM', N'CONDUCTING_WIRE', 25)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (4, N'MINER_MK_1_CM', N'COPPER_ROD', 5)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (5, N'SMELTER_MK_1_CM', N'IRON_PLATE', 10)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (6, N'SMELTER_MK_1_CM', N'IRON_BEAM', 3)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (7, N'SMELTER_MK_1_CM', N'CONDUCTING_WIRE', 5)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (8, N'SMELTER_MK_1_CM', N'STONE_BLOCK', 20)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (9, N'WIND_TURBINE_MK_1_CM', N'IRON_PLATE', 10)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (10, N'WIND_TURBINE_MK_1_CM', N'IRON_BEAM', 2)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (11, N'WIND_TURBINE_MK_1_CM', N'CONDUCTING_WIRE', 20)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (12, N'WIND_TURBINE_MK_1_CM', N'COIL', 10)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (13, N'WIND_TURBINE_MK_2_CM', N'IRON_PLATE', 20)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (14, N'WIND_TURBINE_MK_2_CM', N'IRON_BEAM', 5)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (15, N'WIND_TURBINE_MK_2_CM', N'STONE_BLOCK', 5)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (16, N'WIND_TURBINE_MK_2_CM', N'COIL', 20)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (17, N'WIND_TURBINE_MK_2_CM', N'IRON_SCREW', 250)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (18, N'WIND_TURBINE_MK_2_CM', N'CONDUCTING_WIRE', 80)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (19, N'MINER_MK_2_CM', N'IRON_PLATE', 20)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (20, N'MINER_MK_2_CM', N'IRON_BEAM', 20)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (21, N'MINER_MK_2_CM', N'CONDUCTING_WIRE', 100)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (22, N'MINER_MK_2_CM', N'COPPER_ROD', 15)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (23, N'MINER_MK_2_CM', N'COIL', 15)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (24, N'SMELTER_MK_2_CM', N'IRON_PLATE', 25)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (25, N'SMELTER_MK_2_CM', N'IRON_BEAM', 10)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (26, N'SMELTER_MK_2_CM', N'CONDUCTING_WIRE', 50)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (27, N'SMELTER_MK_2_CM', N'STONE_BLOCK', 50)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (28, N'SMELTER_MK_2_CM', N'COIL', 8)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (29, N'PRODUCTER_MK_1_CM', N'IRON_PLATE', 50)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (30, N'PRODUCTER_MK_1_CM', N'IRON_BEAM', 25)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (31, N'PRODUCTER_MK_1_CM', N'CONDUCTING_WIRE', 80)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (32, N'PRODUCTER_MK_1_CM', N'STONE_BLOCK', 10)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (33, N'PRODUCTER_MK_1_CM', N'COPPER_ROD', 5)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (34, N'PRODUCTER_MK_1_CM', N'IRON_ROD', 10)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (35, N'PRODUCTER_MK_1_CM', N'COIL', 25)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (36, N'PRODUCTER_MK_2_CM', N'IRON_PLATE', 150)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (37, N'PRODUCTER_MK_2_CM', N'IRON_BEAM', 50)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (38, N'PRODUCTER_MK_2_CM', N'CONDUCTING_WIRE', 250)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (39, N'PRODUCTER_MK_2_CM', N'STONE_BLOCK', 15)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (40, N'PRODUCTER_MK_2_CM', N'COPPER_ROD', 15)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (41, N'PRODUCTER_MK_2_CM', N'IRON_ROD', 25)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (42, N'PRODUCTER_MK_2_CM', N'COIL', 50)
INSERT [dbo].[CONSTRUCTION_RECIPES] ([com_RECno], [com_Code], [com_MaterialName], [com_MaterialQuantity]) VALUES (43, N'PRODUCTER_MK_2_CM', N'IRON_SCREW', 500)
SET IDENTITY_INSERT [dbo].[CONSTRUCTION_RECIPES] OFF
SET IDENTITY_INSERT [dbo].[MACHINES] ON 

INSERT [dbo].[MACHINES] ([mac_RECno], [mac_BuildCategory], [mac_Type], [mac_Mark], [mac_Name], [mac_ProductType], [mac_PowerConsumption], [mac_PowerType], [mac_ConstructionRecipe], [mac_IsActive], [mac_ProductPerMin], [mac_Description]) VALUES (1, N'MINER', N'MINER', 1, N'Miner MK 1', N'MATERIAL', -20, N'KW', N'MINER_MK_1_CM', 1, 1, N'Miner MK 1')
INSERT [dbo].[MACHINES] ([mac_RECno], [mac_BuildCategory], [mac_Type], [mac_Mark], [mac_Name], [mac_ProductType], [mac_PowerConsumption], [mac_PowerType], [mac_ConstructionRecipe], [mac_IsActive], [mac_ProductPerMin], [mac_Description]) VALUES (9, N'MINER', N'MINER', 2, N'Miner MK 2', N'MATERIAL', -40, N'KW', N'MINER_MK_2_CM', 1, 2, N'Miner MK 2')
INSERT [dbo].[MACHINES] ([mac_RECno], [mac_BuildCategory], [mac_Type], [mac_Mark], [mac_Name], [mac_ProductType], [mac_PowerConsumption], [mac_PowerType], [mac_ConstructionRecipe], [mac_IsActive], [mac_ProductPerMin], [mac_Description]) VALUES (18, N'SMELTER', N'SMELTER', 1, N'Smelter MK 1', N'MATERIAL', -50, N'KW', N'SMELTER_MK_1_CM', 1, 1, N'Smelter MK 1')
INSERT [dbo].[MACHINES] ([mac_RECno], [mac_BuildCategory], [mac_Type], [mac_Mark], [mac_Name], [mac_ProductType], [mac_PowerConsumption], [mac_PowerType], [mac_ConstructionRecipe], [mac_IsActive], [mac_ProductPerMin], [mac_Description]) VALUES (19, N'SMELTER', N'SMELTER', 2, N'Smelter MK 2', N'MATERIAL', -75, N'KW', N'SMELTER_MK_2_CM', 1, 4, N'Smelter MK 2')
INSERT [dbo].[MACHINES] ([mac_RECno], [mac_BuildCategory], [mac_Type], [mac_Mark], [mac_Name], [mac_ProductType], [mac_PowerConsumption], [mac_PowerType], [mac_ConstructionRecipe], [mac_IsActive], [mac_ProductPerMin], [mac_Description]) VALUES (28, N'POWER_PLANT', N'WIND_TURBINE', 1, N'Wind Turbine MK 1', N'WIND_POWER', 48, N'KW', N'WIND_TURBINE_MK_1_CM', 1, 48, N'Wind Turbine MK 1')
INSERT [dbo].[MACHINES] ([mac_RECno], [mac_BuildCategory], [mac_Type], [mac_Mark], [mac_Name], [mac_ProductType], [mac_PowerConsumption], [mac_PowerType], [mac_ConstructionRecipe], [mac_IsActive], [mac_ProductPerMin], [mac_Description]) VALUES (29, N'POWER_PLANT', N'WIND_TURBINE', 2, N'Wind Turbine MK 2', N'WIND_POWER', 110, N'KW', N'WIND_TURBINE_MK_2_CM', 1, 110, N'Wind Turbine MK 2')
INSERT [dbo].[MACHINES] ([mac_RECno], [mac_BuildCategory], [mac_Type], [mac_Mark], [mac_Name], [mac_ProductType], [mac_PowerConsumption], [mac_PowerType], [mac_ConstructionRecipe], [mac_IsActive], [mac_ProductPerMin], [mac_Description]) VALUES (33, N'PRODUCTER', N'PRODUCTER', 1, N'Producter MK 1', N'MATERIAL', -80, N'KW', N'PRODUCTER_MK_1_CM', 1, 1, N'Producter MK 1')
INSERT [dbo].[MACHINES] ([mac_RECno], [mac_BuildCategory], [mac_Type], [mac_Mark], [mac_Name], [mac_ProductType], [mac_PowerConsumption], [mac_PowerType], [mac_ConstructionRecipe], [mac_IsActive], [mac_ProductPerMin], [mac_Description]) VALUES (34, N'PRODUCTER', N'PRODUCTER', 2, N'Producter MK 2', N'MATERIAL', -150, N'KW', N'PRODUCTER_MK_2_CM', 1, 3, N'Producter MK ')
SET IDENTITY_INSERT [dbo].[MACHINES] OFF
SET IDENTITY_INSERT [dbo].[MATERIALS] ON 

INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (1, N'IRON_ORE', N'Iron Ore', N'just iron ore', 1, N'MINER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (2, N'IRON_INGOT', N'Iron Ingot', N'just iron ingot', 2, N'SMELTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (3, N'IRON_PLATE', N'Iron Plate', N'just iron plate', 3, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (4, N'IRON_BEAM', N'Iron Beam', N'just Iron Beam', 3, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (5, N'CONDUCTING_WIRE', N'Conducting Wire', N'just Condusting Wire', 3, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (6, N'COPPER_ROD', N'Copper Rod', N'just Copper Rod', 3, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (7, N'COPPER_ORE', N'Copper Ore', N'just Copper Ore', 1, N'MINER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (8, N'COPPER_INGOT', N'Copper Ingot', N'just Copper Ingot', 2, N'SMELTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (9, N'IRON_ROD', N'Iron Rod', N'jusy Iron Rod', 3, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (10, N'IRON_SCREW', N'Iron Screw', N'just Iron Screw', 3, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (11, N'COPPER_PLATE', N'Copper Plate', N'just Copper Plate', 3, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (12, N'STONE', N'Stone', N'just Stone', 1, N'MINER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (13, N'POWER', N'Power', N'Just energy', 0, N'POWER_PLANTS', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (14, N'STONE_BLOCK', N'Stone Block', N'just Stone Block', 2, N'SMELTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (15, N'MAGNET', N'Magnet', N'just Magnet', 2, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (16, N'COIL', N'Coil', N'Just Coil', 4, N'PRODUCTER', 1, 0)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (17, N'WIND_POWER', N'Wind Power', N'just green energy', 0, N'POWER_PLANT', 1, 1)
INSERT [dbo].[MATERIALS] ([mat_RECno], [mat_Code], [mat_Name], [mat_Description], [mat_level], [mat_HowProduct], [mat_IsActive], [mat_DontShow]) VALUES (18, N'COAL', N'Coal', N'just Coal', 1, N'MINER', 1, 0)
SET IDENTITY_INSERT [dbo].[MATERIALS] OFF
SET IDENTITY_INSERT [dbo].[RECIPES] ON 

INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (1, N'IRON_INGOT', N'i', N'IRON_ORE', 3, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (2, N'IRON_INGOT', N'o', N'IRON_INGOT', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (3, N'IRON_PLATE', N'i', N'IRON_INGOT', 3, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (4, N'IRON_PLATE', N'o', N'IRON_PLATE', 2, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (5, N'IRON_ORE', N'o', N'IRON_ORE', 1, 1, 0)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (6, N'COPPER_ORE', N'o', N'COPPER_ORE', 1, 1, 0)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (7, N'IRON_BEAM', N'i', N'IRON_INGOT', 5, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (8, N'IRON_BEAM', N'o', N'IRON_BEAM', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (9, N'COPPER_INGOT', N'i', N'COPPER_ORE', 3, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (10, N'COPPER_INGOT', N'o', N'COPPER_INGOT', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (11, N'CONDUCTING_WIRE', N'i', N'COPPER_INGOT', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (12, N'CONDUCTING_WIRE', N'o', N'CONDUCTING_WIRE', 10, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (13, N'COPPER_ROD', N'i', N'COPPER_INGOT', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (14, N'COPPER_ROD', N'o', N'COPPER_ROD', 3, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (15, N'STONE', N'o', N'STONE', 1, 1, 0)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (17, N'IRON_ROD', N'i', N'IRON_INGOT', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (18, N'IRON_ROD', N'o', N'IRON_ROD', 3, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (19, N'IRON_SCREW', N'i', N'IRON_ROD', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (20, N'IRON_SCREW', N'o', N'IRON_SCREW', 10, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (21, N'COPPER_PLATE', N'i', N'COPPER_INGOT', 3, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (22, N'COPPER_PLATE', N'o', N'COPPER_PLATE', 2, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (23, N'STONE_BLOCK', N'i', N'STONE', 10, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (24, N'STONE_BLOCK', N'o', N'STONE_BLOCK', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (25, N'MAGNET', N'i', N'IRON_ORE', 5, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (26, N'MAGNET', N'o', N'MAGNET', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (27, N'COIL', N'i', N'MAGNET', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (28, N'COIL', N'i', N'CONDUCTING_WIRE', 5, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (29, N'COIL', N'o', N'COIL', 1, 1, 1)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (30, N'WIND_POWER', N'o', N'POWER', 48, 1, 0)
INSERT [dbo].[RECIPES] ([rec_RECno], [rec_Code], [rec_IOType], [rec_Material], [rec_Quantity], [rec_IsActive], [rec_Productivite]) VALUES (31, N'COAL', N'o', N'COAL', 1, 1, 0)
SET IDENTITY_INSERT [dbo].[RECIPES] OFF
USE [master]
GO
ALTER DATABASE [data] SET  READ_WRITE 
GO
