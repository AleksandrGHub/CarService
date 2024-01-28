namespace CarService
{
    class Checklist
    {
        public Checklist(Car car)
        {
            NameDetail = car.Detail.Name;
            TotalCost = car.Detail.Cost + car.Detail.CostReplace;
        }

        public string NameDetail { get; private set; }
        public int TotalCost { get; private set; }
    }
}