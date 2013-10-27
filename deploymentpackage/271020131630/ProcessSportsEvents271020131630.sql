DECLARE @FestivalId UNIQUEIDENTIFIER = NEWID()
DECLARE @FestivalStartDate DATETIME = '2014-04-18 00:00:00.000'

INSERT TFestival(FestivalId,Name,StartDate)
SELECT @FestivalId, 'European Sports Festival 2014', @FestivalStartDate

INSERT TTransportPickupPoint(TransportPickupPointId, Name)
SELECT NEWID(), 'Ismaili Centre'
UNION ALL SELECT NEWID(), 'Victoria Station'

INSERT TFestivalDay(FestivalDayId,[Day],[Date], FestivalId)
SELECT
	NEWID(), 
	Src.[Day],
	DATEADD(day,Src.[Day] - 1,@FestivalStartDate),
	@FestivalId
FROM 
	(
	SELECT
		DISTINCT [Day] AS [Day]
	FROM
		SportEventHolding
	)Src

INSERT TSport(SportId,Name)
SELECT
	DISTINCT 
	SportId, 
	Sport
FROM 
	SportEventHolding 

INSERT [TScheduledSportEvent]
	(
		ScheduledSportEventId,
		Name,
		AllowedGenders,
		MinAge,
		MaxAge,
		MinTeamSize,
		MaxTeamSize,
		[Date],
		StartTime,
		EndTime,
		FestivalId,
		SportId
	)
SELECT
	ScheduledSportEventId,
	[Sport Display Name],
	CASE 
		WHEN Gender = 'B' THEN 3
		WHEN Gender = 'F' THEN 2
		WHEN Gender = 'M' THEN 1
	END AS AllowedGenders,
	[Min age],
	[Max age],
	[Team size min],
	[Team size max],
	DATEADD(day,[Day] - 1,@FestivalStartDate),
	[Start Time],
	[End Time],
	@FestivalId,
	SportId
FROM
	SportEventHolding

