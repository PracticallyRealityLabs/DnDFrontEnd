using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDFrontEnd.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acrobatics",
                columns: table => new
                {
                    Acrobaticsid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acrobaticsprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acrobatics", x => x.Acrobaticsid);
                });

            migrationBuilder.CreateTable(
                name: "AnimalHandling",
                columns: table => new
                {
                    AnimalHandlingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Animalhandprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalHandling", x => x.AnimalHandlingId);
                });

            migrationBuilder.CreateTable(
                name: "Arcana",
                columns: table => new
                {
                    Arcanaid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arcanaprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arcana", x => x.Arcanaid);
                });

            migrationBuilder.CreateTable(
                name: "Athletics",
                columns: table => new
                {
                    Athleticsid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Athleticsproficiency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletics", x => x.Athleticsid);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Constitution",
                columns: table => new
                {
                    Constitutionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consaveprof = table.Column<bool>(nullable: true),
                    Convalue = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constitution", x => x.Constitutionid);
                });

            migrationBuilder.CreateTable(
                name: "Deception",
                columns: table => new
                {
                    Deceptionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deceptionprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deception", x => x.Deceptionid);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Historyid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Historyprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Historyid);
                });

            migrationBuilder.CreateTable(
                name: "Insight",
                columns: table => new
                {
                    Insightid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Insighprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insight", x => x.Insightid);
                });

            migrationBuilder.CreateTable(
                name: "Intimidation",
                columns: table => new
                {
                    Intimidationid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intimidationprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intimidation", x => x.Intimidationid);
                });

            migrationBuilder.CreateTable(
                name: "Investigation",
                columns: table => new
                {
                    Investigationid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Investigationprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigation", x => x.Investigationid);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Itemsid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Attunementreq = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Itemsid);
                });

            migrationBuilder.CreateTable(
                name: "Nature",
                columns: table => new
                {
                    Natureid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Natureprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nature", x => x.Natureid);
                });

            migrationBuilder.CreateTable(
                name: "Perception",
                columns: table => new
                {
                    Perceptionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Perceptionprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perception", x => x.Perceptionid);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    Performanceid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Performanceprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.Performanceid);
                });

            migrationBuilder.CreateTable(
                name: "Persuasion",
                columns: table => new
                {
                    Persuasionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persausionprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persuasion", x => x.Persuasionid);
                });

            migrationBuilder.CreateTable(
                name: "Religion",
                columns: table => new
                {
                    Religionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Religionprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religion", x => x.Religionid);
                });

            migrationBuilder.CreateTable(
                name: "SleightOfHand",
                columns: table => new
                {
                    Sleightofhandid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sleightprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleightOfHand", x => x.Sleightofhandid);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Spellsid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Spellname = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: true),
                    Range = table.Column<int>(nullable: true),
                    Components = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    Description = table.Column<int>(nullable: true),
                    Concentration = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Spellsid);
                });

            migrationBuilder.CreateTable(
                name: "Stealth",
                columns: table => new
                {
                    Stealthid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stealthprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stealth", x => x.Stealthid);
                });

            migrationBuilder.CreateTable(
                name: "Survival",
                columns: table => new
                {
                    Survivalid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Survivalprof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survival", x => x.Survivalid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersId);
                });

            migrationBuilder.CreateTable(
                name: "Strength",
                columns: table => new
                {
                    Strengthid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strsaveprof = table.Column<bool>(nullable: true),
                    Strvalue = table.Column<int>(nullable: true),
                    Athleticsid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strength", x => x.Strengthid);
                    table.ForeignKey(
                        name: "FK_Strength_Athletics_Athleticsid",
                        column: x => x.Athleticsid,
                        principalTable: "Athletics",
                        principalColumn: "Athleticsid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Charisma",
                columns: table => new
                {
                    Charismaid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chasaveprof = table.Column<bool>(nullable: true),
                    Chavalue = table.Column<int>(nullable: true),
                    Persuasionid = table.Column<int>(nullable: true),
                    Performanceid = table.Column<int>(nullable: true),
                    Deceptionid = table.Column<int>(nullable: true),
                    Intimidationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charisma", x => x.Charismaid);
                    table.ForeignKey(
                        name: "FK_Charisma_Deception_Deceptionid",
                        column: x => x.Deceptionid,
                        principalTable: "Deception",
                        principalColumn: "Deceptionid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Charisma_Intimidation_Intimidationid",
                        column: x => x.Intimidationid,
                        principalTable: "Intimidation",
                        principalColumn: "Intimidationid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Charisma_Performance_Performanceid",
                        column: x => x.Performanceid,
                        principalTable: "Performance",
                        principalColumn: "Performanceid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Charisma_Persuasion_Persuasionid",
                        column: x => x.Persuasionid,
                        principalTable: "Persuasion",
                        principalColumn: "Persuasionid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intelligence",
                columns: table => new
                {
                    Intelligenceid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intvalue = table.Column<int>(nullable: true),
                    Intsaveprof = table.Column<bool>(nullable: true),
                    Investigationid = table.Column<int>(nullable: true),
                    Historyid = table.Column<int>(nullable: true),
                    Arcanaid = table.Column<int>(nullable: true),
                    Natureid = table.Column<int>(nullable: true),
                    Religionid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intelligence", x => x.Intelligenceid);
                    table.ForeignKey(
                        name: "FK_Intelligence_Arcana_Arcanaid",
                        column: x => x.Arcanaid,
                        principalTable: "Arcana",
                        principalColumn: "Arcanaid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intelligence_History_Historyid",
                        column: x => x.Historyid,
                        principalTable: "History",
                        principalColumn: "Historyid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intelligence_Investigation_Investigationid",
                        column: x => x.Investigationid,
                        principalTable: "Investigation",
                        principalColumn: "Investigationid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intelligence_Nature_Natureid",
                        column: x => x.Natureid,
                        principalTable: "Nature",
                        principalColumn: "Natureid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intelligence_Religion_Religionid",
                        column: x => x.Religionid,
                        principalTable: "Religion",
                        principalColumn: "Religionid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dexterity",
                columns: table => new
                {
                    Dexterityid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dexsaveprof = table.Column<bool>(nullable: true),
                    Dexvalue = table.Column<int>(nullable: true),
                    Acrobaticsid = table.Column<int>(nullable: true),
                    Stealthid = table.Column<int>(nullable: true),
                    Sleightid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dexterity", x => x.Dexterityid);
                    table.ForeignKey(
                        name: "FK_Dexterity_Acrobatics_Acrobaticsid",
                        column: x => x.Acrobaticsid,
                        principalTable: "Acrobatics",
                        principalColumn: "Acrobaticsid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dexterity_SleightOfHand_Sleightid",
                        column: x => x.Sleightid,
                        principalTable: "SleightOfHand",
                        principalColumn: "Sleightofhandid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dexterity_Stealth_Stealthid",
                        column: x => x.Stealthid,
                        principalTable: "Stealth",
                        principalColumn: "Stealthid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wisdom",
                columns: table => new
                {
                    Wisdomid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wissaveprof = table.Column<bool>(nullable: true),
                    Wisvalue = table.Column<int>(nullable: true),
                    Animalhandid = table.Column<int>(nullable: true),
                    Perceptionid = table.Column<int>(nullable: true),
                    Insightid = table.Column<int>(nullable: true),
                    Survivalid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wisdom", x => x.Wisdomid);
                    table.ForeignKey(
                        name: "FK_Wisdom_AnimalHandling_Animalhandid",
                        column: x => x.Animalhandid,
                        principalTable: "AnimalHandling",
                        principalColumn: "AnimalHandlingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wisdom_Insight_Insightid",
                        column: x => x.Insightid,
                        principalTable: "Insight",
                        principalColumn: "Insightid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wisdom_Perception_Perceptionid",
                        column: x => x.Perceptionid,
                        principalTable: "Perception",
                        principalColumn: "Perceptionid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wisdom_Survival_Survivalid",
                        column: x => x.Survivalid,
                        principalTable: "Survival",
                        principalColumn: "Survivalid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCharacter",
                columns: table => new
                {
                    PlayerCharacterid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Charactername = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Alignment = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    Campaignid = table.Column<int>(nullable: true),
                    Userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacter", x => x.PlayerCharacterid);
                    table.ForeignKey(
                        name: "FK_PlayerCharacter_Campaign_Campaignid",
                        column: x => x.Campaignid,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerCharacter_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersBelongToCampaign",
                columns: table => new
                {
                    UsersBelongToCampaignid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Role = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBelongToCampaign", x => x.UsersBelongToCampaignid);
                    table.ForeignKey(
                        name: "FK_UsersBelongToCampaign_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersBelongToCampaign_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Background",
                columns: table => new
                {
                    Backgroundid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Bonds = table.Column<string>(nullable: true),
                    Flaws = table.Column<string>(nullable: true),
                    Ideals = table.Column<string>(nullable: true),
                    Traits = table.Column<string>(nullable: true),
                    Backgroundtype = table.Column<string>(nullable: true),
                    Characterid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Background", x => x.Backgroundid);
                    table.ForeignKey(
                        name: "FK_Background_PlayerCharacter_Characterid",
                        column: x => x.Characterid,
                        principalTable: "PlayerCharacter",
                        principalColumn: "PlayerCharacterid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Featuresid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Aquiredfrom = table.Column<string>(nullable: true),
                    CaharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Featuresid);
                    table.ForeignKey(
                        name: "FK_Features_PlayerCharacter_CaharacterId",
                        column: x => x.CaharacterId,
                        principalTable: "PlayerCharacter",
                        principalColumn: "PlayerCharacterid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Inventoryid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Encumberance = table.Column<string>(nullable: true),
                    Characterid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Inventoryid);
                    table.ForeignKey(
                        name: "FK_Inventory_PlayerCharacter_Characterid",
                        column: x => x.Characterid,
                        principalTable: "PlayerCharacter",
                        principalColumn: "PlayerCharacterid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellList",
                columns: table => new
                {
                    Spelllistid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Characterid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellList", x => x.Spelllistid);
                    table.ForeignKey(
                        name: "FK_SpellList_PlayerCharacter_Characterid",
                        column: x => x.Characterid,
                        principalTable: "PlayerCharacter",
                        principalColumn: "PlayerCharacterid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatBlock",
                columns: table => new
                {
                    Statblockid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basehp = table.Column<int>(nullable: true),
                    Speed = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: true),
                    Passiveperception = table.Column<int>(nullable: true),
                    Vision = table.Column<string>(nullable: true),
                    Characterid = table.Column<int>(nullable: true),
                    Strengthid = table.Column<int>(nullable: true),
                    Dexterityid = table.Column<int>(nullable: true),
                    Constitutionid = table.Column<int>(nullable: true),
                    Intelligenceid = table.Column<int>(nullable: true),
                    Wisdomid = table.Column<int>(nullable: true),
                    Charismaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatBlock", x => x.Statblockid);
                    table.ForeignKey(
                        name: "FK_StatBlock_PlayerCharacter_Characterid",
                        column: x => x.Characterid,
                        principalTable: "PlayerCharacter",
                        principalColumn: "PlayerCharacterid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatBlock_Charisma_Charismaid",
                        column: x => x.Charismaid,
                        principalTable: "Charisma",
                        principalColumn: "Charismaid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatBlock_Constitution_Constitutionid",
                        column: x => x.Constitutionid,
                        principalTable: "Constitution",
                        principalColumn: "Constitutionid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatBlock_Dexterity_Dexterityid",
                        column: x => x.Dexterityid,
                        principalTable: "Dexterity",
                        principalColumn: "Dexterityid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatBlock_Intelligence_Intelligenceid",
                        column: x => x.Intelligenceid,
                        principalTable: "Intelligence",
                        principalColumn: "Intelligenceid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatBlock_Strength_Strengthid",
                        column: x => x.Strengthid,
                        principalTable: "Strength",
                        principalColumn: "Strengthid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatBlock_Wisdom_Wisdomid",
                        column: x => x.Wisdomid,
                        principalTable: "Wisdom",
                        principalColumn: "Wisdomid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryHasItems",
                columns: table => new
                {
                    InventoryHasItemsid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inventoryid = table.Column<int>(nullable: true),
                    Itemid = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    Isattuned = table.Column<bool>(nullable: true),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryHasItems", x => x.InventoryHasItemsid);
                    table.ForeignKey(
                        name: "FK_InventoryHasItems_Inventory_Inventoryid",
                        column: x => x.Inventoryid,
                        principalTable: "Inventory",
                        principalColumn: "Inventoryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryHasItems_Items_Itemid",
                        column: x => x.Itemid,
                        principalTable: "Items",
                        principalColumn: "Itemsid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellListHasSpells",
                columns: table => new
                {
                    SpellListHasSpellsid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpellListId = table.Column<int>(nullable: true),
                    Spellid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellListHasSpells", x => x.SpellListHasSpellsid);
                    table.ForeignKey(
                        name: "FK_SpellListHasSpells_SpellList_SpellListId",
                        column: x => x.SpellListId,
                        principalTable: "SpellList",
                        principalColumn: "Spelllistid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellListHasSpells_Spells_Spellid",
                        column: x => x.Spellid,
                        principalTable: "Spells",
                        principalColumn: "Spellsid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Background_Characterid",
                table: "Background",
                column: "Characterid");

            migrationBuilder.CreateIndex(
                name: "IX_Charisma_Deceptionid",
                table: "Charisma",
                column: "Deceptionid");

            migrationBuilder.CreateIndex(
                name: "IX_Charisma_Intimidationid",
                table: "Charisma",
                column: "Intimidationid");

            migrationBuilder.CreateIndex(
                name: "IX_Charisma_Performanceid",
                table: "Charisma",
                column: "Performanceid");

            migrationBuilder.CreateIndex(
                name: "IX_Charisma_Persuasionid",
                table: "Charisma",
                column: "Persuasionid");

            migrationBuilder.CreateIndex(
                name: "IX_Dexterity_Acrobaticsid",
                table: "Dexterity",
                column: "Acrobaticsid");

            migrationBuilder.CreateIndex(
                name: "IX_Dexterity_Sleightid",
                table: "Dexterity",
                column: "Sleightid");

            migrationBuilder.CreateIndex(
                name: "IX_Dexterity_Stealthid",
                table: "Dexterity",
                column: "Stealthid");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CaharacterId",
                table: "Features",
                column: "CaharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Intelligence_Arcanaid",
                table: "Intelligence",
                column: "Arcanaid");

            migrationBuilder.CreateIndex(
                name: "IX_Intelligence_Historyid",
                table: "Intelligence",
                column: "Historyid");

            migrationBuilder.CreateIndex(
                name: "IX_Intelligence_Investigationid",
                table: "Intelligence",
                column: "Investigationid");

            migrationBuilder.CreateIndex(
                name: "IX_Intelligence_Natureid",
                table: "Intelligence",
                column: "Natureid");

            migrationBuilder.CreateIndex(
                name: "IX_Intelligence_Religionid",
                table: "Intelligence",
                column: "Religionid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Characterid",
                table: "Inventory",
                column: "Characterid");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHasItems_Inventoryid",
                table: "InventoryHasItems",
                column: "Inventoryid");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHasItems_Itemid",
                table: "InventoryHasItems",
                column: "Itemid");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_Campaignid",
                table: "PlayerCharacter",
                column: "Campaignid");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_Userid",
                table: "PlayerCharacter",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_SpellList_Characterid",
                table: "SpellList",
                column: "Characterid");

            migrationBuilder.CreateIndex(
                name: "IX_SpellListHasSpells_SpellListId",
                table: "SpellListHasSpells",
                column: "SpellListId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellListHasSpells_Spellid",
                table: "SpellListHasSpells",
                column: "Spellid");

            migrationBuilder.CreateIndex(
                name: "IX_StatBlock_Characterid",
                table: "StatBlock",
                column: "Characterid");

            migrationBuilder.CreateIndex(
                name: "IX_StatBlock_Charismaid",
                table: "StatBlock",
                column: "Charismaid");

            migrationBuilder.CreateIndex(
                name: "IX_StatBlock_Constitutionid",
                table: "StatBlock",
                column: "Constitutionid");

            migrationBuilder.CreateIndex(
                name: "IX_StatBlock_Dexterityid",
                table: "StatBlock",
                column: "Dexterityid");

            migrationBuilder.CreateIndex(
                name: "IX_StatBlock_Intelligenceid",
                table: "StatBlock",
                column: "Intelligenceid");

            migrationBuilder.CreateIndex(
                name: "IX_StatBlock_Strengthid",
                table: "StatBlock",
                column: "Strengthid");

            migrationBuilder.CreateIndex(
                name: "IX_StatBlock_Wisdomid",
                table: "StatBlock",
                column: "Wisdomid");

            migrationBuilder.CreateIndex(
                name: "IX_Strength_Athleticsid",
                table: "Strength",
                column: "Athleticsid");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBelongToCampaign_CampaignId",
                table: "UsersBelongToCampaign",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBelongToCampaign_UserId",
                table: "UsersBelongToCampaign",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wisdom_Animalhandid",
                table: "Wisdom",
                column: "Animalhandid");

            migrationBuilder.CreateIndex(
                name: "IX_Wisdom_Insightid",
                table: "Wisdom",
                column: "Insightid");

            migrationBuilder.CreateIndex(
                name: "IX_Wisdom_Perceptionid",
                table: "Wisdom",
                column: "Perceptionid");

            migrationBuilder.CreateIndex(
                name: "IX_Wisdom_Survivalid",
                table: "Wisdom",
                column: "Survivalid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Background");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "InventoryHasItems");

            migrationBuilder.DropTable(
                name: "SpellListHasSpells");

            migrationBuilder.DropTable(
                name: "StatBlock");

            migrationBuilder.DropTable(
                name: "UsersBelongToCampaign");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SpellList");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Charisma");

            migrationBuilder.DropTable(
                name: "Constitution");

            migrationBuilder.DropTable(
                name: "Dexterity");

            migrationBuilder.DropTable(
                name: "Intelligence");

            migrationBuilder.DropTable(
                name: "Strength");

            migrationBuilder.DropTable(
                name: "Wisdom");

            migrationBuilder.DropTable(
                name: "PlayerCharacter");

            migrationBuilder.DropTable(
                name: "Deception");

            migrationBuilder.DropTable(
                name: "Intimidation");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Persuasion");

            migrationBuilder.DropTable(
                name: "Acrobatics");

            migrationBuilder.DropTable(
                name: "SleightOfHand");

            migrationBuilder.DropTable(
                name: "Stealth");

            migrationBuilder.DropTable(
                name: "Arcana");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Investigation");

            migrationBuilder.DropTable(
                name: "Nature");

            migrationBuilder.DropTable(
                name: "Religion");

            migrationBuilder.DropTable(
                name: "Athletics");

            migrationBuilder.DropTable(
                name: "AnimalHandling");

            migrationBuilder.DropTable(
                name: "Insight");

            migrationBuilder.DropTable(
                name: "Perception");

            migrationBuilder.DropTable(
                name: "Survival");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
