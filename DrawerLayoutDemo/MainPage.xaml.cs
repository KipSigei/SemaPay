﻿using DrawerLayoutDemo;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DrawerLayoutWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DrawerLayout.InitializeDrawerLayout();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.BackKeyPress += MainPage_BackKeyPress;
        }

        private void DrawerIcon_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
                DrawerLayout.CloseDrawer();
            else
                DrawerLayout.OpenDrawer();
        }

        private void Item_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var grid = sender as Grid;
            if (grid != null)
            {
                string menuItemName = grid.Name;
                //MessageBox dialog = null;

                switch (menuItemName)
                {
                    case "Item1":
                        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
                        break;

                    case "Item2":
                        NavigationService.Navigate(new Uri("/sendmoney.xaml", UriKind.Relative));
                        break;

                    case "Item3":
                        NavigationService.Navigate(new Uri("/payabill.xaml", UriKind.Relative));
                        break;

                    case "Item4":
                        MessageBox.Show("Eat my shorts!");
                        break;

                    case "Item9":
                        NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.RelativeOrAbsolute));
                        break;
                }
            }
        }

        private void MainPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            if (DrawerLayout.IsDrawerOpen)
            {
                DrawerLayout.CloseDrawer();
                e.Cancel = true;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/sendmoney.xaml",UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/payabill.xaml", UriKind.Relative));
        }
    }
}