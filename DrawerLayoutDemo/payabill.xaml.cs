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
    public partial class payabill : PhoneApplicationPage
    {
        List<string> strings = new List<string>() { "School Fees", "Power", "Buy Power Tokens", "Water", "Buy Goods", "Others" };
        public payabill()
        {
            InitializeComponent();
            DrawerLayout.InitializeDrawerLayout();
            

            
        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.BackKeyPress += MainPage_BackKeyPress;
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

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}