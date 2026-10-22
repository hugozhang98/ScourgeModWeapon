using Microsoft.Xna.Framework;

namespace ScourgeModWeapon.Common.DisplayWeapons
{
    public interface IDW_Base
    {
        public Vector2 OriginOffset => Vector2.Zero;
        public Vector2 PositionOffset => Vector2.Zero;
        public float RotationOffset => 0f;
        public float ScaleOffset => 0f;
        public bool HideWhenProjActive => false;
    }

    //链锤
    public interface IDW_Mace : IDW_Base { }

    //链刀
    public interface IDW_ChainKnife : IDW_Base { }

    //链枪
    public interface IDW_ChainGun : IDW_Base { }

    //悠悠球
    public interface IDW_Yoyo : IDW_Base { }

    //大剑
    public interface IDW_GreatSword : IDW_Base { }

    //枪
    public interface IDW_Gun : IDW_Base { }

    //小枪
    public interface IDW_MiniGun : IDW_Base { }

    //弓
    public interface IDW_Bow : IDW_Base { }

    //弩
    public interface IDW_Crossbow : IDW_Base { }

    //刺剑
    public interface IDW_Rapier : IDW_Base { }

    //大棒
    public interface IDW_Stick : IDW_Base { }

    //长矛
    public interface IDW_Spear : IDW_Base { }

    //骑枪
    public interface IDW_Lance : IDW_Base { }

    //剑
    public interface IDW_Sword : IDW_Base { }

    //手套
    public interface IDW_Glove : IDW_Base { }

    //回旋镖、胁差
    public interface IDW_Sidearm : IDW_Base { }

    //三尖回旋镖
    public interface IDW_Trimarang : IDW_Base { }

    //手雷
    public interface IDW_Grenade : IDW_Base { }

    //投镖
    public interface IDW_Javelin : IDW_Base { }

    //法杖
    public interface IDW_Staff : IDW_Base { }

    //魔棒
    public interface IDW_Wand : IDW_Base { }
}
