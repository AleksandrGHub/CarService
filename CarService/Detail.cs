namespace CarService
{
    class Detail
    {
        public Detail(string name, int cost, int costReplace, bool isBroken)
        {
            Name = name;
            Cost = cost;
            CostReplace = costReplace;
            IsBroken = isBroken;
        }

        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int CostReplace { get; private set; }
        public bool IsBroken { get; private set; }

        public Detail Clone(bool isBroken)
        {
            return new Detail(Name, Cost, CostReplace, isBroken);
        }
    }
}