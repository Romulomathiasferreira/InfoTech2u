namespace UsersRegistrationWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasIniciai : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationModules",
                c => new
                    {
                        IdApplicationModule = c.Int(nullable: false, identity: true),
                        NameApplicationModule = c.String(),
                        DescriptionApplicationModule = c.String(),
                        RegistrationDateApplicationModule = c.DateTime(nullable: false),
                        RegistrationUserApplicationModule = c.Int(nullable: false),
                        ChangeDateApplicationModule = c.DateTime(nullable: false),
                        ChangeUserApplicationModule = c.Int(nullable: false),
                        StatusApplicationModule = c.String(),
                    })
                .PrimaryKey(t => t.IdApplicationModule);
            
            CreateTable(
                "dbo.Functionalities",
                c => new
                    {
                        IdFunctionality = c.Int(nullable: false, identity: true),
                        NameFunctionality = c.String(),
                        DescriptionFunctionality = c.String(),
                        RegistrationDateFunctionality = c.DateTime(nullable: false),
                        RegistrationUserFunctionality = c.Int(nullable: false),
                        ChangeDateFunctionality = c.DateTime(nullable: false),
                        ChangeUserFunctionality = c.Int(nullable: false),
                        StatusFunctionality = c.String(),
                        ApplicationModuleId = c.Int(nullable: false),
                        ApplicationModule_IdApplicationModule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFunctionality)
                .ForeignKey("dbo.ApplicationModules", t => t.ApplicationModule_IdApplicationModule, cascadeDelete: true)
                .Index(t => t.ApplicationModule_IdApplicationModule);
            
            CreateTable(
                "dbo.ListApplicationModuleUsers",
                c => new
                    {
                        IdListApplicationModuleUser = c.Int(nullable: false, identity: true),
                        RegistrationDateListApplicationModuleUser = c.DateTime(nullable: false),
                        RegistrationUserListApplicationModuleUser = c.Int(nullable: false),
                        ChangeDateListApplicationModuleUser = c.DateTime(nullable: false),
                        ChangeUserListApplicationModuleUser = c.Int(nullable: false),
                        StatusListApplicationModuleUser = c.String(),
                        UserId = c.Int(nullable: false),
                        ApplicationModuleId = c.Int(nullable: false),
                        ApplicationModule_IdApplicationModule = c.Int(nullable: false),
                        User_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdListApplicationModuleUser)
                .ForeignKey("dbo.ApplicationModules", t => t.ApplicationModule_IdApplicationModule, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_IdUser, cascadeDelete: true)
                .Index(t => t.ApplicationModule_IdApplicationModule)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        EmailUser = c.String(),
                        PasswordUser = c.String(),
                        RegistrationDateUser = c.DateTime(nullable: false),
                        RegistrationUserUser = c.Int(nullable: false),
                        ChangeDateUser = c.DateTime(nullable: false),
                        ChangeUserUser = c.Int(nullable: false),
                        StatusUser = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        IdPersonalInformation = c.Int(nullable: false, identity: true),
                        NamePersonalInformation = c.String(),
                        NicknamePersonalInformation = c.String(),
                        BirthDatePersonalInformation = c.DateTime(nullable: false),
                        GenrePersonalInformation = c.String(),
                        RegistrationDatePersonalInformation = c.DateTime(nullable: false),
                        RegistrationUserPersonalInformation = c.Int(nullable: false),
                        ChangeDatePersonalInformation = c.DateTime(nullable: false),
                        ChangeUserPersonalInformation = c.Int(nullable: false),
                        StatusPersonalInformation = c.String(),
                        UserId = c.Int(nullable: false),
                        User_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPersonalInformation)
                .ForeignKey("dbo.Users", t => t.User_IdUser, cascadeDelete: true)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.ProfilePictures",
                c => new
                    {
                        IdProfilePicture = c.Int(nullable: false, identity: true),
                        PhotoProfilePicture = c.String(),
                        RegistrationDateProfilePicture = c.DateTime(nullable: false),
                        RegistrationUserProfilePicture = c.Int(nullable: false),
                        ChangeDateProfilePicture = c.DateTime(nullable: false),
                        ChangeUserProfilePicture = c.Int(nullable: false),
                        StatusProfilePicture = c.String(),
                        UserId = c.Int(nullable: false),
                        User_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProfilePicture)
                .ForeignKey("dbo.Users", t => t.User_IdUser, cascadeDelete: true)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        IdService = c.Int(nullable: false, identity: true),
                        NameService = c.String(),
                        DescriptionService = c.String(),
                        RegistrationDateService = c.DateTime(nullable: false),
                        RegistrationUserService = c.Int(nullable: false),
                        ChangeDateService = c.DateTime(nullable: false),
                        ChangeUserService = c.Int(nullable: false),
                        StatusService = c.String(),
                        FunctionalityId = c.Int(nullable: false),
                        Functionality_IdFunctionality = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdService)
                .ForeignKey("dbo.Functionalities", t => t.Functionality_IdFunctionality, cascadeDelete: true)
                .Index(t => t.Functionality_IdFunctionality);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Functionality_IdFunctionality", "dbo.Functionalities");
            DropForeignKey("dbo.ProfilePictures", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.PersonalInformations", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.ListApplicationModuleUsers", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.ListApplicationModuleUsers", "ApplicationModule_IdApplicationModule", "dbo.ApplicationModules");
            DropForeignKey("dbo.Functionalities", "ApplicationModule_IdApplicationModule", "dbo.ApplicationModules");
            DropIndex("dbo.Services", new[] { "Functionality_IdFunctionality" });
            DropIndex("dbo.ProfilePictures", new[] { "User_IdUser" });
            DropIndex("dbo.PersonalInformations", new[] { "User_IdUser" });
            DropIndex("dbo.ListApplicationModuleUsers", new[] { "User_IdUser" });
            DropIndex("dbo.ListApplicationModuleUsers", new[] { "ApplicationModule_IdApplicationModule" });
            DropIndex("dbo.Functionalities", new[] { "ApplicationModule_IdApplicationModule" });
            DropTable("dbo.Services");
            DropTable("dbo.ProfilePictures");
            DropTable("dbo.PersonalInformations");
            DropTable("dbo.Users");
            DropTable("dbo.ListApplicationModuleUsers");
            DropTable("dbo.Functionalities");
            DropTable("dbo.ApplicationModules");
        }
    }
}
