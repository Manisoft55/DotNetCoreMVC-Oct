USE [InstituteCmd]
GO

/****** Object:  Table [dbo].[employeesaudit]    Script Date: 27-10-2022 07:27:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--select * from [employeesaudit]


CREATE TABLE [dbo].[employeesaudit](
	[audit_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_id] [int] NOT NULL,
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](25) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone_number] [varchar](20) NULL,
	[hire_date] [date] NOT NULL,
	[job_id] [int] NOT NULL,
	[salary] [decimal](8, 2) NOT NULL,
	[manager_id] [int] NULL,
	[department_id] [int] NULL,
	[operation] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[audit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[employeesaudit] ADD  DEFAULT (NULL) FOR [first_name]
GO

ALTER TABLE [dbo].[employeesaudit] ADD  DEFAULT (NULL) FOR [phone_number]
GO

ALTER TABLE [dbo].[employeesaudit] ADD  DEFAULT (NULL) FOR [manager_id]
GO

ALTER TABLE [dbo].[employeesaudit] ADD  DEFAULT (NULL) FOR [department_id]
GO


