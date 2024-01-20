namespace CarService
{
    class Checklist
    {
        public Checklist(Client client)
        {
            NameDetail = client.Car.Detail.Name;
            TotalCost = client.Car.Detail.Cost + client.Car.Detail.CostReplace;
        }

        public string NameDetail { get; private set; }
        public int TotalCost { get; private set; }
    }
}