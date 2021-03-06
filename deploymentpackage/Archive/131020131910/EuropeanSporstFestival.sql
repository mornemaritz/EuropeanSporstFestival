USE [master]
GO
/****** Object:  Database [EuropeanSportsFestival]    Script Date: 10/16/2013 19:10:51 ******/
CREATE DATABASE [EuropeanSportsFestival] ON  PRIMARY 
( NAME = N'EuropeanSportsFestival', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\EuropeanSportsFestival.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EuropeanSportsFestival_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\EuropeanSportsFestival_log.LDF' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EuropeanSportsFestival] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EuropeanSportsFestival].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EuropeanSportsFestival] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET ANSI_NULLS OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET ANSI_PADDING OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET ARITHABORT OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET AUTO_CLOSE ON
GO
ALTER DATABASE [EuropeanSportsFestival] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [EuropeanSportsFestival] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [EuropeanSportsFestival] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [EuropeanSportsFestival] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET  ENABLE_BROKER
GO
ALTER DATABASE [EuropeanSportsFestival] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [EuropeanSportsFestival] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [EuropeanSportsFestival] SET  READ_WRITE
GO
ALTER DATABASE [EuropeanSportsFestival] SET RECOVERY SIMPLE
GO
ALTER DATABASE [EuropeanSportsFestival] SET  MULTI_USER
GO
ALTER DATABASE [EuropeanSportsFestival] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [EuropeanSportsFestival] SET DB_CHAINING OFF
GO
USE [EuropeanSportsFestival]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TSport]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSport](
	[SportId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SportId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TParticipant]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TParticipant](
	[ParticipantId] [uniqueidentifier] NOT NULL,
	[EmailAddress] [nvarchar](255) NULL,
	[UserId] [int] NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ParticipantId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFestival]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFestival](
	[FestivalId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FestivalId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportHolding]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SportHolding](
	[SportId] [uniqueidentifier] NULL,
	[Sport] [varchar](12) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SportEventHolding]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SportEventHolding](
	[Sport Display Name] [varchar](33) NOT NULL,
	[Sport] [varchar](12) NOT NULL,
	[Day] [int] NOT NULL,
	[Start time] [varchar](8) NOT NULL,
	[End time] [varchar](8) NOT NULL,
	[Gender] [varchar](1) NOT NULL,
	[Team size min] [int] NOT NULL,
	[Team size max] [int] NOT NULL,
	[Min age] [int] NOT NULL,
	[Max age] [int] NOT NULL,
	[SportId] [uniqueidentifier] NULL,
	[ScheduledSportEventId] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TSportEventTeam]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSportEventTeam](
	[SportEventTeamId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[ScheduledSportEventId] [uniqueidentifier] NULL,
	[CaptainParticipantId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[SportEventTeamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TScheduledSportEventParticipant]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TScheduledSportEventParticipant](
	[ScheduledSportEventParticipantId] [uniqueidentifier] NOT NULL,
	[ScheduledSportEventId] [uniqueidentifier] NULL,
	[ParticipantId] [uniqueidentifier] NULL,
	[SportEventTeamId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduledSportEventParticipantId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TScheduledSportEvent]    Script Date: 10/16/2013 19:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TScheduledSportEvent](
	[ScheduledSportEventId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[AllowedGenders] [int] NULL,
	[MinAge] [int] NULL,
	[MaxAge] [int] NULL,
	[MinTeamSize] [int] NULL,
	[MaxTeamSize] [int] NULL,
	[Date] [datetime] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[FestivalId] [uniqueidentifier] NULL,
	[SportId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduledSportEventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__webpages___IsCon__0BC6C43E]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
/****** Object:  Default [DF__webpages___Passw__0CBAE877]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
/****** Object:  ForeignKey [fk_RoleId]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
/****** Object:  ForeignKey [fk_UserId]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
/****** Object:  ForeignKey [FK3D0D3F7FDFE0D740]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[TSportEventTeam]  WITH CHECK ADD  CONSTRAINT [FK3D0D3F7FDFE0D740] FOREIGN KEY([CaptainParticipantId])
REFERENCES [dbo].[TScheduledSportEventParticipant] ([ScheduledSportEventParticipantId])
GO
ALTER TABLE [dbo].[TSportEventTeam] CHECK CONSTRAINT [FK3D0D3F7FDFE0D740]
GO
/****** Object:  ForeignKey [FK3D0D3F7FFA4A3B]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[TSportEventTeam]  WITH CHECK ADD  CONSTRAINT [FK3D0D3F7FFA4A3B] FOREIGN KEY([ScheduledSportEventId])
REFERENCES [dbo].[TScheduledSportEvent] ([ScheduledSportEventId])
GO
ALTER TABLE [dbo].[TSportEventTeam] CHECK CONSTRAINT [FK3D0D3F7FFA4A3B]
GO
/****** Object:  ForeignKey [FK869CFD331958B92A]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD331958B92A] FOREIGN KEY([SportEventTeamId])
REFERENCES [dbo].[TSportEventTeam] ([SportEventTeamId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD331958B92A]
GO
/****** Object:  ForeignKey [FK869CFD335BF1606C]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD335BF1606C] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[TParticipant] ([ParticipantId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD335BF1606C]
GO
/****** Object:  ForeignKey [FK869CFD33FA4A3B]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD33FA4A3B] FOREIGN KEY([ScheduledSportEventId])
REFERENCES [dbo].[TScheduledSportEvent] ([ScheduledSportEventId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD33FA4A3B]
GO
/****** Object:  ForeignKey [FKFAFE8F1CB585E243]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[TScheduledSportEvent]  WITH CHECK ADD  CONSTRAINT [FKFAFE8F1CB585E243] FOREIGN KEY([SportId])
REFERENCES [dbo].[TSport] ([SportId])
GO
ALTER TABLE [dbo].[TScheduledSportEvent] CHECK CONSTRAINT [FKFAFE8F1CB585E243]
GO
/****** Object:  ForeignKey [FKFAFE8F1CD774B32C]    Script Date: 10/16/2013 19:10:53 ******/
ALTER TABLE [dbo].[TScheduledSportEvent]  WITH CHECK ADD  CONSTRAINT [FKFAFE8F1CD774B32C] FOREIGN KEY([FestivalId])
REFERENCES [dbo].[TFestival] ([FestivalId])
GO
ALTER TABLE [dbo].[TScheduledSportEvent] CHECK CONSTRAINT [FKFAFE8F1CD774B32C]
GO
