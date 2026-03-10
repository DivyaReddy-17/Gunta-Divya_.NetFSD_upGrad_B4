/*Level-1 and 2 Problem: Create Database EventDb and create tables as per schema given below. 
Requirements
1.Add entity class UserInfo and add public properties:
Property Name	Type	Constraint
EmailId	varchar	PK
UserName	varchar	Not Null, Length: 1 to 50 char.
Role	varchar 	Not Null, (Admin,Participant)-CHECK
Password	varchar	Not Null Length: 6 to 20 char

2. Add entity class EventDetails and add below public properties.
Property Name	Type	Constraint
EventId	int	PK
EventName	varchar	Not Null, Length: 1 to 50 char.
EventCategory	varchar	Not Null, Length: 1 to 50 char.
EventDate	datetime	Not Null
Description	varchar	Nullable
Status	varchar	Active or In-Active, CHECK

4. Add entity class SpeakersDetails and add below public properties.
Property Name	Type	Constraints
SpeakerId	int	PK
SpeakerName	varchar	Not Null, Length: 1 to 50 char.

5. Add entity class SessionInfo and add below public properties.
Property Name	Type	Constraints
SessionId	int	PK
EventId	int	Not Null (FK)
SessionTitle	varchar	Not Null, Length: 1 to 50 char.
SpeakerId	int	Not Null (FK)
Description	varchar	Nullable
SessionStart	datetime	Not Null (Time Slot)
SessionEnd	datetime	Not Null (Time Slot)
SessionUrl	varchar	
6. Add entity class ParticipantEventDetails and add below public properties.
Property Name	Type	Constraints
Id	int	(PK)
ParticipantEmailId	varchar 	Not Null (FK)
EventId	int	Not Null (FK)
SessionId	Int	Not Null (FK)
IsAttended	bit	Yes or No, CHECK
	
🛠️ Technical Constraints
•	Use SQL Server.
•	Use appropriate data types (INT, VARCHAR, DATE, DECIMAL).
•	Follow normalization up to 2NF.
•	Use ANSI SQL syntax only.

Expectations:
•	Proper table structure with relationships.
•	Valid constraints implementation.
•	Correct data insertion and retrieval queries.

🎯 Learning Outcome
You will understand database structure, basic normalization, constraints, and ANSI SQL queries.*/

database created
CREATE DATABASE EventAb;
GO

USE EventAb;
GO

--UserInfo Table
CREATE TABLE UserInfo(
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Participant')),
    Password VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);

--EventDetails Table
CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(MAX) NULL,
    Status VARCHAR(10) CHECK (Status IN ('Active', 'In-Active'))
);

--SpeakersDetails Table
CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL
);

--SessionInfo Table
CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(MAX) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255),

    -- Foreign Key Constraints
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);


--ParticipantEvent Table
CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL DEFAULT 0, -- 1 for Yes, 0 for No
    -- Foreign Key Constraints
    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);

-- Insert a User
INSERT INTO UserInfo (EmailId, UserName, Role, Password) 
VALUES ('anu@example.com', 'Anusha', 'Participant', 'Anu1234');

-- Insert an Event
INSERT INTO EventDetails (EventId, EventName, EventCategory, EventDate, Status)
VALUES (1, 'Digital', 'IT', '2026-05-20 10:00:00', 'Active');

-- Insert a Speaker
INSERT INTO SpeakersDetails (SpeakerId, SpeakerName)
VALUES (1, 'Dr. Amar');

-- Insert a Session
INSERT INTO SessionInfo (SessionId, EventId, SessionTitle, SpeakerId, SessionStart, SessionEnd)
VALUES (1, 1, 'AI in SQL Server', 1, '2026-05-20 10:00:00', '2026-05-20 11:00:00');
go

--participantEvent
INSERT INTO ParticipantEventDetails (Id, ParticipantEmailId, EventId, SessionId, IsAttended)
VALUES (1, 'anu@example.com', 1, 1, 1);

SELECT * FROM UserInfo;
SELECT * FROM EventDetails;
SELECT * FROM SpeakersDetails;
SELECT * FROM SessionInfo;
SELECT * FROM ParticipantEventDetails;