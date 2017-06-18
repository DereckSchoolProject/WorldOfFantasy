﻿using System;
using System.Collections.Generic;
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
using Dereck_RPG.entities;
using Dereck_RPG.viewmodel.playviewmodel;

namespace Dereck_RPG.views.administration.playadmin
{
    /// <summary>
    /// Logique d'interaction pour CombatAdmin.xaml
    /// </summary>
    public partial class CombatAdmin : Page
    {
        private Monster currentMonster;
        private Player currentPlayer;

        public CombatAdmin()
        {
            InitializeComponent();
            this.DataContext = new CombatAdminVM(this);
        }

        public CombatAdmin(Player currentPlayer, Monster currentMonster)
        {
            this.currentPlayer = currentPlayer;
            this.currentMonster = currentMonster;
            this.DataContext = new CombatAdminVM(this, currentPlayer, currentMonster);
            InitializeComponent();
        }
    }
}
