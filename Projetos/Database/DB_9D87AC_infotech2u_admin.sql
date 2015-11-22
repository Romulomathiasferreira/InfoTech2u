/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     21/11/2015 10:39:16                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TABLEFUNCTIONALITY') and o.name = 'FK_TABLEFUN_FK_TABLEF_TABLEAPP')
alter table TABLEFUNCTIONALITY
   drop constraint FK_TABLEFUN_FK_TABLEF_TABLEAPP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TABLELISTAPPLICATIONMODULEUSER') and o.name = 'FK_TABLELIS_FK_TABLEL_TABLEAPP')
alter table TABLELISTAPPLICATIONMODULEUSER
   drop constraint FK_TABLELIS_FK_TABLEL_TABLEAPP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TABLELISTAPPLICATIONMODULEUSER') and o.name = 'FK_TABLELIS_FK_TABLEL_TABLEUSE')
alter table TABLELISTAPPLICATIONMODULEUSER
   drop constraint FK_TABLELIS_FK_TABLEL_TABLEUSE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TABLEPERSONALINFORMATION') and o.name = 'FK_TABLEPER_FK_TABLEP_TABLEUSE')
alter table TABLEPERSONALINFORMATION
   drop constraint FK_TABLEPER_FK_TABLEP_TABLEUSE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TABLEPROFILEPICTURE') and o.name = 'FK_TABLEPRO_FK_TABLEP_TABLEUSE')
alter table TABLEPROFILEPICTURE
   drop constraint FK_TABLEPRO_FK_TABLEP_TABLEUSE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TABLESERVICE') and o.name = 'FK_TABLESER_FK_TABLES_TABLEFUN')
alter table TABLESERVICE
   drop constraint FK_TABLESER_FK_TABLES_TABLEFUN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TABLEAPPLICATIONMODULE')
            and   name  = 'INDEX_TABLEAPPLICATIONMODULE'
            and   indid > 0
            and   indid < 255)
   drop index TABLEAPPLICATIONMODULE.INDEX_TABLEAPPLICATIONMODULE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TABLEAPPLICATIONMODULE')
            and   type = 'U')
   drop table TABLEAPPLICATIONMODULE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TABLEFUNCTIONALITY')
            and   name  = 'INDEX_TABLEFUNCTIONALITY'
            and   indid > 0
            and   indid < 255)
   drop index TABLEFUNCTIONALITY.INDEX_TABLEFUNCTIONALITY
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TABLEFUNCTIONALITY')
            and   type = 'U')
   drop table TABLEFUNCTIONALITY
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TABLELISTAPPLICATIONMODULEUSER')
            and   name  = 'INDEX_TABLELISTAPPLICATIONMODULEUSER'
            and   indid > 0
            and   indid < 255)
   drop index TABLELISTAPPLICATIONMODULEUSER.INDEX_TABLELISTAPPLICATIONMODULEUSER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TABLELISTAPPLICATIONMODULEUSER')
            and   type = 'U')
   drop table TABLELISTAPPLICATIONMODULEUSER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TABLEPERSONALINFORMATION')
            and   name  = 'INDEX_TABLEPERSONALINFORMATION'
            and   indid > 0
            and   indid < 255)
   drop index TABLEPERSONALINFORMATION.INDEX_TABLEPERSONALINFORMATION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TABLEPERSONALINFORMATION')
            and   type = 'U')
   drop table TABLEPERSONALINFORMATION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TABLEPROFILEPICTURE')
            and   name  = 'INDEX_TABLEPROFILEPICTURE'
            and   indid > 0
            and   indid < 255)
   drop index TABLEPROFILEPICTURE.INDEX_TABLEPROFILEPICTURE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TABLEPROFILEPICTURE')
            and   type = 'U')
   drop table TABLEPROFILEPICTURE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TABLESERVICE')
            and   name  = 'INDEX_TABLESERVICE'
            and   indid > 0
            and   indid < 255)
   drop index TABLESERVICE.INDEX_TABLESERVICE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TABLESERVICE')
            and   type = 'U')
   drop table TABLESERVICE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TABLEUSER')
            and   name  = 'INDEX_TABLEUSER'
            and   indid > 0
            and   indid < 255)
   drop index TABLEUSER.INDEX_TABLEUSER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TABLEUSER')
            and   type = 'U')
   drop table TABLEUSER
go

/*==============================================================*/
/* Table: TABLEAPPLICATIONMODULE                                */
/*==============================================================*/
create table TABLEAPPLICATIONMODULE (
   IDAPPLICATIONMODULE  int                  identity,
   NAMEAPPLICATIONMODULE nvarchar(256)        null,
   DESCRIPTIONAPPLICATIONMODULE text                 null,
   REGISTRATIONDATEAPPLICATIONMODULE datetime             null,
   REGISTRATIONUSERAPPLICATIONMODULE int                  null,
   CHANGEDATEAPPLICATIONMODULE datetime             null,
   CHANGEUSERAPPLICATIONMODULE int                  null,
   STATUSAPPLICATIONMODULE char(1)              null,
   constraint PK_TABLEAPPLICATIONMODULE primary key (IDAPPLICATIONMODULE)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TABLEAPPLICATIONMODULE') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TABLEAPPLICATIONMODULE' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Application module registration table', 
   'user', @CurrentUser, 'table', 'TABLEAPPLICATIONMODULE'
go

/*==============================================================*/
/* Index: INDEX_TABLEAPPLICATIONMODULE                          */
/*==============================================================*/




create nonclustered index INDEX_TABLEAPPLICATIONMODULE on TABLEAPPLICATIONMODULE (IDAPPLICATIONMODULE ASC,
  NAMEAPPLICATIONMODULE ASC,
  STATUSAPPLICATIONMODULE ASC)
go

/*==============================================================*/
/* Table: TABLEFUNCTIONALITY                                    */
/*==============================================================*/
create table TABLEFUNCTIONALITY (
   IDFUNCTIONALITY      int                  identity,
   IDAPPLICATIONMODULE  int                  null,
   NAMEFUNCTIONALITY    nvarchar(256)        null,
   DESCRIPTIONFUNCTIONALITY text                 null,
   REGISTRATIONDATEFUNCTIONALITY datetime             null,
   REGISTRATIONUSERFUNCTIONALITY int                  null,
   CHANGEDATEFUNCTIONALITY datetime             null,
   CHANGEUSERFUNCTIONALITY int                  null,
   STATUSFUNCTIONALITY  char(1)              null,
   constraint PK_TABLEFUNCTIONALITY primary key (IDFUNCTIONALITY)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TABLEFUNCTIONALITY') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TABLEFUNCTIONALITY' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Functionality registration table', 
   'user', @CurrentUser, 'table', 'TABLEFUNCTIONALITY'
go

/*==============================================================*/
/* Index: INDEX_TABLEFUNCTIONALITY                              */
/*==============================================================*/




create nonclustered index INDEX_TABLEFUNCTIONALITY on TABLEFUNCTIONALITY (IDFUNCTIONALITY ASC,
  IDAPPLICATIONMODULE ASC,
  NAMEFUNCTIONALITY ASC,
  STATUSFUNCTIONALITY ASC)
go

/*==============================================================*/
/* Table: TABLELISTAPPLICATIONMODULEUSER                        */
/*==============================================================*/
create table TABLELISTAPPLICATIONMODULEUSER (
   IDLISTAPPLICATIONMODULEUSER int                  identity,
   IDUSER               int                  null,
   IDAPPLICATIONMODULE  int                  null,
   REGISTRATIONDATELISTAPPLICATIONMODULEUSER datetime             null,
   REGISTRATIONUSERLISTAPPLICATIONMODULEUSER int                  null,
   CHANGEDATELISTAPPLICATIONMODULEUSER datetime             null,
   CHANGEUSERLISTAPPLICATIONMODULEUSER int                  null,
   STATUSLISTAPPLICATIONMODULEUSER char(1)              null,
   constraint PK_TABLELISTAPPLICATIONMODULEU primary key (IDLISTAPPLICATIONMODULEUSER)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TABLELISTAPPLICATIONMODULEUSER') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TABLELISTAPPLICATIONMODULEUSER' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Lits Application Module user registration table', 
   'user', @CurrentUser, 'table', 'TABLELISTAPPLICATIONMODULEUSER'
go

/*==============================================================*/
/* Index: INDEX_TABLELISTAPPLICATIONMODULEUSER                  */
/*==============================================================*/




create nonclustered index INDEX_TABLELISTAPPLICATIONMODULEUSER on TABLELISTAPPLICATIONMODULEUSER (IDLISTAPPLICATIONMODULEUSER ASC,
  IDUSER ASC,
  IDAPPLICATIONMODULE ASC,
  STATUSLISTAPPLICATIONMODULEUSER ASC)
go

/*==============================================================*/
/* Table: TABLEPERSONALINFORMATION                              */
/*==============================================================*/
create table TABLEPERSONALINFORMATION (
   IDPERSONALINFORMATION int                  identity,
   IDUSER               int                  null,
   NAMEPERSONALINFORMATION nvarchar(256)        null,
   NICKNAMEPERSONALINFORMATION nvarchar(256)        null,
   BIRTHDATEPERSONALINFORMATION datetime             null,
   GENREPERSONALINFORMATION char(1)              null,
   REGISTRATIONDATEPERSONALINFORMATION datetime             null,
   REGISTRATIONUSERPERSONALINFORMATION int                  null,
   CHANGEDATEPERSONALINFORMATION datetime             null,
   CHANGEUSERPERSONALINFORMATION int                  null,
   STATUSPERSONALINFORMATION char(1)              null,
   constraint PK_TABLEPERSONALINFORMATION primary key (IDPERSONALINFORMATION)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TABLEPERSONALINFORMATION') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TABLEPERSONALINFORMATION' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Personal information registration table', 
   'user', @CurrentUser, 'table', 'TABLEPERSONALINFORMATION'
go

/*==============================================================*/
/* Index: INDEX_TABLEPERSONALINFORMATION                        */
/*==============================================================*/




create nonclustered index INDEX_TABLEPERSONALINFORMATION on TABLEPERSONALINFORMATION (IDPERSONALINFORMATION ASC,
  IDUSER ASC,
  NAMEPERSONALINFORMATION ASC,
  NICKNAMEPERSONALINFORMATION ASC,
  BIRTHDATEPERSONALINFORMATION ASC,
  GENREPERSONALINFORMATION ASC,
  STATUSPERSONALINFORMATION ASC)
go

/*==============================================================*/
/* Table: TABLEPROFILEPICTURE                                   */
/*==============================================================*/
create table TABLEPROFILEPICTURE (
   IDPROFILEPICTURE     int                  identity,
   IDUSER               int                  null,
   PHOTOPROFILEPICTURE  nvarchar(256)        null,
   REGISTRATIONDATEPROFILEPICTURE datetime             null,
   REGISTRATIONUSERPROFILEPICTURE int                  null,
   CHANGEDATEPROFILEPICTURE datetime             null,
   CHANGEUSERPROFILEPICTURE int                  null,
   STATUSPROFILEPICTURE char(1)              null,
   constraint PK_TABLEPROFILEPICTURE primary key (IDPROFILEPICTURE)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TABLEPROFILEPICTURE') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TABLEPROFILEPICTURE' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Profile picture registration table', 
   'user', @CurrentUser, 'table', 'TABLEPROFILEPICTURE'
go

/*==============================================================*/
/* Index: INDEX_TABLEPROFILEPICTURE                             */
/*==============================================================*/




create nonclustered index INDEX_TABLEPROFILEPICTURE on TABLEPROFILEPICTURE (IDPROFILEPICTURE ASC,
  IDUSER ASC,
  PHOTOPROFILEPICTURE ASC,
  STATUSPROFILEPICTURE ASC)
go

/*==============================================================*/
/* Table: TABLESERVICE                                          */
/*==============================================================*/
create table TABLESERVICE (
   IDSERVICE            int                  identity,
   IDFUNCTIONALITY      int                  null,
   NAMESERVICE          nvarchar(256)        null,
   DESCRIPTIONSERVICE   text                 null,
   REGISTRATIONDATESERVICE datetime             null,
   REGISTRATIONUSERSERVICE int                  null,
   CHANGEDATESERVICE    datetime             null,
   CHANGEUSERSERVICE    int                  null,
   STATUSSERVICE        char(1)              null,
   constraint PK_TABLESERVICE primary key (IDSERVICE)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TABLESERVICE') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TABLESERVICE' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Service registration table', 
   'user', @CurrentUser, 'table', 'TABLESERVICE'
go

/*==============================================================*/
/* Index: INDEX_TABLESERVICE                                    */
/*==============================================================*/




create nonclustered index INDEX_TABLESERVICE on TABLESERVICE (IDSERVICE ASC,
  IDFUNCTIONALITY ASC,
  NAMESERVICE ASC,
  STATUSSERVICE ASC)
go

/*==============================================================*/
/* Table: TABLEUSER                                             */
/*==============================================================*/
create table TABLEUSER (
   IDUSER               int                  identity,
   EMAILUSER            nvarchar(256)        null,
   PASSWORDUSER         nvarchar(256)        null,
   REGISTRATIONDATEUSER datetime             null,
   REGISTRATIONUSERUSER int                  null,
   CHANGEDATEUSER       datetime             null,
   CHANGEUSERUSER       int                  null,
   STATUSUSER           char(1)              null,
   constraint PK_TABLEUSER primary key (IDUSER)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TABLEUSER') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TABLEUSER' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Users registration table', 
   'user', @CurrentUser, 'table', 'TABLEUSER'
go

/*==============================================================*/
/* Index: INDEX_TABLEUSER                                       */
/*==============================================================*/




create nonclustered index INDEX_TABLEUSER on TABLEUSER (IDUSER ASC,
  EMAILUSER ASC,
  PASSWORDUSER ASC,
  STATUSUSER ASC)
go

alter table TABLEFUNCTIONALITY
   add constraint FK_TABLEFUN_FK_TABLEF_TABLEAPP foreign key (IDAPPLICATIONMODULE)
      references TABLEAPPLICATIONMODULE (IDAPPLICATIONMODULE)
go

alter table TABLELISTAPPLICATIONMODULEUSER
   add constraint FK_TABLELIS_FK_TABLEL_TABLEAPP foreign key (IDAPPLICATIONMODULE)
      references TABLEAPPLICATIONMODULE (IDAPPLICATIONMODULE)
go

alter table TABLELISTAPPLICATIONMODULEUSER
   add constraint FK_TABLELIS_FK_TABLEL_TABLEUSE foreign key (IDUSER)
      references TABLEUSER (IDUSER)
go

alter table TABLEPERSONALINFORMATION
   add constraint FK_TABLEPER_FK_TABLEP_TABLEUSE foreign key (IDUSER)
      references TABLEUSER (IDUSER)
go

alter table TABLEPROFILEPICTURE
   add constraint FK_TABLEPRO_FK_TABLEP_TABLEUSE foreign key (IDUSER)
      references TABLEUSER (IDUSER)
go

alter table TABLESERVICE
   add constraint FK_TABLESER_FK_TABLES_TABLEFUN foreign key (IDFUNCTIONALITY)
      references TABLEFUNCTIONALITY (IDFUNCTIONALITY)
go

