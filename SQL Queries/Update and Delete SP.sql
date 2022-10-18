CREATE PROCEDURE usp_UpdateCompanyInformation
@CompanyId int,
@pincode int

AS 

	BEGIN
		Update CompanyInformation SET pincode = @pincode where CompanyId = @CompanyId
	END
GO



CREATE PROCEDURE usp_DeleteCompanyInformation
@CompanyId int

AS
	BEGIN
		DELETE FROM CompanyInformation Where CompanyId = @CompanyId
	END

Go


