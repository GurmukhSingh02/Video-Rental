USE [master]
GO
/****** Object:  Database [VideoRental_Gurmukh]    Script Date: 03-06-2020 01:26:31 AM ******/
CREATE DATABASE [VideoRental_Gurmukh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VideoRental_Gurmukh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\VideoRental_Gurmukh.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VideoRental_Gurmukh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\VideoRental_Gurmukh_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VideoRental_Gurmukh] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VideoRental_Gurmukh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VideoRental_Gurmukh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET ARITHABORT OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET  MULTI_USER 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VideoRental_Gurmukh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [VideoRental_Gurmukh] SET DELAYED_DURABILITY = DISABLED 
GO
USE [VideoRental_Gurmukh]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 03-06-2020 01:26:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RentedMovie]    Script Date: 03-06-2020 01:26:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentedMovie](
	[RMID] [int] IDENTITY(1,1) NOT NULL,
	[MovieIDFK] [int] NULL,
	[CustIDFK] [int] NULL,
	[DateRented] [datetime] NULL,
	[DateReturned] [datetime] NULL,
 CONSTRAINT [PK_RentedMovie] PRIMARY KEY CLUSTERED 
(
	[RMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Videos]    Script Date: 03-06-2020 01:26:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Points] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[Copies] [int] NULL,
	[ReleasedBy] [nvarchar](50) NULL,
	[RentalCost] [int] NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

GO
INSERT [dbo].[Customers] ([ID], [Name], [Mobile], [Address]) VALUES (1, N'Nirmal', N'9815276871', N'abcd')
GO
INSERT [dbo].[Customers] ([ID], [Name], [Mobile], [Address]) VALUES (2, N'Gurmukh', N'23244345', N'qwerty')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[RentedMovie] ON 

GO
INSERT [dbo].[RentedMovie] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (1, 1, 1, CAST(N'2019-12-11 00:00:00.000' AS DateTime), CAST(N'2019-12-10 22:21:03.000' AS DateTime))
GO
INSERT [dbo].[RentedMovie] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (2, 1, 1, CAST(N'2019-12-11 00:00:00.000' AS DateTime), CAST(N'2019-12-10 22:33:11.000' AS DateTime))
GO
INSERT [dbo].[RentedMovie] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (3, 1, 1, CAST(N'2019-12-10 00:00:00.000' AS DateTime), CAST(N'2019-12-10 22:36:56.000' AS DateTime))
GO
INSERT [dbo].[RentedMovie] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (4, 1, 1, CAST(N'2019-12-10 00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[RentedMovie] OFF
GO
SET IDENTITY_INSERT [dbo].[Videos] ON 

GO
INSERT [dbo].[Videos] ([ID], [Name], [Points], [Year], [Copies], [ReleasedBy], [RentalCost]) VALUES (1, N'Hum Tum', N'6', 1990, 5, N'Kamal', 2)
GO
SET IDENTITY_INSERT [dbo].[Videos] OFF
GO
USE [master]
GO
ALTER DATABASE [VideoRental_Gurmukh] SET  READ_WRITE 
GO
