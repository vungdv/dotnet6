namespace airproject.domain.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string? City { get; set; }        
        public List<ParameterValue> Parameters { get; set; } = new List<ParameterValue>();
    }
    public class Manufacturer
    {
        public string? ModelName { get; set; }
        public string? ManufacturerName { get; set; }
    }

    public class ParameterValue
    {
        public int Id { get; set; }
        public string? Unit { get; set; }
        public int Count { get; set; }
        public double Average { get; set; }
        public double LastValue { get; set; }
        public string? Parameter { get; set; }
        public string? DisplayName { get; set; }
        public DateTime LastUpdated { get; set; }
        public int ParameterId { get; set; }
        public DateTime FirstUpdated { get; set; }
        public List<Manufacturer>? Manufacturers { get; set; }
    }
}
