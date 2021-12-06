

/****** Object:  Table [dbo].[WalletUsers]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WalletUsers](
	[Id] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Gender] [nvarchar](20) NULL,
	[DateOfBirth] [date] NULL,
	[Transactionpin] [nvarchar](10) NULL,
	[Deviceimei] [nvarchar](50) NULL,
	[HardwareIMEI] [nvarchar](50) NULL,
	[Deviceos] [nvarchar](50) NULL,
	[Devicemake] [nvarchar](50) NULL,
	[Devicemodel] [nvarchar](50) NULL,
	[Ipaddress] [nvarchar](50) NULL,
	[Referralcode] [nvarchar](50) NULL,
	[TransPin] [nvarchar](1000) NULL,
 CONSTRAINT [PK_WalletUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ CustomerAccountSchema]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ CustomerAccountSchema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[AccountGroup] [nvarchar](50) NULL,
	[AccountType] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Balance] [float] NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[Currency] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_CustomerAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiLogItem]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiLogItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestTime] [datetime2](7) NULL,
	[ResponseMillis] [decimal](18, 0) NULL,
	[StatusCode] [int] NULL,
	[Method] [nvarchar](100) NULL,
	[Path] [nvarchar](max) NULL,
	[QueryString] [nvarchar](max) NULL,
	[RequestBody] [nvarchar](max) NULL,
	[ResponseBody] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApiLogItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficiary]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiary](
	[BeneficiaryId] [uniqueidentifier] NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[BeneficiaryAccountNumber] [nvarchar](50) NULL,
	[BeneficiaryAccountName] [nvarchar](50) NULL,
	[BeneficiaryBankName] [nvarchar](50) NULL,
	[BeneficiaryBankCode] [nvarchar](20) NULL,
	[DateCreated] [datetime2](7) NULL,
 CONSTRAINT [PK_Beneficiary] PRIMARY KEY CLUSTERED 
(
	[BeneficiaryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerError]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerError](
	[Refid] [bigint] IDENTITY(1,1) NOT NULL,
	[MobileNum] [varchar](50) NULL,
	[BVN] [varchar](50) NULL,
	[Msg] [varchar](max) NULL,
	[Stage] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
	[Email] [varchar](50) NULL,
	[Screen] [varchar](50) NULL,
 CONSTRAINT [PK_CustomerError] PRIMARY KEY CLUSTERED 
(
	[Refid] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerProfile]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerProfile](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[SMID] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[BVN] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Fullname] [nvarchar](100) NULL,
	[QuestionCompleted] [bit] NULL,
	[DeviceInfoExist] [bit] NULL,
	[IsAgent] [bit] NULL,
	[HasPryAccount] [bit] NULL,
	[PryAccount] [nvarchar](50) NULL,
	[ReferralCode] [nvarchar](50) NULL,
	[IsWalletOnly] [bit] NULL,
	[AgentCode] [nvarchar](50) NULL,
	[LastLogin] [nvarchar](50) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[IsDefaultPassword] [bit] NULL,
	[RMDaoCode] [nvarchar](50) NULL,
	[RMName] [nvarchar](50) NULL,
	[RMEmail] [nvarchar](50) NULL,
	[RMMobile] [nvarchar](50) NULL,
 CONSTRAINT [PK_CustomerProfile] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OTP]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OTP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OTP] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[DateCreated] [datetime2](7) NULL,
	[ExpiryDate] [datetime2](7) NULL,
	[IsUsed] [bit] NULL,
 CONSTRAINT [PK_OTP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [uniqueidentifier] NOT NULL,
	[Question] [varchar](1000) NULL,
	[CreatedBy] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDeviceInfo]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDeviceInfo](
	[DeviceId] [uniqueidentifier] NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[IMEI] [varchar](100) NULL,
	[OSVersion] [varchar](100) NULL,
	[Make] [varchar](100) NULL,
	[Model] [varchar](100) NULL,
	[IPAddress] [varchar](1000) NULL,
	[IsCurrent] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[HardwareIMEI] [varchar](1000) NULL,
 CONSTRAINT [PK_UserDeviceInfo] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserQA]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserQA](
	[UserQAId] [uniqueidentifier] NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[QuestionId] [uniqueidentifier] NULL,
	[Answer] [varchar](1000) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_UserQA] PRIMARY KEY CLUSTERED 
(
	[UserQAId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WalletInfo]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WalletInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customerid] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Nuban] [nvarchar](50) NULL,
	[Availablebalance] [float] NULL,
	[Phone] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[FullName] [nvarchar](50) NULL,
	[CURRENCYCODE] [nvarchar](10) NULL,
 CONSTRAINT [PK_WalletInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WalletTransfers]    Script Date: 24-Mar-21 7:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WalletTransfers](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [float] NULL,
	[SMID] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NULL,
	[CurrencyCode] [nvarchar](50) NULL,
	[ToAcct] [nvarchar](50) NULL,
	[FromAct] [nvarchar](50) NULL,
	[Remarks] [nvarchar](100) NULL,
	[DateCreated] [datetime2](7) NULL,
	[Status] [nvarchar](50) NULL,
	[BalanceAfterDebit] [float] NULL,
	[BalanceAfterCredit] [float] NULL,
	[Balance] [float] NULL,
 CONSTRAINT [PK_WalletTransfers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[OTP] ON 

INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (1, N'B1YZUK', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-02-26T18:17:59.7736267' AS DateTime2), CAST(N'2021-02-26T18:22:59.7736784' AS DateTime2), 1)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (2, N'pJpfTI', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-02-26T18:55:54.6479538' AS DateTime2), CAST(N'2021-02-26T19:00:54.6480081' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (3, N'l8YIto', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-02-26T19:03:51.4490017' AS DateTime2), CAST(N'2021-02-26T19:08:51.4490757' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (4, N'1RUrRL', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-02-28T10:18:52.6906677' AS DateTime2), CAST(N'2021-02-28T10:23:52.6907060' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (5, N'flOtnJ', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-02-28T10:19:49.0254812' AS DateTime2), CAST(N'2021-02-28T10:24:49.0255408' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (6, N'ReA8cW', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-01T02:52:15.3582393' AS DateTime2), CAST(N'2021-03-01T02:57:15.3582794' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (7, N'ZAGyKg', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-01T02:56:04.3655677' AS DateTime2), CAST(N'2021-03-01T03:01:04.3655679' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (8, N'lpm9iU', N'loladeking@gmail.com', N'07036605597', CAST(N'2021-03-01T07:12:43.1492979' AS DateTime2), CAST(N'2021-03-01T07:17:43.1493488' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (9, N'zsT5te', N'loladeking@gmail.com', N'07036605597', CAST(N'2021-03-01T07:23:11.5437858' AS DateTime2), CAST(N'2021-03-01T07:28:11.5437862' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (10, N'fnWQWy', N'loladeking@gmail.com', N'07036605597', CAST(N'2021-03-01T07:24:37.4708478' AS DateTime2), CAST(N'2021-03-01T07:29:37.4708501' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (11, N'mLvolN', N'loladeking@gmail.com', N'07036605597', CAST(N'2021-03-01T07:25:15.3358178' AS DateTime2), CAST(N'2021-03-01T07:30:15.3358182' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (12, N'wNYC7m', N'loladeking@gmail.com', N'07036605597', CAST(N'2021-03-01T10:32:39.4135221' AS DateTime2), CAST(N'2021-03-01T10:37:39.4135253' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (13, N'rKBiFJ', N'loladeking@gmail.com', N'07036605597', CAST(N'2021-03-01T10:58:13.2240818' AS DateTime2), CAST(N'2021-03-01T11:03:13.2240877' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (14, N'osAME2', N'loladeking@gmail.com', N'07036605597', CAST(N'2021-03-01T14:00:26.2317415' AS DateTime2), CAST(N'2021-03-01T14:05:26.2317846' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (15, N'wDTb5Q', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-01T14:06:59.0510680' AS DateTime2), CAST(N'2021-03-01T14:11:59.0510713' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (16, N'jSb7QK', N'loladeking@gmail.com', N'07036605597', CAST(N'2021-03-01T14:26:22.4370061' AS DateTime2), CAST(N'2021-03-01T14:31:22.4370446' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (17, N'BORImG', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-01T14:54:25.6210013' AS DateTime2), CAST(N'2021-03-01T14:59:25.6210571' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (18, N'ZkF9eQ', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-01T14:55:29.6509745' AS DateTime2), CAST(N'2021-03-01T15:00:29.6509753' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (19, N'tEuCHQ', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-01T14:56:20.3362531' AS DateTime2), CAST(N'2021-03-01T15:01:20.3362557' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (20, N'LvQXzr', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-01T15:02:55.4688993' AS DateTime2), CAST(N'2021-03-01T15:07:55.4690550' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (21, N'OzCTm8', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-02T04:42:42.9949873' AS DateTime2), CAST(N'2021-03-02T04:47:42.9950362' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (22, N'gBCdaY', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-03T18:29:03.6682375' AS DateTime2), CAST(N'2021-03-03T18:34:03.6683591' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (23, N'TxWXcG', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T00:40:42.8555825' AS DateTime2), CAST(N'2021-03-04T00:45:42.8557682' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (24, N'ucxkGH', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T00:42:06.9221439' AS DateTime2), CAST(N'2021-03-04T00:47:06.9223373' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (25, N'dzWJQc', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T00:51:31.8321416' AS DateTime2), CAST(N'2021-03-04T00:56:31.8323361' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (26, N'LWqjiD', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T00:53:43.1445235' AS DateTime2), CAST(N'2021-03-04T00:58:43.1445238' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (27, N'B9SE8G', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T00:56:22.8568289' AS DateTime2), CAST(N'2021-03-04T01:01:22.8569680' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (28, N'TSaCi4', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T00:59:45.4880636' AS DateTime2), CAST(N'2021-03-04T01:04:45.4881873' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (29, N'MNLItU', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T01:02:37.6661411' AS DateTime2), CAST(N'2021-03-04T01:07:37.6662797' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (30, N'bw9FO1', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T01:04:09.5258037' AS DateTime2), CAST(N'2021-03-04T01:09:09.5259272' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (31, N'3o6gW3', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T01:32:25.1630299' AS DateTime2), CAST(N'2021-03-04T01:37:25.1632315' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (32, N'USt0dd', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T01:34:35.9447504' AS DateTime2), CAST(N'2021-03-04T01:39:35.9449058' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (33, N'YTfJew', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T01:36:10.5970246' AS DateTime2), CAST(N'2021-03-04T01:41:10.5972138' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (34, N'q78TCT', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T01:36:41.3460306' AS DateTime2), CAST(N'2021-03-04T01:41:41.3460308' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (35, N'zEZ00F', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T01:38:55.1836206' AS DateTime2), CAST(N'2021-03-04T01:43:55.1837439' AS DateTime2), 0)
INSERT [dbo].[OTP] ([Id], [OTP], [Email], [Phone], [DateCreated], [ExpiryDate], [IsUsed]) VALUES (36, N'EOezAh', N'olaniyiolatunji@gmail.com', N'08177654960', CAST(N'2021-03-04T01:41:33.9326636' AS DateTime2), CAST(N'2021-03-04T01:46:33.9327872' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[OTP] OFF
GO
INSERT [dbo].[Question] ([QuestionId], [Question], [CreatedBy], [DateCreated]) VALUES (N'00000000-0000-0000-0000-000000000000', N'Testing Question', N'Olaniyi', CAST(N'2021-02-15T08:13:11.563' AS DateTime))
INSERT [dbo].[Question] ([QuestionId], [Question], [CreatedBy], [DateCreated]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'What is the model of your first car?', N'Olaniyi', CAST(N'2021-02-15T08:57:45.043' AS DateTime))
INSERT [dbo].[Question] ([QuestionId], [Question], [CreatedBy], [DateCreated]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa7', N'Where did you meet your spouse?', N'Olaniyi', CAST(N'2021-02-15T08:58:52.280' AS DateTime))
INSERT [dbo].[Question] ([QuestionId], [Question], [CreatedBy], [DateCreated]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa8', N'What year did you graduate university?', N'Olaniyi', CAST(N'2021-02-15T08:59:57.383' AS DateTime))
GO
INSERT [dbo].[UserDeviceInfo] ([DeviceId], [UserId], [IMEI], [OSVersion], [Make], [Model], [IPAddress], [IsCurrent], [DateCreated], [HardwareIMEI]) VALUES (N'70abdd0c-290b-4f0e-add3-2f1c8d3d5e2c', N'99715d76-ed0b-46d3-9863-d242a8b7122c', N'1cd347afff4e7532', N'10', N'samsung', N'SM-G973N', N'192.168.1.157;   ', 1, CAST(N'2021-03-04T21:52:38.030' AS DateTime), N'samsung MODEL=SM-G97')
INSERT [dbo].[UserDeviceInfo] ([DeviceId], [UserId], [IMEI], [OSVersion], [Make], [Model], [IPAddress], [IsCurrent], [DateCreated], [HardwareIMEI]) VALUES (N'7afae4cd-fb62-4081-a73d-42ece91016a1', N'8b401ed0-c0a5-44a1-b5e4-8617308b8f99', N'02774117CJ004298', N'7', N'TECNO', N'TECNO CX Air', N'100.123.186.78; 192.168.43.1;  ', 1, CAST(N'2021-03-04T21:51:13.073' AS DateTime), N'TECNO MODEL=TECNO CX')
INSERT [dbo].[UserDeviceInfo] ([DeviceId], [UserId], [IMEI], [OSVersion], [Make], [Model], [IPAddress], [IsCurrent], [DateCreated], [HardwareIMEI]) VALUES (N'3ff324dd-351b-451c-a9a3-53d6cc6e0a40', N'0dffb3e1-5a42-4bf1-8f76-a26ea0bbab20', N'1163aa5973cdd05d2', N'11', N'samsung', N'SM-N985F', N'10.152.204.27; 192.168.156.148; 10.254.0.1; ', 1, CAST(N'2021-03-06T05:49:07.840' AS DateTime), N'samsung MODEL=SM-N98')
INSERT [dbo].[UserDeviceInfo] ([DeviceId], [UserId], [IMEI], [OSVersion], [Make], [Model], [IPAddress], [IsCurrent], [DateCreated], [HardwareIMEI]) VALUES (N'8a7bd461-2b8d-46be-a82a-6ae6530acc90', N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'985908cb5dedd461', N'10', N'Xiaomi', N'Mi 9T', N'192.168.0.124;  ', 1, CAST(N'2021-03-04T21:48:07.017' AS DateTime), N'Xiaomi MODEL=Mi 9T U')
INSERT [dbo].[UserDeviceInfo] ([DeviceId], [UserId], [IMEI], [OSVersion], [Make], [Model], [IPAddress], [IsCurrent], [DateCreated], [HardwareIMEI]) VALUES (N'264e0148-93e7-4651-8dbb-7335092f0202', N'1814ab48-61a5-45e8-8a60-8b4734a0fad9', N'1163aa5973cdd05d', N'11', N'samsung', N'SM-N985F', N'10.152.204.54; 10.254.0.1; ', 1, CAST(N'2021-03-04T21:43:16.293' AS DateTime), N'samsung MODEL=SM-N98')
INSERT [dbo].[UserDeviceInfo] ([DeviceId], [UserId], [IMEI], [OSVersion], [Make], [Model], [IPAddress], [IsCurrent], [DateCreated], [HardwareIMEI]) VALUES (N'83ecfd51-7303-48a2-b773-c73819666620', N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'1163aa5973cdd05d', N'11', N'samsung', N'SM-N985F', N'10.152.204.204; 192.168.161.43; 10.254.0.1; ', 1, CAST(N'2021-03-04T21:44:12.710' AS DateTime), N'samsung MODEL=SM-N98')
INSERT [dbo].[UserDeviceInfo] ([DeviceId], [UserId], [IMEI], [OSVersion], [Make], [Model], [IPAddress], [IsCurrent], [DateCreated], [HardwareIMEI]) VALUES (N'ce2cf78b-b2ce-4d7b-82a1-d091c0c74e69', N'0dffb3e1-5a42-4bf1-8f76-a26ea0bbab20', N'1163aa5973cdd05d', N'11', N'samsung', N'SM-N985F', N'10.152.204.27; 192.168.156.148; 10.254.0.1; ', 0, CAST(N'2021-03-06T05:34:33.880' AS DateTime), N'samsung MODEL=SM-N98')
INSERT [dbo].[UserDeviceInfo] ([DeviceId], [UserId], [IMEI], [OSVersion], [Make], [Model], [IPAddress], [IsCurrent], [DateCreated], [HardwareIMEI]) VALUES (N'58b38b05-af29-4a1a-bc21-ec2b024ed958', N'f07250e7-ba70-46da-be45-c63146ec2fb2', N'3da8f3194a717bff', N'11', N'Google', N'Pixel 3', N'10.101.243.190;  ', 1, CAST(N'2021-03-04T21:53:58.943' AS DateTime), N'Google MODEL=Pixel 3')
GO
INSERT [dbo].[UserQA] ([UserQAId], [UserId], [QuestionId], [Answer], [DateCreated]) VALUES (N'82ad5b99-7037-4352-bf6c-1c7d9536b59e', N'f07250e7-ba70-46da-be45-c63146ec2fb2', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'o0wSxXNINYY=', CAST(N'2021-03-02T16:41:03.547' AS DateTime))
INSERT [dbo].[UserQA] ([UserQAId], [UserId], [QuestionId], [Answer], [DateCreated]) VALUES (N'aba42bcb-7bdf-412a-834f-27e0cc7f44b3', N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'00000000-0000-0000-0000-000000000000', N'jHpWyepZDeU=', CAST(N'2021-02-26T20:04:11.867' AS DateTime))
INSERT [dbo].[UserQA] ([UserQAId], [UserId], [QuestionId], [Answer], [DateCreated]) VALUES (N'f762a3b8-23ce-41cc-bd0a-2d8b64dc6709', N'f07250e7-ba70-46da-be45-c63146ec2fb2', N'3fa85f64-5717-4562-b3fc-2c963f66afa8', N'dcLVubMM+d0=', CAST(N'2021-03-02T16:41:03.683' AS DateTime))
INSERT [dbo].[UserQA] ([UserQAId], [UserId], [QuestionId], [Answer], [DateCreated]) VALUES (N'23cccbfc-90c1-43b3-a9cf-9372d35776d2', N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'tnkdgjtfA7E=', CAST(N'2021-02-26T20:04:12.010' AS DateTime))
INSERT [dbo].[UserQA] ([UserQAId], [UserId], [QuestionId], [Answer], [DateCreated]) VALUES (N'47bfe710-d3d7-4a8f-9795-d3038af20909', N'f07250e7-ba70-46da-be45-c63146ec2fb2', N'00000000-0000-0000-0000-000000000000', N'F0l7wnlB1hU=', CAST(N'2021-03-02T16:41:03.403' AS DateTime))
INSERT [dbo].[UserQA] ([UserQAId], [UserId], [QuestionId], [Answer], [DateCreated]) VALUES (N'c236704e-9de9-485d-8d23-e407c72c819f', N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'3fa85f64-5717-4562-b3fc-2c963f66afa7', N'7iIckfYX1ng=', CAST(N'2021-02-26T20:04:12.157' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[WalletInfo] ON 

INSERT [dbo].[WalletInfo] ([Id], [Customerid], [FirstName], [Lastname], [Email], [Mobile], [Nuban], [Availablebalance], [Phone], [Gender], [FullName], [CURRENCYCODE]) VALUES (22, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'olaniyi', N'olatunji', N'olaniyiolatunji@gmail.com', N'08177654960', N'08177654960', 9000, N'08177654960', N'Male', N'olaniyi olatunji', N'NGN')
INSERT [dbo].[WalletInfo] ([Id], [Customerid], [FirstName], [Lastname], [Email], [Mobile], [Nuban], [Availablebalance], [Phone], [Gender], [FullName], [CURRENCYCODE]) VALUES (23, N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'ololade Ahmed', N'oyebanji', N'loladeking@gmail.com', N'07036605597', N'07036605597', 10000, N'07036605597', N'Male', N'ololade Ahmed oyebanji', N'NGN')
INSERT [dbo].[WalletInfo] ([Id], [Customerid], [FirstName], [Lastname], [Email], [Mobile], [Nuban], [Availablebalance], [Phone], [Gender], [FullName], [CURRENCYCODE]) VALUES (24, N'f07250e7-ba70-46da-be45-c63146ec2fb2', N'Aminu', N'Muhammad', N'elminu80@gmail.com', N'07081197352', N'07081197352', 9000, N'07081197352', N'Male', N'Aminu Muhammad', N'NGN')
INSERT [dbo].[WalletInfo] ([Id], [Customerid], [FirstName], [Lastname], [Email], [Mobile], [Nuban], [Availablebalance], [Phone], [Gender], [FullName], [CURRENCYCODE]) VALUES (25, N'8b401ed0-c0a5-44a1-b5e4-8617308b8f99', N'Munirat', N'Ojotu', N'investmunira@gmail.com', N'08107189221', N'08107189221', 10000, N'08107189221', N'Female', N'Munirat Ojotu', N'NGN')
INSERT [dbo].[WalletInfo] ([Id], [Customerid], [FirstName], [Lastname], [Email], [Mobile], [Nuban], [Availablebalance], [Phone], [Gender], [FullName], [CURRENCYCODE]) VALUES (26, N'1814ab48-61a5-45e8-8a60-8b4734a0fad9', N'Adekunle', N'olatunji ', N'olaniyi.olatunji@un.org', N'08023873110', N'08023873110', 10000, N'08023873110', N'Male', N'Adekunle olatunji ', N'NGN')
INSERT [dbo].[WalletInfo] ([Id], [Customerid], [FirstName], [Lastname], [Email], [Mobile], [Nuban], [Availablebalance], [Phone], [Gender], [FullName], [CURRENCYCODE]) VALUES (27, N'99715d76-ed0b-46d3-9863-d242a8b7122c', N'hello', N'bello', N'bellokano@qq.com', N'08038537372', N'08038537372', 10000, N'08038537372', N'Male', N'hello bello', N'NGN')
INSERT [dbo].[WalletInfo] ([Id], [Customerid], [FirstName], [Lastname], [Email], [Mobile], [Nuban], [Availablebalance], [Phone], [Gender], [FullName], [CURRENCYCODE]) VALUES (28, N'0dffb3e1-5a42-4bf1-8f76-a26ea0bbab20', N'ola', N'niyi', N'ola@niyi.com', N'75982026123', N'75982026123', 10000, N'75982026123', N'Male', N'ola niyi', N'NGN')
SET IDENTITY_INSERT [dbo].[WalletInfo] OFF
GO
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'ef403370-0a96-4c1e-9134-006f4aef8fc1', 1000, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'General', N'NGN', N'07036605597', N'08177654960', N'', CAST(N'2021-02-25T21:57:43.4900000' AS DateTime2), N'Successful', 7000, 13000, 7000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'5261efbe-9777-4989-8f7b-0e312caa52c3', 1000, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'General', N'NGN', N'07036605597', N'08177654960', N'', CAST(N'2021-02-24T05:06:47.4133333' AS DateTime2), N'Successful', 10000, 10000, 10000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'566c0597-4968-46c9-b5ec-11cea9601edf', 10000, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'General', N'NGN', N'08107189221', N'08177654960', N'', CAST(N'2021-02-24T08:18:27.7800000' AS DateTime2), N'Successful', 10000, 10000, 10000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'c5312646-49c1-4b1d-bc75-26919d145279', 1000, N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'General', N'NGN', N'08177654960', N'07036605597', N'food', CAST(N'2021-02-27T17:27:45.9400000' AS DateTime2), N'Successful', 9000, 9000, 9000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'3e324f57-3d22-4b77-b08a-320831ccfd29', 10000, N'8b401ed0-c0a5-44a1-b5e4-8617308b8f99', N'General', N'NGN', N'08177654960', N'08107189221', N'Done', CAST(N'2021-02-24T08:13:40.3166667' AS DateTime2), N'Successful', 0, 20000, 0)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'e59faa91-34c0-4f56-9536-33c16e8459d6', 1000, N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'General', N'NGN', N'08177654960', N'07036605597', N'', CAST(N'2021-02-23T23:08:58.9966667' AS DateTime2), N'Successful', 9000, 11000, 9000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'406f1006-69fc-4065-92f5-4aed5a16997b', 1000, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'General', N'NGN', N'07036605597', N'08177654960', N'mecho', CAST(N'2021-03-01T18:30:41.8466667' AS DateTime2), N'Successful', 8000, 10000, 8000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'ada73805-4f8f-4f0c-90f6-60b6d1f79719', 1000, N'f07250e7-ba70-46da-be45-c63146ec2fb2', N'General', N'NGN', N'08177654960', N'07081197352', N'Test Cash', CAST(N'2021-03-04T10:48:57.6800000' AS DateTime2), N'Successful', 9000, 9000, 9000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'b84c93bc-8154-4b17-a506-63aa6852ecbd', 1000, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'General', N'NGN', N'07036605597', N'08177654960', N'', CAST(N'2021-02-28T09:50:09.0800000' AS DateTime2), N'Successful', 8000, 10000, 8000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'aadc4e8c-5649-473b-980b-69eeb9ba3c20', 1000, N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'General', N'NGN', N'08177654960', N'07036605597', N'food', CAST(N'2021-03-01T14:28:55.0133333' AS DateTime2), N'Successful', 10000, 8000, 10000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'7c2d03ea-006f-4fc1-b63c-9e29ab97ed04', 1000, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'General', N'NGN', N'07036605597', N'08177654960', N'', CAST(N'2021-02-25T21:43:48.5400000' AS DateTime2), N'Successful', 9000, 11000, 9000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'3ede21b5-a934-442f-a52b-b3419e45f776', 1000, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'General', N'NGN', N'07036605597', N'08177654960', N'', CAST(N'2021-02-25T21:54:26.0966667' AS DateTime2), N'Successful', 8000, 12000, 8000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'22535ea9-7ce3-4c5f-8e01-b7c8d9be436b', 1000, N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'General', N'NGN', N'08177654960', N'07036605597', N'', CAST(N'2021-02-27T16:32:24.3500000' AS DateTime2), N'Pending', NULL, NULL, NULL)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'5dbbc7dc-be7b-4d01-8643-dcf5cab4ab5b', 1000, N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'General', N'NGN', N'07036605597', N'08177654960', N'fooding ', CAST(N'2021-03-01T13:49:33.2600000' AS DateTime2), N'Successful', 7000, 11000, 7000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'cba7d4b8-039b-4836-a0aa-e64ee8bfa181', 1000, N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'General', N'NGN', N'08177654960', N'07036605597', N'food', CAST(N'2021-02-27T16:09:59.7266667' AS DateTime2), N'Pending', NULL, NULL, NULL)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'9c966fb5-ecda-4722-a1b8-f8588a402163', 1000, N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'General', N'NGN', N'08177654960', N'07036605597', N'', CAST(N'2021-03-01T16:20:45.7366667' AS DateTime2), N'Successful', 9000, 9000, 9000)
INSERT [dbo].[WalletTransfers] ([Id], [Amount], [SMID], [Category], [CurrencyCode], [ToAcct], [FromAct], [Remarks], [DateCreated], [Status], [BalanceAfterDebit], [BalanceAfterCredit], [Balance]) VALUES (N'94d184c5-4789-47e2-82cb-f8cfd17265cc', 1000, N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'General', N'NGN', N'08177654960', N'07036605597', N'', CAST(N'2021-02-27T16:37:00.1033333' AS DateTime2), N'Successful', 10000, 8000, 10000)
GO
INSERT [dbo].[WalletUsers] ([Id], [FirstName], [LastName], [UserName], [PasswordHash], [PasswordSalt], [EmailAddress], [PhoneNumber], [Gender], [DateOfBirth], [Transactionpin], [Deviceimei], [HardwareIMEI], [Deviceos], [Devicemake], [Devicemodel], [Ipaddress], [Referralcode], [TransPin]) VALUES (N'0dffb3e1-5a42-4bf1-8f76-a26ea0bbab20', N'ola', N'niyi', N'Olaniyi ', 0xA7BF9E71EEC1FBAC1599ED7A63693245912CD1EC2D94929A2E20D6BA1FF95E4A00063A256AB7CF80DBDAFFF69A4E5F67809C3BAE46D450C0B8A63975F146D698, 0xF02C60643DE2881ABB9678E44BEE526794F3D4666CFF888192661AAA8C707AA1527ECCE4B12DFE0B7FBF0E274BD1C325C3CDD30314466AB5DA236C61F0FF1B540ED65055E95A18386104589EB096AAB8BA82D8DB196AD15BD667AB084D0806FA987BE9E13EB151F212F9E8241F908A367E2DB9B6676140C4A8D43839DB7EF9AF, N'ola@niyi.com', N'75982026123', N'Male', CAST(N'1943-04-03' AS Date), N'', N'1163aa5973cdd05d', N'samsung MODEL=SM-N98', N'11', N'samsung', N'SM-N985F', N'10.152.204.27; 192.168.156.148; 10.254.0.1; ', N'', N'VEnAAhgcsJo=')
INSERT [dbo].[WalletUsers] ([Id], [FirstName], [LastName], [UserName], [PasswordHash], [PasswordSalt], [EmailAddress], [PhoneNumber], [Gender], [DateOfBirth], [Transactionpin], [Deviceimei], [HardwareIMEI], [Deviceos], [Devicemake], [Devicemodel], [Ipaddress], [Referralcode], [TransPin]) VALUES (N'1814ab48-61a5-45e8-8a60-8b4734a0fad9', N'Adekunle', N'olatunji ', N'adekunleola', 0x81C8A67E7093144EAB0F4C6E6DEA0B98A8E0C3782241D1FA9A8EAE43CBDF4D2793CC84B24DC7EE189120E33E2B25F9E8496CD68429C6843604E295BA2422FC43, 0x216DE6BAFC1ADCC57E97E8D298CE1A52C0A6519A00E69A618C912FFE287C50EC3371177F0831C410A20C2BD741F01EE4FE708A59E90B445D31C2DE5D399C8D560294490F13CADB78C271E5913AC201CBA6E31ED03402A82C4D2F8ACD3AD70244987D46E35FCFA6DCA29B735499D2C0BEEB5FEA5220CFF21A67C94D48E1E31B44, N'olaniyi.olatunji@un.org', N'08023873110', N'Male', CAST(N'2003-02-25' AS Date), N' ', N'1163aa5973cdd05d', N'samsung MODEL=SM-N98', N'11', N'samsung', N'SM-N985F', N'10.152.204.54; 10.254.0.1; ', N'', N'VEnAAhgcsJo=')
INSERT [dbo].[WalletUsers] ([Id], [FirstName], [LastName], [UserName], [PasswordHash], [PasswordSalt], [EmailAddress], [PhoneNumber], [Gender], [DateOfBirth], [Transactionpin], [Deviceimei], [HardwareIMEI], [Deviceos], [Devicemake], [Devicemodel], [Ipaddress], [Referralcode], [TransPin]) VALUES (N'567f9cbc-ed5a-41fd-84dd-3b4d79aa1736', N'ololade Ahmed', N'oyebanji', N'technololy', 0xD9CD7B4976B30191D80911B3BDD522CC7F071119D92ED5E70DDC9C7AACA9AC9A89FD9DDFDEE722820EB79839A0AEE4E7D2DD7E183E31E7ED92E084A4CB1DBD17, 0x2D0A34A20F40B11EF7CC56E24E40FCA616223BE817CA5BBF9AB63D5EC9AFE64118DA28F9B41D1FDAE12D72DD1A522BF870B5A3CABFA06FD61F5BA5A8C648450D38E124ED026ABE4A50285589235DDCA02F7613D282B5100E164F7F558682CDC7FD45FA259BA512F83B58B39B5E1B1F1E7D519D3E6E6B6ACD6A25FC6DD46C16C6, N'loladeking@gmail.com', N'07036605597', N'Male', CAST(N'2000-05-22' AS Date), N' ', N'985908cb5dedd461', N'Xiaomi MODEL=Mi 9T U', N'10', N'Xiaomi', N'Mi 9T', N'192.168.0.124; ', N'', N'VEnAAhgcsJo=')
INSERT [dbo].[WalletUsers] ([Id], [FirstName], [LastName], [UserName], [PasswordHash], [PasswordSalt], [EmailAddress], [PhoneNumber], [Gender], [DateOfBirth], [Transactionpin], [Deviceimei], [HardwareIMEI], [Deviceos], [Devicemake], [Devicemodel], [Ipaddress], [Referralcode], [TransPin]) VALUES (N'5c8c641c-fe5a-4c6f-9750-8806058907b5', N'olaniyi', N'olatunji', N'olaniyiolatunji', 0x724B95F208B35373FC6D0CE5B7839B057EDEDBB93A345A5D8A2C84320A77E18F31AB03E72667D44B99255FE28C0F5B303765A881B61FCD58E35C985CBD23351F, 0xA66CCFC78452C56CD901C4594CFFBBB644CDDB9432A05A814521E6D1C02FEB0C3AA6FDD0C1F861415FAD29E34A4859F00EB79585F31EED836AE2F9222FCE38B5282CACC706ECF5DD9DE0EC345F6B7C32B10A2BD0EBE9984707CFC573D81B68C0D8C7CF97199AE8BFA9CC0CC57FF2DF77C35509346908DE91EA6ED67C5CDE5231, N'olaniyiolatunji@gmail.com', N'08177654960', N'Male', CAST(N'1986-01-21' AS Date), N' ', N'1163aa5973cdd05d', N'samsung MODEL=SM-N98', N'11', N'samsung', N'SM-N985F', N'10.152.204.204; 192.168.161.43; 10.254.0.1; ', N'', N'VEnAAhgcsJo=')
INSERT [dbo].[WalletUsers] ([Id], [FirstName], [LastName], [UserName], [PasswordHash], [PasswordSalt], [EmailAddress], [PhoneNumber], [Gender], [DateOfBirth], [Transactionpin], [Deviceimei], [HardwareIMEI], [Deviceos], [Devicemake], [Devicemodel], [Ipaddress], [Referralcode], [TransPin]) VALUES (N'8b401ed0-c0a5-44a1-b5e4-8617308b8f99', N'Munirat', N'Ojotu', N'Munirat', 0x9F480E8DC682C647A5E3CC3A851BF14FFB3E68510DBF52B61F52F78A46F3D4D79DEA2E99C976A664059008B8D44E48EF40772FF028B0DE7F2C73FC1540A812A0, 0x38C55265E0E0A07268CA0FC316F693557322698A3F25C250D982C04C13FAD81D177E297645AC072DAA65D5CE49A9FCF4A038DC354B0EC06D6ACC8674127D31AAB407DEF0DD626CBFFD9C29DC7478477C4854D777CDED1A56F5CA5AB0B3B4359EB237537D9035F9F082E5EC087652D5A47A01FBBB226A916AFDEAC4CE3608020D, N'investmunira@gmail.com', N'08107189221', N'Female', CAST(N'1995-02-02' AS Date), N' ', N'02774117CJ004298', N'TECNO MODEL=TECNO CX', N'7.0', N'TECNO', N'TECNO CX Air', N'100.123.186.78; 192.168.43.1; ', N'', N'49PHUIeWb1o=')
INSERT [dbo].[WalletUsers] ([Id], [FirstName], [LastName], [UserName], [PasswordHash], [PasswordSalt], [EmailAddress], [PhoneNumber], [Gender], [DateOfBirth], [Transactionpin], [Deviceimei], [HardwareIMEI], [Deviceos], [Devicemake], [Devicemodel], [Ipaddress], [Referralcode], [TransPin]) VALUES (N'99715d76-ed0b-46d3-9863-d242a8b7122c', N'hello', N'bello', N'bkapps', 0xDE8990D9ECAC1FA9FD0F0DC3EED4B572B9838FEA07C6C646284AF2156D2D806FF9A0D284C5E56E7DFBB85BF0634B5C93F70EC4F414400118BCB2239AC8FCB4E9, 0x8AF11AFA8BBAF9B3BB969920F799675CF62419E27E527267C801D89EABBB7325709B8F10135485AF2F33C9165CE1CF912AAE4FD761430D3FE51D8C7177EF7C4E0AC93FA9876EE79F19E8BFDB2047C21AE400780BAC3791D25D48D38EEC17BB508EBD6D9EC07E5A4C9293E6F2FFCD91E72D48CD2441F338857DEA9C069E8B174B, N'bellokano@qq.com', N'08038537372', N'Male', CAST(N'1983-04-23' AS Date), N'', N'1cd347afff4e7532', N'samsung MODEL=SM-G97', N'10', N'samsung', N'SM-G973N', N'192.168.1.157; ', N'', N'BSDwN5Yj0fY=')
INSERT [dbo].[WalletUsers] ([Id], [FirstName], [LastName], [UserName], [PasswordHash], [PasswordSalt], [EmailAddress], [PhoneNumber], [Gender], [DateOfBirth], [Transactionpin], [Deviceimei], [HardwareIMEI], [Deviceos], [Devicemake], [Devicemodel], [Ipaddress], [Referralcode], [TransPin]) VALUES (N'f07250e7-ba70-46da-be45-c63146ec2fb2', N'Aminu', N'Muhammad', N'maghassan', 0x6120504F5850F6DB5D522FC913BEE9ED3F00E6F0BE0BA2DDD4306EBC9E7FE63176724FB4C988A6ADA55F06F00A2799F49703475B8D4DE5AF28972EA5E938B743, 0x4F3F23D65328C4FDA0A652856039BDC255F1A4A475BC460398F4B53BDDA3AEEA681C1C16D29567F95326C88CAA98BC534F57FACC41091A1138671065A87333F5C79F5F050D9D22408DE00A3861AA872E6AC804E8F16888705F8F7013B12BEBFE85A7739B802652D9E62EF9DBFCA4EC71B527A12B8A99DCA7B13D50E99C6E62B9, N'elminu80@gmail.com', N'07081197352', N'Male', CAST(N'1996-08-06' AS Date), N' ', N'3da8f3194a717bff', N'Google MODEL=Pixel 3', N'11', N'Google', N'Pixel 3', N'10.101.243.190; ', N'', N'EgFVDgJK4wU=')
GO
ALTER TABLE [dbo].[Beneficiary] ADD  CONSTRAINT [DF_Beneficiary_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[CustomerError] ADD  CONSTRAINT [DF_CustomerError_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [DF_Question_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[UserDeviceInfo] ADD  CONSTRAINT [DF_UserDeviceInfo_IsCurrent]  DEFAULT ((0)) FOR [IsCurrent]
GO
ALTER TABLE [dbo].[UserDeviceInfo] ADD  CONSTRAINT [DF_UserDeviceInfo_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[UserQA] ADD  CONSTRAINT [DF_UserQA_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[WalletTransfers] ADD  CONSTRAINT [DF_WalletTransfers_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[ CustomerAccountSchema]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAccount_WalletUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[WalletUsers] ([Id])
GO
ALTER TABLE [dbo].[ CustomerAccountSchema] CHECK CONSTRAINT [FK_CustomerAccount_WalletUsers]
GO
ALTER TABLE [dbo].[Beneficiary]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiary_WalletUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[WalletUsers] ([Id])
GO
ALTER TABLE [dbo].[Beneficiary] CHECK CONSTRAINT [FK_Beneficiary_WalletUsers]
GO
ALTER TABLE [dbo].[CustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_CustomerProfile_WalletUsers] FOREIGN KEY([SMID])
REFERENCES [dbo].[WalletUsers] ([Id])
GO
ALTER TABLE [dbo].[CustomerProfile] CHECK CONSTRAINT [FK_CustomerProfile_WalletUsers]
GO
ALTER TABLE [dbo].[UserDeviceInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserDeviceInfo_WalletUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[WalletUsers] ([Id])
GO
ALTER TABLE [dbo].[UserDeviceInfo] CHECK CONSTRAINT [FK_UserDeviceInfo_WalletUsers]
GO
ALTER TABLE [dbo].[UserQA]  WITH CHECK ADD  CONSTRAINT [FK_UserQA_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[UserQA] CHECK CONSTRAINT [FK_UserQA_Question]
GO
ALTER TABLE [dbo].[UserQA]  WITH CHECK ADD  CONSTRAINT [FK_UserQA_WalletUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[WalletUsers] ([Id])
GO
ALTER TABLE [dbo].[UserQA] CHECK CONSTRAINT [FK_UserQA_WalletUsers]
GO
ALTER TABLE [dbo].[WalletInfo]  WITH CHECK ADD  CONSTRAINT [FK_WalletInfo_WalletUsers] FOREIGN KEY([Customerid])
REFERENCES [dbo].[WalletUsers] ([Id])
GO
ALTER TABLE [dbo].[WalletInfo] CHECK CONSTRAINT [FK_WalletInfo_WalletUsers]
GO
ALTER TABLE [dbo].[WalletTransfers]  WITH CHECK ADD  CONSTRAINT [FK_WalletTransfers_WalletUsers] FOREIGN KEY([SMID])
REFERENCES [dbo].[WalletUsers] ([Id])
GO
ALTER TABLE [dbo].[WalletTransfers] CHECK CONSTRAINT [FK_WalletTransfers_WalletUsers]
GO
ALTER DATABASE [AgencyBanking] SET  READ_WRITE 
GO
