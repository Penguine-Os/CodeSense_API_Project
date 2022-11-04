namespace CodeSense_Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public int Amount { get; set; }

        public Requirement(int id, int amount, Level level)
        {
            Id = id;
            Amount = amount;
            Level = level.Name;
        }
    }

}
