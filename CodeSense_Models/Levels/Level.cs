namespace CodeSense_Models
{
    public class Level
    {
        //
        //  Dit is een Super klasse waar alle andere Levels hiervan overerven
        //  Inclusief Levels uit verschillende departement
        //
        public virtual string Name { get; set; }
        public enum DepartmentType
        {
            IT,
            Management,
            Business
        }
        public Level()
        {
            Name = this.GetType().Name;
        }
    }
}
