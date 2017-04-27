namespace ObjectDataBase
{
    class Address
    {

        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public Address(string Street, string PostalCode, string City)
        {
            this.Street = Street;
            this.PostalCode = PostalCode;
            this.City = City;
        }

    }
}
