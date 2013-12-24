--INSERT INTO TSportEvent(SportEventId, Name,Gender)
SELECT
	NEWID() AS SportEventId,
	Sport,
	CASE 
		WHEN CHARINDEX('Men',Sport,0) != 0 THEN 1
		WHEN CHARINDEX('Ladies',Sport,0) != 0 THEN 2
		WHEN CHARINDEX('Boy',Sport,0) != 0 THEN 1
		WHEN CHARINDEX('Girl',Sport,0) != 0 THEN 2
		ELSE NULL
	END AS Gender,
	[Day],
	CASE 
		WHEN CHARINDEX('Friday',[Day],0) = 1 THEN '2013-11-01 00:00:00.000' 
		WHEN CHARINDEX('Saturday',[Day],0) = 1 THEN '2013-11-02 00:00:00.000' 
		WHEN CHARINDEX('Sunday',[Day],0) = 1 THEN '2013-11-03 00:00:00.000' 
	END AS [Date],
	[Time],
	CASE 
		WHEN CHARINDEX('All',[Time],0) != 0 THEN CONVERT(TIME,'07:30:00')
		WHEN ISNULL([Time],'') = '' THEN CONVERT(TIME,'07:30:00')
		ELSE CONVERT(TIME,LEFT([Time],2)+':'+SUBSTRING([Time],3,2)+':00')
	END AS StartTime,
	CASE 
		WHEN CHARINDEX('All',[Time],0) != 0 THEN CONVERT(TIME,'17:30:00')
		WHEN ISNULL([Time],'') = '' THEN CONVERT(TIME,'17:30:00')
		ELSE CONVERT(TIME,SUBSTRING([Time],8,2)+':'+RIGHT([Time],2)+':00')
	END AS EndTime
INTO
	SportEventAndShedule
FROM 
	EventHolding
