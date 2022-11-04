namespace CodeSense_Models
{
    public class Employee : BaseClass
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public double Cost { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? AvailableUntil { get; set; }

        public override string this[string columnName]
        {
            get
            {

                //
                //  indien de onderstaande condities kloppen
                //  wordt er voor elke property waar deze voorwaardes gelden een error bericht voorzien
                //

                if (columnName == nameof(Name) &&
                    string.IsNullOrEmpty(Name))
                    return "Name is required";
                if (columnName == nameof(Level) &&
                     Level is null)
                    return "Level is required";
                return string.Empty;

            }
        }

        public Employee(string name,
                        Level level,
                        DateTime availableFrom,
                        DateTime? availableUntil = null,
                        double cost = 0,
                        int id = 0)
        {
            Name = name;
            Level = level.Name;
            AvailableFrom = availableFrom;
            AvailableUntil = availableUntil;
            Cost = cost;
            Id = id;
        }

    }

}
