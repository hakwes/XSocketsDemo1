using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace XSocketsDemo.Core
{
    [Serializable]
    [DataContract]
    public class Color : PersistentEntity
    {
        [DataMember]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}