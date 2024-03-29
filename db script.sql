
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiLogItem]    Script Date: 29-Jan-21 10:22:01 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficiary]    Script Date: 29-Jan-21 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiary](
	[BeneficiaryId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[BeneficiaryAccountNumber] [nvarchar](50) NULL,
	[BeneficiaryAccountName] [nvarchar](50) NULL,
	[BeneficiaryBankName] [nvarchar](50) NULL,
	[BeneficiaryBankCode] [nvarchar](20) NULL,
	[DateCreated] [datetime2](7) NULL,
 CONSTRAINT [PK_Beneficiary] PRIMARY KEY CLUSTERED 
(
	[BeneficiaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerProfile]    Script Date: 29-Jan-21 10:22:01 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WalletInfo]    Script Date: 29-Jan-21 10:22:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WalletUsers]    Script Date: 29-Jan-21 10:22:02 PM ******/
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
 CONSTRAINT [PK_WalletUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Beneficiary] ADD  CONSTRAINT [DF_Beneficiary_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
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
ALTER TABLE [dbo].[WalletInfo]  WITH CHECK ADD  CONSTRAINT [FK_WalletInfo_WalletUsers] FOREIGN KEY([Customerid])
REFERENCES [dbo].[WalletUsers] ([Id])
GO
ALTER TABLE [dbo].[WalletInfo] CHECK CONSTRAINT [FK_WalletInfo_WalletUsers]
GO
USE [master]
GO
ALTER DATABASE [AgencyBanking] SET  READ_WRITE 
GO
