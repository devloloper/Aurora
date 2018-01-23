using System.Linq;
using System.Windows;
using System.Windows.Media;
using Aurora.Utils;
using Xceed.Wpf.Toolkit;

namespace Aurora.Profiles.GTASanAndreas.Layers
{
    /// <summary>
    ///     Interaction logic for Control_GTASanAndreasBackgroundLayer.xaml
    /// </summary>
    public partial class Control_GTASanAndreasBackgroundLayer
    {
        private bool _profileset;
        private bool _settingsset;

        public Control_GTASanAndreasBackgroundLayer()
        {
            InitializeComponent();
        }

        public Control_GTASanAndreasBackgroundLayer(GTASanAndreasBackgroundLayerHandler datacontext)
        {
            InitializeComponent();

            DataContext = datacontext;
        }

        public void SetSettings()
        {
            if (DataContext is GTASanAndreasBackgroundLayerHandler && !_settingsset)
            {
                ColorPicker_Default.SelectedColor = ColorUtils.DrawingColorToMediaColor(
                    (DataContext as GTASanAndreasBackgroundLayerHandler).Properties._DefaultColor ??
                    System.Drawing.Color.Empty);

                _settingsset = true;
            }
        }

        internal void SetProfile(Application profile)
        {
            if (profile != null && !_profileset)
            {
                var varTypesNumerical =
                    profile.ParameterLookup?.Where(kvp => TypeUtils.IsNumericType(kvp.Value.Item1));

                _profileset = true;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetSettings();

            Loaded -= UserControl_Loaded;
        }

        private void ColorPicker_Default_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (IsLoaded && _settingsset && DataContext is GTASanAndreasBackgroundLayerHandler &&
                sender is ColorPicker && (sender as ColorPicker).SelectedColor.HasValue)
            {
                ((GTASanAndreasBackgroundLayerHandler) DataContext).Properties._DefaultColor =
                    ColorUtils.MediaColorToDrawingColor((sender as ColorPicker).SelectedColor.Value);
            }
        }
    }
}