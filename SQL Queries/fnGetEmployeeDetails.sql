USE [InstituteCmd]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetEmployeeDetails]    Script Date: 19-10-2022 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fnGetEmployeeDetails]()
returns Table
As
 return (Select * from EmployeeDetails) 
