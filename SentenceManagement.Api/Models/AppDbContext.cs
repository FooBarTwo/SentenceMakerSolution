using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WordManagement.Models;

namespace SentenceManagement.Api.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        {
        }

        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Sentences Table
            modelBuilder.Entity<Sentence>().HasData(new Sentence { SentenceId = 1, Content = "Hello World!" });
            modelBuilder.Entity<Sentence>().HasData(new Sentence { SentenceId = 2, Content = "Goodbye cruel World." });
            modelBuilder.Entity<Sentence>().HasData(new Sentence { SentenceId = 3, Content = "Whatever you say is only you're opinion." });
            modelBuilder.Entity<Sentence>().HasData(new Sentence { SentenceId = 4, Content = "When the blueberry sings and the mocking bird hums." });
            modelBuilder.Entity<Sentence>().HasData(new Sentence { SentenceId = 5, Content = "When comes and the sun chaseth the darkness away." });

            // Seed Word Table
            //NOUNS: Box,Brother,Business,Car,Case,Change,Child,
            //VERBS: Roar,Ride,Roast,Run,Say,Sing,Sit
            //Noun, Verb, Adjective, Adverb, Pronoun, Preposition, Conjunction, Determiner, Exclamation
            modelBuilder.Entity<Word>().HasData(new Word { WordId = 1, TypeOfWord = WordType.Noun, Descrip = "Box" });
            modelBuilder.Entity<Word>().HasData(new Word { WordId = 2, TypeOfWord = WordType.Noun, Descrip = "Car" });
            modelBuilder.Entity<Word>().HasData(new Word { WordId = 3, TypeOfWord = WordType.Noun, Descrip = "Case" });
            modelBuilder.Entity<Word>().HasData(new Word { WordId = 4, TypeOfWord = WordType.Verb, Descrip = "Ride" });
            modelBuilder.Entity<Word>().HasData(new Word { WordId = 5, TypeOfWord = WordType.Verb, Descrip = "Sit" });
            modelBuilder.Entity<Word>().HasData(new Word { WordId = 6, TypeOfWord = WordType.Verb, Descrip = "Sing" });
        }
    }
}
