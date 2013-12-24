DECLARE @FestivalId UNIQUEIDENTIFIER = NEWID()

INSERT TFestival(FestivalId,Name,StartDate)
SELECT @FestivalId, 'European Sports Festival 2013', '2013-11-01 00:00:00.000'

INSERT TSportEvent(SportEventId,Name,Gender)
SELECT SportEventId, Sport, Gender
FROM SportEventAndShedule

INSERT [TScheduledSportEvent]
           ([ScheduledSportEventId]
           ,[Date]
           ,[StartTime]
           ,[EndTime]
           ,[FestivalId]
           ,[SportEventId])
SELECT
	NEWID(),
	[Date],
	StartTime,
	EndTime,
	@FestivalId,
	SportEventId
FROM
	SportEventAndShedule

