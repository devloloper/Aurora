namespace Aurora.Profiles.GTASanAndreas
{
    public class PointerData
    {
        public int baseAddress { get; set; }
        public int[] pointers { get; set; }
    }

    public class GTASanAndreasPointers
    {
        public PointerData MaxHealth { get; set; }
        public PointerData Health { get; set; }
        public PointerData MaxArmor { get; set; }
        public PointerData Armor { get; set; }
        public PointerData WantedLevel { get; set; }
    }
}
