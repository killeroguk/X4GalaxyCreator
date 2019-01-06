using GalaSoft.MvvmLight;
using System;

namespace GalaxyCreator.Model
{
    public class StringItem : ObservableObject
    {
        private String _value = default(String);

        public StringItem() { }

        public StringItem(string stringItem)
        {
            this._value = stringItem;
        }

        public String Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    Set(ref _value, value);
                }
            }
        }
    }
}
