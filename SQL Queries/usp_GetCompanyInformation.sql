USE [EmployeeDetails]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCompanyInformation]    Script Date: 17-10-2022 10:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mani
-- Create date: 17/10/2022
-- Description:	To Get company details
-- =============================================
ALTER PROCEDURE [dbo].[usp_GetCompanyInformation]
	-- Add the parameters for the stored procedure here
	@CompanyName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select CompanyName, CompanyMobile, CompanyEmail, CompanyAddress from CompanyInformation where CompanyName like '%' +@CompanyName+'%';
END
