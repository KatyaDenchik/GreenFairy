using GreenFairy.DomainLayer.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFairy.Data.Models
{
    public class PlantModel
    {
        public OrderedPlantEntity OrderedPlant;

        public double Cost => OrderedPlant.Amount * OrderedPlant.Plant.Price;

        public int MaxCount;
    }
}
