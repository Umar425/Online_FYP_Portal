CREATE TABLE ProjectIdeas (
    Id int NOT NULL IDENTITY(1,1),
    Name nvarchar(255) NOT NULL,
    ProjectId nvarchar(255) NOT NULL,
    Details nvarchar(max) NOT NULL,
    PRIMARY KEY (Id)
);

INSERT INTO ProjectIdeas (Name, ProjectId, Details)
VALUES 
    ('Project A', 'A123', 'Details of project A'),
    ('Project B', 'B456', 'Details of project B'),
    ('Project C', 'C789', 'Details of project C');

	select * from ProjectIdeas;