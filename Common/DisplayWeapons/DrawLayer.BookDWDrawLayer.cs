using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ScourgeModWeapon.Helper;
using Terraria;
using Terraria.DataStructures;

namespace ScourgeModWeapon.Common.DisplayWeapons
{
    public class BookDWDrawLayer : DWDrawLayerBase
    {
        public override Position GetDefaultPosition() =>
            new BeforeParent(PlayerDrawLayers.ArmOverItem);

        public override bool MatchWeapon(Item item) => DWRegistry.IsDW_Book(item);

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
                + new Vector2(
                    visibleFrame.Width * 0.4f,
                    visibleFrame.Height
                        * (
                            DWHelper.GetVanillaAnimationType(player) == DWVanillaAnimationType.Idle
                                ? 0.6f
                                : 0.4f
                        )
                );

            return TextureHelper.ApplyFlipToOrigin(origin, frame, effects);
        }

        protected override Vector2 GetPosition(PlayerDrawSet drawInfo, Player player, Item item) =>
            DWHelper.GetPlayerJointPosition(drawInfo, DWPlayerJointType.FrontHand);

        protected override float GetRotationOffset(Player player)
        {
            float baseRotation = 25f;

            if (DWHelper.GetVanillaAnimationType(player) == DWVanillaAnimationType.Walking)
            {
                baseRotation = -30f;
            }

            if (DWHelper.GetVanillaAnimationType(player) == DWVanillaAnimationType.Jumping)
            {
                baseRotation = -140f;
            }

            return baseRotation;
        }

        protected override float GetWeaponSway(Player player) => 3f;

        protected override float GetScale(Item item)
        {
            float defaultScale = 0.75f;

            return defaultScale;
        }
    }
}
