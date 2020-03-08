using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DnDFrontEnd.Models
{
    public partial class DnDDatabaseContext : DbContext
    {
        public DnDDatabaseContext()
        {
        }

        public DnDDatabaseContext(DbContextOptions<DnDDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acrobatics> Acrobatics { get; set; }
        public virtual DbSet<AnimalHandling> AnimalHandling { get; set; }
        public virtual DbSet<Arcana> Arcana { get; set; }
        public virtual DbSet<Athletics> Athletics { get; set; }
        public virtual DbSet<Background> Background { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Charisma> Charisma { get; set; }
        public virtual DbSet<Constitution> Constitution { get; set; }
        public virtual DbSet<Deception> Deception { get; set; }
        public virtual DbSet<Dexterity> Dexterity { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Insight> Insight { get; set; }
        public virtual DbSet<Intelligence> Intelligence { get; set; }
        public virtual DbSet<Intimidation> Intimidation { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryHasItems> InventoryHasItems { get; set; }
        public virtual DbSet<Investigation> Investigation { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Nature> Nature { get; set; }
        public virtual DbSet<Perception> Perception { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<Persuasion> Persuasion { get; set; }
        public virtual DbSet<PlayerCharacter> PlayerCharacter { get; set; }
        public virtual DbSet<Religion> Religion { get; set; }
        public virtual DbSet<SleightOfHand> SleightOfHand { get; set; }
        public virtual DbSet<SpellList> SpellList { get; set; }
        public virtual DbSet<SpellListHasSpells> SpellListHasSpells { get; set; }
        public virtual DbSet<Spells> Spells { get; set; }
        public virtual DbSet<StatBlock> StatBlock { get; set; }
        public virtual DbSet<Stealth> Stealth { get; set; }
        public virtual DbSet<Strength> Strength { get; set; }
        public virtual DbSet<Survival> Survival { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersBelongToCampaign> UsersBelongToCampaign { get; set; }
        public virtual DbSet<Wisdom> Wisdom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:dndsqlserver.database.windows.net,1433;Initial Catalog=DnDDatabase;Persist Security Info=False;User ID=DnDAdmin;Password=DnDdatabase2020!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acrobatics>(entity =>
            {
                entity.Property(e => e.Acrobaticsid).HasColumnName("acrobaticsid");

                entity.Property(e => e.Acrobaticsprof)
                    .HasColumnName("acrobaticsprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<AnimalHandling>(entity =>
            {
                entity.HasKey(e => e.AnimalHandlingId)
                    .HasName("PK__AnimalHa__40A99E63352B5721");

                entity.Property(e => e.AnimalHandlingId).HasColumnName("animalhandid");

                entity.Property(e => e.Animalhandprof)
                    .HasColumnName("animalhandprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Arcana>(entity =>
            {
                entity.Property(e => e.Arcanaid).HasColumnName("arcanaid");

                entity.Property(e => e.Arcanaprof)
                    .HasColumnName("arcanaprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Athletics>(entity =>
            {
                entity.Property(e => e.Athleticsid).HasColumnName("athleticsid");

                entity.Property(e => e.Athleticsproficiency)
                    .HasColumnName("athleticsproficiency")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Background>(entity =>
            {
                entity.Property(e => e.Backgroundid).HasColumnName("backgroundid");

                entity.Property(e => e.Backgroundtype)
                    .HasColumnName("backgroundtype")
                    .HasColumnType("text");

                entity.Property(e => e.Bonds)
                    .HasColumnName("bonds")
                    .HasColumnType("text");

                entity.Property(e => e.Characterid).HasColumnName("characterid");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Flaws)
                    .HasColumnName("flaws")
                    .HasColumnType("text");

                entity.Property(e => e.Ideals)
                    .HasColumnName("ideals")
                    .HasColumnType("text");

                entity.Property(e => e.Traits)
                    .HasColumnName("traits")
                    .HasColumnType("text");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Background)
                    .HasForeignKey(d => d.Characterid)
                    .HasConstraintName("FK__Backgroun__chara__25518C17");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.CampaignId).HasColumnName("campaignID");
                entity.Property(e => e.CampaignName)
                    .HasColumnName("campaignname")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Charisma>(entity =>
            {
                entity.HasKey(e => e.Charismaid)
                    .HasName("PK__Charisma__52B34AEB875D5EFC");

                entity.Property(e => e.Charismaid).HasColumnName("chaid");

                entity.Property(e => e.Chasaveprof).HasColumnName("chasaveprof");

                entity.Property(e => e.Chavalue).HasColumnName("chavalue");

                entity.Property(e => e.Deceptionid).HasColumnName("deceptionid");

                entity.Property(e => e.Intimidationid).HasColumnName("intimidationid");

                entity.Property(e => e.Performanceid).HasColumnName("performanceid");

                entity.Property(e => e.Persuasionid).HasColumnName("persuasionid");

                entity.HasOne(d => d.Deception)
                    .WithMany(p => p.Charisma)
                    .HasForeignKey(d => d.Deceptionid)
                    .HasConstraintName("FK__Charisma__decept__00200768");

                entity.HasOne(d => d.Intimidation)
                    .WithMany(p => p.Charisma)
                    .HasForeignKey(d => d.Intimidationid)
                    .HasConstraintName("FK__Charisma__intimi__01142BA1");

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.Charisma)
                    .HasForeignKey(d => d.Performanceid)
                    .HasConstraintName("FK__Charisma__perfor__7F2BE32F");

                entity.HasOne(d => d.Persuasion)
                    .WithMany(p => p.Charisma)
                    .HasForeignKey(d => d.Persuasionid)
                    .HasConstraintName("FK__Charisma__persua__7E37BEF6");
            });

            modelBuilder.Entity<Constitution>(entity =>
            {
                entity.HasKey(e => e.Constitutionid)
                    .HasName("PK__Constitu__908D93A32BE5D709");

                entity.Property(e => e.Constitutionid).HasColumnName("conid");

                entity.Property(e => e.Consaveprof).HasColumnName("consaveprof");

                entity.Property(e => e.Convalue).HasColumnName("convalue");
            });

            modelBuilder.Entity<Deception>(entity =>
            {
                entity.Property(e => e.Deceptionid).HasColumnName("deceptionid");

                entity.Property(e => e.Deceptionprof)
                    .HasColumnName("deceptionprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Dexterity>(entity =>
            {
                entity.Property(e => e.Dexterityid).HasColumnName("dexterityid");

                entity.Property(e => e.Acrobaticsid).HasColumnName("acrobaticsid");

                entity.Property(e => e.Dexsaveprof).HasColumnName("dexsaveprof");

                entity.Property(e => e.Dexvalue).HasColumnName("dexvalue");

                entity.Property(e => e.Sleightid).HasColumnName("sleightid");

                entity.Property(e => e.Stealthid).HasColumnName("stealthid");

                entity.HasOne(d => d.Acrobatics)
                    .WithMany(p => p.Dexterity)
                    .HasForeignKey(d => d.Acrobaticsid)
                    .HasConstraintName("FK__Dexterity__acrob__02FC7413");

                entity.HasOne(d => d.Sleight)
                    .WithMany(p => p.Dexterity)
                    .HasForeignKey(d => d.Sleightid)
                    .HasConstraintName("FK__Dexterity__sleig__03F0984C");

                entity.HasOne(d => d.Stealth)
                    .WithMany(p => p.Dexterity)
                    .HasForeignKey(d => d.Stealthid)
                    .HasConstraintName("FK__Dexterity__steal__02084FDA");
            });

            modelBuilder.Entity<Features>(entity =>
            {
                entity.HasKey(e => e.Featuresid)
                    .HasName("PK__Features__F4F60CBB1DA9DB05");

                entity.Property(e => e.Featuresid).HasColumnName("featureid");

                entity.Property(e => e.Aquiredfrom)
                    .HasColumnName("aquiredfrom")
                    .HasColumnType("text");

                entity.Property(e => e.CaharacterId).HasColumnName("caharacterID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.HasOne(d => d.Caharacter)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.CaharacterId)
                    .HasConstraintName("FK__Features__cahara__2645B050");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.Historyid).HasColumnName("historyid");

                entity.Property(e => e.Historyprof)
                    .HasColumnName("historyprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Insight>(entity =>
            {
                entity.Property(e => e.Insightid).HasColumnName("insightid");

                entity.Property(e => e.Insighprof)
                    .HasColumnName("insighprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Intelligence>(entity =>
            {
                entity.HasKey(e => e.Intelligenceid)
                    .HasName("PK__Intellig__11A964FABAB97564");

                entity.Property(e => e.Intelligenceid).HasColumnName("intid");

                entity.Property(e => e.Arcanaid).HasColumnName("arcanaid");

                entity.Property(e => e.Historyid).HasColumnName("historyid");

                entity.Property(e => e.Intsaveprof).HasColumnName("intsaveprof");

                entity.Property(e => e.Intvalue).HasColumnName("intvalue");

                entity.Property(e => e.Investigationid).HasColumnName("investigationid");

                entity.Property(e => e.Natureid).HasColumnName("natureid");

                entity.Property(e => e.Religionid).HasColumnName("religionid");

                entity.HasOne(d => d.Arcana)
                    .WithMany(p => p.Intelligence)
                    .HasForeignKey(d => d.Arcanaid)
                    .HasConstraintName("FK__Intellige__arcan__06CD04F7");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Intelligence)
                    .HasForeignKey(d => d.Historyid)
                    .HasConstraintName("FK__Intellige__histo__05D8E0BE");

                entity.HasOne(d => d.Investigation)
                    .WithMany(p => p.Intelligence)
                    .HasForeignKey(d => d.Investigationid)
                    .HasConstraintName("FK__Intellige__inves__04E4BC85");

                entity.HasOne(d => d.Nature)
                    .WithMany(p => p.Intelligence)
                    .HasForeignKey(d => d.Natureid)
                    .HasConstraintName("FK__Intellige__natur__07C12930");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Intelligence)
                    .HasForeignKey(d => d.Religionid)
                    .HasConstraintName("FK__Intellige__relig__08B54D69");
            });

            modelBuilder.Entity<Intimidation>(entity =>
            {
                entity.Property(e => e.Intimidationid).HasColumnName("intimidationid");

                entity.Property(e => e.Intimidationprof)
                    .HasColumnName("intimidationprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Inventoryid).HasColumnName("inventoryid");

                entity.Property(e => e.Characterid).HasColumnName("characterid");

                entity.Property(e => e.Encumberance)
                    .HasColumnName("encumberance")
                    .HasColumnType("text");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Characterid)
                    .HasConstraintName("FK__Inventory__chara__2739D489");
            });

            modelBuilder.Entity<InventoryHasItems>(entity =>
            {
                entity.Property(e => e.InventoryHasItemsid).HasColumnName("InventoryHasItemsid");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Inventoryid).HasColumnName("inventoryid");

                entity.Property(e => e.Isattuned).HasColumnName("isattuned");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasKey(e => new { e.Inventoryid, e.Itemid })
                      .HasName("CompositeKey_IHI");
                
                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryHasItems)
                    .HasForeignKey(d => d.Inventoryid)
                    .HasConstraintName("FK__Inventory__inven__282DF8C2");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.InventoryHasItems)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("FK__Inventory__itemi__29221CFB");
            });

            modelBuilder.Entity<Investigation>(entity =>
            {
                entity.Property(e => e.Investigationid).HasColumnName("investigationid");

                entity.Property(e => e.Investigationprof)
                    .HasColumnName("investigationprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.Itemsid)
                    .HasName("PK__Items__56A22C92B4C7BECA");

                entity.Property(e => e.Itemsid).HasColumnName("itemid");

                entity.Property(e => e.Attunementreq).HasColumnName("attunementreq");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("text");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Nature>(entity =>
            {
                entity.Property(e => e.Natureid).HasColumnName("natureid");

                entity.Property(e => e.Natureprof)
                    .HasColumnName("natureprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Perception>(entity =>
            {
                entity.Property(e => e.Perceptionid).HasColumnName("perceptionid");

                entity.Property(e => e.Perceptionprof)
                    .HasColumnName("perceptionprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Performance>(entity =>
            {
                entity.Property(e => e.Performanceid).HasColumnName("performanceid");

                entity.Property(e => e.Performanceprof)
                    .HasColumnName("performanceprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Persuasion>(entity =>
            {
                entity.Property(e => e.Persuasionid).HasColumnName("persuasionid");

                entity.Property(e => e.Persausionprof)
                    .HasColumnName("persausionprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<PlayerCharacter>(entity =>
            {
                entity.HasKey(e => e.PlayerCharacterid)
                    .HasName("PK__PlayerCh__ADFA1D972ABAEC73");

                entity.Property(e => e.PlayerCharacterid).HasColumnName("characterid");

                entity.Property(e => e.Alignment)
                    .HasColumnName("alignment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Campaignid).HasColumnName("campaignid");

                entity.Property(e => e.Charactername)
                    .HasColumnName("charactername")
                    .HasColumnType("text");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("text");

                entity.Property(e => e.Languages)
                    .HasColumnName("languages")
                    .HasColumnType("text");

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.PlayerCharacter)
                    .HasForeignKey(d => d.Campaignid)
                    .HasConstraintName("FK__PlayerCha__campa__09A971A2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PlayerCharacter)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__PlayerCha__useri__2CF2ADDF");
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.Property(e => e.Religionid).HasColumnName("religionid");

                entity.Property(e => e.Religionprof)
                    .HasColumnName("religionprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<SleightOfHand>(entity =>
            {
                entity.HasKey(e => e.Sleightofhandid)
                    .HasName("PK__SleightO__99AABAE3D302C313");

                entity.Property(e => e.Sleightofhandid).HasColumnName("sleightid");

                entity.Property(e => e.Sleightprof)
                    .HasColumnName("sleightprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<SpellList>(entity =>
            {
                entity.Property(e => e.Spelllistid).HasColumnName("spelllistid");

                entity.Property(e => e.Characterid).HasColumnName("characterid");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.SpellList)
                    .HasForeignKey(d => d.Characterid)
                    .HasConstraintName("FK__SpellList__chara__2A164134");
            });

            modelBuilder.Entity<SpellListHasSpells>(entity =>
            {
                entity.Property(e => e.SpellListHasSpellsid).HasColumnName("SpellListHasSpellsid");

                entity.Property(e => e.SpellListId).HasColumnName("SpellListID");

                entity.Property(e => e.Spellid).HasColumnName("spellid");

                entity.HasKey(e => new { e.SpellListId, e.Spellid })
                      .HasName("CompositeKey_SHS");


                entity.HasOne(d => d.SpellList)
                    .WithMany(p => p.SpellListHasSpells)
                    .HasForeignKey(d => d.SpellListId)
                    .HasConstraintName("FK__SpellList__Spell__2B0A656D");

                entity.HasOne(d => d.Spell)
                    .WithMany(p => p.SpellListHasSpells)
                    .HasForeignKey(d => d.Spellid)
                    .HasConstraintName("FK__SpellList__spell__2BFE89A6");
            });

            modelBuilder.Entity<Spells>(entity =>
            {
                entity.HasKey(e => e.Spellsid)
                    .HasName("PK__Spells__5C37CA74D38B7323");

                entity.Property(e => e.Spellsid).HasColumnName("spellid");

                entity.Property(e => e.Components)
                    .HasColumnName("components")
                    .HasColumnType("text");

                entity.Property(e => e.Concentration).HasColumnName("concentration");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Range).HasColumnName("range");

                entity.Property(e => e.School)
                    .HasColumnName("school")
                    .HasColumnType("text");

                entity.Property(e => e.Spellname)
                    .HasColumnName("spellname")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<StatBlock>(entity =>
            {
                entity.Property(e => e.Statblockid).HasColumnName("statblockid");

                entity.Property(e => e.Basehp).HasColumnName("basehp");

                entity.Property(e => e.Characterid).HasColumnName("characterid");

                entity.Property(e => e.Charismaid).HasColumnName("charismaid");

                entity.Property(e => e.Constitutionid).HasColumnName("constitutionid");

                entity.Property(e => e.Dexterityid).HasColumnName("dexterityid");

                entity.Property(e => e.Intelligenceid).HasColumnName("intelligenceid");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Passiveperception).HasColumnName("passiveperception");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.Strengthid).HasColumnName("strengthid");

                entity.Property(e => e.Vision)
                    .HasColumnName("vision")
                    .HasColumnType("text");

                entity.Property(e => e.Wisdomid).HasColumnName("wisdomid");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.StatBlock)
                    .HasForeignKey(d => d.Characterid)
                    .HasConstraintName("FK__StatBlock__chara__0A9D95DB");

                entity.HasOne(d => d.Charisma)
                    .WithMany(p => p.StatBlock)
                    .HasForeignKey(d => d.Charismaid)
                    .HasConstraintName("FK__StatBlock__chari__10566F31");

                entity.HasOne(d => d.Constitution)
                    .WithMany(p => p.StatBlock)
                    .HasForeignKey(d => d.Constitutionid)
                    .HasConstraintName("FK__StatBlock__const__0D7A0286");

                entity.HasOne(d => d.Dexterity)
                    .WithMany(p => p.StatBlock)
                    .HasForeignKey(d => d.Dexterityid)
                    .HasConstraintName("FK__StatBlock__dexte__0C85DE4D");

                entity.HasOne(d => d.Intelligence)
                    .WithMany(p => p.StatBlock)
                    .HasForeignKey(d => d.Intelligenceid)
                    .HasConstraintName("FK__StatBlock__intel__0E6E26BF");

                entity.HasOne(d => d.Strength)
                    .WithMany(p => p.StatBlock)
                    .HasForeignKey(d => d.Strengthid)
                    .HasConstraintName("FK__StatBlock__stren__0B91BA14");

                entity.HasOne(d => d.Wisdom)
                    .WithMany(p => p.StatBlock)
                    .HasForeignKey(d => d.Wisdomid)
                    .HasConstraintName("FK__StatBlock__wisdo__0F624AF8");
            });

            modelBuilder.Entity<Stealth>(entity =>
            {
                entity.Property(e => e.Stealthid).HasColumnName("stealthid");

                entity.Property(e => e.Stealthprof)
                    .HasColumnName("stealthprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Strength>(entity =>
            {
                entity.Property(e => e.Strengthid).HasColumnName("strengthid");

                entity.Property(e => e.Athleticsid).HasColumnName("athleticsid");

                entity.Property(e => e.Strsaveprof).HasColumnName("strsaveprof");

                entity.Property(e => e.Strvalue).HasColumnName("strvalue");

                entity.HasOne(d => d.Athletics)
                    .WithMany(p => p.Strength)
                    .HasForeignKey(d => d.Athleticsid)
                    .HasConstraintName("FK__Strength__athlet__114A936A");
            });

            modelBuilder.Entity<Survival>(entity =>
            {
                entity.Property(e => e.Survivalid).HasColumnName("survivalid");

                entity.Property(e => e.Survivalprof)
                    .HasColumnName("survivalprof")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Users__CB9A1CDF274FFE66");

                entity.Property(e => e.UsersId).HasColumnName("userID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("userEmail")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersBelongToCampaign>(entity =>
            {
                entity.Property(e => e.UsersBelongToCampaignid).HasColumnName("UsersBelongToCampaignid");

                entity.Property(e => e.CampaignId).HasColumnName("campaignID");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasKey(e => new { e.CampaignId, e.UserId })
                     .HasName("CompositeKey_UBC");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.UsersBelongToCampaign)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK__UsersBelo__campa__123EB7A3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersBelongToCampaign)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UsersBelo__userI__1332DBDC");
            });

            modelBuilder.Entity<Wisdom>(entity =>
            {
                entity.HasKey(e => e.Wisdomid)
                    .HasName("PK__Wisdom__F7DD7A8D70D31A22");

                entity.Property(e => e.Wisdomid).HasColumnName("wisid");

                entity.Property(e => e.Animalhandid).HasColumnName("animalhandid");

                entity.Property(e => e.Insightid).HasColumnName("insightid");

                entity.Property(e => e.Perceptionid).HasColumnName("perceptionid");

                entity.Property(e => e.Survivalid).HasColumnName("survivalid");

                entity.Property(e => e.Wissaveprof).HasColumnName("wissaveprof");

                entity.Property(e => e.Wisvalue).HasColumnName("wisvalue");

                entity.HasOne(d => d.Animalhand)
                    .WithMany(p => p.Wisdom)
                    .HasForeignKey(d => d.Animalhandid)
                    .HasConstraintName("FK__Wisdom__animalha__14270015");

                entity.HasOne(d => d.Insight)
                    .WithMany(p => p.Wisdom)
                    .HasForeignKey(d => d.Insightid)
                    .HasConstraintName("FK__Wisdom__insighti__160F4887");

                entity.HasOne(d => d.Perception)
                    .WithMany(p => p.Wisdom)
                    .HasForeignKey(d => d.Perceptionid)
                    .HasConstraintName("FK__Wisdom__percepti__151B244E");

                entity.HasOne(d => d.Survival)
                    .WithMany(p => p.Wisdom)
                    .HasForeignKey(d => d.Survivalid)
                    .HasConstraintName("FK__Wisdom__survival__17036CC0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
