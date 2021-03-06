USE [master]
GO
CREATE LOGIN [web] WITH PASSWORD=N'password1', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
EXEC master..sp_addsrvrolemember @loginame = N'web', @rolename = N'sysadmin'
GO
/****** Object:  Database [EuropeanSportsFestival]    Script Date: 23/12/2013 18:11:06 ******/
CREATE DATABASE [EuropeanSportsFestival]
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
ALTER DATABASE [EuropeanSportsFestival] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [EuropeanSportsFestival] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EuropeanSportsFestival] SET  MULTI_USER 
GO
ALTER DATABASE [EuropeanSportsFestival] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EuropeanSportsFestival] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EuropeanSportsFestival', N'ON'
GO
USE [EuropeanSportsFestival]
GO
/****** Object:  User [web]    Script Date: 23/12/2013 18:11:06 ******/
CREATE USER [web] FOR LOGIN [web] WITH DEFAULT_SCHEMA=[dbo]
GO
EXEC sp_addrolemember N'db_owner', N'web'
GO
/****** Object:  Table [dbo].[TCountry]    Script Date: 23/12/2013 18:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCountry](
	[CountryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TCounty]    Script Date: 23/12/2013 18:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCounty](
	[CountyId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TFestival]    Script Date: 23/12/2013 18:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFestival](
	[FestivalId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[MorningStartTime] [time](7) NULL,
	[AfternoonStartTime] [time](7) NULL,
	[EveningStartTime] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[FestivalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TFestivalDay]    Script Date: 23/12/2013 18:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFestivalDay](
	[FestivalDayId] [uniqueidentifier] NOT NULL,
	[Day] [int] NULL,
	[Date] [datetime] NULL,
	[FestivalId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[FestivalDayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TJamatkhana]    Script Date: 23/12/2013 18:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TJamatkhana](
	[JamatkhanaId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Area] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[JamatkhanaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TParticipant]    Script Date: 23/12/2013 18:11:06 ******/
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
	[Gender] [nvarchar](255) NULL,
	[MobileNumber] [nvarchar](255) NULL,
	[HomePhoneNumber] [nvarchar](255) NULL,
	[AddressLine1] [nvarchar](255) NULL,
	[AddressLine2] [nvarchar](255) NULL,
	[AddressLine3] [nvarchar](255) NULL,
	[AddressLine4] [nvarchar](255) NULL,
	[Town] [nvarchar](255) NULL,
	[Postcode] [nvarchar](255) NULL,
	[HasDisability] [nvarchar](255) NULL,
	[IsInterestedInVolunteering] [bit] NULL,
	[JamatkhanaId] [uniqueidentifier] NULL,
	[CountyId] [uniqueidentifier] NULL,
	[CountryId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ParticipantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TScheduledSportEvent]    Script Date: 23/12/2013 18:11:06 ******/
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
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[Date] [datetime] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[FestivalId] [uniqueidentifier] NULL,
	[SportId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduledSportEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TScheduledSportEventParticipant]    Script Date: 23/12/2013 18:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TScheduledSportEventParticipant](
	[ScheduledSportEventParticipantId] [uniqueidentifier] NOT NULL,
	[TeamAllocationStatus] [nvarchar](255) NULL,
	[ScheduledSportEventId] [uniqueidentifier] NULL,
	[ParticipantId] [uniqueidentifier] NULL,
	[SportEventTeamId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduledSportEventParticipantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSport]    Script Date: 23/12/2013 18:11:06 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSportEventTeam]    Script Date: 23/12/2013 18:11:06 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTransportPickupPoint]    Script Date: 23/12/2013 18:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTransportPickupPoint](
	[TransportPickupPointId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TransportPickupPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTransportRequest]    Script Date: 23/12/2013 18:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTransportRequest](
	[TransportRequestId] [uniqueidentifier] NOT NULL,
	[ParticipantId] [uniqueidentifier] NULL,
	[FestivalDayId] [uniqueidentifier] NULL,
	[TransportPickupPointId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransportRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 23/12/2013 18:11:06 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 23/12/2013 18:11:06 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 23/12/2013 18:11:06 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 23/12/2013 18:11:06 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 23/12/2013 18:11:06 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[TFestivalDay]  WITH CHECK ADD  CONSTRAINT [FK44DB6D98D774B32C] FOREIGN KEY([FestivalId])
REFERENCES [dbo].[TFestival] ([FestivalId])
GO
ALTER TABLE [dbo].[TFestivalDay] CHECK CONSTRAINT [FK44DB6D98D774B32C]
GO
ALTER TABLE [dbo].[TParticipant]  WITH CHECK ADD  CONSTRAINT [FKD2AF9DAA33DC2A16] FOREIGN KEY([CountryId])
REFERENCES [dbo].[TCountry] ([CountryId])
GO
ALTER TABLE [dbo].[TParticipant] CHECK CONSTRAINT [FKD2AF9DAA33DC2A16]
GO
ALTER TABLE [dbo].[TParticipant]  WITH CHECK ADD  CONSTRAINT [FKD2AF9DAA9BCE56C3] FOREIGN KEY([JamatkhanaId])
REFERENCES [dbo].[TJamatkhana] ([JamatkhanaId])
GO
ALTER TABLE [dbo].[TParticipant] CHECK CONSTRAINT [FKD2AF9DAA9BCE56C3]
GO
ALTER TABLE [dbo].[TParticipant]  WITH CHECK ADD  CONSTRAINT [FKD2AF9DAAD7FDB598] FOREIGN KEY([CountyId])
REFERENCES [dbo].[TCounty] ([CountyId])
GO
ALTER TABLE [dbo].[TParticipant] CHECK CONSTRAINT [FKD2AF9DAAD7FDB598]
GO
ALTER TABLE [dbo].[TScheduledSportEvent]  WITH CHECK ADD  CONSTRAINT [FKFAFE8F1CB585E243] FOREIGN KEY([SportId])
REFERENCES [dbo].[TSport] ([SportId])
GO
ALTER TABLE [dbo].[TScheduledSportEvent] CHECK CONSTRAINT [FKFAFE8F1CB585E243]
GO
ALTER TABLE [dbo].[TScheduledSportEvent]  WITH CHECK ADD  CONSTRAINT [FKFAFE8F1CD774B32C] FOREIGN KEY([FestivalId])
REFERENCES [dbo].[TFestival] ([FestivalId])
GO
ALTER TABLE [dbo].[TScheduledSportEvent] CHECK CONSTRAINT [FKFAFE8F1CD774B32C]
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD331958B92A] FOREIGN KEY([SportEventTeamId])
REFERENCES [dbo].[TSportEventTeam] ([SportEventTeamId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD331958B92A]
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD335BF1606C] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[TParticipant] ([ParticipantId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD335BF1606C]
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD33FA4A3B] FOREIGN KEY([ScheduledSportEventId])
REFERENCES [dbo].[TScheduledSportEvent] ([ScheduledSportEventId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD33FA4A3B]
GO
ALTER TABLE [dbo].[TSportEventTeam]  WITH CHECK ADD  CONSTRAINT [FK3D0D3F7FDFE0D740] FOREIGN KEY([CaptainParticipantId])
REFERENCES [dbo].[TScheduledSportEventParticipant] ([ScheduledSportEventParticipantId])
GO
ALTER TABLE [dbo].[TSportEventTeam] CHECK CONSTRAINT [FK3D0D3F7FDFE0D740]
GO
ALTER TABLE [dbo].[TSportEventTeam]  WITH CHECK ADD  CONSTRAINT [FK3D0D3F7FFA4A3B] FOREIGN KEY([ScheduledSportEventId])
REFERENCES [dbo].[TScheduledSportEvent] ([ScheduledSportEventId])
GO
ALTER TABLE [dbo].[TSportEventTeam] CHECK CONSTRAINT [FK3D0D3F7FFA4A3B]
GO
ALTER TABLE [dbo].[TTransportRequest]  WITH CHECK ADD  CONSTRAINT [FKFB0455795BF1606C] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[TParticipant] ([ParticipantId])
GO
ALTER TABLE [dbo].[TTransportRequest] CHECK CONSTRAINT [FKFB0455795BF1606C]
GO
ALTER TABLE [dbo].[TTransportRequest]  WITH CHECK ADD  CONSTRAINT [FKFB045579A6BE1FDB] FOREIGN KEY([TransportPickupPointId])
REFERENCES [dbo].[TTransportPickupPoint] ([TransportPickupPointId])
GO
ALTER TABLE [dbo].[TTransportRequest] CHECK CONSTRAINT [FKFB045579A6BE1FDB]
GO
ALTER TABLE [dbo].[TTransportRequest]  WITH CHECK ADD  CONSTRAINT [FKFB045579EC8DCF5F] FOREIGN KEY([FestivalDayId])
REFERENCES [dbo].[TFestivalDay] ([FestivalDayId])
GO
ALTER TABLE [dbo].[TTransportRequest] CHECK CONSTRAINT [FKFB045579EC8DCF5F]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
USE [master]
GO
ALTER DATABASE [EuropeanSportsFestival] SET  READ_WRITE 
GO
