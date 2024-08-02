﻿//Codebehind for the app shell
//Contains routing information for all of the
//pages that the user can navigate to via the flyout
//navigation bar

namespace Green_Light
{    
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(SummaryPage), typeof(SummaryPage));
            Routing.RegisterRoute(nameof(DatabasePage), typeof(DatabasePage));
            Routing.RegisterRoute(nameof(ConditionsPage), typeof(ConditionsPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}
