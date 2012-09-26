using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSocketHandler
{
    /// <summary>
    /// Although you can define event with string, I find it better to use constants
    /// for it and then create a mirror in javascript of these events for easier development and management
    /// </summary>
    public static class Commands
    {
        public static class PersonBinding
        {
            public const string GetAll = "Person.Bind.GetAll";
            public const string Create = "Person.Bind.Create";
            public const string Update = "Person.Bind.Update";
            public const string Delete = "Person.Bind.Delete";            
        }
        public static class PersonTrigger
        {
            public const string GetAll = "Person.Trigger.GetAll";
            public const string Created = "Person.Trigger.Created";
            public const string Updated = "Person.Trigger.Updated";
            public const string Deleted = "Person.Trigger.Deleted";            
        }
        public static class FruitTrigger
        {
            public const string GetAll = "Fruit.Trigger.GetAll";           
        }
        public static class ColorTrigger
        {
            public const string GetAll = "Color.Trigger.GetAll";
        }
        public static class GlobalBinding 
        {
            public const string Init = "Global.Bind.Init";
        }
    }
}
