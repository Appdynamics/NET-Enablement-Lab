USE [master]
GO
/****** Object:  Database [DevicesDemo]    Script Date: 12/21/16 2:07:31 PM ******/
CREATE DATABASE [DevicesDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DevicesDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\DevicesDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DevicesDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\DevicesDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DevicesDemo] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DevicesDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DevicesDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DevicesDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DevicesDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DevicesDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DevicesDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [DevicesDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DevicesDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DevicesDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DevicesDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DevicesDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DevicesDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DevicesDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DevicesDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DevicesDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DevicesDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DevicesDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DevicesDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DevicesDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DevicesDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DevicesDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DevicesDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DevicesDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DevicesDemo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DevicesDemo] SET  MULTI_USER 
GO
ALTER DATABASE [DevicesDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DevicesDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DevicesDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DevicesDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DevicesDemo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DevicesDemo] SET QUERY_STORE = OFF
GO
USE [DevicesDemo]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DevicesDemo]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[jobid] [int] IDENTITY(1,1) NOT NULL,
	[guid] [nchar](100) NOT NULL,
	[status] [int] NOT NULL,
	[type] [nchar](100) NOT NULL,
	[data] [text] NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[jobid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [NonClusteredIndex-20161122-203800]    Script Date: 12/21/16 2:07:32 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20161122-203800] ON [dbo].[Jobs]
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Authenticate]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Authenticate] (@userId nvarchar(255), @code int )
AS

-- Convert ms to timespan for delay 

DECLARE @t as varchar(255)
SET @t = CONVERT(varchar, DATEADD(ms, @code , 0), 114)
WAITFOR DELAY @t

-- Return current data, who cares...
SELECT GetDate()


GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDevicesForUser]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllDevicesForUser] (@userId nvarchar(255), @code int )
AS

-- Convert ms to timespan for delay 

DECLARE @t as varchar(255)
SET @t = CONVERT(varchar, DATEADD(ms, @code , 0), 114)
WAITFOR DELAY @t

-- Return current data, who cares...
SELECT GetDate()


GO
/****** Object:  StoredProcedure [dbo].[sp_GetDeviceDetails]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_GetDeviceDetails] (@userId nvarchar(255), @deviceId nvarchar(255), @code int )
AS

-- Convert ms to timespan for delay 

DECLARE @t as varchar(255)
SET @t = CONVERT(varchar, DATEADD(ms, @code , 0), 114)
WAITFOR DELAY @t

-- Return current data, who cares...
SELECT GetDate()


GO
/****** Object:  StoredProcedure [dbo].[sp_GetDeviceSettings]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_GetDeviceSettings] (@userId nvarchar(255), @deviceId nvarchar(255), @code int )
AS

-- Convert ms to timespan for delay 

DECLARE @t as varchar(255)
SET @t = CONVERT(varchar, DATEADD(ms, @code , 0), 114)
WAITFOR DELAY @t

-- Return current data, who cares...
SELECT GetDate()


GO
/****** Object:  StoredProcedure [dbo].[sp_LogError]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_LogError] (@error text, @message nvarchar(255) )
AS


-- Return current data, who cares...
SELECT GetDate()


GO
/****** Object:  StoredProcedure [dbo].[sp_ScheduleReport]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ScheduleReport] (@type nvarchar(255), @code int )
AS

-- Convert ms to timespan for delay 

DECLARE @t as varchar(255)
SET @t = CONVERT(varchar, DATEADD(ms, @code , 0), 114)
WAITFOR DELAY @t

-- Return current data, who cares...
SELECT GetDate()


GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDeviceSettings]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_UpdateDeviceSettings] (@userId nvarchar(255), @deviceId nvarchar(255), @code int )
AS

-- Convert ms to timespan for delay 

DECLARE @t as varchar(255)
SET @t = CONVERT(varchar, DATEADD(ms, @code , 0), 114)
WAITFOR DELAY @t

-- Return current data, who cares...
SELECT GetDate()


GO
/****** Object:  StoredProcedure [dbo].[sp_ValidateUserAccess]    Script Date: 12/21/16 2:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ValidateUserAccess] (@userId nvarchar(255), @code int )
AS

-- Convert ms to timespan for delay 

DECLARE @t as varchar(255)
SET @t = CONVERT(varchar, DATEADD(ms, @code , 0), 114)
WAITFOR DELAY @t

-- Return current data, who cares...
SELECT GetDate()


GO
USE [master]
GO
ALTER DATABASE [DevicesDemo] SET  READ_WRITE 
GO
