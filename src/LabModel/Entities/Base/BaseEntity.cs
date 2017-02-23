using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabKhufu.Model.Entities.Base
{
    public abstract class BaseEntity : INotifyPropertyChanging, INotifyPropertyChanged, IComparable
    {
        [Column(Order = 1)]
        public Guid ID { get; set; }

        //public virtual bool Iptal { get; set; }

        public BaseEntity()
        {
            ID = Guid.NewGuid();
        }

        protected virtual bool HasChanged(object o1, object o2)
        {
            if (o1 == null && o2 == null) return false;
            if ((o1 != null && o2 == null) ||
                (o1 == null && o2 != null)) return true;
            return !(o1.Equals(o2));
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return GetHashCode() == obj.GetHashCode();
        }

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;
        protected virtual void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IComparable Members
        public virtual int CompareTo(object obj)
        {
            if (Equals(obj))
                return 0;
            else
            {
                string s1 = obj.ToString();
                string s2 = ToString();
                return s1.CompareTo(s2);
            }
        }
        #endregion

    }
}
