create database HospitalManagement;

Use HospitalManagement;

Create table Role(
RoleId int identity(1,1) primary key,
RoleName varchar(15)
);

Insert into Role values('Admin');
Insert into Role values('Doctor');
Insert into Role values('Patient');

select * from Role;


Create table Users(
userId int identity(1,1) primary key,
FirstName varchar(10),
LastName varchar(10),
Email varchar(10),
Password varchar(10),
Mobile bigint,
Gender varchar(6),
Dob date,
RoleId int foreign key references Role,
CreatedAt datetime,
ModifiedAt datetime,
);

Alter table users add IsTrash bit default(0);

Alter table users alter column Dob datetime;
select * from Users;

Alter procedure InsertUser
@FirstName varchar(10),
@LastName varchar(10),
@Email varchar(10),
@Password varchar(10),
@Mobile bigint,
@Gender varchar(6),
@Dob date,
@RoleId int,
@CreatedAt datetime,
@ModifiedAt datetime,
@IsTrash bit

As
Begin

if not exists(select 1 from Users where Email=@Email)
begin

Insert into Users 
values(@FirstName,@LastName,@Email,@Password,@Mobile,@Gender,@Dob,@RoleId,@CreatedAt,
@ModifiedAt,@IsTrash);
end

else 
begin
print 'Email already exists'
end

End

----------------

create procedure UserLogin
@Email varchar(10),
@Password varchar(10)

As
Begin 

if exists(select 1 from Users where Email=@Email and Password=@Password)
begin

select * From Users;

end

else
begin
print 'User not exists'
end

End;

