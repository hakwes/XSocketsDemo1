using System;
using System.Collections.Generic;
using System.Linq;
using XSocketHandler.ViewModel;
using XSockets.Core.XSocket.Event.Attributes;
using XSockets.Core.XSocket.Helpers;
using XSocketsDemo.Core;
using System.Data;

namespace XSocketHandler
{
    /// <summary>
    /// A partial of our DemoController
    /// This one will handle People commands
    /// </summary>
	public partial class DemoController
	{
        /// <summary>
        /// Returns all people from the EF Context to the client asking for them
        /// </summary>
        [HandlerEvent(Commands.PersonBinding.GetAll)]
        public void PersonGetAll()
        {
            try
            {
                var Db = this.getContext();
                var json = new List<PersonViewModel>();

                foreach (var person in Db.People.ToList().OrderBy(p => p.Name))
                {
                    json.Add(new PersonViewModel(person));
                }
                
                this.Send(json, Commands.PersonTrigger.GetAll);
            }
            catch(Exception ex)
            {
                this.DispatchError(ex, "Exception in PersonGetAll");
            }
        }

        /// <summary>
        /// Adds a person to EF Context and then alerts 
        /// all clients listening that a new person was created
        /// </summary>
        [HandlerEvent(Commands.PersonBinding.Create)]
        public void PersonCreate(Person entity)
        {
            try
            {
                var Db = this.getContext();
                
                var p = Db.People.Add(entity);
                Db.SaveChanges();
                //Get from DB since we might miss the Fruit/Color entity due to only setting FK´s on them.
                p.FavoriteFruit = Db.Set<Fruit>().Find(p.FavoriteFruitId);
                p.FavoriteColor = Db.Set<Color>().Find(p.FavoriteColorId);
                var json = new PersonViewModel(p);
                //Notify all clients listening for this event that a new Person was created!
                this.SendToAll(json, Commands.PersonTrigger.Created);
            }
            catch (Exception ex)
            {
                this.DispatchError(ex, "Exception in PersonCreate");
            }
        }

        /// <summary>
        /// Removes a person from the EF Context and send information about it to all 
        /// clients listening
        /// </summary>
        /// <param name="entity"></param>
        [HandlerEvent(Commands.PersonBinding.Delete)]
        public void PersonDelete(Person entity)
        {
            try
            {
                var Db = this.getContext();
                
                var dbEntity = Db.Set<Person>().Find(entity.Id);
                var p = Db.People.Remove(dbEntity);

                Db.SaveChanges();

                //Notify all clients listening for this event that a Person was deleted!
                this.SendToAll(entity, Commands.PersonTrigger.Deleted);
            }
            catch (Exception ex)
            {
                this.DispatchError(ex, "Exception in PersonDelete");
            }
        }

        /// <summary>
        /// Updates the entity and notify all clients listening
        /// </summary>
        /// <param name="entity"></param>
        [HandlerEvent(Commands.PersonBinding.Update)]
        public void PersonUpdate(Person entity)
        {
            try
            {
                var Db = this.getContext();

                var dbEntity = Db.Set<Person>().Find(entity.Id);

                dbEntity.GenderValue = entity.GenderValue;
                dbEntity.Name = entity.Name;
                dbEntity.FavoriteColorId = entity.FavoriteColorId;
                dbEntity.FavoriteFruitId = entity.FavoriteFruitId;

                Db.Entry(dbEntity).State = EntityState.Modified;

                Db.SaveChanges();

                entity.FavoriteFruit = Db.Set<Fruit>().Find(entity.FavoriteFruitId);
                entity.FavoriteColor = Db.Set<Color>().Find(entity.FavoriteColorId);
                var json = new PersonViewModel(entity);

                //Notify all clients listening for this event that a Person was updated!
                this.SendToAll(json, Commands.PersonTrigger.Updated);
            }
            catch (Exception ex)
            {
                this.DispatchError(ex, "Exception in PersonUpdate");
            }
        } 
	}
}
