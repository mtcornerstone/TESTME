using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernateTutorial.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadNHibernateCfg();

            /* CRUD */
            CharacterRepository repo = new CharacterRepository();

            //CREATE!
            var MikeAbyss = new Character { Name = "MikeAbyss", HealthPoints = 700, Mana = 10, Profession = "Knight" };
            repo.Add(MikeAbyss);

            //READ!
            Character mike = repo.GetCharacterByName("MikeAbyss");

            //UPDATE!
            mike.Name = "Mike";
            repo.Update(mike);

            //DELETE!
            repo.Delete(mike);

            Console.ReadKey();
        }

        public static void LoadNHibernateCfg()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Character).Assembly);
            new SchemaExport(cfg).Execute(true, true, false);
        }

    }
}
