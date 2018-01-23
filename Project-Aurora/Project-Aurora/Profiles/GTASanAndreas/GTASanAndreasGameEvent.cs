using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Aurora.EffectsEngine;
using Aurora.Profiles.GTASanAndreas.GSI;
using Aurora.Utils;

namespace Aurora.Profiles.GTASanAndreas
{
    public class GTASanAndreasGameEvent : LightEvent
    {
        private bool _isInitialized;

        //Pointers
        private GTASanAndreasPointers _pointers;

        public GTASanAndreasGameEvent() : base()
        {
            _isInitialized = true;
//            var watcher = new FileSystemWatcher {Path = Path.Combine(Global.ExecutingDirectory, "Pointers")};
//            watcher.Changed += PointersChanged;
//            watcher.EnableRaisingEvents = true;
//
//            ReloadPointers();
        }

//        private void PointersChanged(object sender, FileSystemEventArgs e)
//        {
//            if (e.Name.Equals("GTASanAndreas.json") && e.ChangeType == WatcherChangeTypes.Changed)
//                ReloadPointers();
//        }

//        private void ReloadPointers()
//        {
//            var path = Path.Combine(Global.ExecutingDirectory, "Pointers", "GTASanAndreas.json");
//
//            if (File.Exists(path))
//            {
//                try
//                {
//                    // deserialize JSON directly from a file
//                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
//                    using (var sr = new StreamReader(fs, System.Text.Encoding.Default))
//                    {
//                        var serializer = new JsonSerializer();
//                        _pointers = (GTASanAndreasPointers)serializer.Deserialize(sr, typeof(GTASanAndreasPointers));
//                    }
//                }
//                catch (Exception exc)
//                {
//                    Global.logger.Error(exc.Message);
//                    _isInitialized = false;
//                }
//
//                _isInitialized = true;
//            }
//            else
//            {
//                _isInitialized = false;
//            }
//        }

        public override void ResetGameState()
        {
            _game_state = new GTASanAndreasGameState();
        }

        public new bool IsEnabled => Application.Settings.IsEnabled && _isInitialized;

        public override void UpdateLights(EffectFrame frame)
        {

            var layers = new Queue<EffectLayer>();

            var settings = (GTASanAndreasProfile)Application.Profile;

            var processSearch = Process.GetProcessesByName("gta-sa");

            if (processSearch.Length != 0)
            {
                var process = processSearch.FirstOrDefault(c => c.BasePriority == 13);
                // TODO Does it always find 2 gta-sa? What is the first find? Probably the launcher where you select resolution
                if (process != null)
                {
                    using (var memread = new MemoryReader(process))
                    {
//                    PlayerTeam parsed_team = PlayerTeam.Undefined;
//                    if(Enum.TryParse<PlayerTeam>(memread.ReadInt(_pointers.Team.baseAddress, _pointers.Team.pointers).ToString(), out parsed_team))
//                        (_game_state as GameState_RocketLeague).Player.Team = parsed_team;
                        if (_game_state is GTASanAndreasGameState gs)
                        {
                            //const int address = 0x76F3B8;
                            // TODO Add addresses for v2.0 and v3.0
                            const int address = 0xB6F5F0;
                            var pedPointer = memread.ReadInt((IntPtr) address);
                            var healthPointer = pedPointer + 0x540;
                            var maxHealthPointer = pedPointer + 0x544;
                            var armorPointer = pedPointer + 0x548;
                            const int wantedPointer = 0xBAA420;
                            gs.Player.MaxHealth = memread.ReadFloat((IntPtr) maxHealthPointer);
                            gs.Player.Health = memread.ReadFloat((IntPtr) healthPointer);
                            gs.Player.Armor = memread.ReadFloat((IntPtr) armorPointer);
                            //gs.Player.Armor = memread.ReadFloat(_pointers.Armor.baseAddress, _pointers.Armor.pointers);
                            gs.Player.WantedLevel = memread.ReadInt((IntPtr) wantedPointer);
                        }

                    }
                }
            }

            foreach (var layer in Application.Profile.Layers.Reverse().ToArray())
            {
                if (layer.Enabled && layer.LogicPass)
                {
                    layers.Enqueue(layer.Render(_game_state));
                }
            }

            //Scripts
            Application.UpdateEffectScripts(layers);

            frame.AddLayers(layers.ToArray());
        }

        public override void SetGameState(IGameState new_game_state)
        {
//            UpdateLights(frame);
        }
    }
}
