SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------start craete database-----------------------------------------
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'UBTER')
BEGIN
Create database UBTER;
END
------------end craete database-----------------------------------------
GO
use UBTER;
----Create REGISTRATION
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[REGISTRATION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[REGISTRATION](
	[CANDIDATEID] [varchar](8) NOT NULL,
	[ROLL] [varchar](11) NULL,
	[PASSWORD] [varchar](12) NULL,
	[SEM] [varchar](2) NULL,
	[JROLL] [varchar](8) NULL,
	[INSCODE] [varchar](3) NULL,
	[INSNAME] [varchar](100) NULL,
	[REGCAT] [varchar](4) NULL,
	[ADDCAT] [varchar](1) NULL,
	[BRCODE] [varchar](5) NULL,
	[BRNAME] [varchar](50) NULL,
	[SHIFT] [varchar](2) NULL,
	[GRP] [varchar](1) NULL,
	[CNAME] [varchar](35) NULL,
	[FNAME] [varchar](35) NULL,
	[DOB] [varchar](10) NULL,
	[GENDER] [varchar](1) NULL,
	[CAT] [varchar](3) NULL,
	[SUBCAT] [varchar](3) NULL,
	[NATION] [varchar](50) NULL,
	[MONO] [varchar](10) NULL,
	[LLN] [varchar](13) NULL,
	[EMAIL] [varchar](50) NULL,
	[FEE] [int] NULL,
	[EXFEE] [int] NULL,
	[APPFEE] [int] NULL,
	[MSFEE] [int] NULL,
	[LATFEE] [int] NULL,
	[FEEDATE] [varchar](10) NULL,
	[TENUNI] [varchar](100) NULL,
	[TENYEAR] [varchar](4) NULL,
	[TENMO] [varchar](4) NULL,
	[TENMM] [varchar](4) NULL,
	[TENPER] [varchar](5) NULL,
	[TENSUB] [varchar](200) NULL,
	[INTERUNI] [varchar](100) NULL,
	[INTERYEAR] [varchar](4) NULL,
	[INTERMO] [varchar](4) NULL,
	[INTERMM] [varchar](4) NULL,
	[INTERPER] [varchar](5) NULL,
	[INTERSUB] [varchar](200) NULL,
	[UG] [varchar](50) NULL,
	[UGUNI] [varchar](100) NULL,
	[UGYEAR] [varchar](4) NULL,
	[UGMO] [varchar](4) NULL,
	[UGMM] [varchar](4) NULL,
	[UGPER] [varchar](5) NULL,
	[UGSUB] [varchar](200) NULL,
	[PG] [varchar](50) NULL,
	[PGUNI] [varchar](100) NULL,
	[PGYEAR] [varchar](4) NULL,
	[PGMO] [varchar](4) NULL,
	[PGMM] [varchar](4) NULL,
	[PGPER] [varchar](5) NULL,
	[PGSUB] [varchar](200) NULL,
	[OTH] [varchar](50) NULL,
	[OUNI] [varchar](100) NULL,
	[OYEAR] [varchar](4) NULL,
	[OMO] [varchar](4) NULL,
	[OMM] [varchar](4) NULL,
	[OPER] [varchar](5) NULL,
	[OSUB] [varchar](200) NULL,
	[CADDRESS] [varchar](100) NULL,
	[CSTATE] [varchar](50) NULL,
	[CDISTRICT] [varchar](50) NULL,
	[CPIN] [varchar](6) NULL,
	[ISSAME] [int] NULL,
	[PADDRESS] [varchar](100) NULL,
	[PSTATE] [varchar](50) NULL,
	[PDISTRICT] [varchar](50) NULL,
	[PPIN] [varchar](6) NULL,
	[ISREG] [bit] NULL,
	[ISQUA] [bit] NULL,
	[ISADD] [bit] NULL,
	[ISPH] [bit] NULL,
	[ISCOMPLETED] [bit] NULL,
	[BACKT] [varchar](50) NULL,
	[BACKP] [varchar](50) NULL,
	[ISSEM2] [bit] NULL,
	[ISSEM2COMP] [bit] NULL,
	[SEM2FEE] [int] NULL,
	[BACKFEE] [int] NULL,
	[SEM1] [bit] NULL,
	[SEMCOM1] [bit] NULL,
	[SEMFEE1] [int] NULL,
	[SEM2] [bit] NULL,
	[SEMCOM2] [bit] NULL,
	[SEMFEE2] [int] NULL,
	[SEM3] [bit] NULL,
	[SEMCOM3] [bit] NULL,
	[SEMFEE3] [int] NULL,
	[SEM4] [bit] NULL,
	[SEMCOM4] [bit] NULL,
	[SEMFEE4] [int] NULL,
	[SEM5] [bit] NULL,
	[SEMCOM5] [bit] NULL,
	[SEMFEE5] [int] NULL,
	[SEM6] [bit] NULL,
	[SEMCOM6] [bit] NULL,
	[SEMFEE6] [int] NULL,
[CREATEDON] [datetime] NULL CONSTRAINT [DF_REGISTRATION_CreatedOn]  DEFAULT (getdate()),
[UPDATEDON] [datetime] NULL CONSTRAINT [DF_REGISTRATION_UpdatedOn]  DEFAULT (getdate()),
CONSTRAINT [PK_REGISTRATION] PRIMARY KEY CLUSTERED
(
[CANDIDATEID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'REGISTRATION', N'COLUMN',N'GENDER'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'M -Male/F-Female' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'REGISTRATION', @level2type=N'COLUMN',@level2name=N'GENDER'
----Create REGID TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[REGID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[REGID](
[CANDIDATEID] [int] IDENTITY(18000001,1) NOT NULL,
[PASSWORD] [varchar](12) NULL,
CONSTRAINT [PK_REGID] PRIMARY KEY CLUSTERED
(
[CANDIDATEID] ASC

)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
----Create INSLOGIN TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSLOGIN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[INSLOGIN](
[INSCODE] [varchar](3) NULL,
[INSNAME] [varchar](100) NULL,
[STATUS] [varchar](4) NULL,
[TYPE] [varchar](10) NULL,
[PASSWORD] [varchar](12) NULL,
[PWD] [varchar](1) NULL,
[MONO] [varchar](10) NULL,
[LLNO] [varchar](15) NULL,
[EMAIL] [varchar](50) NULL,
[GENDER] [varchar](1) NULL,
)
END
----Create BRLOGIN TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BRLOGIN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BRLOGIN](
[INSCODE] [varchar](3) NULL,
[INSNAME] [varchar](100) NULL,
[BRCODE] [varchar](5) NULL,
[BRNAME] [varchar](60) NULL,
[GRP] [varchar](1) NULL,
[PASSWORD] [varchar](12) NULL,
[SHIFT] [varchar](2) NULL,
[EMAIL] [varchar](50) NULL,
)
END
--Create UDP_REGID
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_REGID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[UDP_REGID]
@CANDIDATEID varchar(8) out,
@PASSWORD varchar(12)
As
begin tran
insert into REGID(PASSWORD)
values(@PASSWORD)
select @CANDIDATEID=@@identity
if @@error<>0  
 begin  
  Set @CANDIDATEID=0  
   rollback;  
end
commit;
' 
END
----Creare UDP_UserLogin
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_UserLogin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UDP_UserLogin]
@CANDIDATEID varchar(8),
@PASSWORD varchar(12)
As
begin
select * from REGISTRATION where CANDIDATEID=@CANDIDATEID and PASSWORD=@PASSWORD
end
'
END
----Creare UDP_RollLogin
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_RollLogin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UDP_RollLogin]
@ROLL varchar(11),
@PASSWORD varchar(12)
As
begin
select * from REGISTRATION where ROLL=@ROLL and PASSWORD=@PASSWORD
end
'
END
----Creare UDP_LOGIN Principal
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_Loginins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UDP_Loginins]
@INSCODE varchar(3),
@PASSWORD varchar(12)
As
begin
select * from INSLOGIN where INSCODE=@INSCODE and PASSWORD=@PASSWORD
end
'
END

--Create UDP_REGISTRATION
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_REG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[UDP_REG]

@CANDIDATEID varchar(8),
@GENDER varchar(1),
@CAT varchar(3),
@SUBCAT varchar(3),
@NATION varchar(50),
@MONO varchar(10),
@LLN varchar(13),
@EMAIL varchar(50),
@AADHAR varchar(12),
@MINORITY varchar(1),
@RESULT varchar(1) out
As
begin tran
update REGISTRATION
set
GENDER=@GENDER,
CAT=@CAT,
SUBCAT=@SUBCAT,
NATION=@NATION,
MONO=@MONO,
LLN=@LLN,
EMAIL=@EMAIL,
AADHAR=@AADHAR,
MINORITY=@MINORITY,
ISREG=1,
UPDATEDON=getdate()
where CANDIDATEID =@CANDIDATEID
set @RESULT=1
if @@error<>0      
begin   
set @RESULT=0          
rollback;      
end      
commit;
' 
END
--CREATE QUALIFICATION
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_QUA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UDP_QUA]  
@RESULT varchar(1) out,
@CANDIDATEID varchar(8),  
@TENUNI varchar(100),
@TENYEAR varchar(4),
@TENMO varchar(4),
@TENMM varchar(4),
@TENPER varchar(5),
@INTERUNI varchar(100),
@INTERYEAR varchar(4),
@INTERMO varchar(4),
@INTERMM varchar(4),
@INTERPER varchar(5),
@UG varchar(50),
@UGUNI varchar(100),
@UGYEAR varchar(4),
@UGMO varchar(4),
@UGMM varchar(4),
@UGPER varchar(5),
@PG varchar(50),
@PGUNI varchar(100),
@PGYEAR varchar(4),
@PGMO varchar(4),
@PGMM varchar(4),
@PGPER varchar(5),
@OTH varchar(50),
@OUNI varchar(100),
@OYEAR varchar(4),
@OMO varchar(4),
@OMM varchar(4),
@OPER varchar(5),
@HPASS varchar(1),
@HAREA varchar(1),
@IPASS varchar(1),
@ITIPASS varchar(1)
As  
Begin
update REGISTRATION set   
TENUNI=@TENUNI,
TENYEAR=@TENYEAR,
TENMO=@TENMO,
TENMM=@TENMM,
TENPER=@TENPER,
INTERUNI=@INTERUNI,
INTERYEAR=@INTERYEAR,
INTERMO=@INTERMO,
INTERMM=@INTERMM,
INTERPER=@INTERPER,
UG=@UG,
UGUNI=@UGUNI,
UGYEAR=@UGYEAR,
UGMO=@UGMO,
UGMM=@UGMM,
UGPER=@UGPER,
PG=@PG,
PGUNI=@PGUNI,
PGYEAR=@PGYEAR,
PGMO=@PGMO,
PGMM=@PGMM,
PGPER=@PGPER,
OTH=@OTH,
OUNI=@OUNI,
OYEAR=@OYEAR,
OMO=@OMO,
OMM=@OMM,
OPER=@OPER,
HPASS=@HPASS,
HAREA=@HAREA,
IPASS=@IPASS,
ITIPASS=@ITIPASS,
ISQUA=1,
UPDATEDON=getdate()
where CANDIDATEID=@CANDIDATEID
set @RESULT=1       
if @@error<>0
begin
set @RESULT=0
rollback;
commit;
end
end
'
END
--CREATE ADDRESS
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_ADDRESS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UDP_ADDRESS]
@CANDIDATEID varchar(8),
@CADDRESS varchar(100),
@CSTATE varchar(50),
@CDISTRICT varchar(50),
@CTEHSIL varchar(35),
@CBLOCK varchar(35),
@CPIN varchar(6),
@ISSAME int,
@PADDRESS varchar(100),
@PSTATE varchar(50),
@PDISTRICT varchar(50),
@PTEHSIL varchar(35),
@PBLOCK varchar(35),
@PPIN varchar(6),
@RESULT varchar(1) out
As
begin tran
update REGISTRATION
set
CADDRESS=@CADDRESS,
CDISTRICT=@CDISTRICT,
CSTATE=@CSTATE,
CTEHSIL=@CTEHSIL,
CBLOCK=@CBLOCK,
CPIN=@CPIN,
ISSAME=@ISSAME,
PADDRESS=@PADDRESS,
PDISTRICT=@PDISTRICT,
PSTATE=@PSTATE,
PTEHSIL=@PTEHSIL,
PBLOCK=@PBLOCK,
PPIN=@PPIN,
ISADD=1,
UPDATEDON=getdate()
where CANDIDATEID =@CANDIDATEID
set @RESULT=1
if @@error<>0      
begin   
set @RESULT=0          
rollback;      
end      
commit;
' 
END
--CREATE INSTITUTE PASSWORD
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_INS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UDP_INS]
@OLDPASS varchar(12),
@PASSWORD varchar(12),
@INSCODE varchar(3),
@PWD varchar(1),
@MONO varchar(10),
@LLNO varchar(13),
@EMAIL varchar(50),
@RESULT varchar(1) out
As
begin tran
update INSLOGIN
set
PASSWORD=@PASSWORD,
MONO=@MONO,
LLNO=@LLNO,
EMAIL=@EMAIL,
PWD=@PWD
where INSCODE=@INSCODE and PASSWORD=@OLDPASS
set @RESULT=1
if @@error<>0      
begin   
set @RESULT=0          
rollback;      
end      
commit;
' 
END
----Creare UDP_QUERY
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_QUERY]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UDP_QUERY]
@QUERYTEXT varchar(1000)
As
begin
EXECUTE(@QUERYTEXT)
end
' 
END
----Creare UDP_ONLYQUERY
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDP_ONLYQUERY]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UDP_ONLYQUERY]
@QUERYTEXT varchar(1000),
@Result varchar(1) out
As
begin
EXECUTE(@QUERYTEXT)
set @Result=1    
if @@error<>0
begin
set @Result=0
rollback;
commit;
end
end
'
END
----Create ADMIN TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADMIN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ADMIN](
[USERID] [varchar](30) NULL,
[PASSWORD] [varchar](12) NULL,
)
END
----Create LISTE TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LISTE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].LISTE(
[CANDIDATEID] [varchar](8) NULL,
[CNAME] [varchar](35) NULL,
[FNAME] [varchar](35) NULL,
[DOB] [varchar](10) NULL,
[GENDER] [varchar](1) NULL,
[INSCODE] [varchar](3) NULL,
[BRCODE] [varchar](5) NULL,
[SUBCODE] [varchar](4) NULL,
[SEM] [varchar](2) NULL,
[MARKS] [varchar](3) NULL,
[FLG] [varchar](1) NULL,
[UPDATEDON] [datetime] NULL
)
END
----Create LISTD TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LISTD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].LISTD(
[CANDIDATEID] [varchar](8) NULL,
[CNAME] [varchar](35) NULL,
[FNAME] [varchar](35) NULL,
[DOB] [varchar](10) NULL,
[GENDER] [varchar](1) NULL,
[INSCODE] [varchar](3) NULL,
[BRCODE] [varchar](5) NULL,
[SUBCODE] [varchar](4) NULL,
[SEM] [varchar](2) NULL,
[MARKS] [varchar](3) NULL,
[FLG] [varchar](1) NULL,
[UPDATEDON] [datetime] NULL
)
END
----Create SESSMRK TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SESSMRK]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].SESSMRK(
[CANDIDATEID] [varchar](8) NULL,
[CNAME] [varchar](35) NULL,
[FNAME] [varchar](35) NULL,
[DOB] [varchar](10) NULL,
[GENDER] [varchar](1) NULL,
[INSCODE] [varchar](3) NULL,
[BRCODE] [varchar](5) NULL,
[SUBCODE1] [varchar](4) NULL,
[SUBCODE2] [varchar](4) NULL,
[SUBCODE3] [varchar](4) NULL,
[SEM] [varchar](2) NULL,
[MARK1] [varchar](3) NULL,
[MARK2] [varchar](3) NULL,
[MARK3] [varchar](3) NULL,
[FLG1] [varchar](1) NULL,
[FLG2] [varchar](1) NULL,
[FLG3] [varchar](1) NULL,
[UPDATEDON] [datetime] NULL
)
END
----Create ROLL TABLE FOR GENERATE ROLL NUMBER
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ROLL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ROLL](
[CANDIDATEID] [varchar](8) NOT NULL,
[INSCODE] [varchar](3) NULL,
[INSNAME] [varchar](100) NULL,
[BRCODE] [varchar](5) NULL,
[BRNAME] [varchar](100) NULL,
[SHIFT] [varchar](2) NULL,
[GRP] [varchar](1) NULL,
[CNAME] [varchar](35) NULL,
[FNAME] [varchar](35) NULL,
[DOB] [varchar](10) NULL,
[ROLL] [varchar](11) NULL
) ON [PRIMARY]
END
----Create SCRUTINY TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SCRU]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SCRU](
[CANDIDATEID] [varchar](8) NULL,
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[INSCODE] [varchar](3) NULL,
[INSNAME] [varchar](100) NULL,
[BRCODE] [varchar](5) NULL,
[BRNAME] [varchar](50) NULL,
[SHIFT] [varchar](2) NULL,
[CNAME] [varchar](35) NULL,
[FNAME] [varchar](35) NULL,
[DOB] [varchar](10) NULL,
[SUB] [varchar](150) NULL,
[TYPE] [varchar](1) NULL,
[FEE] [int] NULL,
[ISCOMPLETED] [bit] NULL,
[CREATEDON] [datetime] NULL CONSTRAINT [DF_SCRU_CreatedOn]  DEFAULT (getdate()),
[UPDATEDON] [datetime] NULL CONSTRAINT [DF_SCRU_UpdatedOn]  DEFAULT (getdate()),
) ON [PRIMARY]
END
----Create RE-EVALUATION TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[REEVA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[REEVA](
[CANDIDATEID] [varchar](8) NULL,
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[INSCODE] [varchar](3) NULL,
[INSNAME] [varchar](100) NULL,
[BRCODE] [varchar](5) NULL,
[BRNAME] [varchar](50) NULL,
[SHIFT] [varchar](2) NULL,
[CNAME] [varchar](35) NULL,
[FNAME] [varchar](35) NULL,
[DOB] [varchar](10) NULL,
[SUB] [varchar](150) NULL,
[TYPE] [varchar](1) NULL,
[FEE] [int] NULL,
[ISCOMPLETED] [bit] NULL,
[CREATEDON] [datetime] NULL CONSTRAINT [DF_REEVA_CreatedOn]  DEFAULT (getdate()),
[UPDATEDON] [datetime] NULL CONSTRAINT [DF_REEVA_UpdatedOn]  DEFAULT (getdate()),
) ON [PRIMARY]
END
----Create BACKPAPER TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BACKP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BACKP](
[CANDIDATEID] [varchar](8) NULL,
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[INSCODE] [varchar](3) NULL,
[INSNAME] [varchar](100) NULL,
[BRCODE] [varchar](5) NULL,
[BRNAME] [varchar](50) NULL,
[SHIFT] [varchar](2) NULL,
[CNAME] [varchar](35) NULL,
[FNAME] [varchar](35) NULL,
[DOB] [varchar](10) NULL,
[SUBA] [varchar](250) NULL,
[SUBN] [varchar](250) NULL,
[TYPE] [varchar](1) NULL,
[FEE] [int] NULL,
[ISCOMPLETED] [bit] NULL,
[CREATEDON] [datetime] NULL CONSTRAINT [DF_BACKP_CreatedOn]  DEFAULT (getdate()),
[UPDATEDON] [datetime] NULL CONSTRAINT [DF_BACKP_UpdatedOn]  DEFAULT (getdate()),
) ON [PRIMARY]
END
----Create EXAMINER
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EXAMINER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EXAMINER](
[EXID] [int] IDENTITY(18000001,1) NOT NULL,
[EXCODE] [varchar](10) NULL,
[EXNAME] [varchar](50) NULL,
[EXDESIG] [varchar](3) NULL,
[BRCODE] [varchar](50) NULL,
[INSCODE] [varchar](3) NULL,
[EXCITY] [varchar](50) NULL,
[EXDIST] [varchar](2) NULL,
[MONO] [varchar](10) NULL,
[EMAIL] [varchar](50) NULL,
[STAT] [varchar](1) NULL,
[UPDATEDON] [datetime] NULL CONSTRAINT [DF_BACKP_UpdatedOn]  DEFAULT (getdate()),
) ON [PRIMARY]
END
