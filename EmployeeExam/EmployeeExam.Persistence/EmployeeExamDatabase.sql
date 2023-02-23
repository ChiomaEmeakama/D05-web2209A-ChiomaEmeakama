USE [EmployeeExamDatabase]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[Employees]
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(10001,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[HourlyWage] [decimal](10, 2) NOT NULL,
	[HoursWorked] [decimal](10, 2) NOT NULL,
	[HoursPaid] [decimal](10, 2) NOT NULL,
	[PaymentReceived] [decimal](10, 2) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10001, N'Amandeep', N'Sharma', CAST(N'1989-01-13T00:00:00.0000000' AS DateTime2), N'Senior Developer', CAST(56.25 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10002, N'Stéphane', N'Brunet', CAST(N'1981-07-11T00:00:00.0000000' AS DateTime2), N'Project Manager', CAST(58.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-01-07T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-07T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10003, N'Marita', N'Alvarez', CAST(N'1987-04-03T00:00:00.0000000' AS DateTime2), N'Accountant', CAST(40.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-01-10T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10004, N'Timothy', N'Aston', CAST(N'1984-02-21T00:00:00.0000000' AS DateTime2), N'Senior UX Designer', CAST(42.50 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-01-18T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-18T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10005, N'Amandine', N'Duval', CAST(N'1992-11-30T00:00:00.0000000' AS DateTime2), N'Software Architect', CAST(58.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-01-25T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-25T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10006, N'Raj', N'Patel', CAST(N'1996-08-15T00:00:00.0000000' AS DateTime2), N'Junior Developer', CAST(34.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-01-31T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-31T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10007, N'Jean-François', N'Legendre', CAST(N'1977-06-10T00:00:00.0000000' AS DateTime2), N'Human Resources Coordinator', CAST(36.50 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-02-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10008, N'Ben', N'Martinez', CAST(N'1972-03-03T00:00:00.0000000' AS DateTime2), N'Systems Administrator', CAST(42.75 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-02-06T00:00:00.0000000' AS DateTime2), CAST(N'2022-02-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10009, N'Elsa', N'Wagner', CAST(N'1993-08-23T00:00:00.0000000' AS DateTime2), N'Front-end Web Developer', CAST(38.50 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-02-13T00:00:00.0000000' AS DateTime2), CAST(N'2022-02-13T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [DateOfBirth], [JobTitle], [HourlyWage], [HoursWorked], [HoursPaid], [PaymentReceived], [DateCreated], [DateUpdated]) VALUES (10010, N'Satomi', N'Kitigawa', CAST(N'1998-05-31T00:00:00.0000000' AS DateTime2), N'Clerical Assistant', CAST(22.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-02-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-02-22T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_HoursWorked]  DEFAULT ((0)) FOR [HoursWorked]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_HoursPaid]  DEFAULT ((0)) FOR [HoursPaid]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_PaymentReceived]  DEFAULT ((0)) FOR [PaymentReceived]
GO
USE [master]
GO
ALTER DATABASE [EmployeeExamDatabase] SET  READ_WRITE 
GO
