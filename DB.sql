USE [MedicStore]
GO
/****** Object:  Table [dbo].[Batch]    Script Date: 17/02/2024 6:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Batch](
	[BatchID] [int] IDENTITY(1,1) NOT NULL,
	[InputDate] [date] NULL,
	[BatchNumber] [int] NULL,
	[BatchCode]  AS ((CONVERT([nvarchar](255),[InputDate],(112))+'-LH')+CONVERT([nvarchar](255),[BatchNumber])),
PRIMARY KEY CLUSTERED 
(
	[BatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 17/02/2024 6:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NOT NULL,
	[ToM] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 17/02/2024 6:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[DiscountCode] [nvarchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[TotalSaleAmount] [decimal](10, 2) NOT NULL,
	[DiscountPercentage] [decimal](5, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medic]    Script Date: 17/02/2024 6:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MedicId] [nvarchar](250) NOT NULL,
	[MName] [nvarchar](250) NOT NULL,
	[MDate] [date] NOT NULL,
	[EDate] [date] NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[PerUnit] [bigint] NOT NULL,
	[BatchID] [int] NULL,
	[CategoryID] [int] NULL,
	[Description] [nvarchar](1000) NULL,
	[Status] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 17/02/2024 6:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[SaleID] [int] IDENTITY(1,1) NOT NULL,
	[SaleDate] [date] NULL,
	[TotalAmount] [decimal](10, 2) NULL,
	[SellerAccountID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleDetail]    Script Date: 17/02/2024 6:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetail](
	[SaleDetailID] [int] IDENTITY(1,1) NOT NULL,
	[SaleID] [int] NULL,
	[MedicineID] [int] NULL,
	[QuantitySold] [int] NULL,
	[SalePrice] [decimal](10, 2) NULL,
	[DiscountID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/02/2024 6:50:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRole] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Dob] [nvarchar](10) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Degree] [nvarchar](250) NOT NULL,
	[PersonalID] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](10) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Username] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Batch] ON 

INSERT [dbo].[Batch] ([BatchID], [InputDate], [BatchNumber]) VALUES (1, CAST(N'2024-01-31' AS Date), 1)
INSERT [dbo].[Batch] ([BatchID], [InputDate], [BatchNumber]) VALUES (3, CAST(N'2024-02-15' AS Date), 1)
INSERT [dbo].[Batch] ([BatchID], [InputDate], [BatchNumber]) VALUES (2, CAST(N'2024-02-15' AS Date), 2)
SET IDENTITY_INSERT [dbo].[Batch] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName], [ToM]) VALUES (1, N'Thuốc Chữa Bệnh', N'TCB')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [ToM]) VALUES (2, N'Thực Phẩm Chức Năng', N'TPCN')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [ToM]) VALUES (3, N'Thuốc Không Kê Đơn', N'TKKD')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [ToM]) VALUES (4, N'Thuốc Kê Đơn', N'TKD')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [ToM]) VALUES (5, N'Thuốc Điều Trị Các Bệnh Cụ Thể', N'TDTBCT')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([DiscountID], [DiscountCode], [StartDate], [EndDate], [TotalSaleAmount], [DiscountPercentage]) VALUES (3, N'CODE1', CAST(N'2024-02-10' AS Date), CAST(N'2024-02-20' AS Date), CAST(10000.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(5, 2)))
INSERT [dbo].[Discount] ([DiscountID], [DiscountCode], [StartDate], [EndDate], [TotalSaleAmount], [DiscountPercentage]) VALUES (4, N'CODE2', CAST(N'2024-02-10' AS Date), CAST(N'2024-02-17' AS Date), CAST(50000.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[Discount] OFF
GO
SET IDENTITY_INSERT [dbo].[Medic] ON 

INSERT [dbo].[Medic] ([Id], [MedicId], [MName], [MDate], [EDate], [Quantity], [PerUnit], [BatchID], [CategoryID], [Description], [Status]) VALUES (1, N'TCB-1', N'Paracetamol', CAST(N'2023-01-31' AS Date), CAST(N'2024-02-13' AS Date), 99999, 100, 1, 1, N'', N'Hết hạn')
INSERT [dbo].[Medic] ([Id], [MedicId], [MName], [MDate], [EDate], [Quantity], [PerUnit], [BatchID], [CategoryID], [Description], [Status]) VALUES (2, N'TCB-2', N'Ibuprofen', CAST(N'2020-01-31' AS Date), CAST(N'2023-01-31' AS Date), 10000, 100, 1, 1, NULL, N'Hết hạn')
INSERT [dbo].[Medic] ([Id], [MedicId], [MName], [MDate], [EDate], [Quantity], [PerUnit], [BatchID], [CategoryID], [Description], [Status]) VALUES (4, N'TPCN20240215-LH2', N'TPCN', CAST(N'2024-01-31' AS Date), CAST(N'2024-03-21' AS Date), 100, 2000, 2, 2, N'Không uống', N'Còn hạn')
INSERT [dbo].[Medic] ([Id], [MedicId], [MName], [MDate], [EDate], [Quantity], [PerUnit], [BatchID], [CategoryID], [Description], [Status]) VALUES (5, N'TCB20240215-LH2', N'chữa bệnh', CAST(N'2024-01-16' AS Date), CAST(N'2024-05-16' AS Date), 122, 12222, 2, 1, N'Uống đi', N'Còn hạn')
INSERT [dbo].[Medic] ([Id], [MedicId], [MName], [MDate], [EDate], [Quantity], [PerUnit], [BatchID], [CategoryID], [Description], [Status]) VALUES (6, N'TCB20240215-LH1', N'JJJ', CAST(N'2024-02-15' AS Date), CAST(N'2024-05-17' AS Date), 111, 11111, 3, 1, N'făf', N'Còn hạn')
SET IDENTITY_INSERT [dbo].[Medic] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserRole], [Name], [Dob], [Address], [Degree], [PersonalID], [Mobile], [Email], [Username], [Password], [Gender]) VALUES (1, N'Admin', N'Minh', N'31/01/2024', N'123asdf', N'College', N'123456', N'0123456', N'avdc', N'Minh', N'1', N'Male')
INSERT [dbo].[Users] ([Id], [UserRole], [Name], [Dob], [Address], [Degree], [PersonalID], [Mobile], [Email], [Username], [Password], [Gender]) VALUES (2, N'Pharmacist', N'Hải', N'31/01/2024', N'123asdf', N'College', N'123456', N'0123456', N'acdv', N'User', N'2', N'Female')
INSERT [dbo].[Users] ([Id], [UserRole], [Name], [Dob], [Address], [Degree], [PersonalID], [Mobile], [Email], [Username], [Password], [Gender]) VALUES (4, N'Admin', N'Nam', N'27/01/2024', N'1', N'Associate', N'1', N'1', N'1', N'Nam', N'1', N'Male')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [UC_InputDate_BatchNumber]    Script Date: 17/02/2024 6:50:01 PM ******/
ALTER TABLE [dbo].[Batch] ADD  CONSTRAINT [UC_InputDate_BatchNumber] UNIQUE NONCLUSTERED 
(
	[InputDate] ASC,
	[BatchNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Medic] ADD  DEFAULT (N'Còn hạn') FOR [Status]
GO
ALTER TABLE [dbo].[Medic]  WITH CHECK ADD FOREIGN KEY([BatchID])
REFERENCES [dbo].[Batch] ([BatchID])
GO
ALTER TABLE [dbo].[Medic]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([SellerAccountID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD FOREIGN KEY([DiscountID])
REFERENCES [dbo].[Discount] ([DiscountID])
GO
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD FOREIGN KEY([MedicineID])
REFERENCES [dbo].[Medic] ([Id])
GO
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD FOREIGN KEY([SaleID])
REFERENCES [dbo].[Sale] ([SaleID])
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD CHECK  (([DiscountPercentage]>=(0) AND [DiscountPercentage]<=(100)))
GO
