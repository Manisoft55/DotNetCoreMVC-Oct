USE [InstituteCmd]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetEmployee]    Script Date: 19-10-2022 10:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fnGetEmployee]()
returns Table
As
 return (Select * from EmployeeDetails) 
