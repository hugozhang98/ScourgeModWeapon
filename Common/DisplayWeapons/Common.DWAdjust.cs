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
            [ItemID.Anchor] = new() { PositionOffset = new Vector2(6f, 4f) },
            [ItemID.ChainGuillotines] = new()
            {
                PositionOffset = new Vector2(0f, 5f),
                ScaleOffset = -0.2f,
            },
            [ItemID.TheRottedFork] = new() { PositionOffset = new Vector2(-4f, 0f) },
        };

        public static bool TryGet(Item item, out DWAdjust adjust) =>
            ByItemType.TryGetValue(item.type, out adjust);
    }
}
