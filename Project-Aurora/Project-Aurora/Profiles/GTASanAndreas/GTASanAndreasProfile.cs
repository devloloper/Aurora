using System.Collections.ObjectModel;
using System.Drawing;
using Aurora.Devices;
using Aurora.EffectsEngine;
using Aurora.Profiles.GTASanAndreas.Layers;
using Aurora.Settings;
using Aurora.Settings.Layers;

namespace Aurora.Profiles.GTASanAndreas
{
    public class GTASanAndreasProfile : ApplicationProfile
    {
        public override void Reset()
        {
            base.Reset();
            Layers = new ObservableCollection<Layer>
            {
                new Layer("Health Indicator", new PercentLayerHandler
                {
                    Properties = new PercentLayerHandlerProperties
                    {
                        _PrimaryColor = Color.Red,
                        _SecondaryColor = Color.DarkRed,
                        _PercentType = PercentEffectType.Progressive_Gradual,
                        _Sequence = new KeySequence(new[]
                        {
                            DeviceKeys.ONE, DeviceKeys.TWO, DeviceKeys.THREE, DeviceKeys.FOUR, DeviceKeys.FIVE,
                            DeviceKeys.SIX, DeviceKeys.SEVEN, DeviceKeys.EIGHT, DeviceKeys.NINE, DeviceKeys.ZERO,
                            DeviceKeys.MINUS, DeviceKeys.EQUALS
                        }),
                        _BlinkThreshold = 0.1,
                        _BlinkDirection = false,
                        _VariablePath = "Player/Health",
                        _MaxVariablePath = "Player/MaxHealth"
                    }
                }),
                new Layer("Armor Indicator", new PercentLayerHandler
                {
                    Properties = new PercentLayerHandlerProperties
                    {
                        _PrimaryColor = Color.Azure,
                        _SecondaryColor = Color.Lavender,
                        _PercentType = PercentEffectType.Progressive_Gradual,
                        _Sequence = new KeySequence(new[]
                        {
                            DeviceKeys.F1, DeviceKeys.F2, DeviceKeys.F3, DeviceKeys.F4,
                            DeviceKeys.F5, DeviceKeys.F6, DeviceKeys.F7, DeviceKeys.F8,
                            DeviceKeys.F9, DeviceKeys.F10, DeviceKeys.F11, DeviceKeys.F12
                        }),
                        _BlinkThreshold = 0.0,
                        _BlinkDirection = false,
                        _VariablePath = "Player/Armor",
                        _MaxVariablePath = "Player/MaxArmor"
                    }
                }),
                new Layer("GTA San Andreas Police Siren", new GTASanAndreasPoliceSirenLayerHandler()),
                new Layer("GTA San Andreas Background", new GTASanAndreasBackgroundLayerHandler())
            };
        }
    }
}