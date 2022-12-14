USE [EmployeeDetails]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCompanyInfomation]    Script Date: 17-10-2022 10:01:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_InsertCompanyInfomation]
	-- Add the parameters for the stored procedure here
	@CompanyName nvarchar(50),
	@CompanyMobile bigint,
	@CompanyEmail nvarchar(50),
	@CompanyAddress nvarchar(200),
	@pincode int,
	@CompanyId int OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO CompanyInformation(CompanyName,CompanyMobile,CompanyEmail,CompanyAddress, pincode) VALUES
	(@CompanyName, @CompanyMobile, @CompanyEmail, @CompanyAddress, @pincode)

	SET @CompanyId = SCOPE_IDENTITY()
END
