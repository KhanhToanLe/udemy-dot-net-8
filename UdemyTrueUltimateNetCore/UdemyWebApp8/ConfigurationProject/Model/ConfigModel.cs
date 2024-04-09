namespace ConfigurationProject.Model
{
    public class ConfigModel
    {
        public ConfigModel(string? name, int? timeOutNumber)
        {
            Name = name;
            TimeOutNumber = timeOutNumber;
        }
        public ConfigModel(){}

        public string? Name { get; set; }
        public int? TimeOutNumber { get; set; }
        public override string ToString()
        {
            return $"{Name} & {TimeOutNumber}";
        }
    }

}
