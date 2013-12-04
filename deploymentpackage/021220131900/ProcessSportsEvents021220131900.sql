DECLARE @FestivalId UNIQUEIDENTIFIER = NEWID()
DECLARE @FestivalStartDate DATETIME = '2014-04-18 00:00:00.000'

INSERT TFestival(FestivalId,Name,StartDate,MorningStartTime,AfternoonStartTime,EveningStartTime)
SELECT @FestivalId, 'European Sports Festival 2014', @FestivalStartDate, '00:00:00', '12:00:00', '18:00:00'

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

INSERT TCounty(CountyId, Name)
SELECT NEWID(), 'Essex'
UNION ALL SELECT NEWID(), 'Wessex'
UNION ALL SELECT NEWID(), 'Sussex'
UNION ALL SELECT NEWID(), 'Greater London'
UNION ALL SELECT NEWID(), 'Surrey'
UNION ALL SELECT NEWID(), 'Kent'
UNION ALL SELECT NEWID(), 'NotApplicable'

INSERT TCountry(CountryId, Name)
SELECT NEWID(), 'United Kingdom'
UNION ALL SELECT NEWID(), 'Germany'
UNION ALL SELECT NEWID(), 'Italy'
UNION ALL SELECT NEWID(), 'France'

INSERT TJamatkhana(JamatkhanaId, Name, Area)
SELECT NEWID(), 'Amsterdam', 'European'
UNION ALL SELECT NEWID(), 'Austria', 'European'
UNION ALL SELECT NEWID(), 'Bad Salzuflen', 'European'
UNION ALL SELECT NEWID(), 'Berlin', 'European'
UNION ALL SELECT NEWID(), 'Birmingham', 'UK'
UNION ALL SELECT NEWID(), 'Bolton', 'UK'
UNION ALL SELECT NEWID(), 'Bournemouth', 'UK'
UNION ALL SELECT NEWID(), 'Brighton', 'UK'
UNION ALL SELECT NEWID(), 'Bristol', 'UK'
UNION ALL SELECT NEWID(), 'Burnley', 'UK'
UNION ALL SELECT NEWID(), 'Bösel', 'European'
UNION ALL SELECT NEWID(), 'Cambridge', 'UK'
UNION ALL SELECT NEWID(), 'Cardiff', 'UK'
UNION ALL SELECT NEWID(), 'Chelmsford', 'UK'
UNION ALL SELECT NEWID(), 'Chester', 'UK'
UNION ALL SELECT NEWID(), 'Copenhagen', 'European'
UNION ALL SELECT NEWID(), 'Coventry', 'UK'
UNION ALL SELECT NEWID(), 'Crawley', 'UK'
UNION ALL SELECT NEWID(), 'Darkhana', 'UK'
UNION ALL SELECT NEWID(), 'Dublin', 'European'
UNION ALL SELECT NEWID(), 'East London', 'UK'
UNION ALL SELECT NEWID(), 'Eastbourne / Hastings', 'UK'
UNION ALL SELECT NEWID(), 'Edinburgh', 'UK'
UNION ALL SELECT NEWID(), 'Eindhoven', 'European'
UNION ALL SELECT NEWID(), 'Essen', 'European'
UNION ALL SELECT NEWID(), 'Finland', 'European'
UNION ALL SELECT NEWID(), 'Frankfurt', 'European'
UNION ALL SELECT NEWID(), 'Glasgow', 'UK'
UNION ALL SELECT NEWID(), 'Gloucester', 'UK'
UNION ALL SELECT NEWID(), 'Gothenburg', 'European'
UNION ALL SELECT NEWID(), 'Grantham', 'UK'
UNION ALL SELECT NEWID(), 'Guildford', 'UK'
UNION ALL SELECT NEWID(), 'Hamburg', 'European'
UNION ALL SELECT NEWID(), 'Hatfield', 'UK'
UNION ALL SELECT NEWID(), 'Italy', 'European'
UNION ALL SELECT NEWID(), 'Leeds / Bradford', 'UK'
UNION ALL SELECT NEWID(), 'Leicester', 'UK'
UNION ALL SELECT NEWID(), 'Liverpool', 'UK'
UNION ALL SELECT NEWID(), 'Ljungby', 'European'
UNION ALL SELECT NEWID(), 'Manchester', 'UK'
UNION ALL SELECT NEWID(), 'Mariestad', 'European'
UNION ALL SELECT NEWID(), 'Milton Keynes', 'UK'
UNION ALL SELECT NEWID(), 'Motala', 'European'
UNION ALL SELECT NEWID(), 'Munich', 'European'
UNION ALL SELECT NEWID(), 'Newcastle', 'UK'
UNION ALL SELECT NEWID(), 'North London', 'UK'
UNION ALL SELECT NEWID(), 'Northampton', 'UK'
UNION ALL SELECT NEWID(), 'Northwest', 'UK'
UNION ALL SELECT NEWID(), 'Nottingham', 'UK'
UNION ALL SELECT NEWID(), 'Oslo', 'European'
UNION ALL SELECT NEWID(), 'Oxford', 'UK'
UNION ALL SELECT NEWID(), 'Peterborough', 'UK'
UNION ALL SELECT NEWID(), 'Preston', 'UK'
UNION ALL SELECT NEWID(), 'Reading', 'UK'
UNION ALL SELECT NEWID(), 'Sheffield', 'UK'
UNION ALL SELECT NEWID(), 'South East London', 'UK'
UNION ALL SELECT NEWID(), 'South London', 'UK'
UNION ALL SELECT NEWID(), 'South West London', 'UK'
UNION ALL SELECT NEWID(), 'Southampton', 'UK'
UNION ALL SELECT NEWID(), 'Stockholm', 'European'
UNION ALL SELECT NEWID(), 'Stoke On Trent', 'UK'
UNION ALL SELECT NEWID(), 'Swindon', 'UK'
UNION ALL SELECT NEWID(), 'West London', 'UK'
UNION ALL SELECT NEWID(), 'Zevenaar', 'European'


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
		StartDateTime,
		EndDateTime,
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
	CONVERT(DATETIME,CONVERT(VARCHAR(12),DATEADD(day,[Day] - 1,@FestivalStartDate)) + CONVERT(VARCHAR(8),[Start Time]))  AS StartDateTime,
	CONVERT(DATETIME,CONVERT(VARCHAR(12),DATEADD(day,[Day] - 1,@FestivalStartDate)) + CONVERT(VARCHAR(8),[End Time]))  AS EndDateTime,
	DATEADD(day,[Day] - 1,@FestivalStartDate) AS [Date],
	[Start Time],
	[End Time],
	@FestivalId,
	SportId
FROM
	SportEventHolding

INSERT TScheduledSportEventOverLap
	(
		ScheduledSportEventOverLapId,
		ScheduledSportEventId,
		OverLappingScheduledSportEventId
	)
SELECT
	NEWID(),
	Main.ScheduledSportEventId,
	OverLapping.ScheduledSportEventId AS OverLappingScheduledSportEventId
FROM
	[TScheduledSportEvent] Main
	JOIN [TScheduledSportEvent] OverLapping ON OverLapping.ScheduledSportEventId != Main.ScheduledSportEventId
		AND OverLapping.[Date] = Main.[Date]
		AND (OverLapping.StartDateTime  < Main.EndDateTime OR OverLapping.EndDateTime > Main.StartDateTime)
	


