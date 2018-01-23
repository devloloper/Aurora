using System.Collections.Generic;
using Aurora.Profiles.GTASanAndreas.GSI;
using Aurora.Profiles.GTASanAndreas.Layers;

namespace Aurora.Profiles.GTASanAndreas
{
    public class GTASanAndreas : Application
    {
        public GTASanAndreas()
            : base(new LightEventConfig
            {
                Name = "GTA San Andreas",
                ID = "gtasanandreas",
                ProcessNames = new[] {"gta-sa.exe"},
                ProfileType = typeof(GTASanAndreasProfile),
                OverviewControlType = typeof(Control_GTASanAndreas),
                GameStateType = typeof(GTASanAndreasGameState),
                Event = new GTASanAndreasGameEvent(),
                IconURI = "Resources/gta_sa_256x256.png"
            })
        {
            var extra = new List<LayerHandlerEntry>
            {
                new LayerHandlerEntry("GTASanAndreasBackground", "GTA San Andreas Background Layer",
                    typeof(GTASanAndreasBackgroundLayerHandler)),
                new LayerHandlerEntry("GTASanAndreasPoliceSiren", "GTA San Andreas Police Siren Layer",
                    typeof(GTASanAndreasPoliceSirenLayerHandler))
            };

            Global.LightingStateManager.RegisterLayerHandlers(extra, false);

            foreach (var entry in extra)
                Config.ExtraAvailableLayers.Add(entry.Key);
        }
    }
}