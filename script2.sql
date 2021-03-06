drop database [BanSach]
create database [BanSach]

USE [BanSach]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/24/2019 9:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Telephone] [varchar](20) NULL,
	[Gender] [int] NULL,
	[CreatedDate] [date] NULL,
	[DateOfBirth] [date] NULL,
	[Address] [nvarchar](500) NULL,
	[Status] [int] NULL CONSTRAINT [DF_Account_Status]  DEFAULT ((1)),
	[Avatar] [nvarchar](500) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Account_Role]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Account_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Review] [nvarchar](1000) NULL,
	[Price] [decimal](18, 0) NULL,
	[ID_Category] [int] NULL,
	[ID_Publisher] [int] NULL,
	[Quantity] [int] NULL,
	[MainImage] [varchar](1000) NULL,
	[Author] [nvarchar](500) NULL,
	[Status] [int] NULL CONSTRAINT [DF_Book_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_CuonSach] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Account] [int] NOT NULL,
	[Status] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_MuaHang_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CartDetail]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetail](
	[ID_Book] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cart] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_CuonSach_MuaHang] PRIMARY KEY CLUSTERED 
(
	[ID_Book] ASC,
	[ID_Cart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Status] [int] NULL CONSTRAINT [DF_Category_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Coupon]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Name] [nvarchar](500) NULL,
	[Value] [decimal](5, 2) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CouponDetail]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CouponDetail](
	[ID_Coupon] [int] NOT NULL,
	[ID_Book] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[ID_Coupon] ASC,
	[ID_Book] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Telephone] [varchar](20) NOT NULL,
	[Gender] [int] NULL,
	[join_Date] [date] NULL,
	[DateOfBirth] [date] NULL,
	[Address] [nvarchar](500) NULL,
	[Status] [int] NULL CONSTRAINT [DF_Customer_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Import]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Import](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [date] NULL,
	[AccountID] [int] NULL,
	[TotalPrice] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Import] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportDetail]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NULL,
	[ImportID] [int] NULL,
	[Amount] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ImportDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Account] [int] NULL,
	[DiscountCode] [varchar](50) NULL,
	[Price] [money] NULL,
	[OrderDate] [datetime] NULL,
	[DeliveryDate] [date] NULL,
	[ID_InvoiceStatus] [int] NULL,
	[CustomerName] [nvarchar](250) NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Address] [nvarchar](500) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Book] [int] NOT NULL,
	[ID_Invoice] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceStatus]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[TheOrder] [nchar](10) NULL,
 CONSTRAINT [PK_InvoiceStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListImage]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ListImage](
	[ID_Book] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Link] [varchar](1000) NULL,
 CONSTRAINT [PK_ListImage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Date] [date] NULL,
	[Description] [nvarchar](4000) NULL,
	[Status] [int] NULL CONSTRAINT [DF_Publisher_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_NhaXuaBan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rate]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate](
	[ID_Book] [int] NOT NULL,
	[ID_Account] [int] NOT NULL,
	[Comment] [int] NULL,
	[Rate] [nvarchar](500) NULL,
 CONSTRAINT [PK_DanhGia] PRIMARY KEY CLUSTERED 
(
	[ID_Book] ASC,
	[ID_Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_VaiTro] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (1, N'Nguyễn Xuân Sơn', N'sonnx', N'xuansonkrt@gmail.com', N'a', N'0344647733', 1, NULL, CAST(N'1998-05-01' AS Date), N'Hưng Yên', 1, N'/UploadedFiles/1558656019IMG_9405-3.jpg')
INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (3, N'Nguyễn Xuân Sơn', N'sonnx1', N'xuansonkaratedo.com@gmail.com', N'a', N'0967555025', 1, CAST(N'2019-05-23' AS Date), CAST(N'1998-01-05' AS Date), N'Hưng Yên', 1, N'/UploadedFiles/1558656084IMG_9405-3.jpg')
INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (4, N'Vô danh', N'sonnx2', N'xuansonkaratedo.com@gmail.com', N'a', NULL, NULL, CAST(N'2019-05-23' AS Date), NULL, NULL, 1, N'/UploadedFiles/noimage.png')
INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (5, N'Vô danh', N'sonnx3', N'xuansonkaratedo.com@gmail.com', N'a', NULL, NULL, CAST(N'2019-05-23' AS Date), NULL, NULL, 1, N'/UploadedFiles/noimage.png')
INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (6, N'Vô danh', N'sonnx4', N'xuansonkaratedo.com@gmail.com', N'a', N'0346467733', 0, CAST(N'2019-05-23' AS Date), CAST(N'1998-04-28' AS Date), N'Hưng Yên', 1, N'/UploadedFiles/1558656070IMG_9405-3.jpg')
INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (7, N'Vô danh', N'sonnx6', N'xuansonkrt@gmail.com', N'a', NULL, NULL, CAST(N'2019-05-23' AS Date), NULL, NULL, 0, N'/UploadedFiles/noimage.png')
INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (8, N'Vô danh', N'sonnx7', N'xuanson@gmail.com', N'a', NULL, NULL, CAST(N'2019-05-23' AS Date), NULL, NULL, 0, N'/UploadedFiles/noimage.png')
INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (9, N'Vô danh', N'sonnx8', N'xuansonkaratedo.com@gmail.com', N'a', NULL, NULL, CAST(N'2019-05-23' AS Date), NULL, NULL, 0, N'/UploadedFiles/noimage.png')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Account_Role] ON 

INSERT [dbo].[Account_Role] ([ID], [AccountID], [RoleID]) VALUES (1, 1, 1)
INSERT [dbo].[Account_Role] ([ID], [AccountID], [RoleID]) VALUES (3, 3, 2)
INSERT [dbo].[Account_Role] ([ID], [AccountID], [RoleID]) VALUES (4, 4, 2)
INSERT [dbo].[Account_Role] ([ID], [AccountID], [RoleID]) VALUES (5, 5, 1)
INSERT [dbo].[Account_Role] ([ID], [AccountID], [RoleID]) VALUES (6, 6, 2)
INSERT [dbo].[Account_Role] ([ID], [AccountID], [RoleID]) VALUES (7, 7, 1)
INSERT [dbo].[Account_Role] ([ID], [AccountID], [RoleID]) VALUES (8, 8, 2)
INSERT [dbo].[Account_Role] ([ID], [AccountID], [RoleID]) VALUES (9, 9, 2)
SET IDENTITY_INSERT [dbo].[Account_Role] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (6, N'Tuổi trẻ đáng giá bao nhiêu?', N'                            Nhưng khi đã đi qua gần hết thời đôi mươi, ngấp nghé ở ngưỡng ba mươi, nhìn lại tôi mới thấy tiếc nuối. Thấy bây giờ cuộc sống có quá nhiều cơ hội, nhiều điều phải làm, nhiều thứ để học, mà mình lại không có đủ thời gian cho ngần ấy thứ. Nghĩ nếu mà mình biết những điều này khi còn đi học, khi mình còn trẻ tuổi, chắc hẳn cuộc sống của mình sẽ khác, chắc mình sẽ bớt đi nhiều vật vã gian nan.   
                        ', CAST(15000 AS Decimal(18, 0)), 10, 4, 14, N'/UploadedFiles/1558575015VD1.PNG', NULL, 1)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (7, N'Nhà giả kim', N'Nhà Giả Kim, chính là hành trình chuyển hóa tâm linh của một Linh hồn, khao khát chạm tới điều quý giá nhất. Bằng chính Đức Tin của mình, linh hồn ấy đã được Chúa dẫn dắt trở về với Người. ', CAST(50000 AS Decimal(18, 0)), 10, 2, 13, N'/UploadedFiles/1556745595VD2.PNG', NULL, 1)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (8, N'Đi tìm lẽ sống', N'Là nguồn cảm hứng cho độc giả trên khắp thế giới trong gần một thế kỉ qua, "Đi tìm lẽ sống" là một cuốn sách mà tất cả chúng ta có lẽ đều nên đọc một lần trên con đường đi tìm ý nghĩa cho cuộc đời của mình.', CAST(450000 AS Decimal(18, 0)), 11, 2, 1, N'/UploadedFiles/1556745645VD3.PNG', NULL, 1)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (9, N'Cho tôi xin một vé đi tuổi thơ', N'Truyện Cho tôi xin một vé đi tuổi thơ là sáng tác mới nhất của nhà văn Nguyễn Nhật Ánh. Nhà văn mời người đọc lên chuyến tàu quay ngược trở lại thăm tuổi thơ và tình bạn dễ thương của 4 bạn nhỏ. Những trò chơi dễ thương thời bé, tính cách thật thà, thẳng thắn một cách thông minh và dại dột, những ước mơ tự do trong lòng… khiến cuốn sách có thể làm các bậc phụ huynh lo lắng rồi thở phào. Không chỉ thích hợp với người đọc trẻ, cuốn sách còn có thể hấp dẫn và thực sự có ích cho người lớn trong quan hệ với con mình.
                ', CAST(50000 AS Decimal(18, 0)), 10, 4, 12, N'/UploadedFiles/1556745716VD4.PNG', NULL, 1)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (10, N'Cảm ơn người lớn', N'Cảm ơn người lớn - một áng văn lãng mạn trong giọng hài hước đặc biệt “dành cho trẻ em, và những ai từng là trẻ em”..  Bạn sẽ gặp lại Mùi, Tủn, Tí sún, Hải cò… của Cho tôi xin một vé đi tuổi thơ, cùng chơi những trò chơi quen thuộc, và được đắm mình vào những ước mơ điên rồ, ngốc nghếch nhưng trong veo của tuổi mới lớn hồn nhiên và đầy ắp dự định.
                
                ', CAST(99000 AS Decimal(18, 0)), 11, 2, 100, N'/UploadedFiles/1556745788VD5.PNG', NULL, 1)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (11, N'Túp lều Bác Tom', N'Bác Tom là một nô lệ da đen trung thực, ngay thẳng và trọng danh dự nhưng cuộc đời lại chịu nhiều đớn đau và tủi nhục. Phải lìa bỏ vợ con, bị đánh đạp tàn nhẫn và bị bán từ nơi này qua nơi khác, bác đã trải qua những tháng ngày thống khổ trong các đồn điền trồng bông khủng khiếp ở miền Nam nước Mỹ. Đây cũng là địa ngục của bao cuộc đời lầm than khác như Eliza, một người mẹ đã hi sinh tất cả để cứu đứa con yêu thương của mình hay George, một thanh niên thông minh, cương nghị và yêu tự do tha thiết. Họ đều là những con người đáng quý nhưng lại bị xiềng xích, đánh đập, săn đuổi và giết chết như một bầy thú.', CAST(450000 AS Decimal(18, 0)), 10, 2, 3, N'/UploadedFiles/1556745883VD6.PNG', NULL, 1)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (12, N'Xách ba lô lên và đi', N'"Bước chân của Huyền khởi đầu cho trào lưu mới trong giới trẻ Việt: Khát khao vươn ra thế giới, đi và trải nghiệm" - Tiền Phong  "“Ta ba lô” không chỉ để thỏa mãn khát khao khám phá, trưởng thành mà còn đem hình ảnh, văn hóa Việt Nam đến với bạn bè năm châu. Nhưng không phải ai cũng có bản lĩnh để đi như Huyền" - CAND', CAST(99000 AS Decimal(18, 0)), 15, 2, 4, N'/UploadedFiles/1556746035VD7.PNG', NULL, 1)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (14, N'abc', N'Truyện Cho tôi xin một vé đi tuổi thơ là sáng tác mới nhất của nhà văn Nguyễn Nhật Ánh. Nhà văn mời người đọc lên chuyến tàu quay ngược trở lại thăm tuổi thơ và tình bạn dễ thương của 4 bạn nhỏ. Những trò chơi dễ thương thời bé, tính cách thật thà, thẳng thắn một cách thông minh và dại dột, những ước mơ tự do trong lòng… khiến cuốn sách có thể làm các bậc phụ huynh lo lắng rồi thở phào. Không chỉ thích hợp với người đọc trẻ, cuốn sách còn có thể hấp dẫn và thực sự có ích cho người lớn trong quan hệ với con mình.
                
                
                
                
                ', CAST(450000 AS Decimal(18, 0)), 17, 7, 100, N'/UploadedFiles/1558532960VD5.PNG', NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (15, N'a', N'Truyện Cho tôi xin một vé đi tuổi thơ là sáng tác mới nhất của nhà văn Nguyễn Nhật Ánh. Nhà văn mời người đọc lên chuyến tàu quay ngược trở lại thăm tuổi thơ và tình bạn dễ thương của 4 bạn nhỏ. Những trò chơi dễ thương thời bé, tính cách thật thà, thẳng thắn một cách thông minh và dại dột, những ước mơ tự do trong lòng… khiến cuốn sách có thể làm các bậc phụ huynh lo lắng rồi thở phào. Không chỉ thích hợp với người đọc trẻ, cuốn sách còn có thể hấp dẫn và thực sự có ích cho người lớn trong quan hệ với con mình.', CAST(123 AS Decimal(18, 0)), 10, 2, 123, N'/UploadedFiles/1558565681589011750.jpg', NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (16, N'adfad', N'123', CAST(99000 AS Decimal(18, 0)), 14, 6, 12, N'/UploadedFiles/1558569230VD7.PNG', NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (17, N'Nguyễn Xuân Sơn', N' aba', CAST(123 AS Decimal(18, 0)), 14, 4, 12, N'/UploadedFiles/1558569473VD4.PNG', NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (18, N'Nguyễn Xuân Sơn123', N'123
                        ', CAST(345 AS Decimal(18, 0)), 10, 2, 345, NULL, NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (19, N'Nguyễn Xuân Sơn234324', N'23423       ', CAST(234 AS Decimal(18, 0)), 10, 2, 234, NULL, NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (20, N'Nguyễn Xuân Sơn fgdgdf', N'                            ffgs
                        ', CAST(450000 AS Decimal(18, 0)), 10, 7, 3454, NULL, NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (21, N'123', N'dfgd', CAST(2342 AS Decimal(18, 0)), 10, 2, 23423, NULL, NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (22, N'adfadfds', N'fdf', CAST(23423 AS Decimal(18, 0)), 10, 2, 23423, NULL, NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (23, N'Nguyễn Xuân Sơn123123', N'
                        2313123', CAST(13123 AS Decimal(18, 0)), 10, 2, 123, NULL, NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (24, N'Nguyễn Xuân Sơn', N'345345345', CAST(3454 AS Decimal(18, 0)), 10, 2, 34543, NULL, NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (25, N'312', N'
                        ', CAST(1 AS Decimal(18, 0)), 10, 2, NULL, NULL, NULL, 0)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (26, N'nhà giả kim xyz', N'hay lắm ý', CAST(123 AS Decimal(18, 0)), 10, 2, 1231, N'/UploadedFiles/1558573636VD2.PNG', NULL, 1)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (27, N'Nguyễn Xuân Sơn', N'                                                        
                        123
                        
                        ', CAST(123 AS Decimal(18, 0)), 10, 2, 123, N'/UploadedFiles/1558575166ANKLE BOOTS PH222.jpg', NULL, 0)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Status]) VALUES (10, N'SÁCH KỸ NĂNG', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Status]) VALUES (11, N'VĂN HỌC VIỆT NAM', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Status]) VALUES (13, N'TIỂU THUYẾT', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Status]) VALUES (14, N'VĂN HỌC NƯỚC NGOÀI', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Status]) VALUES (15, N'SÁCH SONG NGỮ', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Status]) VALUES (16, N'SÁCH THIẾU NHI', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Status]) VALUES (17, N'TRINH THÁM', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (1, N'Nguyễn Xuân Sơn', N'xuansonkaratedo.com@gmail.com', N'null', N'02343545', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Hưng Yên', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (2, N'Nguyễn Xuân Sơn', N'xuansonkaratedo.com@gmail.com', N'null', N'11234123', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Yên Mỹ, Hưng Yên', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (3, N'Nguyễn Xuân Sơn', N'xuansonkrt@gmail.com', N'null', N'0344647733', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Thanh Long, Yên Mỹ, Hưng Yên', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (4, N'Nguyễn Hữu Mạnh', N'huumanh56@gmail.com', N'null', N'3231254', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Hưng Yên', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (5, N'Phan Trung Kiên', N'kiendeptrai@gmail.com', N'null', N'035645468', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Đông Anh, Hà Nội', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (6, N'Nguyễn Xuân Sơn', N'xuansonkrt@gmail.com', N'545456', N'0344647733', 1, CAST(N'2019-05-10' AS Date), CAST(N'1998-01-05' AS Date), NULL, NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (7, N'Nguyễn Xuân Sơn', N'xuansonkrt@gmail.com', N'null', N'12333333355', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Hưng Yên', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (8, N'Nguyễn Xuân Sơn', N'doctorwho.vip@gmail.com', N'null', N'123123234', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Hưng Yên', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (10, N'Nguyễn Xuân Sơn', N'xuansonkaratedo.com@gmail.com', N'null', N'0164647523', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Hưng Yên', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (11, N'Nguyễn Xuân Sơn', N'xuansonkrt@gmail.com', N'null', N'0346447733', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Hưng Yên', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (12, N'Nguyễn Hữu Mạnh', N'xuanson@gmail.com', N'null', N'0164649334', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Mê Linh, Hà Nội', NULL)
INSERT [dbo].[Customer] ([ID], [Name], [Email], [Password], [Telephone], [Gender], [join_Date], [DateOfBirth], [Address], [Status]) VALUES (13, N'Phan Trung Kiên', N'doctorwho.vip@gmail.com', N'null', N'01314546', NULL, CAST(N'2019-05-10' AS Date), NULL, N'Đông Anh, Hà Nội', NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Import] ON 

INSERT [dbo].[Import] ([ID], [CreatedDate], [AccountID], [TotalPrice]) VALUES (1, CAST(N'2019-05-24' AS Date), 1, CAST(1000000 AS Decimal(18, 0)))
INSERT [dbo].[Import] ([ID], [CreatedDate], [AccountID], [TotalPrice]) VALUES (2, CAST(N'2019-05-24' AS Date), 1, CAST(1750000 AS Decimal(18, 0)))
INSERT [dbo].[Import] ([ID], [CreatedDate], [AccountID], [TotalPrice]) VALUES (3, CAST(N'2019-05-24' AS Date), 1, CAST(2800000 AS Decimal(18, 0)))
INSERT [dbo].[Import] ([ID], [CreatedDate], [AccountID], [TotalPrice]) VALUES (4, CAST(N'2019-05-24' AS Date), 1, CAST(2050000 AS Decimal(18, 0)))
INSERT [dbo].[Import] ([ID], [CreatedDate], [AccountID], [TotalPrice]) VALUES (5, CAST(N'2019-05-24' AS Date), 1, CAST(1500000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Import] OFF
SET IDENTITY_INSERT [dbo].[ImportDetail] ON 

INSERT [dbo].[ImportDetail] ([ID], [BookID], [ImportID], [Amount], [Price]) VALUES (1, 7, 1, 10, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[ImportDetail] ([ID], [BookID], [ImportID], [Amount], [Price]) VALUES (2, 7, 2, 10, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[ImportDetail] ([ID], [BookID], [ImportID], [Amount], [Price]) VALUES (3, 6, 2, 5, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[ImportDetail] ([ID], [BookID], [ImportID], [Amount], [Price]) VALUES (4, 7, 3, 10, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[ImportDetail] ([ID], [BookID], [ImportID], [Amount], [Price]) VALUES (5, 6, 3, 12, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[ImportDetail] ([ID], [BookID], [ImportID], [Amount], [Price]) VALUES (6, 7, 5, 10, CAST(150000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[ImportDetail] OFF
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([ID], [ID_Account], [DiscountCode], [Price], [OrderDate], [DeliveryDate], [ID_InvoiceStatus], [CustomerName], [Email], [PhoneNumber], [Address]) VALUES (13, NULL, NULL, 90000.0000, CAST(N'2019-05-22 00:00:00.000' AS DateTime), NULL, 3, N'Nguyễn Xuân Sơn', N'xuansonkrt@gmail.com', N'0344647733', N'Thanh Long, Yên Mỹ, Hưng Yên')
SET IDENTITY_INSERT [dbo].[Invoice] OFF
SET IDENTITY_INSERT [dbo].[InvoiceDetail] ON 

INSERT [dbo].[InvoiceDetail] ([ID], [ID_Book], [ID_Invoice], [Quantity], [Price]) VALUES (19, 6, 13, 5, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[InvoiceDetail] ([ID], [ID_Book], [ID_Invoice], [Quantity], [Price]) VALUES (20, 7, 13, 4, CAST(20000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[InvoiceDetail] OFF
SET IDENTITY_INSERT [dbo].[InvoiceStatus] ON 

INSERT [dbo].[InvoiceStatus] ([ID], [Name], [TheOrder]) VALUES (1, N'Đang xử lý', N'1         ')
INSERT [dbo].[InvoiceStatus] ([ID], [Name], [TheOrder]) VALUES (2, N'Đang giao', N'2         ')
INSERT [dbo].[InvoiceStatus] ([ID], [Name], [TheOrder]) VALUES (3, N'Đã giao', N'3         ')
INSERT [dbo].[InvoiceStatus] ([ID], [Name], [TheOrder]) VALUES (4, N'Hủy', N'4         ')
SET IDENTITY_INSERT [dbo].[InvoiceStatus] OFF
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([ID], [Name], [Date], [Description], [Status]) VALUES (2, N'NHÀ XUẤT BẢN KIM ĐỒNG', CAST(N'2019-01-05' AS Date), N'NHÀ XUẤT BẢN KIM ĐỒNG', NULL)
INSERT [dbo].[Publisher] ([ID], [Name], [Date], [Description], [Status]) VALUES (4, N'NHÃ NAM', NULL, N'NHÃ NAM', NULL)
INSERT [dbo].[Publisher] ([ID], [Name], [Date], [Description], [Status]) VALUES (5, N'SKYBOOK', NULL, N'SKYBOOK', NULL)
INSERT [dbo].[Publisher] ([ID], [Name], [Date], [Description], [Status]) VALUES (6, N'NHÀ XUẤT BẢN TRẺ', NULL, N'NHÀ XUẤT BẢN TRẺ', NULL)
INSERT [dbo].[Publisher] ([ID], [Name], [Date], [Description], [Status]) VALUES (7, N'THÁI HÀ', NULL, N'THÁI HÀ', NULL)
INSERT [dbo].[Publisher] ([ID], [Name], [Date], [Description], [Status]) VALUES (8, N'NHÀ XUẤT BẢN GIÁO DỤC', NULL, N'NHÀ XUẤT BẢN GIÁO DỤC', NULL)
INSERT [dbo].[Publisher] ([ID], [Name], [Date], [Description], [Status]) VALUES (9, N'Tiểu thuyết', CAST(N'2019-01-05' AS Date), N'NHÀ XUẤT BẢN TRẺ', NULL)
SET IDENTITY_INSERT [dbo].[Publisher] OFF
INSERT [dbo].[Role] ([ID], [Name]) VALUES (1, N'ADMIN     ')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (2, N'CUSTOMER  ')
ALTER TABLE [dbo].[Account_Role]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role_Account1] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Account_Role] CHECK CONSTRAINT [FK_Account_Role_Account1]
GO
ALTER TABLE [dbo].[Account_Role]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role_Role1] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Account_Role] CHECK CONSTRAINT [FK_Account_Role_Role1]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Publisher] FOREIGN KEY([ID_Publisher])
REFERENCES [dbo].[Publisher] ([ID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Publisher]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_CuonSach_TheLoai] FOREIGN KEY([ID_Category])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_CuonSach_TheLoai]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Account] FOREIGN KEY([ID_Account])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Account]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_Cart] FOREIGN KEY([ID_Cart])
REFERENCES [dbo].[Cart] ([ID_Cart])
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_Cart]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGioHang_CuonSach] FOREIGN KEY([ID_Book])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_ChiTietGioHang_CuonSach]
GO
ALTER TABLE [dbo].[CouponDetail]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_CuonSach] FOREIGN KEY([ID_Book])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[CouponDetail] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_CuonSach]
GO
ALTER TABLE [dbo].[CouponDetail]  WITH CHECK ADD  CONSTRAINT [FK_CouponDetail_Coupon] FOREIGN KEY([ID_Coupon])
REFERENCES [dbo].[Coupon] ([ID])
GO
ALTER TABLE [dbo].[CouponDetail] CHECK CONSTRAINT [FK_CouponDetail_Coupon]
GO
ALTER TABLE [dbo].[Import]  WITH CHECK ADD  CONSTRAINT [FK_Import_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Import] CHECK CONSTRAINT [FK_Import_Account]
GO
ALTER TABLE [dbo].[ImportDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportDetail_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[ImportDetail] CHECK CONSTRAINT [FK_ImportDetail_Book]
GO
ALTER TABLE [dbo].[ImportDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportDetail_Import] FOREIGN KEY([ImportID])
REFERENCES [dbo].[Import] ([ID])
GO
ALTER TABLE [dbo].[ImportDetail] CHECK CONSTRAINT [FK_ImportDetail_Import]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Account] FOREIGN KEY([ID_Account])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Account]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_InvoiceStatus] FOREIGN KEY([ID_InvoiceStatus])
REFERENCES [dbo].[InvoiceStatus] ([ID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_InvoiceStatus]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_CuonSach] FOREIGN KEY([ID_Book])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_ChiTietHoaDon_CuonSach]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Invoice] FOREIGN KEY([ID_Invoice])
REFERENCES [dbo].[Invoice] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Invoice]
GO
ALTER TABLE [dbo].[ListImage]  WITH CHECK ADD  CONSTRAINT [FK_ListImage_CuonSach] FOREIGN KEY([ID_Book])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[ListImage] CHECK CONSTRAINT [FK_ListImage_CuonSach]
GO
ALTER TABLE [dbo].[Rate]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_CuonSach] FOREIGN KEY([ID_Book])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[Rate] CHECK CONSTRAINT [FK_DanhGia_CuonSach]
GO
ALTER TABLE [dbo].[Rate]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Account] FOREIGN KEY([ID_Account])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Rate] CHECK CONSTRAINT [FK_Rate_Account]
GO
/****** Object:  StoredProcedure [dbo].[Account_ChangeRole]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Account_ChangeRole]
	@accountid int,
	@roleid int
as
begin
	update Account_Role
	set RoleID=@roleid
	where AccountID=@accountid
end
GO
/****** Object:  StoredProcedure [dbo].[Account_GetAllSearch]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Account_GetAllSearch]
	@roleid int, 
	@keyWord nvarchar(200)
as
begin
	select a.* 
	from Account a
	inner join Account_Role ar on a.ID = ar.AccountID
	where (@roleid = 0 or ar.RoleID=@roleid )
	and (@keyword is null or Name like ('%'+@keyword+'%') or  Email like ('%'+@keyword+'%')
		or  Telephone like ('%'+@keyword+'%') or  UserName like ('%'+@keyword+'%'))
	and a.Status=1
end
GO
/****** Object:  StoredProcedure [dbo].[Account_GetRoleID]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Account_GetRoleID]
	@accountid int
as
begin
	select ar.RoleID
	from Account_Role ar
	where ar.AccountID=@accountid
end
GO
/****** Object:  StoredProcedure [dbo].[Book_GetAllSearch]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Book_GetAllSearch]
	@categoryId int,
	@min decimal,
	@max decimal,
	@keyword nvarchar(200)
as
begin
	select * 
	from Book
	where( @categoryId is null or @categoryId=0 or ID_Category=@categoryId )
	and  (@min is null or Price>=@min ) 
	and (@max is null or Price<=@max ) 
	and (@keyword is null or (Name like ('%'+@keyword+'%') or Review like ('%'+@keyword+'%')))
	and Book.Status=1
	order by Name
end
GO
/****** Object:  StoredProcedure [dbo].[Invoice_GetAllSearch]    Script Date: 5/24/2019 9:33:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Invoice_GetAllSearch]
	@invoiceStatusID int,
	@keyword nvarchar(200)
as
begin
	select *
	from Invoice
	where ( @invoiceStatusID=0  or ID_InvoiceStatus = @invoiceStatusID ) 
	and (@keyword is null or CustomerName like ('%'+@keyword+'%') or  Email like ('%'+@keyword+'%')
		or  PhoneNumber like ('%'+@keyword+'%') )
end
GO
