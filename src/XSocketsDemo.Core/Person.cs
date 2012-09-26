using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace XSocketsDemo.Core
{
    [Serializable]
    [DataContract]
    public class Person : PersistentEntity
    {
        [DataMember]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public int Age { get; set; }

        [DataMember]
        [Required]
        public int Gender { get; set; }

        public Gender GenderValue
        {
            get { return (Gender)Gender; }
            set { Gender = (int)value; }
        }
        [DataMember]
        [Required]
        public int FavoriteColorId { get; set; }
        [DataMember]
        [ForeignKey("FavoriteColorId")]
        public virtual Color FavoriteColor { get; set; }

        [DataMember]
        [Required]
        public int FavoriteFruitId { get; set; }
        [DataMember]
        [ForeignKey("FavoriteFruitId")]
        public virtual Fruit FavoriteFruit { get; set; }
    }
}
