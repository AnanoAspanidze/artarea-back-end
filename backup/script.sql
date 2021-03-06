USE [master]
GO
/****** Object:  Database [Artarea]    Script Date: 02/02/2018 13:24:03 ******/
CREATE DATABASE [Artarea]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Artarea', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Artarea.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Artarea_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Artarea_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Artarea] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Artarea].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Artarea] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Artarea] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Artarea] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Artarea] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Artarea] SET ARITHABORT OFF 
GO
ALTER DATABASE [Artarea] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Artarea] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Artarea] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Artarea] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Artarea] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Artarea] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Artarea] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Artarea] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Artarea] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Artarea] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Artarea] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Artarea] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Artarea] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Artarea] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Artarea] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Artarea] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Artarea] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Artarea] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Artarea] SET  MULTI_USER 
GO
ALTER DATABASE [Artarea] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Artarea] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Artarea] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Artarea] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Artarea] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Artarea] SET QUERY_STORE = OFF
GO
USE [Artarea]
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
USE [Artarea]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Photo] [nvarchar](500) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorProgram]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Authorid] [int] NOT NULL,
	[Programid] [int] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_AuthorProgram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorSeries]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorSeries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Authorid] [int] NOT NULL,
	[Seriesid] [int] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_AuthorSeries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorTranslate]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorTranslate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Authorid] [int] NOT NULL,
	[LangCode] [char](5) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Biography] [nvarchar](max) NOT NULL,
	[Profession] [nvarchar](50) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_AuthorTranslate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogpost]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogpost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Photo] [nvarchar](500) NOT NULL,
	[Authorid] [int] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Blogpost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogpostTranslate]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogpostTranslate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Blogpostid] [int] NOT NULL,
	[LangCode] [char](5) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_BlogpostTranslate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryProgram]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Programid] [int] NOT NULL,
	[Categoryid] [int] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_CategoryProgram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryTranslate]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryTranslate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoryid] [int] NOT NULL,
	[LangCode] [char](5) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_CategoryTranslate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 02/02/2018 13:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Startdate] [datetime] NOT NULL,
	[Enddate] [datetime] NULL,
	[isArchive] [bit] NOT NULL,
	[Fblink] [nvarchar](500) NULL,
	[Categoryid] [int] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventTranslate]    Script Date: 02/02/2018 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTranslate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Eventid] [int] NOT NULL,
	[LangCode] [char](5) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_EventTranslate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 02/02/2018 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Filetypeid] [int] NOT NULL,
	[Articleid] [int] NOT NULL,
	[isMainfile] [bit] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filetype]    Script Date: 02/02/2018 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filetype](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Filetype] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 02/02/2018 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LangCode] [char](5) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LangCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Program]    Script Date: 02/02/2018 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Srartdate] [datetime] NOT NULL,
	[Enddate] [datetime] NOT NULL,
	[Yeoutubelink] [nvarchar](500) NOT NULL,
	[isArchive] [bit] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Program1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramTranslate]    Script Date: 02/02/2018 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramTranslate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Programid] [int] NOT NULL,
	[LangCode] [char](5) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_ProgramTranslate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Series]    Script Date: 02/02/2018 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Programid] [int] NOT NULL,
	[VideoLink] [nvarchar](500) NOT NULL,
	[Episodedate] [datetime] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Series] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeriesTranslate]    Script Date: 02/02/2018 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeriesTranslate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Seriesid] [int] NOT NULL,
	[LangCode] [char](5) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_SeriesTranslate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Language] ([LangCode], [Name]) VALUES (N'en-us', N'English')
INSERT [dbo].[Language] ([LangCode], [Name]) VALUES (N'ka-ge', N'Georgian')
ALTER TABLE [dbo].[AuthorProgram]  WITH CHECK ADD  CONSTRAINT [FK_AuthorProgram_Author1] FOREIGN KEY([Authorid])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[AuthorProgram] CHECK CONSTRAINT [FK_AuthorProgram_Author1]
GO
ALTER TABLE [dbo].[AuthorProgram]  WITH CHECK ADD  CONSTRAINT [FK_AuthorProgram_Program1] FOREIGN KEY([Programid])
REFERENCES [dbo].[Program] ([Id])
GO
ALTER TABLE [dbo].[AuthorProgram] CHECK CONSTRAINT [FK_AuthorProgram_Program1]
GO
ALTER TABLE [dbo].[AuthorSeries]  WITH CHECK ADD  CONSTRAINT [FK_AuthorSeries_Author] FOREIGN KEY([Authorid])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[AuthorSeries] CHECK CONSTRAINT [FK_AuthorSeries_Author]
GO
ALTER TABLE [dbo].[AuthorSeries]  WITH CHECK ADD  CONSTRAINT [FK_AuthorSeries_Series1] FOREIGN KEY([Seriesid])
REFERENCES [dbo].[Series] ([Id])
GO
ALTER TABLE [dbo].[AuthorSeries] CHECK CONSTRAINT [FK_AuthorSeries_Series1]
GO
ALTER TABLE [dbo].[AuthorTranslate]  WITH CHECK ADD  CONSTRAINT [FK_AuthorTranslate_Author] FOREIGN KEY([Authorid])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[AuthorTranslate] CHECK CONSTRAINT [FK_AuthorTranslate_Author]
GO
ALTER TABLE [dbo].[AuthorTranslate]  WITH CHECK ADD  CONSTRAINT [FK_AuthorTranslate_Language] FOREIGN KEY([LangCode])
REFERENCES [dbo].[Language] ([LangCode])
GO
ALTER TABLE [dbo].[AuthorTranslate] CHECK CONSTRAINT [FK_AuthorTranslate_Language]
GO
ALTER TABLE [dbo].[Blogpost]  WITH CHECK ADD  CONSTRAINT [FK_Blogpost_Author1] FOREIGN KEY([Authorid])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[Blogpost] CHECK CONSTRAINT [FK_Blogpost_Author1]
GO
ALTER TABLE [dbo].[BlogpostTranslate]  WITH CHECK ADD  CONSTRAINT [FK_BlogpostTranslate_Blogpost] FOREIGN KEY([Blogpostid])
REFERENCES [dbo].[Blogpost] ([Id])
GO
ALTER TABLE [dbo].[BlogpostTranslate] CHECK CONSTRAINT [FK_BlogpostTranslate_Blogpost]
GO
ALTER TABLE [dbo].[BlogpostTranslate]  WITH CHECK ADD  CONSTRAINT [FK_BlogpostTranslate_Language] FOREIGN KEY([LangCode])
REFERENCES [dbo].[Language] ([LangCode])
GO
ALTER TABLE [dbo].[BlogpostTranslate] CHECK CONSTRAINT [FK_BlogpostTranslate_Language]
GO
ALTER TABLE [dbo].[CategoryProgram]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProgram_Category1] FOREIGN KEY([Categoryid])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[CategoryProgram] CHECK CONSTRAINT [FK_CategoryProgram_Category1]
GO
ALTER TABLE [dbo].[CategoryProgram]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProgram_Program1] FOREIGN KEY([Programid])
REFERENCES [dbo].[Program] ([Id])
GO
ALTER TABLE [dbo].[CategoryProgram] CHECK CONSTRAINT [FK_CategoryProgram_Program1]
GO
ALTER TABLE [dbo].[CategoryTranslate]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTranslate_Category] FOREIGN KEY([Categoryid])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[CategoryTranslate] CHECK CONSTRAINT [FK_CategoryTranslate_Category]
GO
ALTER TABLE [dbo].[CategoryTranslate]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTranslate_Language] FOREIGN KEY([LangCode])
REFERENCES [dbo].[Language] ([LangCode])
GO
ALTER TABLE [dbo].[CategoryTranslate] CHECK CONSTRAINT [FK_CategoryTranslate_Language]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Category] FOREIGN KEY([Categoryid])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Category]
GO
ALTER TABLE [dbo].[EventTranslate]  WITH CHECK ADD  CONSTRAINT [FK_EventTranslate_Event] FOREIGN KEY([Eventid])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[EventTranslate] CHECK CONSTRAINT [FK_EventTranslate_Event]
GO
ALTER TABLE [dbo].[EventTranslate]  WITH CHECK ADD  CONSTRAINT [FK_EventTranslate_Language] FOREIGN KEY([LangCode])
REFERENCES [dbo].[Language] ([LangCode])
GO
ALTER TABLE [dbo].[EventTranslate] CHECK CONSTRAINT [FK_EventTranslate_Language]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Event1] FOREIGN KEY([Articleid])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Event1]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Filetype1] FOREIGN KEY([Filetypeid])
REFERENCES [dbo].[Filetype] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Filetype1]
GO
ALTER TABLE [dbo].[ProgramTranslate]  WITH CHECK ADD  CONSTRAINT [FK_ProgramTranslate_Language] FOREIGN KEY([LangCode])
REFERENCES [dbo].[Language] ([LangCode])
GO
ALTER TABLE [dbo].[ProgramTranslate] CHECK CONSTRAINT [FK_ProgramTranslate_Language]
GO
ALTER TABLE [dbo].[ProgramTranslate]  WITH CHECK ADD  CONSTRAINT [FK_ProgramTranslate_Program] FOREIGN KEY([Programid])
REFERENCES [dbo].[Program] ([Id])
GO
ALTER TABLE [dbo].[ProgramTranslate] CHECK CONSTRAINT [FK_ProgramTranslate_Program]
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD  CONSTRAINT [FK_Series_Program] FOREIGN KEY([Programid])
REFERENCES [dbo].[Program] ([Id])
GO
ALTER TABLE [dbo].[Series] CHECK CONSTRAINT [FK_Series_Program]
GO
ALTER TABLE [dbo].[SeriesTranslate]  WITH CHECK ADD  CONSTRAINT [FK_SeriesTranslate_Language] FOREIGN KEY([LangCode])
REFERENCES [dbo].[Language] ([LangCode])
GO
ALTER TABLE [dbo].[SeriesTranslate] CHECK CONSTRAINT [FK_SeriesTranslate_Language]
GO
ALTER TABLE [dbo].[SeriesTranslate]  WITH CHECK ADD  CONSTRAINT [FK_SeriesTranslate_Series] FOREIGN KEY([Seriesid])
REFERENCES [dbo].[Series] ([Id])
GO
ALTER TABLE [dbo].[SeriesTranslate] CHECK CONSTRAINT [FK_SeriesTranslate_Series]
GO
USE [master]
GO
ALTER DATABASE [Artarea] SET  READ_WRITE 
GO
