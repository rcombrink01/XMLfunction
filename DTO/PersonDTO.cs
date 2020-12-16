namespace XMLFunction
{
    //We Create a DTO to avoid exposing the entire entity.
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
    }
}
