using System;

namespace Framework.Domain
{
    public class Property : BaseEntity, ICloneable
    {
        /// <summary>
        /// Gets or sets the Property Name
        /// </summary>
        public virtual string PropertyName{ get; set; }

        /// <summary>
        /// Gets or sets the Property Description
        /// </summary>
        public virtual string PropertyDescription { get; set; }

        /// <summary>
        /// Gets or sets the Last ModifiedUser ID
        /// </summary>
        public virtual int LastModifiedUserID { get; set; }
    
        
        public object Clone()
        {
            var proper = new Property()
            {
                PropertyName = this.PropertyName,
                PropertyDescription = this.PropertyDescription,
                LastModifiedUserID= this.LastModifiedUserID
            };
            return proper;
        }

        public bool Deleted { get; set; }
    }
}
