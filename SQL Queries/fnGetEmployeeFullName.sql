USE [InstituteCmd]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetEmployeeFullName]    Script Date: 19-10-2022 10:05:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fnGetEmployeeFullName]
(
 @FirstName varchar(50),
 @LastName varchar(50)
)
returns varchar(101)
As
Begin return (Select @FirstName + ' '+ @LastName);
end 
