﻿using GreenFairy.Data;
using GreenFairy.DomainLayer.DataBase;
using GreenFairy.DomainLayer.DataBase.Entities;
using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using Prism.Mvvm;
using System.Reflection;

namespace GreenFairy.ViewModels
{
    public class DataBaseView : BindableBase
    {
        public class EntityModel
        {
            public Type Type { get; set; }
            public string Name { get; set; }
        }

        private EntityService entityService;
        private Repository repository;

        public IEnumerable<EntityModel> EntityTypes { get; set; } = new List<EntityModel>
      {
      new EntityModel{Type= typeof(AdminEntity), Name ="Адміни" },
      new EntityModel{Type= typeof(ClientEntity), Name = "Кліенти" },
      new EntityModel{Type= typeof(PlantEntity), Name = "Рослини" },
      new EntityModel{Type= typeof(OrderEntity), Name = "Замовлення"
      }};

        private string tabelName;
        public string TabelName { get { return tabelName; } set { SetProperty(ref tabelName, value); } }
        public Type Type => EntityTypes.First(s => s.Name == TabelName).Type;

        public List<IEntity> Entities;

        public DataBaseView(EntityService entityService, Repository repository)
        {
            this.entityService = entityService;
            this.repository = repository;

            TabelName = EntityTypes.First().Name;

            Entities = entityService.GetEntities(Type).ToList();

            this.PropertyChanged += (a, e) => { Entities = entityService.GetEntities(Type).ToList(); };
        }
        public void Save()
        {
            foreach (var entity in Entities)
            {
                entity.SaveToDB(repository);
            }
        }
        public void Add()
        {
            IEntity entity = (IEntity)Activator.CreateInstance(Type);
            entity.Id = Entities.Count + 1;
            Entities.Add(entity);
        }

        public void Change(object entity, PropertyInfo property, string value)
        {
            property.SetValue(entity, value);
        }

        public void Delete(IList<IEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Delete(repository);
                Entities.Remove(entity);
            }
        }

    }
}
