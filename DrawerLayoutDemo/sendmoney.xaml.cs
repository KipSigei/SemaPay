using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System;

namespace DrawerLayoutDemo
{
    public partial class sendmoney : PhoneApplicationPage
    {
        public sendmoney()
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
            NavigationService.Navigate(new Uri("/receiverdetails.xaml", UriKind.Relative));
        }
    }
}