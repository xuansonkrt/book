USE [BanSach]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/22/2019 8:14:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
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
/****** Object:  Table [dbo].[Account_Role]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[Book]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[Cart]    Script Date: 5/22/2019 8:14:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID_Account] [int] NOT NULL,
	[ID_Cart] [int] NOT NULL,
	[Status] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_MuaHang_1] PRIMARY KEY CLUSTERED 
(
	[ID_Cart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CartDetail]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[Coupon]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[CouponDetail]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[Invoice]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[InvoiceStatus]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[ListImage]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[Publisher]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[Rate]    Script Date: 5/22/2019 8:14:46 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 5/22/2019 8:14:46 PM ******/
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

INSERT [dbo].[Account] ([ID], [Name], [UserName], [Email], [Password], [Telephone], [Gender], [CreatedDate], [DateOfBirth], [Address], [Status], [Avatar]) VALUES (1, N'Nguyễn Xuân Sơn', N'sonnx', N'xuansonkrt@gmail.com', N'a', NULL, NULL, NULL, NULL, NULL, 1, N'/UploadedFiles/1556701840IMG_9405-3.jpg')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (6, N'Tuổi trẻ đáng giá bao nhiêu?', N'Nhưng khi đã đi qua gần hết thời đôi mươi, ngấp nghé ở ngưỡng ba mươi, nhìn lại tôi mới thấy tiếc nuối. Thấy bây giờ cuộc sống có quá nhiều cơ hội, nhiều điều phải làm, nhiều thứ để học, mà mình lại không có đủ thời gian cho ngần ấy thứ. Nghĩ nếu mà mình biết những điều này khi còn đi học, khi mình còn trẻ tuổi, chắc hẳn cuộc sống của mình sẽ khác, chắc mình sẽ bớt đi nhiều vật vã gian nan.   ', CAST(15000 AS Decimal(18, 0)), 10, 4, 14, N'/UploadedFiles/1556745478VD1.PNG', NULL, NULL)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (7, N'Nhà giả kim', N'Nhà Giả Kim, chính là hành trình chuyển hóa tâm linh của một Linh hồn, khao khát chạm tới điều quý giá nhất. Bằng chính Đức Tin của mình, linh hồn ấy đã được Chúa dẫn dắt trở về với Người. ', CAST(50000 AS Decimal(18, 0)), 10, 2, 3, N'/UploadedFiles/1556745595VD2.PNG', NULL, NULL)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (8, N'Đi tìm lẽ sống', N'Là nguồn cảm hứng cho độc giả trên khắp thế giới trong gần một thế kỉ qua, "Đi tìm lẽ sống" là một cuốn sách mà tất cả chúng ta có lẽ đều nên đọc một lần trên con đường đi tìm ý nghĩa cho cuộc đời của mình.', CAST(450000 AS Decimal(18, 0)), 11, 2, 1, N'/UploadedFiles/1556745645VD3.PNG', NULL, NULL)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (9, N'Cho tôi xin một vé đi tuổi thơ', N'Truyện Cho tôi xin một vé đi tuổi thơ là sáng tác mới nhất của nhà văn Nguyễn Nhật Ánh. Nhà văn mời người đọc lên chuyến tàu quay ngược trở lại thăm tuổi thơ và tình bạn dễ thương của 4 bạn nhỏ. Những trò chơi dễ thương thời bé, tính cách thật thà, thẳng thắn một cách thông minh và dại dột, những ước mơ tự do trong lòng… khiến cuốn sách có thể làm các bậc phụ huynh lo lắng rồi thở phào. Không chỉ thích hợp với người đọc trẻ, cuốn sách còn có thể hấp dẫn và thực sự có ích cho người lớn trong quan hệ với con mình.
                ', CAST(50000 AS Decimal(18, 0)), 10, 4, 12, N'/UploadedFiles/1556745716VD4.PNG', NULL, NULL)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (10, N'Cảm ơn người lớn', N'Cảm ơn người lớn - một áng văn lãng mạn trong giọng hài hước đặc biệt “dành cho trẻ em, và những ai từng là trẻ em”..  Bạn sẽ gặp lại Mùi, Tủn, Tí sún, Hải cò… của Cho tôi xin một vé đi tuổi thơ, cùng chơi những trò chơi quen thuộc, và được đắm mình vào những ước mơ điên rồ, ngốc nghếch nhưng trong veo của tuổi mới lớn hồn nhiên và đầy ắp dự định.
                
                ', CAST(99000 AS Decimal(18, 0)), 11, 2, 100, N'/UploadedFiles/1556745788VD5.PNG', NULL, NULL)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (11, N'Túp lều Bác Tom', N'Bác Tom là một nô lệ da đen trung thực, ngay thẳng và trọng danh dự nhưng cuộc đời lại chịu nhiều đớn đau và tủi nhục. Phải lìa bỏ vợ con, bị đánh đạp tàn nhẫn và bị bán từ nơi này qua nơi khác, bác đã trải qua những tháng ngày thống khổ trong các đồn điền trồng bông khủng khiếp ở miền Nam nước Mỹ. Đây cũng là địa ngục của bao cuộc đời lầm than khác như Eliza, một người mẹ đã hi sinh tất cả để cứu đứa con yêu thương của mình hay George, một thanh niên thông minh, cương nghị và yêu tự do tha thiết. Họ đều là những con người đáng quý nhưng lại bị xiềng xích, đánh đập, săn đuổi và giết chết như một bầy thú.', CAST(450000 AS Decimal(18, 0)), 10, 2, 3, N'/UploadedFiles/1556745883VD6.PNG', NULL, NULL)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (12, N'Xách ba lô lên và đi', N'"Bước chân của Huyền khởi đầu cho trào lưu mới trong giới trẻ Việt: Khát khao vươn ra thế giới, đi và trải nghiệm" - Tiền Phong  "“Ta ba lô” không chỉ để thỏa mãn khát khao khám phá, trưởng thành mà còn đem hình ảnh, văn hóa Việt Nam đến với bạn bè năm châu. Nhưng không phải ai cũng có bản lĩnh để đi như Huyền" - CAND', CAST(99000 AS Decimal(18, 0)), 15, 2, 4, N'/UploadedFiles/1556746035VD7.PNG', NULL, NULL)
INSERT [dbo].[Book] ([ID], [Name], [Review], [Price], [ID_Category], [ID_Publisher], [Quantity], [MainImage], [Author], [Status]) VALUES (14, N'abc', N'                    Truyện Cho tôi xin một vé đi tuổi thơ là sáng tác mới nhất của nhà văn Nguyễn Nhật Ánh. Nhà văn mời người đọc lên chuyến tàu quay ngược trở lại thăm tuổi thơ và tình bạn dễ thương của 4 bạn nhỏ. Những trò chơi dễ thương thời bé, tính cách thật thà, thẳng thắn một cách thông minh và dại dột, những ước mơ tự do trong lòng… khiến cuốn sách có thể làm các bậc phụ huynh lo lắng rồi thở phào. Không chỉ thích hợp với người đọc trẻ, cuốn sách còn có thể hấp dẫn và thực sự có ích cho người lớn trong quan hệ với con mình.
                ', CAST(450000 AS Decimal(18, 0)), 17, 7, 100, N'/UploadedFiles/1558532960VD5.PNG', NULL, NULL)
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
ALTER TABLE [dbo].[Account_Role]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Account_Role] CHECK CONSTRAINT [FK_Account_Role_Account]
GO
ALTER TABLE [dbo].[Account_Role]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Account_Role] CHECK CONSTRAINT [FK_Account_Role_Role]
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
/****** Object:  StoredProcedure [dbo].[Book_GetAllSearch]    Script Date: 5/22/2019 8:14:46 PM ******/
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
	order by Name
end
GO
