﻿using Dungeons_And_Dragons_Character_Manager_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Dungeons_And_Dragons_Character_Manager_App.Data
{
    public class CharacterManagerContext : DbContext
    {
        public CharacterManagerContext(DbContextOptions<CharacterManagerContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<AbilityScore> AbilityScores { get; set; }
        public DbSet<AbilityScoreIncrease> AbilityScoreIncreases { get; set; }

        public DbSet<Fighter> Fighter { get; set; }

        public DbSet<Spell> Spells { get; set; }

        //public DbSet<Background> Backgrounds { get; set; }

        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Weapon>();
            builder.Entity<Tool>();
            builder.Entity<Armor>();
            builder.Entity<Shield>();

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
