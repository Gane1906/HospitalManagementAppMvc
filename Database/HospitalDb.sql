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
FirstName varchar(30),
LastName varchar(30),
Email varchar(50),
Password varchar(10),
Mobile bigint,
Gender varchar(6),
RoleId int foreign key references Role,
CreatedAt datetime,
ModifiedAt datetime,
);

Alter table users add IsTrash bit default(0);

select * from Users;

alter procedure InsertUsers
@FirstName varchar(20),
@LastName varchar(20),
@Email varchar(50),
@Password varchar(10),
@Mobile bigint,
@Gender varchar(6),
@RoleId int,
@CreatedAt datetime,
@ModifiedAt datetime,
@IsTrash bit

As
Begin

if not exists(select 1 from Users where Email=@Email)
begin

Insert into Users 
values(@FirstName,@LastName,@Email,@Password,@Mobile,@Gender,@RoleId,@CreatedAt,
@ModifiedAt,@IsTrash);
end

else 
begin
print 'Email already exists'
end

End

select * from Users;
delete from Users where userId=4;


---------------

Alter procedure UserLogin
@Email varchar(30),
@Password varchar(10)

As
Begin 

if exists(select 1 from Users where Email=@Email and Password=@Password)
begin
select * from Users where Email=@Email and Password=@Password;
end

else
begin
print 'User not exists'
end

End;

execute UserLogin @Email='ram@gmail.com',@Password='Ram@1213';


------------------------------

Create procedure GetRecords
As
Begin

select * From Users;

End;

execute GetRecords;

----------------------
create table Doctors(
DoctorId int primary key identity(100,1),
ProfilePic varchar(250),
Qualification varchar(50),
Specialization varchar(50),
Experience int,
IsTrash Bit default(0),
CreatedAt datetime,
ModifiedAt datetime,
userId int foreign key references Users(userId)
);

select * from Doctors;

Drop table Doctors;

alter Procedure InsertDoctor
@ProfilePic varchar(250),
@Qualification varchar(50),
@Specialization varchar(50),
@Experience int,
@IsTrash Bit,
@CreatedAt datetime,
@ModifiedAt datetime,
@userId int

As 
Begin
if exists(select 1 from users where userId=@userId)
begin
Insert into Doctors values(@ProfilePic,@Qualification,@Specialization,@Experience,
@IsTrash,@CreatedAt,@ModifiedAt,@userId);
end

else
begin
print 'User Not registered';
end

End
select GetDate();


select * from Doctors;

delete from Doctors where DoctorId=100;



------------------------

Create table Patients
(
PatientId int primary key identity(1000,1),
profilePic varchar(250),
Concern varchar(50),
Gender varchar(6),
Age int,
MedicalHistory varchar(50),
IsTrash Bit default(0),
CreatedAt datetime,
ModifiedAt datetime,
userId int foreign key references Users(userId)
);
select * from Patients;


alter procedure InsertPatients	
@ProfilePic varchar(250),
@Concern varchar(50),
@Gender varchar(6),
@Age int,
@MedicalHistory varchar(50),
@IsTrash Bit,
@CreatedAt datetime,
@ModifiedAt datetime,
@userId int

As
Begin

if exists(select 1 from Users where userId=@userId)
begin
Insert into Patients values(@ProfilePic,@Concern,@Gender,@Age,@MedicalHistory,@IsTrash,
@CreatedAt,@ModifiedAt,@userId);
end

else
begin
print 'User not registered'
end

End

-----------------------

Alter procedure GetDoctorById
@DoctorId int

As
Begin

if exists(select 1 from Doctors where DoctorId=@DoctorId)
begin
select * from Doctors where DoctorId=@DoctorId;
end

else
begin
print 'Doctor with Id not not exists'
end

End

-------------------------------

Create procedure GetByUSerId
@userId int
As
Begin

if exists(select 1 from Doctors where userId=@userId)
begin

select * from Doctors where userId=@userId;
end

else
begin
print 'Doctor not found';
end 
End;

execute GetByUSerId @userId=6;
----------------
Create procedure GetPateintbyId
@PatientId int
As
Begin
if exists(select 1 from Patients where PatientId=@PatientId)
begin
select * from Patients where PatientId=@PatientId;
end
else
print 'patientId is invalid';

End

Execute GetPateintbyId @PatientId=1000;

------------------------

Create procedure GetPatientByUserId
@userId int
As
Begin
if exists(select 1 from Patients where userId=@userId)
begin
select * from Patients where userId=@userId;
end
else
print 'Patient not exists'
End
Execute GetPatientByUserId @userId=7;

-------------------------

create Procedure GetAllDoctors
As
Begin
Select * from Doctors;
End

Execute GetAllDoctors
------------------

Create procedure GetAllPatients
As
Begin
Select * from Patients;
End

Execute GetAllPatients;