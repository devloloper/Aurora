using System.Drawing;
using System.Windows.Controls;
using Aurora.EffectsEngine;
using Aurora.Profiles.GTASanAndreas.GSI;
using Aurora.Settings.Layers;
using Newtonsoft.Json;

namespace Aurora.Profiles.GTASanAndreas.Layers
{
    public class GTASanAndreasBackgroundLayerHandlerProperties : LayerHandlerProperties2Color<GTASanAndreasBackgroundLayerHandlerProperties>
    {
        public Color? _DefaultColor { get; set; }

        [JsonIgnore]
        public Color DefaultColor => Logic._DefaultColor ?? _DefaultColor ?? Color.Empty;

        public GTASanAndreasBackgroundLayerHandlerProperties()
        { }

        public GTASanAndreasBackgroundLayerHandlerProperties(bool assignDefault = false) : base(assignDefault) { }

        public override void Default()
        {
            base.Default();

            _DefaultColor = Color.Coral;
        }

    }

    public class GTASanAndreasBackgroundLayerHandler : LayerHandler<GTASanAndreasBackgroundLayerHandlerProperties>
    {
        public GTASanAndreasBackgroundLayerHandler()
        {
            _ID = "GTASanAndreasBackground";
        }

        protected override UserControl CreateControl()
        {
            return new Control_GTASanAndreasBackgroundLayer(this);
        }

        public override EffectLayer Render(IGameState state)
        {
            var bgLayer = new EffectLayer("GTA San Andreas - Background");

            if (state is GTASanAndreasGameState rlstate)
            {
                bgLayer.Fill(Properties.DefaultColor);
//                switch (rlstate.Player.Team)
//                {
//                    case PlayerTeam.Blue:
//                        bgLayer.Fill(Properties.BlueColor);
//                        break;
//                    case PlayerTeam.Orange:
//                        bgLayer.Fill(Properties.OrangeColor);
//                        break;
//                    default:
//                        bgLayer.Fill(Properties.DefaultColor);
//                        break;
//                }

//                if (Properties.ShowTeamScoreSplit)
//                {
//
//                    if (rlstate.Match.BlueTeam_Score != 0 || rlstate.Match.OrangeTeam_Score != 0)
//                    {
//                        int total_score = rlstate.Match.BlueTeam_Score + rlstate.Match.OrangeTeam_Score;
//
//
//                        LinearGradientBrush the__split_brush =  new LinearGradientBrush(
//                                new Point(0, 0),
//                                new Point(Effects.canvas_biggest, 0),
//                                Color.Red, Color.Red);
//                        Color[] colors = new Color[]
//                        {
//                                Properties.OrangeColor, //Orange //Team 1
//                                Properties.OrangeColor, //Orange "Line"
//                                Properties.BlueColor, //Blue "Line" //Team 2
//                                Properties.BlueColor  //Blue
//                        };
//                        int num_colors = colors.Length;
//                        float[] blend_positions = new float[num_colors];
//
//                        if (rlstate.Match.OrangeTeam_Score > rlstate.Match.BlueTeam_Score)
//                        {
//                            blend_positions[0] = 0.0f;
//                            blend_positions[1] = ((float)rlstate.Match.OrangeTeam_Score / (float)total_score) - 0.01f;
//                            blend_positions[2] = ((float)rlstate.Match.OrangeTeam_Score / (float)total_score) + 0.01f;
//                            blend_positions[3] = 1.0f;
//                        }
//                        else if (rlstate.Match.OrangeTeam_Score < rlstate.Match.BlueTeam_Score)
//                        {
//                            blend_positions[0] = 0.0f;
//                            blend_positions[1] = (1.0f - ((float)rlstate.Match.BlueTeam_Score / (float)total_score)) - 0.01f;
//                            blend_positions[2] = (1.0f - ((float)rlstate.Match.BlueTeam_Score / (float)total_score)) + 0.01f;
//                            blend_positions[3] = 1.0f;
//                        }
//                        else
//                        {
//                            blend_positions[0] = 0.0f;
//                            blend_positions[1] = 0.49f;
//                            blend_positions[2] = 0.51f;
//                            blend_positions[3] = 1.0f;
//                        }
//
//                        ColorBlend color_blend = new ColorBlend();
//                        color_blend.Colors = colors;
//                        color_blend.Positions = blend_positions;
//                        the__split_brush.InterpolationColors = color_blend;
//
//                        bgLayer.Fill(the__split_brush);
//                    }
//                }
            }
            return bgLayer;
        }

        public override void SetApplication(Application profile)
        {
            (Control as Control_GTASanAndreasBackgroundLayer)?.SetProfile(profile);
            base.SetApplication(profile);
        }
    }
}