----Create RESMRK TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESMRK]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESMRK](
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[TOTMRK] [varchar](4) NULL,
[RESULT] [varchar](15) NULL,
[SRNO] [varchar](2) NULL,
[EXTYP] [varchar](1) NULL,
) ON [PRIMARY]
END
----Create RESBACK TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESBACK]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESBACK](
[ROLL] [varchar](11) NULL,
[SUB] [varchar](4) NULL,
[TP] [varchar](1) NULL,
) ON [PRIMARY]
END
----Create RESSEM1 TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESSEM1]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESSEM1](
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[SUB] [varchar](4) NULL,
[TH] [varchar](4) NULL,
[PR] [varchar](4) NULL,
[TOT] [varchar](4) NULL,
[TB] [varchar](1) NULL,
[PB] [varchar](1) NULL,
[TPS] [varchar](2) NULL,
[SRNO] [varchar](2) NULL,
[SESS] [varchar](7) NULL,
[EXTYP] [varchar](1) NULL,
) ON [PRIMARY]
END
----Create RESSEM2 TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESSEM2]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESSEM2](
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[SUB] [varchar](4) NULL,
[TH] [varchar](4) NULL,
[PR] [varchar](4) NULL,
[TOT] [varchar](4) NULL,
[TB] [varchar](1) NULL,
[PB] [varchar](1) NULL,
[TPS] [varchar](2) NULL,
[SRNO] [varchar](2) NULL,
[SESS] [varchar](7) NULL,
[EXTYP] [varchar](1) NULL,
) ON [PRIMARY]
END
----Create RESSEM3 TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESSEM3]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESSEM3](
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[SUB] [varchar](4) NULL,
[TH] [varchar](4) NULL,
[PR] [varchar](4) NULL,
[TOT] [varchar](4) NULL,
[TB] [varchar](1) NULL,
[PB] [varchar](1) NULL,
[TPS] [varchar](2) NULL,
[SRNO] [varchar](2) NULL,
[SESS] [varchar](7) NULL,
[EXTYP] [varchar](1) NULL,
) ON [PRIMARY]
END
----Create RESSEM4 TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESSEM4]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESSEM4](
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[SUB] [varchar](4) NULL,
[TH] [varchar](4) NULL,
[PR] [varchar](4) NULL,
[TOT] [varchar](4) NULL,
[TB] [varchar](1) NULL,
[PB] [varchar](1) NULL,
[TPS] [varchar](2) NULL,
[SRNO] [varchar](2) NULL,
[SESS] [varchar](7) NULL,
[EXTYP] [varchar](1) NULL,
) ON [PRIMARY]
END
----Create RESSEM5 TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESSEM5]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESSEM5](
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[SUB] [varchar](4) NULL,
[TH] [varchar](4) NULL,
[PR] [varchar](4) NULL,
[TOT] [varchar](4) NULL,
[TB] [varchar](1) NULL,
[PB] [varchar](1) NULL,
[TPS] [varchar](2) NULL,
[SRNO] [varchar](2) NULL,
[SESS] [varchar](7) NULL,
[EXTYP] [varchar](1) NULL,
) ON [PRIMARY]
END
----Create RESSEM6 TABLE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESSEM6]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESSEM6](
[ROLL] [varchar](11) NULL,
[SEM] [varchar](2) NULL,
[SUB] [varchar](4) NULL,
[TH] [varchar](4) NULL,
[PR] [varchar](4) NULL,
[TOT] [varchar](4) NULL,
[TB] [varchar](1) NULL,
[PB] [varchar](1) NULL,
[TPS] [varchar](2) NULL,
[SRNO] [varchar](2) NULL,
[SESS] [varchar](7) NULL,
[EXTYP] [varchar](1) NULL,
) ON [PRIMARY]
END
