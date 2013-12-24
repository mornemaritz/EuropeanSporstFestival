SELECT * INTO SportEventHolding FROM
(
SELECT 'Mixed Doubles badminton' AS [Sport Display Name], 'Badminton' AS [Sport], 1 AS [Day], '12:30:00' AS [Start time], '17:30:00' AS [End time], 'B' AS [Gender], 2 AS [Team size min], 2 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Under 14s dance' AS [Sport Display Name], 'Dance' AS [Sport], 1 AS [Day], '10:00:00' AS [Start time], '17:30:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 5 AS [Team size max], 0 AS [Min age], 13 AS [Max age]
UNION ALL SELECT 'Over 14s dance' AS [Sport Display Name], 'Dance' AS [Sport], 1 AS [Day], '10:00:00' AS [Start time], '17:30:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 5 AS [Team size max], 14 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Under 9''s football*' AS [Sport Display Name], 'Football' AS [Sport], 1 AS [Day], '10:30:00' AS [Start time], '12:30:00' AS [End time], 'B' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 8 AS [Max age]
UNION ALL SELECT 'Under 12''s football*' AS [Sport Display Name], 'Football' AS [Sport], 1 AS [Day], '08:00:00' AS [Start time], '12:30:00' AS [End time], 'B' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 11 AS [Max age]
UNION ALL SELECT 'Under 16''s football' AS [Sport Display Name], 'Football' AS [Sport], 1 AS [Day], '08:00:00' AS [Start time], '11:00:00' AS [End time], 'B' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'Ladies basketball' AS [Sport Display Name], 'Basketball' AS [Sport], 1 AS [Day], '12:30:00' AS [Start time], '17:30:00' AS [End time], 'F' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s basketball' AS [Sport Display Name], 'Basketball' AS [Sport], 1 AS [Day], '12:30:00' AS [Start time], '17:30:00' AS [End time], 'M' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s singles table tennis' AS [Sport Display Name], 'Table Tennis' AS [Sport], 1 AS [Day], '12:30:00' AS [Start time], '18:00:00' AS [End time], 'M' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Athletics' AS [Sport Display Name], 'Athletics' AS [Sport], 1 AS [Day], '12:30:00' AS [Start time], '16:00:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Golf' AS [Sport Display Name], 'Golf' AS [Sport], 1 AS [Day], '08:00:00' AS [Start time], '22:00:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Dodgeball' AS [Sport Display Name], 'Dodgeball' AS [Sport], 1 AS [Day], '19:30:00' AS [Start time], '22:30:00' AS [End time], 'B' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Ladies Doubles badminton' AS [Sport Display Name], 'Badminton' AS [Sport], 2 AS [Day], '08:00:00' AS [Start time], '12:30:00' AS [End time], 'F' AS [Gender], 2 AS [Team size min], 2 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s Doubles badminton' AS [Sport Display Name], 'Badminton' AS [Sport], 2 AS [Day], '08:00:00' AS [Start time], '13:00:00' AS [End time], 'M' AS [Gender], 2 AS [Team size min], 2 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Ladies football' AS [Sport Display Name], 'Football' AS [Sport], 2 AS [Day], '11:30:00' AS [Start time], '13:00:00' AS [End time], 'F' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Under 16s netball' AS [Sport Display Name], 'Netball' AS [Sport], 2 AS [Day], '08:00:00' AS [Start time], '12:30:00' AS [End time], 'F' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'Under 16''s Athletics' AS [Sport Display Name], 'Athletics' AS [Sport], 2 AS [Day], '13:30:00' AS [Start time], '17:30:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'Mixed Netball' AS [Sport Display Name], 'Netball' AS [Sport], 2 AS [Day], '08:00:00' AS [Start time], '12:30:00' AS [End time], 'B' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s squash' AS [Sport Display Name], 'Squash' AS [Sport], 2 AS [Day], '08:00:00' AS [Start time], '13:00:00' AS [End time], 'M' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s Cricket (all day)' AS [Sport Display Name], 'Cricket' AS [Sport], 2 AS [Day], '08:00:00' AS [Start time], '18:30:00' AS [End time], 'M' AS [Gender], 11 AS [Team size min], 15 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Under 16s singles table tennis' AS [Sport Display Name], 'Table Tennis' AS [Sport], 2 AS [Day], '13:30:00' AS [Start time], '17:30:00' AS [End time], 'B' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'Under 16''s Gymnastics' AS [Sport Display Name], 'Gymnastics' AS [Sport], 2 AS [Day], '13:30:00' AS [Start time], '17:30:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'Mixed International Volleyball' AS [Sport Display Name], 'Vollyball' AS [Sport], 2 AS [Day], '13:30:00' AS [Start time], '18:15:00' AS [End time], 'B' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Mixed Doubles tennis' AS [Sport Display Name], 'Tennis' AS [Sport], 2 AS [Day], '13:00:00' AS [Start time], '17:30:00' AS [End time], 'B' AS [Gender], 2 AS [Team size min], 2 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s over 35''s football*' AS [Sport Display Name], 'Football' AS [Sport], 2 AS [Day], '14:00:00' AS [Start time], '16:30:00' AS [End time], 'M' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 35 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Over 45''s Mixed Doubles Badminton' AS [Sport Display Name], 'Badminton' AS [Sport], 2 AS [Day], '13:30:00' AS [Start time], '17:00:00' AS [End time], 'B' AS [Gender], 2 AS [Team size min], 2 AS [Team size max], 45 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Rounders' AS [Sport Display Name], 'Rounders' AS [Sport], 2 AS [Day], '13:30:00' AS [Start time], '17:30:00' AS [End time], 'B' AS [Gender], 7 AS [Team size min], 12 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Ladies netball' AS [Sport Display Name], 'Netball' AS [Sport], 3 AS [Day], '08:30:00' AS [Start time], '16:30:00' AS [End time], 'F' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s football' AS [Sport Display Name], 'Football' AS [Sport], 3 AS [Day], '08:00:00' AS [Start time], '17:45:00' AS [End time], 'M' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s Traditional volleyball' AS [Sport Display Name], 'Vollyball' AS [Sport], 3 AS [Day], '07:30:00' AS [Start time], '17:45:00' AS [End time], 'M' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Cycling' AS [Sport Display Name], 'Cycling' AS [Sport], 3 AS [Day], '08:00:00' AS [Start time], '22:00:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Men''s doubles tennis' AS [Sport Display Name], 'Tennis' AS [Sport], 3 AS [Day], '08:00:00' AS [Start time], '17:30:00' AS [End time], 'M' AS [Gender], 2 AS [Team size min], 2 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Under 16s singles tennis' AS [Sport Display Name], 'Tennis' AS [Sport], 3 AS [Day], '08:00:00' AS [Start time], '13:00:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'Under 12s swimming' AS [Sport Display Name], 'Swimming' AS [Sport], 3 AS [Day], '09:00:00' AS [Start time], '12:00:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 11 AS [Max age]
UNION ALL SELECT 'Ladies singles table tennis' AS [Sport Display Name], 'Table Tennis' AS [Sport], 3 AS [Day], '09:30:00' AS [Start time], '13:30:00' AS [End time], 'F' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Over 45s table tennis' AS [Sport Display Name], 'Table Tennis' AS [Sport], 3 AS [Day], '10:30:00' AS [Start time], '16:00:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 45 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Ladies Squash' AS [Sport Display Name], 'Squash' AS [Sport], 3 AS [Day], '13:30:00' AS [Start time], '16:30:00' AS [End time], 'F' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
UNION ALL SELECT 'Boys under 16s singles badminton' AS [Sport Display Name], 'Badminton' AS [Sport], 3 AS [Day], '12:00:00' AS [Start time], '17:30:00' AS [End time], 'M' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'Girls under 16s singles badminton' AS [Sport Display Name], 'Badminton' AS [Sport], 3 AS [Day], '12:00:00' AS [Start time], '17:30:00' AS [End time], 'F' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'Under 16s Dodgeball' AS [Sport Display Name], 'Dodgeball' AS [Sport], 3 AS [Day], '13:30:00' AS [Start time], '16:30:00' AS [End time], 'B' AS [Gender], 5 AS [Team size min], 10 AS [Team size max], 0 AS [Min age], 15 AS [Max age]
UNION ALL SELECT 'BUI Interhouse Sports Combo' AS [Sport Display Name], 'Interhouse' AS [Sport], 3 AS [Day], '13:30:00' AS [Start time], '16:30:00' AS [End time], 'B' AS [Gender], 1 AS [Team size min], 1 AS [Team size max], 0 AS [Min age], 150 AS [Max age]
) src

-- Add Id column for the sport and sport event.
ALTER TABLE SportEventHolding ADD SportId UNIQUEIDENTIFIER, ScheduledSportEventId  UNIQUEIDENTIFIER

-- Select distinct sports into a holding table while generating an id for each
SELECT NEWID() AS SportId, Sport INTO SportHolding 
FROM 
	(SELECT DISTINCT Sport FROM SportEventHolding) SpSrc

-- Update the main holding table with the sport id
UPDATE
	SEH
SET
	SEH.SportId = IdSrc.SportId
FROM
	SportEventHolding SEH
	JOIN SportHolding IdSrc ON IdSrc.Sport = SEH.Sport

-- Generate Ids for the sport events
UPDATE SportEventHolding SET ScheduledSportEventId = NEWID()
