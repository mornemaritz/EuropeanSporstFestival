USE [EuropeanSportsFestival]
GO
/****** Object:  Table [dbo].[TTransportPickupPoint]    Script Date: 10/27/2013 16:32:22 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFestival]    Script Date: 10/27/2013 16:32:22 ******/
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
/****** Object:  Table [dbo].[TSport]    Script Date: 10/27/2013 16:32:22 ******/
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
/****** Object:  Table [dbo].[TParticipant]    Script Date: 10/27/2013 16:32:22 ******/
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
/****** Object:  Table [dbo].[TScheduledSportEvent]    Script Date: 10/27/2013 16:32:22 ******/
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
/****** Object:  Table [dbo].[TSportEventTeam]    Script Date: 10/27/2013 16:32:22 ******/
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
/****** Object:  Table [dbo].[TScheduledSportEventParticipant]    Script Date: 10/27/2013 16:32:22 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFestivalDay]    Script Date: 10/27/2013 16:32:22 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTransportRequest]    Script Date: 10/27/2013 16:32:22 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK44DB6D98D774B32C]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TFestivalDay]  WITH CHECK ADD  CONSTRAINT [FK44DB6D98D774B32C] FOREIGN KEY([FestivalId])
REFERENCES [dbo].[TFestival] ([FestivalId])
GO
ALTER TABLE [dbo].[TFestivalDay] CHECK CONSTRAINT [FK44DB6D98D774B32C]
GO
/****** Object:  ForeignKey [FKFAFE8F1CB585E243]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TScheduledSportEvent]  WITH CHECK ADD  CONSTRAINT [FKFAFE8F1CB585E243] FOREIGN KEY([SportId])
REFERENCES [dbo].[TSport] ([SportId])
GO
ALTER TABLE [dbo].[TScheduledSportEvent] CHECK CONSTRAINT [FKFAFE8F1CB585E243]
GO
/****** Object:  ForeignKey [FKFAFE8F1CD774B32C]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TScheduledSportEvent]  WITH CHECK ADD  CONSTRAINT [FKFAFE8F1CD774B32C] FOREIGN KEY([FestivalId])
REFERENCES [dbo].[TFestival] ([FestivalId])
GO
ALTER TABLE [dbo].[TScheduledSportEvent] CHECK CONSTRAINT [FKFAFE8F1CD774B32C]
GO
/****** Object:  ForeignKey [FK869CFD331958B92A]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD331958B92A] FOREIGN KEY([SportEventTeamId])
REFERENCES [dbo].[TSportEventTeam] ([SportEventTeamId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD331958B92A]
GO
/****** Object:  ForeignKey [FK869CFD335BF1606C]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD335BF1606C] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[TParticipant] ([ParticipantId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD335BF1606C]
GO
/****** Object:  ForeignKey [FK869CFD33FA4A3B]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TScheduledSportEventParticipant]  WITH CHECK ADD  CONSTRAINT [FK869CFD33FA4A3B] FOREIGN KEY([ScheduledSportEventId])
REFERENCES [dbo].[TScheduledSportEvent] ([ScheduledSportEventId])
GO
ALTER TABLE [dbo].[TScheduledSportEventParticipant] CHECK CONSTRAINT [FK869CFD33FA4A3B]
GO
/****** Object:  ForeignKey [FK3D0D3F7FDFE0D740]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TSportEventTeam]  WITH CHECK ADD  CONSTRAINT [FK3D0D3F7FDFE0D740] FOREIGN KEY([CaptainParticipantId])
REFERENCES [dbo].[TScheduledSportEventParticipant] ([ScheduledSportEventParticipantId])
GO
ALTER TABLE [dbo].[TSportEventTeam] CHECK CONSTRAINT [FK3D0D3F7FDFE0D740]
GO
/****** Object:  ForeignKey [FK3D0D3F7FFA4A3B]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TSportEventTeam]  WITH CHECK ADD  CONSTRAINT [FK3D0D3F7FFA4A3B] FOREIGN KEY([ScheduledSportEventId])
REFERENCES [dbo].[TScheduledSportEvent] ([ScheduledSportEventId])
GO
ALTER TABLE [dbo].[TSportEventTeam] CHECK CONSTRAINT [FK3D0D3F7FFA4A3B]
GO
/****** Object:  ForeignKey [FKFB0455795BF1606C]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TTransportRequest]  WITH CHECK ADD  CONSTRAINT [FKFB0455795BF1606C] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[TParticipant] ([ParticipantId])
GO
ALTER TABLE [dbo].[TTransportRequest] CHECK CONSTRAINT [FKFB0455795BF1606C]
GO
/****** Object:  ForeignKey [FKFB045579A6BE1FDB]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TTransportRequest]  WITH CHECK ADD  CONSTRAINT [FKFB045579A6BE1FDB] FOREIGN KEY([TransportPickupPointId])
REFERENCES [dbo].[TTransportPickupPoint] ([TransportPickupPointId])
GO
ALTER TABLE [dbo].[TTransportRequest] CHECK CONSTRAINT [FKFB045579A6BE1FDB]
GO
/****** Object:  ForeignKey [FKFB045579EC8DCF5F]    Script Date: 10/27/2013 16:32:22 ******/
ALTER TABLE [dbo].[TTransportRequest]  WITH CHECK ADD  CONSTRAINT [FKFB045579EC8DCF5F] FOREIGN KEY([FestivalDayId])
REFERENCES [dbo].[TFestivalDay] ([FestivalDayId])
GO
ALTER TABLE [dbo].[TTransportRequest] CHECK CONSTRAINT [FKFB045579EC8DCF5F]
GO
