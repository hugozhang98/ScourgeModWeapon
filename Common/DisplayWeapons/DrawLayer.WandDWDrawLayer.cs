using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ScourgeModWeapon.Helper;
using Terraria;
using Terraria.DataStructures;

namespace ScourgeModWeapon.Common.DisplayWeapons
{
    public class WandDWDrawLayer : DWDrawLayerBase
    {
        public override Position GetDefaultPosition() =>
            new BeforeParent(PlayerDrawLayers.ArmOverItem);

        public override bool MatchWeapon(Item item) => DWRegistry.IsDW_Wand(item);

        protected override Vector2 GetOrigin(
            Texture2D texture,
            Rectangle frame,
            SpriteEffects effects,
            Item item,
            Player player
        )
        {
            Rectangle visibleFrame = TextureHelper.GetVisibleFrame(texture);

            if (visibleFrame == Rectangle.Empty)
                return frame.Size() * 0.5f;

            // 原点在完整贴图中的位置
            Vector2 origin =
                visibleFrame.Location.ToVector2()
                + new Vector2(visibleFrame.Width * 0.3f, visibleFrame.Height * 0.7f);

            return TextureHelper.ApplyFlipToOrigin(origin, frame, effects);
        }

        protected override Vector2 GetPosition(PlayerDrawSet drawInfo, Player player, Item item) =>
            DWHelper.GetPlayerJointPosition(drawInfo, DWPlayerJointType.FrontHand);

        protected override float GetRotationOffset(Player player)
        {
            float baseRotation = 20f;

            if (DWHelper.GetVanillaAnimationType(player) == DWVanillaAnimationType.Walking)
            {
                baseRotation = -30f;
            }

            if (DWHelper.GetVanillaAnimationType(player) == DWVanillaAnimationType.Jumping)
            {
                baseRotation = -120f;
            }

            return baseRotation;
        }

        protected override float GetWeaponSway(Player player) => 3f;

        protected override float GetScale(Item item)
        {
            float defaultScale = 0.9f;

            return defaultScale;
        }
    }
}
