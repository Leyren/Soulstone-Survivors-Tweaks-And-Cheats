using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneCheats.Util
{
    public static class SoulstonePluginUtils
    {

        public static void Scale(PlayerProfileCurrencies currencies, float multiplier)
        {
            currencies.MinorSoulstones = (int)Math.Ceiling(currencies.MinorSoulstones * multiplier);
            currencies.CorruptedSoulstones = (int)Math.Ceiling(currencies.CorruptedSoulstones * multiplier);
            currencies.HatefulSoulstones = (int)Math.Ceiling(currencies.HatefulSoulstones * multiplier);
            currencies.RogueSoulstones = (int)Math.Ceiling(currencies.RogueSoulstones * multiplier);
            currencies.VileSoulstones = (int)Math.Ceiling(currencies.VileSoulstones * multiplier);
            currencies.WickedSoulstones = (int)Math.Ceiling(currencies.WickedSoulstones * multiplier);
        }

        public static string AsString(PlayerProfileCurrencies currencies)
        {
            return $"{currencies.MinorSoulstones} {currencies.CorruptedSoulstones} {currencies.VileSoulstones} {currencies.WickedSoulstones} {currencies.HatefulSoulstones} {currencies.RogueSoulstones}";
        }

    }
}
