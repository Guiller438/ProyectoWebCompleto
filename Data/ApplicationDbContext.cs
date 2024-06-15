using IW7PP.Models;
using IW7PP.Models.Amputations;
using IW7PP.Models.Cliente;
using IW7PP.Models.ProsthesisM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IW7PP.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserModel> userModels { get; set; }

        public DbSet<UpperLimbAmputation> UpperLimbAmputations { get; set; }

        public DbSet<LowerLimbAmputation> LowerLimbAmputations { get; set; }

        public DbSet<Prosthesis> Prostheses { get; set; }

        public DbSet<Socket> Sockets { get; set; }

        public DbSet<Liner> Liners { get; set; }

        public DbSet<Tube> Tubes { get; set; }

        public DbSet<Foot> Feet { get; set; }

        public DbSet<UnionSocket> UnionSockets { get; set; }

        public DbSet<KneeArticulate> KneeArticulates { get; set; }

        public DbSet<LifeStyle> LifeStyles { get; set; }

        public DbSet<ClientesProtesicos> ClientesProtesicos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UpperLimbAmputation>().HasData(
                new UpperLimbAmputation
                {
                    Id = Guid.NewGuid(),
                    AmputationName = "Finger Partial"
                },
                new UpperLimbAmputation
                {
                    Id = Guid.NewGuid(),
                    AmputationName = "Finger Complete"
                },
                new UpperLimbAmputation
                {
                    Id = Guid.NewGuid(),
                    AmputationName = "Hand Partial"
                },
                new UpperLimbAmputation
                {
                    Id = Guid.NewGuid(),
                    AmputationName = "Wrist Disarticulation"
                },
                new UpperLimbAmputation
                {
                    Id = Guid.NewGuid(),
                    AmputationName = "Transradial"
                },
                new UpperLimbAmputation
                {
                    Id = Guid.NewGuid(),
                    AmputationName = "Elbow Disarticulation"
                }
            );

            builder.Entity<LowerLimbAmputation>().HasData(
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "Below Knee"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "Above Knee"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "ToePartial"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "ToeComplete"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "FootPartial"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "Lisfranc"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "Chopart"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "AnkleDisarticulation"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "Transtibial"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "KneeDisarticulation"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "Transfemoral"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "HipDisarticulation"
               },
               new LowerLimbAmputation
               {
                   Id = Guid.NewGuid(),
                   AmputationName = "Hemipelvectomy"
               }
           );

            //Seed para Liners Id, Name, DESCRIPTION, DURABILITY in months

            builder.Entity<Liner>().HasData(
              new Liner
              {
                  Id = 1,
                  Name = "Liner 1",
                  Description = "Liner 1 Description",
                  Durability = 6
              },
              new Liner
              {
                  Id = 2,
                  Name = "Liner 2",
                  Description = "Liner 2 Description",
                  Durability = 12
              },
              new Liner
              {
                  Id = 3,
                  Name = "Liner 3",
                  Description = "Liner 3 Description",
                  Durability = 18
              },
              new Liner
              {
                  Id = 4,
                  Name = "Liner 4",
                  Description = "Liner 4 Description",
                  Durability = 24
              },
              new Liner
              {
                  Id = 5,
                  Name = "Liner 5",
                  Description = "Liner 5 Description",
                  Durability = 30
              }
            );

            //Seed para Sockets Id, Description, Durability in months

            builder.Entity<Socket>().HasData(
                new Socket
                {
                    Id = 1,
                    Description = "Socket 1",
                    Durability = 6
                },
                new Socket
                {
                    Id = 2,
                    Description = "Socket 2",
                    Durability = 12
                },
                new Socket
                {
                    Id = 3,
                    Description = "Socket 3",
                    Durability = 18
                },
                new Socket
                {
                    Id = 4,
                    Description = "Socket 4",
                    Durability = 24
                },
                new Socket
                {
                    Id = 5,
                    Description = "Socket 5",
                    Durability = 30
                }
            );

            //Seed para Tubes Id, Name, Description, Durability in months

            builder.Entity<Tube>().HasData(
                new Tube
                {
                    Id = 1,
                    Name = "Tube 1",
                    Description = "Tube 1 Description",
                    Durability = 6
                },
                new Tube
                {
                    Id = 2,
                    Name = "Tube 2",
                    Description = "Tube 2 Description",
                    Durability = 12
                },
                new Tube
                {
                    Id = 3,
                    Name = "Tube 3",
                    Description = "Tube 3 Description",
                    Durability = 18
                },
                new Tube
                {
                    Id = 4,
                    Name = "Tube 4",
                    Description = "Tube 4 Description",
                    Durability = 24
                },
                new Tube
                {
                    Id = 5,
                    Name = "Tube 5",
                    Description = "Tube 5 Description",
                    Durability = 30
                }
            );

            //Seed para Feet Id, Name, Description, Durability in months

            builder.Entity<Foot>().HasData(
                new Foot
                {
                    Id = 1,
                    Name = "Foot 1",
                    Description = "Foot 1 Description",
                    Durability = 6
                },
                new Foot
                {
                    Id = 2,
                    Name = "Foot 2",
                    Description = "Foot 2 Description",
                    Durability = 12
                },
                new Foot
                {
                    Id = 3,
                    Name = "Foot 3",
                    Description = "Foot 3 Description",
                    Durability = 18
                },
                new Foot
                {
                    Id = 4,
                    Name = "Foot 4",
                    Description = "Foot 4 Description",
                    Durability = 24
                },
                new Foot
                {
                    Id = 5,
                    Name = "Foot 5",
                    Description = "Foot 5 Description",
                    Durability = 30
                }
            );

            //Seed para UnionSockets Id, Name, Description, Durability in months

            builder.Entity<UnionSocket>().HasData(
                new UnionSocket
                {
                    Id = 1,
                    Name = "UnionSocket 1",
                    Description = "UnionSocket 1 Description",
                    Durability = 6
                },
                new UnionSocket
                {
                    Id = 2,
                    Name = "UnionSocket 2",
                    Description = "UnionSocket 2 Description",
                    Durability = 12
                },
                new UnionSocket
                {
                    Id = 3,
                    Name = "UnionSocket 3",
                    Description = "UnionSocket 3 Description",
                    Durability = 18
                },
                new UnionSocket
                {
                    Id = 4,
                    Name = "UnionSocket 4",
                    Description = "UnionSocket 4 Description",
                    Durability = 24
                },
                new UnionSocket
                {
                    Id = 5,
                    Name = "UnionSocket 5",
                    Description = "UnionSocket 5 Description",
                    Durability = 30
                }
            );

            //Seed para KneeArticulates Id, Name, Description, Durability in months

            builder.Entity<KneeArticulate>().HasData(
                new KneeArticulate
                {
                    Id = 1,
                    Name = "KneeArticulate 1",
                    Description = "KneeArticulate 1 Description",
                    Durability = 6
                },
                new KneeArticulate
                {
                    Id = 2,
                    Name = "KneeArticulate 2",
                    Description = "KneeArticulate 2 Description",
                    Durability = 12
                },
                new KneeArticulate
                {
                    Id = 3,
                    Name = "KneeArticulate 3",
                    Description = "KneeArticulate 3 Description",
                    Durability = 18
                },
                new KneeArticulate
                {
                    Id = 4,
                    Name = "KneeArticulate 4",
                    Description = "KneeArticulate 4 Description",
                    Durability = 24
                },
                new KneeArticulate
                {
                    Id = 5,
                    Name = "KneeArticulate 5",
                    Description = "KneeArticulate 5 Description",
                    Durability = 30
                }
            );

            //Seed para LifeStyles Id, Name, Description

            builder.Entity<LifeStyle>().HasData(
                new LifeStyle
                {
                    Id = 1,
                    Name = "Sedentary",
                    Description = "El estilo de vida sedentario implica baja actividad física y largos periodos sentados, a menudo por trabajo o uso de dispositivos",
                    promedioDesgaste = 0.5
                },
                new LifeStyle
                {
                    Id = 2,
                    Name = "Activo",
                    Description = "Un estilo de vida activo incluye actividad física moderada y regular, con ejercicios de intensidad moderada",
                    promedioDesgaste = 1.0
                },
                new LifeStyle
                {
                    Id = 3,
                    Name = "Deportista",
                    Description = "El estilo de vida de un deportista se enfoca en alta actividad física y rendimiento, dedicando mucho tiempo al entrenamiento",
                    promedioDesgaste = 1.5
                }
            );
        }


    }
}
