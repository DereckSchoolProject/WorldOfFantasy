﻿using ClassLibrary2.Entities.Generator;
using Dereck_RPG.entities;
using Dereck_RPG.entities.json;
using Dereck_RPG.logger;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Dereck_RPG.database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        const int genernumber = 10;

        public DbSet<Player> playerTable { get; set; }
        public DbSet<Monster> monsterTable { get; set; }

        public DbSet<Donjon> donjonTable { get; set; }
        public DbSet<Items> itemsTable { get; set; }
        public DbSet<Planetes> planetesTable { get; set; }
        public DbSet<Regions> regionsTable { get; set; }
        public DbSet<Stats> statsTable { get; set; }
        

        Logger logger = new Logger("MySQLFullDB", LogMode.CURRENT_FOLDER, AlertMode.CONSOLE, "MYSQL", true);


        public MySQLFullDB()
            : base(JsonManager.Instance.ReadFile<ConnectionString>(@"..\..\..\jsonconfig\", @"MysqlConfig.json").ToString())
        {
            InitLocalMySQL();
        }

        public void InitLocalMySQL()
        {
            if (this.Database.CreateIfNotExists())
            {
                EntityGenerator<Planetes> generatorPlanete = new EntityGenerator<Planetes>();
                for (int i = 0; i < genernumber; i++)
                {
                    planetesTable.Add(generatorPlanete.GenerateItem());
                    logger.Log("Initalisation Planete:" + i);
                }

                EntityGenerator<Regions> generatorRegions = new EntityGenerator<Regions>();
                for (int i = 0; i < genernumber; i++)
                {
                    regionsTable.Add(generatorRegions.GenerateItem());
                    logger.Log("Initalisation Regions:" + i);
                }
                this.SaveChangesAsync();

                EntityGenerator<Donjon> generatorDonjon = new EntityGenerator<Donjon>();
                for (int i = 0; i < genernumber; i++)
                {
                    donjonTable.Add(generatorDonjon.GenerateItem());
                    logger.Log("Initalisation Donjon:" + i);
                }

                EntityGenerator<Items> generatorItems = new EntityGenerator<Items>();
                for (int i = 0; i < genernumber; i++)
                {
                    itemsTable.Add(generatorItems.GenerateItem());
                    logger.Log("Initalisation Items:" + i);
                }
                this.SaveChangesAsync();

                GenerateMonster();
                this.SaveChangesAsync();

                GeneratePlayer();
                this.SaveChangesAsync();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }





        #region GenerateDefaultMonster
       public void GenerateMonster()
        {
            for (int i = 0; i < 20; i++)
            {
                Monster monster = new Monster();
                monster.Name = "Orc Mal Lecher";
                GenRandomMonster(monster);
                GenStatsMonster(monster);
                monster.MonsterRace = entities.enums.MonsterRace.ORC;
                monsterTable.Add(monster);
            }

            for (int i = 0; i < 20; i++)
            {
                Monster monster = new Monster();
                monster.Name = "Gob";
                GenRandomMonster(monster);
                GenStatsMonster(monster);
                monster.MonsterRace = entities.enums.MonsterRace.GOBLIN;
                monsterTable.Add(monster);
            }

            for (int i = 0; i < 20; i++)
            {
                Monster monster = new Monster();
                monster.Name = "Tas d'os";
                GenRandomMonster(monster);
                GenStatsMonster(monster);
                monster.MonsterRace = entities.enums.MonsterRace.SQUELETTE;
                monsterTable.Add(monster);
            }

            for (int i = 0; i < 20; i++)
            {
                Monster monster = new Monster();
                monster.Name = "Rodeur";
                GenRandomMonster(monster);
                GenStatsMonster(monster);
                monster.MonsterRace = entities.enums.MonsterRace.ZOMBIE;
                monsterTable.Add(monster);
            }
        }

        public void GenStatsMonster(Monster monster)
        {
            Stats stat = new Stats();
            monster.Stats = stat.GenRandomStats();
        }

        public void GenRandomMonster(Monster monster)
        {
            Random rnd = new Random();
            monster.Lvl = rnd.Next(1, 20);
            monster.Vie = rnd.Next((1 * monster.Lvl), (100 * monster.Lvl)) * 75;
        }

        #endregion



        #region GenerateDefaultPlayer
        public void GeneratePlayer()
        {
            Player player = new Player();
            player.Name = "Zoya";
            GenRandomPlayer(player);
            GenStatsPlayer(player);
            player.Classe = entities.enums.Classe.ARCHER;
            player.Race = entities.enums.Race.ELFE;
            playerTable.Add(player);

            Player player1 = new Player();
            player1.Name = "Conan";
            GenRandomPlayer(player1);
            GenStatsPlayer(player1);
            player1.Classe = entities.enums.Classe.BARBARE;
            player1.Race = entities.enums.Race.NAIN;
            playerTable.Add(player1);

            Player player2 = new Player();
            player2.Name = "Sparadrap";
            GenRandomPlayer(player2);
            GenStatsPlayer(player2);
            player2.Classe = entities.enums.Classe.PRETRE;
            player2.Race = entities.enums.Race.HUMAIN;
            playerTable.Add(player2);

            Player player3 = new Player();
            player3.Name = "Amadeus";
            GenRandomPlayer(player3);
            GenStatsPlayer(player3);
            player3.Classe = entities.enums.Classe.SORCIER;
            player3.Race = entities.enums.Race.LAPOURS;
            playerTable.Add(player3);

            Player player4 = new Player();
            player4.Name = "Pontius";
            GenRandomPlayer(player4);
            GenStatsPlayer(player4);
            player4.Classe = entities.enums.Classe.TEMPLIER;
            player4.Race = entities.enums.Race.PANDICORNE;
            playerTable.Add(player4);

        }

        public void GenStatsPlayer(Player player)
        {
            Stats stat = new Stats();
            player.Stats = stat.GenRandomStats();
        }

        public void GenRandomPlayer(Player player)
        {
            Random rnd = new Random();
            player.Lvl = rnd.Next(1, 20);
            player.Vie = rnd.Next((1 * player.Lvl), (100 * player.Lvl)) * 100;
        }

        #endregion



    }
}
