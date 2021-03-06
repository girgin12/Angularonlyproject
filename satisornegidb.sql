USE [master]
GO
/****** Object:  Database [satis]    Script Date: 30.11.2020 15:15:29 ******/
CREATE DATABASE [satis]
 CONTAINMENT = NONE


GO
ALTER DATABASE [satis] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [satis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [satis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [satis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [satis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [satis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [satis] SET ARITHABORT OFF 
GO
ALTER DATABASE [satis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [satis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [satis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [satis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [satis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [satis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [satis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [satis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [satis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [satis] SET  DISABLE_BROKER 
GO
ALTER DATABASE [satis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [satis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [satis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [satis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [satis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [satis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [satis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [satis] SET RECOVERY FULL 
GO
ALTER DATABASE [satis] SET  MULTI_USER 
GO
ALTER DATABASE [satis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [satis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [satis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [satis] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [satis] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'satis', N'ON'
GO
USE [satis]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 30.11.2020 15:15:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](50) NOT NULL,
	[SilindiMi] [bit] NOT NULL CONSTRAINT [DF_Kullanici_SilindiMi]  DEFAULT ((0)),
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Satis]    Script Date: 30.11.2020 15:15:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satis](
	[SatisID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[SatisAdedi] [int] NOT NULL CONSTRAINT [DF_Satis_SatisAdedi]  DEFAULT ((1)),
	[ToplamTutar] [float] NOT NULL,
	[SatisZamani] [datetime] NOT NULL CONSTRAINT [DF_Satis_SatisZamani]  DEFAULT (getdate()),
 CONSTRAINT [PK_Satis] PRIMARY KEY CLUSTERED 
(
	[SatisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Urun]    Script Date: 30.11.2020 15:15:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](50) NOT NULL,
	[UrunMarkasi] [nvarchar](50) NULL,
	[UrunFiyat] [float] NOT NULL,
	[StokAdedi] [int] NOT NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

GO
INSERT [dbo].[Kullanici] ([KullaniciID], [AdSoyad], [SilindiMi]) VALUES (1, N'Serkan TELCİ', 0)
GO
INSERT [dbo].[Kullanici] ([KullaniciID], [AdSoyad], [SilindiMi]) VALUES (2, N'Ali Veli', 0)
GO
INSERT [dbo].[Kullanici] ([KullaniciID], [AdSoyad], [SilindiMi]) VALUES (3, N'Burak Sağlam', 0)
GO
INSERT [dbo].[Kullanici] ([KullaniciID], [AdSoyad], [SilindiMi]) VALUES (4, N'deneme ad soyad', 0)
GO
INSERT [dbo].[Kullanici] ([KullaniciID], [AdSoyad], [SilindiMi]) VALUES (5, N'serkan veli', 0)
GO
INSERT [dbo].[Kullanici] ([KullaniciID], [AdSoyad], [SilindiMi]) VALUES (6, N'Muhammet Girgin', 0)
GO
INSERT [dbo].[Kullanici] ([KullaniciID], [AdSoyad], [SilindiMi]) VALUES (7, N'deneme', 0)
GO
INSERT [dbo].[Kullanici] ([KullaniciID], [AdSoyad], [SilindiMi]) VALUES (8, N'denem adsoyad', 1)
GO
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[Satis] ON 

GO
INSERT [dbo].[Satis] ([SatisID], [KullaniciID], [UrunID], [SatisAdedi], [ToplamTutar], [SatisZamani]) VALUES (1, 1, 1, 2, 3, CAST(N'2020-11-30 11:33:10.957' AS DateTime))
GO
INSERT [dbo].[Satis] ([SatisID], [KullaniciID], [UrunID], [SatisAdedi], [ToplamTutar], [SatisZamani]) VALUES (2, 2, 3, 1, 20, CAST(N'2020-11-30 11:34:33.010' AS DateTime))
GO
INSERT [dbo].[Satis] ([SatisID], [KullaniciID], [UrunID], [SatisAdedi], [ToplamTutar], [SatisZamani]) VALUES (3, 3, 2, 2, 5.5, CAST(N'2020-12-01 11:33:10.957' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Satis] OFF
GO
SET IDENTITY_INSERT [dbo].[Urun] ON 

GO
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [UrunMarkasi], [UrunFiyat], [StokAdedi]) VALUES (1, N'Ekmek', NULL, 1.5, 100)
GO
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [UrunMarkasi], [UrunFiyat], [StokAdedi]) VALUES (2, N'Çikolata', N'ülker', 2, 50)
GO
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [UrunMarkasi], [UrunFiyat], [StokAdedi]) VALUES (3, N'Şeker', N'Torku', 15, 25)
GO
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [UrunMarkasi], [UrunFiyat], [StokAdedi]) VALUES (5, N'aa', N'aa', 50, 50)
GO
SET IDENTITY_INSERT [dbo].[Urun] OFF
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Kullanici] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanici] ([KullaniciID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Kullanici]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Urun]
GO
USE [master]
GO
ALTER DATABASE [satis] SET  READ_WRITE 
GO
