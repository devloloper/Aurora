namespace Aurora.Profiles.GTASanAndreas.GSI.Nodes
{
    /// <summary>
    /// Class representing player information
    /// </summary>
    public class Player : Node<Player>
    {
        public float MaxHealth = 0.0f;
        public float MaxArmor = 100.0f;
        public float Armor = 0.0f;
        public float Health = 0.0f;
        public int WantedLevel = 0;

        internal Player(string jsonData) : base(jsonData)
        {
        }
    }
}
