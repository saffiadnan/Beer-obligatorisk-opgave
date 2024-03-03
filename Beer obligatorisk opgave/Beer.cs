namespace Beer_obligatorisk_opgave
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Abv { get; set; }

        public override string ToString()
        {
            return $"Beer ID: {Id}, Name: {Name}, ABV: {Abv}%";
        }

        public void ValidateName()
        {
            {
                if (Name is null)
                {
                    throw new ArgumentException("Name må ikke null.");
                }
                if (Name.Length < 3)
                {
                    throw new ArgumentException("Name skal være mindst 3 karakterer lang.", (Name));
                }

            }
        }

        public void ValidateAbv()
        {
            if (Abv < 0 || Abv > 67)
            {
                throw new ArgumentOutOfRangeException(nameof(Abv), "ABV skal være mellem 0 og 67.");
            }
        }

    }
}
