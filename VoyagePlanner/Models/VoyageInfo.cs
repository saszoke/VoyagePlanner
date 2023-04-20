namespace VoyagePlanner.Models
{
    public class VoyageInfo
    {
        private readonly int _basePrice = 25000;
        private readonly int _personPrice = 45000;
        private readonly int _ferryBaseCost = 22;
        private readonly int _travelTaxPercentage = 12;
        private Destination _destination;
        private TravelType _travelType;
        private List<Person> _persons;
        private List<Extra> _extras;

        public VoyageInfo(Voyage voyage)
        {
            _destination = voyage.Destination;
            _travelType = voyage.TravelType;
            _persons = voyage.Persons;
            _extras = voyage.Extras;
        }

        public VoyageInfo(Destination destination, TravelType travelType, List<Person> persons, List<Extra> extras) {
            _destination = destination;
            _travelType = travelType;
            _persons = persons;
            _extras = extras;
        }

        public Destination GetDestination() { return _destination; }

        public TravelType GetTravelType() {  return _travelType; }
        public List<Person> GetPersons() {  return _persons; }
        public List<Extra> GetExtras() {  return _extras; }

        public int GetTotalCost()
        {
            int totalCost = _basePrice;

            totalCost += this.countPersonsCost(_persons);
            totalCost += this.countExtrasCost(_extras);
            totalCost += this.countTravelCost(_destination, _travelType);

            totalCost = totalCost * (1 + (_travelTaxPercentage / 100));

            return totalCost;
        }

        private int countPersonsCost(List<Person> persons) {
            int personsCost = 0;
            int discountPercentage = 0;

            foreach (Person person in persons) {
                if (person.Allowance.Id == 6) {
                    personsCost += _personPrice;
                } else
                {
                    discountPercentage = person.Allowance.ReductionPercentage;
                    personsCost += (int)(_personPrice * (1 - (discountPercentage / 100.0)));
                }
            }
            return personsCost;
        }

        private int countExtrasCost(List<Extra> extras)
        {
            int extrasCost = 0;

            foreach(Extra extra in extras)
            {
                extrasCost += (int) extra.ExtraDetail.Price * extra.Quantity;
            }

            return extrasCost;
        }

        private int countTravelCost(Destination destination, TravelType travelType)
        {
            int travelCost = 0;
            // We assume that each destination where a ferry is needed, requires to travel 25% of the total distance by ferry.
            if (destination.FerryNeeded)
            {
                int ferryDistance = (int) ((int)travelType.CostPerKilometre * 0.25);
                int ferryCost = ferryDistance * _ferryBaseCost;
            }

            if (travelType.Name != "plane")
            {
                travelCost += (int) (destination.DistanceRoad * travelType.CostPerKilometre);
            } else
            {
                travelCost += (int)(destination.DistancePlane * travelType.CostPerKilometre);
            }

            return travelCost;
        }
    }
}
