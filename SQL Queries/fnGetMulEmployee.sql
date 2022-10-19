USE [InstituteCmd]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetMulEmployee]    Script Date: 19-10-2022 10:05:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fnGetMulEmployee]()
returns @Emp Table
(
EmpID int, 
FirstName varchar(50),
Salary int
)
As
begin
 Insert into @Emp Select e.EmpID,e.EmpFirstName,e.EmpSalary from EmployeeDetails e;
--Now update salary of first employee
 update @Emp set Salary=25000 where EmpID=1;
--It will update only in @Emp table not in Original Employee table
return
end 