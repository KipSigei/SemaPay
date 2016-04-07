using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DrawerLayoutDemo
{
    public partial class receiverdetails : PhoneApplicationPage
    {
        public receiverdetails()
        {
            InitializeComponent();
            DrawerLayout.InitializeDrawerLayout();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.BackKeyPress += MainPage_BackKeyPress;
        }

        private void ShowFlyoutPopup(object sender, RoutedEventArgs e)
        {
            if (!logincontrol1.IsOpen)
            {
                //RootPopupBorder.Width = 446;
                logincontrol1.HorizontalOffset = Application.Current.Host.Content.ActualWidth - 480;
                logincontrol1.VerticalOffset = Application.Current.Host.Content.ActualHeight - 798;
                logincontrol1.IsOpen = true;
            }

            
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (logincontrol1.IsOpen)
            {
                logincontrol1.IsOpen = false;
                e.Cancel = true;
            }

            base.OnBackKeyPress(e);
        }
        private void MainPage_BackKeyPress(object sender, CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            if (DrawerLayout.IsDrawerOpen)
            {
                DrawerLayout.CloseDrawer();
                e.Cancel = true;
            }

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
                        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
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
                }
            }
        }
    }
}