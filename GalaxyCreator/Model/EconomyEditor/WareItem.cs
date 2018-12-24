using GalaSoft.MvvmLight;
using System;

namespace GalaxyCreator.Model.EconomyEditor
{
    public class WareItem : ObservableObject
    {
        private String _value = default(String);

        public WareItem() { }

        public WareItem(string ware)
        {
            this._value = ware;
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
