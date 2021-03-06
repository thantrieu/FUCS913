USE [master]
GO
/****** Object:  Database [CSDL Exercises2]    Script Date: 05/31/2022 10:31:19 ******/
CREATE DATABASE [CSDL Exercises2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CSDL Exercises2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CSDL Exercises2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CSDL Exercises2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CSDL Exercises2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CSDL Exercises2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CSDL Exercises2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CSDL Exercises2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET ARITHABORT OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CSDL Exercises2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CSDL Exercises2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CSDL Exercises2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CSDL Exercises2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CSDL Exercises2] SET  MULTI_USER 
GO
ALTER DATABASE [CSDL Exercises2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CSDL Exercises2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CSDL Exercises2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CSDL Exercises2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CSDL Exercises2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CSDL Exercises2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CSDL Exercises2] SET QUERY_STORE = OFF
GO
USE [CSDL Exercises2]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 05/31/2022 10:31:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[RegisterId] [int] NOT NULL,
	[StudentId] [nvarchar](50) NULL,
	[SubjectId] [int] NULL,
	[RegisterTime] [datetime] NULL,
 CONSTRAINT [PK_Register] PRIMARY KEY CLUSTERED 
(
	[RegisterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 05/31/2022 10:31:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[BirthDate] [date] NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Major] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 05/31/2022 10:31:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Credit] [int] NULL,
	[NumOfLesson] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10000, N'B25DCCN101', 11001, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10001, N'B25DCCN103', 11001, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10002, N'B25DCCN102', 11001, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10003, N'B25DCCN105', 11001, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10004, N'B25DCCN104', 11001, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10005, N'B25DCCN101', 11006, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10006, N'B25DCCN103', 11003, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10007, N'B25DCCN102', 11002, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10008, N'B25DCCN105', 11004, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10009, N'B25DCCN104', 11005, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10010, N'B25DCCN103', 11002, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10011, N'B25DCCN103', 11006, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10012, N'B25DCCN101', 11002, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10013, N'B25DCCN101', 11003, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10014, N'B25DCCN101', 11004, CAST(N'2022-05-30T11:24:01.073' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10015, N'B25DCCN116', 11001, CAST(N'2022-05-30T11:30:59.590' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10016, N'B25DCCN116', 11002, CAST(N'2022-05-30T11:31:13.890' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10017, N'B25DCCN116', 11003, CAST(N'2022-05-30T11:31:23.007' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10018, N'B25DCCN116', 11005, CAST(N'2022-05-30T11:31:38.990' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10019, N'B25DCCN116', 11004, CAST(N'2022-05-30T11:31:58.190' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10020, N'B25DCCN103', 11004, CAST(N'2022-05-31T10:26:45.533' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10021, N'B25DCCN102', 11003, CAST(N'2022-05-31T10:27:25.423' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10022, N'B25DCCN102', 11004, CAST(N'2022-05-31T10:27:39.677' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10023, N'B25DCCN102', 11009, CAST(N'2022-05-31T10:27:52.243' AS DateTime))
INSERT [dbo].[Register] ([RegisterId], [StudentId], [SubjectId], [RegisterTime]) VALUES (10024, N'B25DCCN107', 11004, CAST(N'2022-05-31T10:29:52.943' AS DateTime))
GO
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN101', N'Trần Văn Nam', CAST(N'2007-06-15' AS Date), N'0912365211', N'vannam@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN103', N'Ngô Văn Tài', CAST(N'2007-04-15' AS Date), N'0912365211', N'vantai123@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN102', N'Hồ Hoàng Yến', CAST(N'2007-07-27' AS Date), N'0912365211', N'hoangyenkk@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN105', N'Võ Hoàng Yến', CAST(N'2007-09-11' AS Date), N'0912365211', N'yenvo@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN104', N'Vy Thị Yến', CAST(N'2007-02-14' AS Date), N'0912365211', N'yenvi@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN108', N'Mai Văn Dũng', CAST(N'2007-08-19' AS Date), N'0912365211', N'vandung@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN107', N'Lê Thanh Thảo', CAST(N'2007-09-18' AS Date), N'0912365211', N'thanhthao@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN106', N'Ngô Nhật Phong', CAST(N'2007-10-10' AS Date), N'0912365211', N'nhatphong@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN109', N'Ma Thanh Thức', CAST(N'2007-11-16' AS Date), N'0912365211', N'thanhthuc@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN111', N'Khúc Thị Lệ Quyên', CAST(N'2007-12-18' AS Date), N'0912365211', N'lequyenkhuc@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN110', N'Trương Trọng Anh', CAST(N'2007-05-17' AS Date), N'0912365211', N'tronganhtruong@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN112', N'Nguyễn Quỳnh Anh', CAST(N'2007-01-25' AS Date), N'0912365211', N'quynhanhng@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN115', N'Thân Văn Huấn', CAST(N'2007-04-30' AS Date), N'0912365211', N'vanhuanth@xmail.com', N'CNTT')
INSERT [dbo].[Student] ([StudentId], [FullName], [BirthDate], [PhoneNumber], [Email], [Major]) VALUES (N'B25DCCN116', N'Tran Trung Khiem', CAST(N'2007-09-16' AS Date), N'0354123654', N'hoabinhtruong@xmail.com', N'CNTT')
GO
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11001, N'C++', 3, 42)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11002, N'C', 3, 36)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11003, N'C#', 4, 48)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11004, N'Java', 4, 46)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11005, N'Kotlin', 3, 36)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11006, N'Android', 5, 60)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11007, N'SQL', 3, 36)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11008, N'Python', 4, 48)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11009, N'JavaScript', 3, 36)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11010, N'Web design', 2, 25)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11011, N'ASP.NET', 36, 42)
INSERT [dbo].[Subject] ([SubjectId], [Name], [Credit], [NumOfLesson]) VALUES (11012, N'ASP.Net nang cao', 3, 36)
GO
USE [master]
GO
ALTER DATABASE [CSDL Exercises2] SET  READ_WRITE 
GO
