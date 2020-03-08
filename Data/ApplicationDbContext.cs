using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DnDFrontEnd.Models;

namespace DnDFrontEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DnDFrontEnd.Models.Items> Items { get; set; }
        public DbSet<DnDFrontEnd.Models.Acrobatics> Acrobatics { get; set; }
        public DbSet<DnDFrontEnd.Models.AnimalHandling> AnimalHandling { get; set; }
        public DbSet<DnDFrontEnd.Models.Arcana> Arcana { get; set; }
        public DbSet<DnDFrontEnd.Models.Athletics> Athletics { get; set; }
        public DbSet<DnDFrontEnd.Models.Background> Background { get; set; }
        public DbSet<DnDFrontEnd.Models.Campaign> Campaign { get; set; }
        public DbSet<DnDFrontEnd.Models.Charisma> Charisma { get; set; }
        public DbSet<DnDFrontEnd.Models.Constitution> Constitution { get; set; }
        public DbSet<DnDFrontEnd.Models.Deception> Deception { get; set; }
        public DbSet<DnDFrontEnd.Models.Dexterity> Dexterity { get; set; }
        public DbSet<DnDFrontEnd.Models.Features> Features { get; set; }
        public DbSet<DnDFrontEnd.Models.History> History { get; set; }
        public DbSet<DnDFrontEnd.Models.Insight> Insight { get; set; }
        public DbSet<DnDFrontEnd.Models.Intelligence> Intelligence { get; set; }
        public DbSet<DnDFrontEnd.Models.Intimidation> Intimidation { get; set; }
        public DbSet<DnDFrontEnd.Models.Inventory> Inventory { get; set; }
        public DbSet<DnDFrontEnd.Models.InventoryHasItems> InventoryHasItems { get; set; }
        public DbSet<DnDFrontEnd.Models.Investigation> Investigation { get; set; }
        public DbSet<DnDFrontEnd.Models.Nature> Nature { get; set; }
        public DbSet<DnDFrontEnd.Models.Perception> Perception { get; set; }
        public DbSet<DnDFrontEnd.Models.Performance> Performance { get; set; }
        public DbSet<DnDFrontEnd.Models.Persuasion> Persuasion { get; set; }
        public DbSet<DnDFrontEnd.Models.PlayerCharacter> PlayerCharacter { get; set; }
        public DbSet<DnDFrontEnd.Models.Religion> Religion { get; set; }
        public DbSet<DnDFrontEnd.Models.SleightOfHand> SleightOfHand { get; set; }
        public DbSet<DnDFrontEnd.Models.SpellList> SpellList { get; set; }
        public DbSet<DnDFrontEnd.Models.SpellListHasSpells> SpellListHasSpells { get; set; }
        public DbSet<DnDFrontEnd.Models.Spells> Spells { get; set; }
        public DbSet<DnDFrontEnd.Models.StatBlock> StatBlock { get; set; }
        public DbSet<DnDFrontEnd.Models.Stealth> Stealth { get; set; }
        public DbSet<DnDFrontEnd.Models.Strength> Strength { get; set; }
        public DbSet<DnDFrontEnd.Models.Survival> Survival { get; set; }
        public DbSet<DnDFrontEnd.Models.Users> Users { get; set; }
        public DbSet<DnDFrontEnd.Models.UsersBelongToCampaign> UsersBelongToCampaign { get; set; }
        public DbSet<DnDFrontEnd.Models.Wisdom> Wisdom { get; set; }
    }
}
