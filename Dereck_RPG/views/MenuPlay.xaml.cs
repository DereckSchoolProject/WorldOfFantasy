﻿using Dereck_RPG.database;
using Dereck_RPG.database.entitieslinks;
using Dereck_RPG.entities;
using Dereck_RPG.viewmodel.playviewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dereck_RPG.views
{
    /// <summary>
    /// Logique d'interaction pour MenuPlay.xaml
    /// </summary>
    public partial class MenuPlay : Page
    {
        private Planetes currentPlanete;
        private Regions currentRegion;
        private Donjon currentDonjon;
        private Player currentPlayer;

        MySQLPlaneteManager planeteManager = new MySQLPlaneteManager();
        MySQLRegionManager regionManager = new MySQLRegionManager();
        MySQLDonjonManager donjonManager = new MySQLDonjonManager();
        MySQLManager<Player> playerManager = new MySQLManager<Player>();

        ObservableCollection<Planetes> planeteList = new ObservableCollection<Planetes>();
        ObservableCollection<Regions> regionList = new ObservableCollection<Regions>();
        ObservableCollection<Donjon> donjonList = new ObservableCollection<Donjon>();
        ObservableCollection<Player> playerList = new ObservableCollection<Player>();



        public MenuPlay()
        {
            InitializeComponent();
            this.DataContext = new PlanetePlayVM(this);
            InitLists();
        }

        private async void InitLists()
        {
            MySQLManager<Planetes> planetesManager = new MySQLManager<Planetes>();
            this.ListPlaneteUC.LoadItems((await planetesManager.Get()).ToList());

            MySQLManager<Regions> regionManager = new MySQLManager<Regions>();
            this.ListRegionUC.LoadItems((await regionManager.Get()).ToList());

            MySQLManager<Donjon> donjonManager = new MySQLManager<Donjon>();
            this.ListDonjonUC.LoadItems((await donjonManager.Get()).ToList());

            MySQLManager<Player> playerManager = new MySQLManager<Player>();
            this.ListPlayerUC.LoadItems((await playerManager.Get()).ToList());

        }

        private void InitActions()
        {
            this.ListPlaneteUC.ItemsList.SelectionChanged += PlaneteList_SelectionChanged;
            this.ListRegionUC.ItemsList.SelectionChanged += RegionList_SelectionChanged;
            this.ListDonjonUC.ItemsList.SelectionChanged += DonjonList_SelectionChanged;
            this.ListPlayerUC.ItemsList.SelectionChanged += PlayerList_SelectionChanged;
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            /*
            Page page = new Page();
            NavigationService.Navigate(new DonjonAdmin());
            */
        }

        private void InitLUCPlanete()
        {
            planeteManager.GetRegion(currentPlanete);
            regionManager.GetDonjon(currentRegion);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).Close();

        }


        #region SelectionChange
        private void PlaneteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Planetes item = (e.AddedItems[0] as Planetes);
                this.currentPlanete = item;
            }
        }

        private void RegionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Regions item = (e.AddedItems[0] as Regions);
                this.currentRegion = item;
            }
        }
        private void DonjonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Donjon item = (e.AddedItems[0] as Donjon);
                this.currentDonjon = item;
            }
        }
        private void PlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems.Count > 0)
                {
                    Player item = (e.AddedItems[0] as Player);
                    this.currentPlayer = item;
                }
            }
        }
        #endregion

    }
}
