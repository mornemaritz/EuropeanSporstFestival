DECLARE @FestivalId UNIQUEIDENTIFIER = NEWID()
DECLARE @FestivalStartDate DATETIME = '2014-04-18 00:00:00.000'

INSERT TFestival(FestivalId,Name,StartDate)
SELECT @FestivalId, 'European Sports Festival 2014', @FestivalStartDate

INSERT TTransportPickupPoint(TransportPickupPointId, Name)
SELECT NEWID(), 'Birmingham'
UNION ALL SELECT NEWID(), 'Bolton'
UNION ALL SELECT NEWID(), 'Bournemouth'
UNION ALL SELECT NEWID(), 'Brighton'
UNION ALL SELECT NEWID(), 'Bristol'
UNION ALL SELECT NEWID(), 'Burnley'
UNION ALL SELECT NEWID(), 'Cambridge'
UNION ALL SELECT NEWID(), 'Cardiff'
UNION ALL SELECT NEWID(), 'Chelmsford'
UNION ALL SELECT NEWID(), 'Chester'
UNION ALL SELECT NEWID(), 'Coventry'
UNION ALL SELECT NEWID(), 'Crawley'
UNION ALL SELECT NEWID(), 'Darkhana'
UNION ALL SELECT NEWID(), 'East London'
UNION ALL SELECT NEWID(), 'Eastbourne / Hastings'
UNION ALL SELECT NEWID(), 'Edinburgh'
UNION ALL SELECT NEWID(), 'Glasgow'
UNION ALL SELECT NEWID(), 'Gloucester'
UNION ALL SELECT NEWID(), 'Grantham'
UNION ALL SELECT NEWID(), 'Guildford'
UNION ALL SELECT NEWID(), 'Hatfield'
UNION ALL SELECT NEWID(), 'Leeds / Bradford'
UNION ALL SELECT NEWID(), 'Leicester'
UNION ALL SELECT NEWID(), 'Liverpool'
UNION ALL SELECT NEWID(), 'Manchester'
UNION ALL SELECT NEWID(), 'Milton Keynes'
UNION ALL SELECT NEWID(), 'Newcastle'
UNION ALL SELECT NEWID(), 'North London'
UNION ALL SELECT NEWID(), 'Northampton'
UNION ALL SELECT NEWID(), 'Northwest'
UNION ALL SELECT NEWID(), 'Nottingham'
UNION ALL SELECT NEWID(), 'Oxford'
UNION ALL SELECT NEWID(), 'Peterborough'
UNION ALL SELECT NEWID(), 'Preston'
UNION ALL SELECT NEWID(), 'Reading'
UNION ALL SELECT NEWID(), 'Sheffield'
UNION ALL SELECT NEWID(), 'South East London'
UNION ALL SELECT NEWID(), 'South London'
UNION ALL SELECT NEWID(), 'South West London'
UNION ALL SELECT NEWID(), 'Southampton'
UNION ALL SELECT NEWID(), 'Stoke On Trent'
UNION ALL SELECT NEWID(), 'Swindon'
UNION ALL SELECT NEWID(), 'West London'



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

