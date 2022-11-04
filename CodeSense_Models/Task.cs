namespace CodeSense_Models
{
    public class Task : BaseClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
        private double _profit;

        public double Profit
        {
            get { return _profit; }
            set
            {
                if (value < 0)
                    _profit = 0;

                else
                    _profit = value;

            }
        }

        public DateTime Deadline { get; set; }



        public List<Requirement> Requirements { get; set; }

        public override string this[string columnName]
        {
            get
            {
                //
                //  indien de onderstaande condities kloppen
                //  wordt er voor elke property waar deze voorwaardes gelden een error bericht voorzien
                //

                if (columnName == nameof(Deadline) &&
                    Deadline.Date < DateTime.Now)
                    return "Date should be in future";
                return string.Empty;

            }
        }
    }

}
