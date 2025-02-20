CREATE DATABASE [HospitalManagementDB]
GO

USE [HospitalManagementDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 6/26/2023 7:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] NOT NULL,
	[DepartmentName] [nvarchar](120) NOT NULL,
	[DepartmentLocation] [nvarchar](250) NULL,
	[TelephoneNumber] [nvarchar](20) NULL,
	[ShortDescription] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorInformation]    Script Date: 6/26/2023 7:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorInformation](
	[DoctorID] [nvarchar](20) NOT NULL,
	[DoctorName] [nvarchar](100) NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[DoctorAddress] [nvarchar](200) NULL,
	[GraduationYear] [int] NULL,
	[DoctorLicenseNumber] [nvarchar](25) NULL,
	[DepartmentID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffAccount]    Script Date: 6/26/2023 7:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffAccount](
	[HRAccountId] [nvarchar](50) NOT NULL,
	[HRFullname] [nvarchar](50) NOT NULL,
	[HREmail] [nvarchar](50) NOT NULL,
	[HRPassword] [nvarchar](50) NULL,
	[StaffRole] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HRAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [DepartmentLocation], [TelephoneNumber], [ShortDescription]) VALUES (9610, N'Emergency Department', N'Block H, Building A, Room 122, Floor 2', N'880903914555', N'Emergency Department')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [DepartmentLocation], [TelephoneNumber], [ShortDescription]) VALUES (9611, N'Otorhinolaryngology', N'Block H, Building A, Room 455 Floor 4', N'880903914666', N'Otorhinolaryngology')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [DepartmentLocation], [TelephoneNumber], [ShortDescription]) VALUES (9612, N'Department of Gastroenterology', N'Tower K, Building M, Room 2342 Floor 23', N'880903914777', N'Department of Gastroenterology')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [DepartmentLocation], [TelephoneNumber], [ShortDescription]) VALUES (9613, N'Cardiology Department', N'Tower J, Building M, Room 459 Floor 4', N'880903914444', N'Cardiology Department')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [DepartmentLocation], [TelephoneNumber], [ShortDescription]) VALUES (9614, N'Department of Gastroenterology', N'Room 1233 Floor 12, Building M', N'880903914888', N'Department of Gastroenterology')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [DepartmentLocation], [TelephoneNumber], [ShortDescription]) VALUES (9615, N'Ophthalmology', N'Room 123 Floor 12, Building M, Block A', N'880903919999', N'Ophthalmology Department')
GO
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'215121', N'Lâm', CAST(N'2023-06-24T23:09:00.000' AS DateTime), N'lamnhungoc@gmail.com', N'Tân bình', 1930, N'1515161', 9610)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0001', N'Corbin Beckham', CAST(N'1990-09-01T00:00:00.000' AS DateTime), N'CorbinBeckham@AbcHospital.gov', N'Paris, France', 2015, N'VNBS011022033', 9615)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0002', N'Otis Saint', CAST(N'1988-05-01T00:00:00.000' AS DateTime), N'OtisSaint@AbcHospital.gov', N'Paris, France', 2010, N'VNBS011022997', 9615)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0004', N'Amory Patrick', CAST(N'1986-08-01T00:00:00.000' AS DateTime), N'AmoryPatrick@AbcHospital.gov', N'Vienna, Austria', 2008, N'VNBS011021228', 9615)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0007', N'Dalziel Leighton', CAST(N'1991-10-01T00:00:00.000' AS DateTime), N'DalzielLeighton@AbcHospital.gov', N'Vienna, Austria', 2016, N'VNBS011029877', 9615)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0009', N'Michael John', CAST(N'1992-07-01T00:00:00.000' AS DateTime), N'MichaelJohn@AbcHospital.gov', N'Berlin, Germany', 2013, N'VNBS011026223', 9615)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0010', N'Alexander Leo', CAST(N'1992-07-01T00:00:00.000' AS DateTime), N'AlexanderLeo@AbcHospital.gov', N'Berlin, Germany', 2013, N'VNBS011026223', 9614)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0012', N'Athelstan Leo', CAST(N'1988-05-01T00:00:00.000' AS DateTime), N'AthelstanDelvin@AbcHospital.gov', N'Paris, France', 2010, N'VNBS011022997', 9613)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0014', N'Joyce Randolph', CAST(N'1986-08-01T00:00:00.000' AS DateTime), N'JoyceRandolph@AbcHospital.gov', N'Vienna, Austria', 2008, N'VNBS011021228', 9612)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0017', N'Kenelm Maynard', CAST(N'1991-10-01T00:00:00.000' AS DateTime), N'KenelmMaynard@AbcHospital.gov', N'Vienna, Austria', 2016, N'VNBS011029877', 9612)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0229', N'Engelbert Orson', CAST(N'1992-08-01T00:00:00.000' AS DateTime), N'EngelbertOrson@AbcHospital.gov', N'Oslo, Norway', 2013, N'VNBS011026223', 9615)
INSERT [dbo].[DoctorInformation] ([DoctorID], [DoctorName], [Birthday], [Email], [DoctorAddress], [GraduationYear], [DoctorLicenseNumber], [DepartmentID]) VALUES (N'DOC0449', N'Stephan Halk', CAST(N'1992-09-01T00:00:00.000' AS DateTime), N'StephanHalk@AbcHospital.gov', N'Moskow, Russia', 2013, N'VNBS011026223', 9615)
GO
INSERT [dbo].[StaffAccount] ([HRAccountId], [HRFullname], [HREmail], [HRPassword], [StaffRole]) VALUES (N'SA0001', N'Hospital Admin', N'HospitalAdmin@AbcHospital.gov', N'abc', 0)
INSERT [dbo].[StaffAccount] ([HRAccountId], [HRFullname], [HREmail], [HRPassword], [StaffRole]) VALUES (N'SA0002', N'Ralph Chen', N'RalphChen@AbcHospital.gov', N'123', 1)
INSERT [dbo].[StaffAccount] ([HRAccountId], [HRFullname], [HREmail], [HRPassword], [StaffRole]) VALUES (N'SA0003', N'Dominic Magnus', N'DominicMagnus@AbcHospital.gov', N'123@abc', 2)
GO
ALTER TABLE [dbo].[DoctorInformation]  WITH CHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
