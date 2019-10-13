using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; private set; }

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }
        public List<TypePlane> GetPlanes<TypePlane>() where TypePlane:Plane
        {
            List<TypePlane> planes = new List<TypePlane>();
            foreach(var plane in Planes)
            {
                if (plane is TypePlane)
                    planes.Add((TypePlane)plane);
            }
            return planes;
        }
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPlanes<PassengerPlane>().Aggregate((currentPlane, nextPlane) => currentPlane.PassengersCapacity > nextPlane.PassengersCapacity ? currentPlane : nextPlane);             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetPlanes<MilitaryPlane>().Where(militaryPlane=>militaryPlane.PlaneType==MilitaryType.TRANSPORT).ToList() ;
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxLoadCapacity));
        }
        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(plane => plane.PlaneModel)) +
                    '}';
        }
    }
}
