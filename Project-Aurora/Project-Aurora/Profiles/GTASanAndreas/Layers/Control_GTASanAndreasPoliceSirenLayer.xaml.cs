using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Aurora.Profiles.GTA5;
using Xceed.Wpf.Toolkit;

namespace Aurora.Profiles.GTASanAndreas.Layers
{
    /// <summary>
    /// Interaction logic for Control_GTASanAndreasPoliceSirenLayer.xaml
    /// </summary>
    public partial class Control_GTASanAndreasPoliceSirenLayer : UserControl
    {
        private bool settingsset = false;
        private bool profileset = false;

        public Control_GTASanAndreasPoliceSirenLayer()
        {
            InitializeComponent();
        }

        public Control_GTASanAndreasPoliceSirenLayer(GTASanAndreasPoliceSirenLayerHandler datacontext)
        {
            InitializeComponent();

            DataContext = datacontext;
        }

        private void SetSettings()
        {
            if (DataContext is GTASanAndreasPoliceSirenLayerHandler handler && !settingsset)
            {
                ColorPicker_LeftSiren.SelectedColor = Utils.ColorUtils.DrawingColorToMediaColor(handler.Properties._LeftSirenColor ?? System.Drawing.Color.Empty);
                ColorPicker_RightSiren.SelectedColor = Utils.ColorUtils.DrawingColorToMediaColor(handler.Properties._RightSirenColor ?? System.Drawing.Color.Empty);
                ComboBox_SirenEffectType.SelectedItem = handler.Properties._SirenType;
                Checkbox_DisplayOnPeripherals.IsChecked = handler.Properties._PeripheralUse;
                KeySequence_LeftSiren.Sequence = handler.Properties._LeftSirenSequence;
                KeySequence_RightSiren.Sequence = handler.Properties._RightSirenSequence;

                settingsset = true;
            }
        }

        internal void SetProfile(Application profile)
        {
            if (profile != null && !profileset)
            {
                var var_types_numerical = profile.ParameterLookup?.Where(kvp => Utils.TypeUtils.IsNumericType(kvp.Value.Item1));

                profileset = true;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetSettings();

            Loaded -= UserControl_Loaded;
        }

        private void ColorPicker_LeftSiren_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (IsLoaded && settingsset && DataContext is GTASanAndreasPoliceSirenLayerHandler && (sender as ColorPicker)?.SelectedColor != null)
                ((GTASanAndreasPoliceSirenLayerHandler) DataContext).Properties._LeftSirenColor = Utils.ColorUtils.MediaColorToDrawingColor((sender as ColorPicker).SelectedColor.Value);
        }

        private void ColorPicker_RightSiren_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (IsLoaded && settingsset && DataContext is GTASanAndreasPoliceSirenLayerHandler && (sender as ColorPicker)?.SelectedColor != null)
                ((GTASanAndreasPoliceSirenLayerHandler) DataContext).Properties._RightSirenColor = Utils.ColorUtils.MediaColorToDrawingColor((sender as ColorPicker).SelectedColor.Value);
        }

        private void Checkbox_DisplayOnPeripherals_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded && settingsset && DataContext is GTASanAndreasPoliceSirenLayerHandler && (sender as CheckBox)?.IsChecked != null)
                ((GTASanAndreasPoliceSirenLayerHandler) DataContext).Properties._PeripheralUse = (sender as CheckBox).IsChecked.Value;
        }

        private void KeySequence_LeftSiren_SequenceUpdated(object sender, EventArgs e)
        {
            if (IsLoaded && settingsset && DataContext is GTASanAndreasPoliceSirenLayerHandler && sender is Controls.KeySequence)
            {
                ((GTASanAndreasPoliceSirenLayerHandler) DataContext).Properties._LeftSirenSequence = ((Controls.KeySequence) sender).Sequence;
            }
        }

        private void KeySequence_RightSiren_SequenceUpdated(object sender, EventArgs e)
        {
            if (IsLoaded && settingsset && DataContext is GTASanAndreasPoliceSirenLayerHandler && sender is Controls.KeySequence)
            {
                ((GTASanAndreasPoliceSirenLayerHandler) DataContext).Properties._RightSirenSequence = ((Controls.KeySequence) sender).Sequence;
            }
        }

        private void ComboBox_SirenEffectType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded && settingsset && DataContext is GTASanAndreasPoliceSirenLayerHandler && sender is ComboBox)
            {
                ((GTASanAndreasPoliceSirenLayerHandler) DataContext).Properties._SirenType = (GTA5_PoliceEffects)Enum.Parse(typeof(GTA5_PoliceEffects), ((ComboBox) sender).SelectedIndex.ToString());
            }
        }
    }
}
