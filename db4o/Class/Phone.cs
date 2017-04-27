namespace ObjectDataBase
{
    class Phone
    {

        public string Number { get; set; }
        public string Operator { get; set; }
        public string PhoneType { get; set; }

        public Phone(string Number, string Operator, string PhoneType)
        {
            this.Number = Number;
            this.Operator = Operator;
            this.PhoneType = PhoneType;
        }

    }
}
