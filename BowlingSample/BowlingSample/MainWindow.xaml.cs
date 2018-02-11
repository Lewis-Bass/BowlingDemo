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

namespace BowlingSample
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region properties

        public ViewModel.GameEntryVM Games { get; private set; }

        #endregion

        #region constructor
        public MainWindow()
        {
            InitializeComponent();
            Games = new ViewModel.GameEntryVM();
            PlayGames.DataContext = Games;
        }

        #endregion
    }
}
