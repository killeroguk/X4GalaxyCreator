using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GalaxyCreator.Model
{
    public enum Race
    {
        [Description("Player")]
        PLAYER,
        [Description("Argon")]
        ARGON,
        [Description("Paranid")]
        PARANID,
        [Description("Teladi")]
        TELADI,
        [Description("Split")]
        SPLIT,
        [Description("Terran")]
        TERRAN,
        [Description("Khaak")]
        KHAAK,
        [Description("XENON")]
        XENON,
        [Description("Ownerless")]
        OWNERLESS,
    }

    public enum Faction
    {
        [Description("Player")]
        PLAYER,
        [Description("Argon")]
        ARGON,
        [Description("Alliance")]
        ALLIANCE,
        [Description("Antigone")]
        ANTIGONE,
        [Description("Civilian")]
        CIVILIAN,
        [Description("Criminal")]
        CRIMINAL,
        [Description("Hatikvah")]
        HATIKVAH,
        [Description("Holyorder")]
        HOLYORDER,
        [Description("Ministry")]
        MINISTRY,
        [Description("Scaleplate")]
        SCALEPLATE,
        [Description("Smuggler")]
        SMUGGLER,
        [Description("Visitor")]
        VISITOR,
        [Description("Paranid")]
        PARANID,
        [Description("Teladi")]
        TELADI,
        [Description("Split")]
        SPLIT,
        [Description("Terran")]
        TERRAN,
        [Description("Khaak")]
        KHAAK,
        [Description("XENON")]
        XENON,
        [Description("Ownerless")]
        OWNERLESS,
    }

    public enum StationType
    {
        [Description("Shipyard")]
        SHIPYARD,
        [Description("Wharf")]
        WHARF,
        [Description("Defence")]
        DEFENCE,
        [Description("Tradestation")]
        TRADE,
        [Description("Piratebase")]
        PIRATEBASE,
        [Description("Piratedock")]
        PIRATEDOCK,
        [Description("Teladi Ring")]
        TELADI_RING,

    }

    public enum BeltType
    {
        [Description("Ore")]
        ORE,
        [Description("Silicon")]
        SILICON,
        [Description("Ice")]
        ICE,
        [Description("Nividium")]
        NIVIDIUM,
        [Description("Hydrogen")]
        HYDROGEN,
        [Description("Helium")]
        HELIUM,
        [Description("Methane")]
        METHANE,
    }


    public class EnumerationExtension : MarkupExtension
    {
        private Type _enumType;


        public EnumerationExtension(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");

            EnumType = enumType;
        }

        public Type EnumType
        {
            get { return _enumType; }
            private set
            {
                if (_enumType == value)
                    return;

                var enumType = Nullable.GetUnderlyingType(value) ?? value;

                if (enumType.IsEnum == false)
                    throw new ArgumentException("Type must be an Enum.");

                _enumType = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var enumValues = Enum.GetValues(EnumType);

            return (
              from object enumValue in enumValues
              select new EnumerationMember
              {
                  Value = enumValue,
                  Description = GetDescription(enumValue)
              }).ToArray();
        }

        private string GetDescription(object enumValue)
        {
            var descriptionAttribute = EnumType
              .GetField(enumValue.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;


            return descriptionAttribute != null
              ? descriptionAttribute.Description
              : enumValue.ToString();
        }

        public class EnumerationMember
        {
            public string Description { get; set; }
            public object Value { get; set; }
        }
    }
}
