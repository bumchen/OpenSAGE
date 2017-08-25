﻿using OpenSage.Data.Ini;
using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    /// <summary>
    /// Like Transport, but when full, passes transport queries along to first passenger 
    /// (redirects like tunnel). Basically works like the Overlord Contain.
    /// </summary>
    public sealed class HelixContain : ObjectBehavior
    {
        internal static HelixContain Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        private static readonly IniParseTable<HelixContain> FieldParseTable = new IniParseTable<HelixContain>
        {
            { "Slots", (parser, x) => x.Slots = parser.ParseInteger() },
            { "DamagePercentToUnits", (parser, x) => x.DamagePercentToUnits = parser.ParsePercentage() },
            { "AllowInsideKindOf", (parser, x) => x.AllowInsideKindOf = parser.ParseEnum<ObjectKinds>() },
            { "PassengersAllowedToFire", (parser, x) => x.PassengersAllowedToFire = parser.ParseBoolean() },
            //{ "PassengersInTurret", (parser, x) => x.PassengersInTurret = parser.ParseBoolean() }
        };

        public int Slots { get; private set; }
        public float DamagePercentToUnits { get; private set; }
        public ObjectKinds AllowInsideKindOf { get; private set; }
        public bool PassengersAllowedToFire { get; private set; }
        //public bool PassengersInTurret { get; private set; }
    }
}
