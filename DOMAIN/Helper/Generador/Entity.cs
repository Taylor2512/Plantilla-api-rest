using DOMAIN.Interfaces.Helper.IGenerador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Helper.Generador
{
    public abstract class Entity<T> : IEntity<T>
    {
        /// <summary>
        /// Default Constructor. If TDt is <see cref="System.Guid"/>, the value of the Id property is automatically set.
        /// </summary>
        protected Entity()
        {
            if (typeof(T) == typeof(Guid))
            {
                Id = (T)(object)Guid.NewGuid();
            }
        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="id">An <see cref="T"/> that 
        /// represents the primary identifier value for the 
        /// class.</param>
        protected Entity(T id)
        {
            Id = id;
        }

        /// <summary>
        /// An <see cref="Entity{T}"/> that represents the 
        /// primary identifier value for the class.
        /// </summary>
        [Key]
        public T Id { get; set; }

        object IEntity.Id
        {
            get => this.Id;
            set => this.Id = (T)Convert.ChangeType(value, typeof(T));
        }

        #region Equality Tests

        /// <summary>
        /// Determines whether the specified entity is equal to the 
        /// current instance.
        /// </summary>
        /// <param name="entity">An <see cref="System.Object"/> that 
        /// will be compared to the current instance.</param>
        /// <returns>True if the passed in entity is equal to the 
        /// current instance.</returns>
        public override bool Equals(object entity)
        {
            if (!(entity is Entity<T>))
            {
                return false;
            }

            return this == (Entity<T>)entity;
        }

        /// <summary>
        /// Operator overload for determining equality.
        /// </summary>
        /// <param name="base1">The first instance of an 
        /// <see cref="Entity{T}"/>.</param>
        /// <param name="base2">The second instance of an 
        /// <see cref="Entity{T}"/>.</param>
        /// <returns>True if equal.</returns>
        public static bool operator ==(Entity<T> base1, Entity<T> base2)
        {
            // check for both null (cast to object or recursive loop)
            if (base1 is null && base2 is null)
            {
                return true;
            }

            // check for either of them == to null
            if (base1 is null || base2 is null)
            {
                return false;
            }

            return Equals(base1.Id, base2.Id);
        }

        /// <summary>
        /// Operator overload for determining inequality.
        /// </summary>
        /// <param name="base1">The first instance of an 
        /// <see cref="Entity{T}"/>.</param>
        /// <param name="base2">The second instance of an 
        /// <see cref="Entity{T}"/>.</param>
        /// <returns>True if not equal.</returns>
        public static bool operator !=(Entity<T> base1, Entity<T> base2)
        {
            return (!(base1 == base2));
        }

        /// <summary>
        /// Serves as a hash function for this type.
        /// </summary>
        /// <returns>A hash code for the current Key 
        /// property.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion

    }
}
