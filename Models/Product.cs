namespace RestSharpAutomationExerciseSite.Models
{
    public class Product
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? price { get; set; }
        public string? brand { get; set; }
        public Category? category { get; set; }
    }
}
