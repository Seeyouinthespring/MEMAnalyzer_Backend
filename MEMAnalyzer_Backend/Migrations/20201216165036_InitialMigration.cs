using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MEMAnalyzer_Backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Code = table.Column<string>(nullable: true),
            //        OfficialCode = table.Column<string>(nullable: true),
            //        Order = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Statements",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OfficialCode = table.Column<string>(nullable: true),
            //        Text = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Statements", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        RoleId = table.Column<string>(nullable: true),
            //        ProfilePic = table.Column<string>(nullable: true),
            //        FullName = table.Column<string>(nullable: true),
            //        Gender = table.Column<bool>(nullable: false),
            //        BirthDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUsers_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Memes",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Code = table.Column<string>(nullable: true),
            //        Picture = table.Column<byte[]>(nullable: true),
            //        CategoryId = table.Column<long>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Memes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Memes_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(nullable: false),
            //        ProviderKey = table.Column<string>(nullable: false),
            //        ProviderDisplayName = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Results",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(nullable: true),
            //        Date = table.Column<DateTime>(nullable: false),
            //        CategoryOnePercentage = table.Column<double>(nullable: false),
            //        CategorytwoPercentage = table.Column<double>(nullable: false),
            //        CategoryThreePercentage = table.Column<double>(nullable: false),
            //        CategoryFourPercentage = table.Column<double>(nullable: false),
            //        CategoryFivePercentage = table.Column<double>(nullable: false),
            //        StatementId = table.Column<long>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Results", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Results_Statements_StatementId",
            //            column: x => x.StatementId,
            //            principalTable: "Statements",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Results_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Answers",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Mark = table.Column<int>(nullable: false),
            //        MemId = table.Column<long>(nullable: false),
            //        ResultId = table.Column<long>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Answers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Answers_Memes_MemId",
            //            column: x => x.MemId,
            //            principalTable: "Memes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Answers_Results_ResultId",
            //            column: x => x.ResultId,
            //            principalTable: "Results",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Answers_MemId",
            //    table: "Answers",
            //    column: "MemId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Answers_ResultId",
            //    table: "Answers",
            //    column: "ResultId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUsers_RoleId",
            //    table: "AspNetUsers",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Memes_CategoryId",
            //    table: "Memes",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Results_StatementId",
            //    table: "Results",
            //    column: "StatementId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Results_UserId",
            //    table: "Results",
            //    column: "UserId");

            migrationBuilder.Sql(@"
                insert into Categories ([Code], [OfficialCode], [Order]) values
                ('dom', 'domestic', 1),
                ('pop', 'popular', 2),
                ('poi', 'pointless', 3),
                ('int', 'intellectual', 4),
                ('con', 'conservative', 5)
                
                INSERT INTO [dbo].[Statements]([OfficialCode],[Text]) VALUES
                ('domestic','You prefer a stable and calm lifestyle, everyday life does not disgust you. You strongly appreciate material well-being and support the standard foundations of society such as the institution of the family or a religion typical for the region of residence. You can be a good friend and an important member of the company. Most likely your character, habits and manners were laid down for you from childhood by your parents.'),
		        ('popular','You are a person open to innovations, new trends and customs, you quickly adapt to changes in your life and enjoy it. You like to make new acquaintances and you will always find how to keep up a conversation with the company. Your opinion can often change and depend on the person who is authoritative for you. Attention and material condition in life are very important to you.'),
		        ('pointless','You have a non-standard mindset, most likely you consider a few acquaintances as your friends. You prefer calmness and solitude to noisy companies. You tend to notice in other people what the majority does not notice in them, as well as to face misunderstanding on the part of the majority. You are engaged in and are interested in one business for a long time and you do not really care about what people think about you.'),
		        ('conservative','You are a person who respects established things and events, you have a negative attitude towards any innovations and you are afraid of changes in your lifestyle. You are uncomfortable in a new company and make new acquaintances. You try to hold on to people you have known for a long time, respect the archaic foundations of society, focus on opinions of more experienced people and always know exactly what you want. You do not get bored with old, familiar actions and things'),
		        ('intellectual','You are a rather intelligent, sensible person who tends to consider yourself smarter than many others. Most likely, your main activity is associated with mental stress, you like solving problems by finding a logical way to solve them. You prefer to deeply understand the issues that interest you and make acquaintances according to a common circle of interests. Material values in life do not play a key role for you.'),
		        ('negation','You do not understand the usual standards for everyone. Your opinion will often differ strongly from that of the majority. You are extremely picky in your tastes, do not try to please anyone and most often express your honest opinion in person without hypocrisy. You are a serious enough person and choose a social circle to match yourself. You are most likely a perfectionist. [Maybe you just have a bad day today, don`t worry, everything will work out]'),
		        ('unpretentiousness','Your tastes are unpretentious, you like variety in everything and in every business you can find interests for yourself.You have a good sense of humor and you can find a common language with completely different people, you do not adhere to any principles, you are open to innovations and experiments, trying to live simply and enjoy life. Most likely you are an optimist and it can be difficult for you to refuse someone.')
                
                insert into Memes (Code, Picture, CategoryId) values
                ('https://sun9-27.userapi.com/impg/MwavTUCuaBxuxu8s3qMh-8FuB6F0Wf1BFg_1Pg/popeueEEZgw.jpg?size=1678x2160&quality=96&proxy=1&sign=000c3b8aa79ade1b67c360fb14fb7097',null, 3),
                ('https://sun9-70.userapi.com/impg/6AYDi1QQPOgOHtMborSW3zHsk8ZHlEtxUBJf4g/-A0wP44sJ1k.jpg?size=688x617&quality=96&proxy=1&sign=ad2e05c53d86d237e6cb45328f40d4c7',null, 4),
                ('https://sun9-47.userapi.com/impg/l2Fi01SMwW5YlqA9HYzggnEDDzXNVsILzEU-ag/fscG24AgB_s.jpg?size=1024x1280&quality=96&proxy=1&sign=3453d05315909940ff89f9c87aa4d70b',null, 3),
                ('https://sun9-57.userapi.com/impg/e1iLmY2UvN8z93xfnQk4b5nObB9fg2mVtSopTQ/z1HESZkv9XM.jpg?size=1439x1455&quality=96&proxy=1&sign=5a6576b067e2e3a4e09560941ba4e7a0',null, 5),
                ('https://sun9-61.userapi.com/impg/tBI2bqfRuVb07FQkOPtwUycKJ-tsbOAiE08viA/-V5A6rJaHuc.jpg?size=915x1018&quality=96&proxy=1&sign=2947648f3e71238b95e0ad995338c759',null, 4),
                ('https://sun9-63.userapi.com/impg/rooZ25R_IVSQ23fDlAMCmDcePmuyoZkgVWjt_g/Kt0s82prf4M.jpg?size=465x604&quality=96&proxy=1&sign=51f08dd58a7c8d502d9236fd0eda4227',null, 1),
                ('https://sun9-6.userapi.com/impg/QHFS4m6qaYhZ702H1_7YxBcErsCMPQw3BOZndQ/UFA_Sd9RygU.jpg?size=1600x1279&quality=96&proxy=1&sign=4c193e202a0ec24eeba7cd78b936e6b3',null, 1),
                ('https://sun9-14.userapi.com/impf/w1YUYTjNsllOQQhLQ6R_44bxvL-cKsJIVc7Dbw/kITCyMiKBMU.jpg?size=852x1080&quality=96&proxy=1&sign=ca2e845d7c54fadd1ef2d94206f67f11',null, 5),
                ('https://sun9-30.userapi.com/impg/Qp5-qhJyXi64WWwaStL-2XOskSBP9plgeElGMg/3dKA9JSa-Kk.jpg?size=750x579&quality=96&proxy=1&sign=6bb0f694e3e4591109bf1d62a8737d59',null, 1),
                ('https://sun9-20.userapi.com/impg/c857332/v857332031/182afa/I7E7zKW7vtA.jpg?size=1126x1152&quality=96&proxy=1&sign=a27d379942455f2b5545362b61abbb4c',null, 2),
                ('https://sun9-65.userapi.com/impg/7bDCSyulK_UlAu5hT10ebjGAn_toHUqgIqrBPQ/hKScHmB_hBY.jpg?size=719x715&quality=96&proxy=1&sign=dfe8a51b422a5f78501c2ebeb41a8ae7',null, 3),
                ('https://sun9-9.userapi.com/impg/XPJH6yfhAxpC_Q00euHhysQrKenzz29zjpAK3A/PzLY9wdBBRw.jpg?size=1527x2160&quality=96&proxy=1&sign=08c279ae8e0c7886e485afc29be213a7',null, 2),
                ('https://sun9-67.userapi.com/impg/n6tOsW962mHMaK0VroSf_AaMhnB0O7ZQqeUGxw/wC41ESLDaSo.jpg?size=449x476&quality=96&proxy=1&sign=79a54e1f95b08b51a0c6999c11c6e2a4',null, 4),
                ('https://sun9-70.userapi.com/impg/c853516/v853516778/1fcd39/8ZD21oXPzjM.jpg?size=814x703&quality=96&proxy=1&sign=d41f231286e7b3dbbbc56e9d6809316d',null, 5),
                ('https://sun9-65.userapi.com/impg/c858228/v858228142/17d9de/3yMJaYqQAMU.jpg?size=499x662&quality=96&proxy=1&sign=8b8b662209875da8c900a150b1286973',null, 1),
                ('https://sun9-9.userapi.com/impf/c858424/v858424775/52500/FrVNvk-Pks8.jpg?size=650x564&quality=96&proxy=1&sign=fb30073f8c6fd6fbffd0b8e72713a51e',null, 5),
                ('https://sun9-33.userapi.com/impf/c849320/v849320182/1d3a36/pHCPOVh0BUY.jpg?size=604x400&quality=96&proxy=1&sign=e1ed44710ef7f0f0db60d8dfc91f72fd',null, 2),
                ('https://sun9-7.userapi.com/impf/c856016/v856016708/2b931/qgE0YjRaW-E.jpg?size=720x417&quality=96&proxy=1&sign=f767fa095dca47145664eed431b3da37',null, 4),
                ('https://sun9-59.userapi.com/impf/c853420/v853420573/3b305/Lc6eyKJ8XjQ.jpg?size=512x1026&quality=96&proxy=1&sign=c8b870b7413db622f4b8ead05ef59e75',null, 3),
                ('https://sun9-68.userapi.com/impf/c849224/v849224678/1bb92a/wr0cxUM_Oss.jpg?size=600x517&quality=96&proxy=1&sign=8ebd05e176cdfe5800515d4b91005136',null, 2)"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Memes");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
