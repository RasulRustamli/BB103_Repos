CREATE DATABASE EducationSystem
use EducationSystem


CREATE TABLE Universities
(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(50) NOT NULL
) 

CREATE TABLE Groups
(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(50) NOT NULL,
UniversityId int FOREIGN KEY REFERENCES Universities(Id)
) 


CREATE TABLE Students
(
Id int PRIMARY KEY IDENTITY(1,1),
Name nvarchar(50) NOT NULL,
Surname nvarchar(50) DEFAULT 'XXX',
GroupId int FOREIGN KEY REFERENCES Groups(Id),
UniversityId int REFERENCES Universities(Id)
)


CREATE TABLE Subjects
(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(50) NOT NULL,
)

CREATE TABLE StudentSubject
(
Id int PRIMARY KEY IDENTITY,
StudentId int REFERENCES Students(Id),
SubjectId int REFERENCES Subjects(Id)

)

INSERT INTO Students(Name,GroupId,UniversityId) VALUES(N'Qəmzə',2,1)

INSERT INTO StudentSubject(StudentId,SubjectId) VALUES(4,1),(4,2)


--SELECT s.Name,u.Name AS 'University Name' FROM Students AS s
--JOIN Universities AS u
--ON s.UniversityId=u.Id

--SELECT s.Name,u.Name AS 'University Name' FROM Students AS s
--RIGHT JOIN Universities AS u
--ON s.UniversityId=u.Id


SELECT s.Name,u.Name AS 'University Name' FROM Students AS s
FULL OUTER JOIN Universities AS u
ON s.UniversityId=u.Id

SELECT s.Name,u.Name AS 'University Name' FROM Students AS s
LEFT JOIN Universities AS u
ON s.UniversityId=u.Id
WHERE u.Id is null



CREATE TABLE Employee
(
Id int primary key identity,
Name nvarchar(50) not null,
DependId int REFERENCES Employee(Id)
)



SELECT em.Name,depend.Name as 'Depend Name' FROM Employee as em
Left JOIN Employee as depend
ON em.DependId=depend.Id

