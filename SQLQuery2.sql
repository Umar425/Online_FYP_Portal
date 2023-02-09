Create Table Users
(
  UserID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  Username VARCHAR(255) NOT NULL,
  [Password] VARCHAR(255) NOT NULL
)

INSERT INTO Users (Username, Password)
VALUES
  ('user1', 'password1'),
  ('user2', 'password2'),
  ('user3', 'password3'),
  ('user4', 'password4'),
  ('user5', 'password5');


select * from Users;
