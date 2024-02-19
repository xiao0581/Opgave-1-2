namespace BeersRepositoryLib
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Abv { get; set; }


        public void validateName()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }
            if (Name.Length < 3)
            {
                throw new ArgumentException("Name must be at least 3 characters long");
            }

        }
        public void validateAbv()
        {
            if (Abv <= 0 || Abv >= 67)
            {
                throw new ArgumentOutOfRangeException("Abv must be between 0 and 67");
            }
        }

        public override string? ToString() =>
            $"Id: {Id}, Name: {Name}, Abv: {Abv}";
    }
}
