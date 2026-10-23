using Microsoft.Xna.Framework;
using ScourgeModWeapon.Helper;
using Terraria;
using Terraria.DataStructures;

namespace ScourgeModWeapon.Common.DisplayWeapons
{
    public class MagicAccessoryDWDrawLayer : DWDrawLayerBase
    {
        const ulong cycleTicks = 180UL;
        const ulong halfCycleTicks = cycleTicks / 2;

        private float cycleFrame;

        public override Position GetDefaultPosition()
        {
            var position = new Multiple();

            // 后半圈：人物后方
            position.Add(
                new Between(null, PlayerDrawLayers.MountBack),
                _ => Main.GameUpdateCount % cycleTicks > halfCycleTicks
            );

            // 前半圈：人物前方
            position.Add(
                new Between(PlayerDrawLayers.ArmOverItem, null),
                _ => Main.GameUpdateCount % cycleTicks <= halfCycleTicks
            );

            return position;
        }

        public override bool MatchWeapon(Item item) => DWRegistry.IsDW_MagicAccessory(item);

        protected override bool IsPositionFloor => false;

        protected override bool PreDraw(PlayerDrawSet drawInfo)
        {
            // 先用整数取模，避免运行时间很长时 GameUpdateCount 转 float 丢失低位。
            cycleFrame = (float)(Main.GameUpdateCount % cycleTicks);

            return true;
        }

        protected override Vector2 GetPosition(PlayerDrawSet drawInfo, Player player, Item item)
        {
            Vector2 position =
                DWHelper.GetPlayerJointPosition(drawInfo, DWPlayerJointType.Body)
                + new Vector2(0, 3f);

            float angle = MathHelper.TwoPi * cycleFrame / (float)cycleTicks;

            float Swing = ProcessHelper.Swing(cycleFrame, cycleTicks / 3f);

            Vector2 offset =
                ShapeHelper.GetEllipse(position, 24f, 3f, angle) + new Vector2(0, Swing * 2f);

            return offset;
        }

        protected override float GetScale(Item item)
        {
            const float minScale = 0.5f;
            const float maxScale = 0.6f;

            float progress = ProcessHelper.BackAndForth(cycleFrame, cycleTicks, 0.25f);

            return MathHelper.Lerp(minScale, maxScale, progress);
        }
    }
}
