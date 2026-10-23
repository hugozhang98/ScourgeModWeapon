using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ScourgeModWeapon.Common.DisplayWeapons
{
    public sealed class DWAdjust
    {
        public Vector2 PositionOffset { get; init; }
        public Vector2 OriginOffset { get; init; }
        public float RotationOffset { get; init; }
        public float ScaleOffset { get; init; }
        public bool HideWhenProjActive { get; init; }
    }

    public static class DWVanillaAdjustments
    {
        private static readonly Dictionary<int, DWAdjust> ByItemType = new()
        {
            [ItemID.Razorpine] = new() { ScaleOffset = -0.2f },
            [ItemID.WeatherPain] = new()
            {
                ScaleOffset = -0.35f,
                PositionOffset = new Vector2(2f, 2f),
            },
            [ItemID.Megashark] = new() { OriginOffset = new Vector2(0f, 3f) },
            [ItemID.Anchor] = new()
            {
                PositionOffset = new Vector2(6f, 4f),
                HideWhenProjActive = true,
            },
            [ItemID.ChainGuillotines] = new()
            {
                PositionOffset = new Vector2(0f, 5f),
                ScaleOffset = -0.2f,
            },
            [ItemID.TheRottedFork] = new() { PositionOffset = new Vector2(-4f, 0f) },
            [ItemID.FlyingKnife] = new() { ScaleOffset = -0.2f, HideWhenProjActive = true },
            [ItemID.RottenEgg] = new() { ScaleOffset = -0.2f },
            [ItemID.MolotovCocktail] = new() { ScaleOffset = -0.2f },
            [ItemID.SolarEruption] = new() { ScaleOffset = -0.2f },
            [ItemID.PiercingStarlight] = new() { ScaleOffset = -0.2f },
            [ItemID.CrystalSerpent] = new() { ScaleOffset = -0.2f },
            [ItemID.WoodenBoomerang] = new() { HideWhenProjActive = true },
            [ItemID.EnchantedBoomerang] = new() { HideWhenProjActive = true },
            [ItemID.FruitcakeChakram] = new() { HideWhenProjActive = true },
            [ItemID.BloodyMachete] = new() { HideWhenProjActive = true },
            [ItemID.Shroomerang] = new() { HideWhenProjActive = true },
            [ItemID.IceBoomerang] = new() { HideWhenProjActive = true },
            [ItemID.ThornChakram] = new() { HideWhenProjActive = true },
            [ItemID.Flamarang] = new() { HideWhenProjActive = true },
            [ItemID.Bananarang] = new() { HideWhenProjActive = true },
            [ItemID.PossessedHatchet] = new() { HideWhenProjActive = true },
            [ItemID.LightDisc] = new() { HideWhenProjActive = true },
            [ItemID.PaladinsHammer] = new() { HideWhenProjActive = true },
            [ItemID.Trimarang] = new() { HideWhenProjActive = true },
            [ItemID.SpiritFlame] = new() { ScaleOffset = 0.2f },
        };

        public static bool TryGet(Item item, out DWAdjust adjust) =>
            ByItemType.TryGetValue(item.type, out adjust);
    }
}
