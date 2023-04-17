using GreenFairy.DomainLayer.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFairy.Data.Helpers
{
    public static class PlantHelper
    {
        public static List<OrderedPlantEntity> Plants { get; set;} = new ();
        private static List<OrderedPlantEntity> sortPlant = new ();
        public static List<OrderedPlantEntity> SortPlants 
        { 
            get => sortPlant;
            set { sortPlant = value; SortPlantsUpdate?.Invoke(); } } 
        public static event Action SortPlantsUpdate;

    }
}
