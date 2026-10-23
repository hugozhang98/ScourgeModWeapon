using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ScourgeModWeapon.Common.DisplayWeapons
{
    public class WhipDWDrawLayer : DWDrawLayerBase
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Wings);

        public override bool MatchWeapon(Item item) => DWRegistry.IsDW_Whip(item);

        protected override Vector2 GetPositionOffset(
            PlayerDrawSet drawInfo,
            Player player,
            Item item
        ) => new Vector2(-4f, 2f);

        protected override float GetRotationOffset(Player player) => 80f;

        protected override float GetWeaponSway(Player player) => 4f;

        protected override float GetScale(Item item)
        {
            return 1f;
        }
    }
}
