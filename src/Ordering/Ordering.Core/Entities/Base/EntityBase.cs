using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Entities.Base
{
    public abstract class EntityBase<Tid> : IEntityBase<Tid>
    {
        public virtual Tid id { get; protected set; }

        int? _requestedHashCode;

        public bool IsTransient()
        {
            return id.Equals(default(Tid));
        }

        public override bool Equals(object obj)
        {
            if(obj == null || !(obj is EntityBase<Tid>))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if(GetType() != obj.GetType())
            {
                return false;
            }
            var item = (EntityBase<Tid>)obj;
            if(item.IsTransient() || IsTransient())
            {
                return false;
            }
            else
            {
                return item == this;
            }
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                {
                    _requestedHashCode = id.GetHashCode() ^ 31;
                }
                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        public static bool operator == (EntityBase<Tid> left , EntityBase<Tid> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(EntityBase<Tid> left, EntityBase<Tid> right)
        {
            return !(left == right);
        }



    }
}
