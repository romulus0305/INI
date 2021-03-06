USE [master]
GO
/****** Object:  Database [INIGroup]    Script Date: 5/15/2017 2:21:41 PM ******/
CREATE DATABASE [INIGroup]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'INIGroup', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\INIGroup.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'INIGroup_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\INIGroup_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [INIGroup] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [INIGroup].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [INIGroup] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [INIGroup] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [INIGroup] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [INIGroup] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [INIGroup] SET ARITHABORT OFF 
GO
ALTER DATABASE [INIGroup] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [INIGroup] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [INIGroup] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [INIGroup] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [INIGroup] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [INIGroup] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [INIGroup] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [INIGroup] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [INIGroup] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [INIGroup] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [INIGroup] SET  DISABLE_BROKER 
GO
ALTER DATABASE [INIGroup] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [INIGroup] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [INIGroup] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [INIGroup] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [INIGroup] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [INIGroup] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [INIGroup] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [INIGroup] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [INIGroup] SET  MULTI_USER 
GO
ALTER DATABASE [INIGroup] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [INIGroup] SET DB_CHAINING OFF 
GO
ALTER DATABASE [INIGroup] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [INIGroup] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [INIGroup]
GO
/****** Object:  User [INI_user]    Script Date: 5/15/2017 2:21:42 PM ******/
CREATE USER [INI_user] FOR LOGIN [INI_user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [INI_user]
GO
/****** Object:  Table [dbo].[Labels]    Script Date: 5/15/2017 2:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Labels](
	[ViewId] [varchar](30) NOT NULL,
	[ElementId] [varchar](50) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Text] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Labels] PRIMARY KEY CLUSTERED 
(
	[ViewId] ASC,
	[ElementId] ASC,
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Language]    Script Date: 5/15/2017 2:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Contact', N'lblContact', 6, N'<p>Naša adresa, Vam je na raspolaganju:</p>       <h3>INI Industrijski inženjering</h3>
       <span style="text-align:left;">
          Danka Popovića 32<br/>
            11000 Beograd<br/>
            tel.: 011 20-88-666<br /> 
            fax: 011 20-88-637<br /> 
           <p><a href="mailto:ini@ini.rs">e-mail: ini@ini.rs</a>,<a href="mailto:office@das-serbia.com">office@das-serbia.com</a></p>
       </span>')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Contact', N'lblContact-img', 6, N'<img src="../img/cms_images/STR_631_74_957_5.jpg" alt="contact" />
       <div style="margin:4px 0 0 4px">
           <span>
           Slobodno nas pozovite uvek kada Vam je potrebno dodatno obaveštenje.
         </span> 
       </div>
       <div>
           <img src="../img/img/nav/f3.gif" alt="" />
       </div>')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Contact', N'lblInfo', 6, N' <h3>Poslovne informacije</h3>
            <br />
            <span>
                <b>INI&nbsp;doo</b><br />
                Matični broj:&nbsp;<b>17099736</b><br />
                PIB:&nbsp;SR&nbsp;102181527<br /> 
                Poslovni&nbsp;račun:&nbsp;160-81326-53,<br />
                Intesa banka   ')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Contact', N'lblSideNav-left', 6, N'<ul class="navs" style="width:150px;">
            <li><img src="../img/img/nav/t2-Onama_sr.gif" alt="nav" /></li>
            <li><a href="#">Ko smo mi</a></li>
            <li><a href="#">Kvalitet</a></li>
            <li><a href="#">Kontakt</a></li>
            <li><img src="../img/img/nav/2b.gif" alt="nav" /></li>
        </ul>')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Index', N'lblFocusLink1', 6, N'<div style="float:left; width:auto;">
        <a href="#" id="linkBox">
        <div>
            <img src="../Content/cms_images/fokus_na_kompetenciji.jpg" alt="Alternate Text" />
        </div>
        <div style="width:200px;">
            <p>
                Mnoge od vodećih svetskih kompanija spadaju u naše klijente. Biće nam zadovoljstvo da i Vama ponudimo vrhunska rešenja, kvalitet i kompetenciju, 
                koji su ove korporacije opredelili za nas. I da iskustva i znanja stečena u saradnji sa svetskim liderima prenesemo i Vama, u zajedničkom radu. 
            </p>
        </div>
    </a>')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Index', N'lblFocusLink2', 6, N'<div style="float:left; width:auto;">
        <a href="#" id="linkBox">
        <div>
            <img src="../Content/cms_images/fokus_na_vasim_potrebama.jpg" alt="potrebe" />
        </div>
        <div style="width:200px;">
            <p>
                Mnoge od vodećih svetskih kompanija spadaju u naše klijente. Biće nam zadovoljstvo da i Vama ponudimo vrhunska rešenja, kvalitet i kompetenciju, 
                koji su ove korporacije opredelili za nas. I da iskustva i znanja stečena u saradnji sa svetskim liderima prenesemo i Vama, u zajedničkom radu. 
            </p>
        </div>
       </a>
    </div>')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Index', N'lblFocusLink3', 6, N'    <div style="float:left; width:auto;">
        <a href="#" id="linkBox" >
        <div>
            <img src="../Content/cms_images/fokus_na_kvalitetu.jpg" alt="kompetencija" />
        </div>
        <div style="width:200px;">
            <p>
                Mi radimo sa svim vrstama kompanija — od svetskih giganata Fortune 500, preko velikih, srednjih i malih, do mikro. 
                Oni su došli u INI raznim putevima i iz različitih razloga,
                ali ostaju sa nama pre svega zbog jednog: mi im dajemo vrhunski tretman od prvog dana i nikada ne prestajemo.
            </p>
        </div>
       </a>
    </div>')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Index', N'lblNews1', 6, N' <div>
                <img src="../Content/nav/news_rs.gif" alt="news" style="width:300px" />
               <p style="text-align:left;">
                   <a href="#">Nova INI vrhunska internet infrastruktura</a><br>
                    Pored šestostruko redudantnog pristupa preko Tier 1 globalnih provajdera i 100% dostupnosti, 
                   nova infrastruktura omogućava našim kupcima izuzetne performanse i siguran rad, 
                   i u uslovima vanrednih situacija, kroz našu bezbednu superstrukturu.
               </p>
          </div>')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Index', N'lblNews2', 6, N'<div>
               <p>
                  <a href="#">INI u vrhunskom razvojnom projektu EU</a><br>    
                Kao jedno od malog broja preduzeća iz regiona, INI učestvuje u vrhunskom razvojnom projektu iz šeme FP7 Evropske Unije.
               </p>
          </div>')
INSERT [dbo].[Labels] ([ViewId], [ElementId], [LanguageId], [Text]) VALUES (N'Index', N'lblSolutionImg', 6, N'<div style="float:left;  margin-right:10px">
            <img class="img" src="../Content/cms_images/resenje.jpg" alt="solutions" />
        </div>')
INSERT [dbo].[Language] ([LanguageId], [Name]) VALUES (1, N'ENGLISH')
INSERT [dbo].[Language] ([LanguageId], [Name]) VALUES (2, N'ESPAÑOL')
INSERT [dbo].[Language] ([LanguageId], [Name]) VALUES (3, N'DEUTSCH')
INSERT [dbo].[Language] ([LanguageId], [Name]) VALUES (4, N'ITALIANO')
INSERT [dbo].[Language] ([LanguageId], [Name]) VALUES (5, N'FRANCAIS')
INSERT [dbo].[Language] ([LanguageId], [Name]) VALUES (6, N'SERBIAN')
ALTER TABLE [dbo].[Labels]  WITH CHECK ADD  CONSTRAINT [FK_Labels_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Labels] CHECK CONSTRAINT [FK_Labels_Language]
GO
USE [master]
GO
ALTER DATABASE [INIGroup] SET  READ_WRITE 
GO
