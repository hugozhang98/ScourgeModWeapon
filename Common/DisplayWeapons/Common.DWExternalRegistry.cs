using System;
using System.Collections.Generic;
using Terraria;

namespace ScourgeModWeapon.Common.DisplayWeapons
{
    /// <summary>
    /// 展示武器所使用的绘制层类别。
    /// </summary>
    public enum DWWeaponDisplayType
    {
        Mace,
        ChainKnife,
        ChainGun,
        Yoyo,
        GreatSword,
        Gun,
        MiniGun,
        Bow,
        Crossbow,
        Rapier,
        Stick,
        Spear,
        Lance,
        Sword,
        Glove,
        Sidearm,
        Trimarang,
        Grenade,
        Javelin,
        Staff,
        Wand,
        MagicAccessory,
        Book,
        Whip,
    }

    public static partial class DWRegistry
    {
        private sealed class ExternalWeaponDisplay
        {
            public DWWeaponDisplayType DisplayType { get; }
            public DWAdjust Adjust { get; }

            public ExternalWeaponDisplay(DWWeaponDisplayType displayType, DWAdjust adjust)
            {
                DisplayType = displayType;
                Adjust = adjust;
            }
        }

        private static readonly Dictionary<int, ExternalWeaponDisplay> ExternalWeaponDisplays = new();

        /// <summary>
        /// 注册不引用本 Mod 程序集的外部武器展示数据。
        /// 重复注册同一物品会覆盖其先前的类别与偏移设置。
        /// </summary>
        public static void RegisterExternalWeaponDisplay(
            int itemType,
            DWWeaponDisplayType displayType,
            DWAdjust adjust
        )
        {
            if (itemType <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(itemType),
                    "itemType 必须是已注册物品的正整数类型 ID。"
                );
            }

            ExternalWeaponDisplays[itemType] = new ExternalWeaponDisplay(displayType, adjust);
        }

        public static bool TryParseWeaponDisplayType(
            string value,
            out DWWeaponDisplayType displayType
        )
        {
            return Enum.TryParse(value, ignoreCase: true, out displayType)
                && Enum.IsDefined(typeof(DWWeaponDisplayType), displayType);
        }

        public static bool IsRegisteredAs(Item item, DWWeaponDisplayType displayType)
        {
            return ExternalWeaponDisplays.TryGetValue(item.type, out ExternalWeaponDisplay display)
                && display.DisplayType == displayType;
        }

        public static bool TryGetExternalAdjust(Item item, out DWAdjust adjust)
        {
            if (ExternalWeaponDisplays.TryGetValue(item.type, out ExternalWeaponDisplay display))
            {
                adjust = display.Adjust;
                return true;
            }

            adjust = null;
            return false;
        }

        public static bool TryGetAdjust(Item item, out DWAdjust adjust)
        {
            return TryGetExternalAdjust(item, out adjust)
                || DWVanillaAdjustments.TryGet(item, out adjust);
        }

        public static void ClearExternalWeaponDisplays()
        {
            ExternalWeaponDisplays.Clear();
        }
    }
}
