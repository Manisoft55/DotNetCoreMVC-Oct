CREATE TRIGGER dbo.trg_employee
ON dbo.employees
AFTER INSERT, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO employeesaudit(
	employee_id,
	first_name,
	last_name,
	email,
	phone_number,
	hire_date,
	job_id,
	salary,
	manager_id,
	department_id,
	operation
    )
    SELECT
        i.employee_id,
		i.first_name,
		i.last_name,
		i.email,
		i.phone_number,
		i.hire_date,
		i.job_id,
		i.salary,
		i.manager_id,
		i.department_id,
        'INSERTED'
    FROM
        inserted i
    UNION ALL
    SELECT
        d.employee_id,
		d.first_name,
		d.last_name,
		d.email,
		d.phone_number,
		d.hire_date,
		d.job_id,
		d.salary,
		d.manager_id,
		d.department_id,
        'DELETED'
    FROM
        deleted d;
END
