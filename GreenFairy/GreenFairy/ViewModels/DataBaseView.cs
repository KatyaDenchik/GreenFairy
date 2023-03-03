using GreenFairy.Data;
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

        // Имя таблицы
        private string tabelName;
        // Перерисовка таблиц
        public string TabelName { get { return tabelName; } set { 
                SetProperty(ref tabelName, value); } }
        // Если выбираем админа, то тип будет AdminEntity
        public Type Type => EntityTypes.First(s => s.Name == TabelName).Type;

        public List<IEntity> Entities;

        /// <summary>
        /// Метод, который формирует таблицу сущностей после того, как был указан тип
        /// </summary>
        /// <param name="entityService">Сервис, который вытиаскивает нужный нам тип сущности</param>
        /// <param name="repository"></param>
        public DataBaseView(EntityService entityService, Repository repository)
        {
            this.entityService = entityService;
            this.repository = repository;

            TabelName = EntityTypes.First().Name;
            //Вытаскиваем все сущности выбранного типа
            Entities = entityService.GetEntities(Type).ToList();
            //Вытаскиваем все сущности выбранного типа заново, если был поменян тип 
            this.PropertyChanged += (a, e) => { 
                Entities = entityService.GetEntities(Type).ToList(); };
        }

        public void Save()
        {
            try
            {
                foreach (var entity in Entities)
                {
                    entity.SaveToDB(repository);
                }
            }
            catch (Exception)
            {

            }
           
        }
        public void Add()
        {
            // Создание сущности конкретного типа
            IEntity entity = (IEntity)Activator.CreateInstance(Type);
            entity.Id = Entities.Last().Id + 1;
            Entities.Add(entity);
        }
        /// <summary>
        /// Метод, который меняет конкретное поле сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="property">Значение поля</param>
        /// <param name="value">На что поменялось поле</param>
        public void Change(object entity, PropertyInfo property, string value)
        {
            try
            {
                var newValue = new object();
                if (property.PropertyType.Name == "ClientEntity")
                {
                    var id = int.Parse(value);
                    newValue = repository.Get<ClientEntity>(s => s.Id == id).FirstOrDefault();

                }
                else if (property.Name == "Plants")
                {
                    var ids = new List<int>();

                    foreach (var item in value.Replace(" ", "").Split(","))
                    {
                        ids.Add(int.Parse(item));
                    }
                    newValue = repository.Get<PlantEntity>(s => ids.Contains(s.Id)).ToList();
                }
                else if (property.Name.Contains("Kind"))
                {
                    newValue = Enum.Parse(property.PropertyType, value);
                }
                else
                {
                    newValue = Convert.ChangeType(value, property.PropertyType);
                }
                property.SetValue(entity, newValue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
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
