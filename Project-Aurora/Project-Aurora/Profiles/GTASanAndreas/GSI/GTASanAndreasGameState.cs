using System.ComponentModel;
using System.Drawing;
using Aurora.Profiles.GTASanAndreas.GSI.Nodes;

namespace Aurora.Profiles.GTASanAndreas.GSI
{
    /// <summary>
    /// Enum of various player states
    /// </summary>
    public enum PlayerState
    {
        /// <summary>
        /// Undefined
        /// </summary>
        [Description("Undefined")]
        Undefined,

        /// <summary>
        /// Player is in a menu
        /// </summary>
        [Description("Menu")]
        Menu,

        /// <summary>
        /// Player is playing Single player
        /// </summary>
        [Description("Singleplayer")]
        PlayingSinglePlayer,

        /// <summary>
        /// Player is in a race, in first position
        /// </summary>
        [Description("Race - Platinum")]
        PlayingRace_Platinum,

        /// <summary>
        /// Player is in a race, in second position
        /// </summary>
        [Description("Race - Gold")]
        PlayingRace_Gold,

        /// <summary>
        /// Player is in a race, in third position
        /// </summary>
        [Description("Race - Silver")]
        PlayingRace_Silver,

        /// <summary>
        /// Player is in a race, in fourth or lower position
        /// </summary>
        [Description("Race - Bronze")]
        PlayingRace_Bronze,
    }

    /// <summary>
    /// A class representing various information relating to GTA San Andreas
    /// </summary>
    public class GTASanAndreasGameState : GameState<GTASanAndreasGameState>
    {
        /// <summary>
        /// The current left siren color (Keys F1 - F6)
        /// </summary>
        public Color LeftSirenColor;

        /// <summary>
        /// The current right siren color (Keys F7 - F12)
        /// </summary>
        public Color RightSirenColor;

        private Player _player;

        /// <summary>
        /// Information about the local player
        /// </summary>
        public Player Player => _player ?? (_player = new Player(""));

        /// <inheritdoc />
        /// <summary>
        /// Creates a default GTASanAndreasGameState instance.
        /// </summary>
        public GTASanAndreasGameState()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a GameState instance based on the passed json data.
        /// </summary>
        /// <param name="jsonData">The passed json data</param>
        public GTASanAndreasGameState(string jsonData) : base(jsonData)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// A copy constructor, creates a GTASanAndreasGameState instance based on the data from the passed GameState instance.
        /// </summary>
        /// <param name="otherState">The passed GameState</param>
        public GTASanAndreasGameState(IGameState otherState) : base(otherState)
        {
        }
    }
}
