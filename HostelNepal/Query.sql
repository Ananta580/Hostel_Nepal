
-- Insert into roles table
Insert into dbo.tblRoles (RoleName)
VALUES 
('Admin'),
('Warden'),
('Student')

-- Insert into user table for initial admin
Insert into dbo.tblUsers(UserName, Email, Password)
VALUES 
('ananta580','anantapoudel580@gmail.com','ananta580')

--Insert into user and role mapping for admin
Insert into dbo.tblUserRoles(UserId, RoleId)
VALUES 
(1,1)