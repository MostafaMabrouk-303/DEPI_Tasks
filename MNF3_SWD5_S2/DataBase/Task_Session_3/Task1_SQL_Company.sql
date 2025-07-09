Use Co;
go

--1-Create the EMPLOYEE table with all constraints
Create Table Employee 
(
SSN int Primary Key,
FName VarChar(255)not null,
LName VarChar(255)not null,
Gender Char(1) Check (Gender ='M' or Gender ='F') ,
BirthDate Date not null,
SuperSSN int not null,
DNumber int,

--Foregin Key Deprt and SuperviserSSN
Constraint Emp_Manger_FK foreign key (SuperSSN)
references Employee(SSN),

--Foregin Key Deprt and Employee
--Constraint Emp_Dept_FK foreign key (DNumber)
--   references Department(DNum)
-- Will Add Constraint with Alter
)

--2-Create the DEPARTMENT table with proper relationships
Create Table  Department
(
DNum int identity(1,1) Primary Key,
DName VarChar(255) unique,
HiringDate Date Default GetDate(),
ManagerSSN int ,

--Foregin Key Deprtment and Employee (Manage)
Constraint Emp_Dept_FK foreign key (ManagerSSN)
references Employee(SSN)

)

--Locations Table it's a MultiValued Attribute
CREATE TABLE Locations 
(
 DNumber int,
 Locations VarChar(255),
 Primary Key (DNumber, Locations), --Composie Primary Key
 Constraint Locations_Depart_FK Foreign Key(DNumber) 
 References Department(DNum)
);

--3-Create the PROJECT table
Create Table  Project
(
PNum int identity(1,1) Primary Key,
PName VarChar(255) not null,
City VarChar(255) Default 'Cairo',
DNo int Default 1,

--Foregin Key Deprtment and Project 
Constraint Project_Dept_FK foreign key (DNo)
references Department(DNum)

)

--4-Dependent Table
Create Table Dependent
(
EmpSSN int ,
DepndentName VarChar(255) ,
Primary Key(EmpSSN,DepndentName),
Gender Char(1) Check (Gender ='M' or Gender ='F') ,
BirthDate date,
--Foregin Key Employee and Dependent 
Constraint Emp_Dependebt_FK foreign key (EmpSSN)
references Employee(SSN)

)

--5- Employee_Project Table (Work in)
Create Table  WorkIn
(
EmpSSN int ,
ProgNum int,
Primary Key(EmpSSN,ProgNum), --Composite Primary Key
NumberOfHours int default 8,

--Foregin Key Employee and Project 
Constraint Project_FK foreign key (ProgNum)
references Project(PNum),

Constraint Emp_FK foreign key (EmpSSN)
references Employee(SSN)
)

--Add Constraint BetWeen Employee and Department
Alter table Employee
Add Constraint Dept_Emp_FK foreign key (DNumber)
  references Department(DNum) 
  on Delete set null
  on update cascade

-- Insert sample data into EMPLOYEE table (at least 5 employees)
insert into Employee(SSN,FName,LName,Gender,BirthDate,SuperSSN)
values
(1111,'Mostafa','Mohamed','M','2003-1-1',1111),
(2222,'Ali','Mohamed','M','2004-1-1',1111),
(3333,'Karim','Mohamed','M','2005-1-1',1111),
(4444,'Abdo','ElSayed','M','2006-1-1',1111),
(1122,'Adel','Magdy','M','2007-1-1',1111),
(3344,'Mohamed','Ali','M','2008-1-1',3333),
(1234,'Aya','Naser','F','2009-1-1',3333)

--Insert sample data into DEPARTMENT table (at least 3 departments)
insert into Department(DName,HiringDate,ManagerSSN)
values
('IT','2000-9-1',1111),
('HR','2000-11-6',2222),
('CS','2000-10-5',3333),
('Marketing','2000-1-1',4444)

--Update an employee's department
update Employee
set DNumber=1
where SSN=1111;

update Employee
set DNumber=2
where SSN in (2222,3333,1122) ;

update Employee
set DNumber=3
where SSN = 3344 ;

update Employee
set DNumber=4
where DNumber is null;

Select * from Employee;
Select * from Department;

--Delete a dependent record
Drop table Dependent;
--Retrieve all employees working in a specific department
Select * from Employee
where DNumber=2;

--Find all employees and their project assignments with working hours
-- with Relationship (Work in) between Employee and Project 

Select * from Employee;
Select * from Project;

insert into Project(PName,City,DNo)
values
('Project_1','Alex',1),
('Project_2','Cairo',1),
('Project_3','Mansoura',2);



insert into WorkIn(EmpSSN,ProgNum,NumberOfHours)
values
(1111,1,6),
(2222,1,9),
(3333,2,5);

insert into WorkIn(EmpSSN,ProgNum) --Hours By Default 8
values
(4444,3),
(1122,3),
(3344,3);

Select * from WorkIn;





