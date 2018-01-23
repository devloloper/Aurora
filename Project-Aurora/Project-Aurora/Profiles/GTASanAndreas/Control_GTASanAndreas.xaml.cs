using System;
using System.Windows;

namespace Aurora.Profiles.GTASanAndreas
{
    /// <summary>
    /// Interaction logic for Control_GTASanAndreas.xaml
    /// </summary>
    public partial class Control_GTASanAndreas
    {
        private readonly Application _profileManager;

        public Control_GTASanAndreas(Application profile)
        {
            InitializeComponent();

            _profileManager = profile;

            SetSettings();

            _profileManager.ProfileChanged += Profile_manager_ProfileChanged;
        }

        private void Profile_manager_ProfileChanged(object sender, EventArgs e)
        {
            SetSettings();
        }

        private void SetSettings()
        {
            game_enabled.IsChecked = _profileManager.Settings.IsEnabled;
        }

        private void game_enabled_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                _profileManager.Settings.IsEnabled = game_enabled.IsChecked ?? false;
                _profileManager.SaveProfiles();
            }
        }
    }
}
