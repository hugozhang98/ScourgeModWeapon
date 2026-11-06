using System;
using Microsoft.Xna.Framework;
using ScourgeModWeapon.Common.DisplayWeapons;
using Terraria.ModLoader;

namespace ScourgeModWeapon
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class ScourgeModWeapon : Mod
    {
        public static ScourgeModWeapon Instance { get; private set; }

        public override void Load()
        {
            base.Load();

            Instance = this;
        }

        public override void Unload()
        {
            base.Unload();

            DWRegistry.ClearExternalWeaponDisplays();
            Instance = null;
        }

        /// <summary>
        /// 供未引用本程序集的 Mod 注册武器展示。
        /// <code>
        /// ModLoader.GetMod("ScourgeModWeapon").Call(
        ///     "RegisterWeaponDisplay",
        ///     weapon.Type,
        ///     "Gun",
        ///     originOffset,
        ///     positionOffset,
        ///     rotationOffset,
        ///     scaleOffset,
        ///     hideWhenProjActive
        /// );
        /// </code>
        /// 从 <c>originOffset</c> 开始的参数均可省略，省略时采用零值或 <c>false</c>。
        /// </summary>
        public override object Call(params object[] args)
        {
            if (args.Length == 0 || args[0] is not string message)
            {
                throw new ArgumentException("Mod.Call 的第一个参数必须是 API 名称字符串。", nameof(args));
            }

            return message switch
            {
                "RegisterWeaponDisplay" => RegisterWeaponDisplay(args),
                _ => throw new ArgumentException($"未知的 Mod.Call API：{message}", nameof(args)),
            };
        }

        private static bool RegisterWeaponDisplay(object[] args)
        {
            const int MinimumArgumentCount = 3;
            const int MaximumArgumentCount = 8;

            if (args.Length < MinimumArgumentCount || args.Length > MaximumArgumentCount)
            {
                throw new ArgumentException(
                    "RegisterWeaponDisplay 需要 3 至 8 个参数："
                        + "命令、物品 Type、展示类别，以及最多五个可选展示参数。",
                    nameof(args)
                );
            }

            if (args[1] is not int itemType || itemType <= 0)
            {
                throw new ArgumentException(
                    "RegisterWeaponDisplay 的第 2 个参数必须是武器的有效 Type（int）。",
                    nameof(args)
                );
            }

            if (
                args[2] is not string displayTypeName
                || !DWRegistry.TryParseWeaponDisplayType(displayTypeName, out DWWeaponDisplayType displayType)
            )
            {
                throw new ArgumentException(
                    "RegisterWeaponDisplay 的第 3 个参数必须是有效展示类别，例如 \"Gun\"。",
                    nameof(args)
                );
            }

            DWAdjust adjust = new()
            {
                OriginOffset = GetOptionalVector2(args, 3, "originOffset"),
                PositionOffset = GetOptionalVector2(args, 4, "positionOffset"),
                RotationOffset = GetOptionalFloat(args, 5, "rotationOffset"),
                ScaleOffset = GetOptionalFloat(args, 6, "scaleOffset"),
                HideWhenProjActive = GetOptionalBoolean(args, 7, "hideWhenProjActive"),
            };

            DWRegistry.RegisterExternalWeaponDisplay(itemType, displayType, adjust);
            return true;
        }

        private static Vector2 GetOptionalVector2(object[] args, int index, string parameterName)
        {
            if (index >= args.Length)
            {
                return Vector2.Zero;
            }

            return args[index] is Vector2 value
                ? value
                : throw new ArgumentException(
                    $"RegisterWeaponDisplay 的 {parameterName} 必须是 Vector2。",
                    nameof(args)
                );
        }

        private static float GetOptionalFloat(object[] args, int index, string parameterName)
        {
            if (index >= args.Length)
            {
                return 0f;
            }

            return args[index] switch
            {
                float value => value,
                double value => (float)value,
                int value => value,
                _ => throw new ArgumentException(
                    $"RegisterWeaponDisplay 的 {parameterName} 必须是数值。",
                    nameof(args)
                ),
            };
        }

        private static bool GetOptionalBoolean(object[] args, int index, string parameterName)
        {
            if (index >= args.Length)
            {
                return false;
            }

            return args[index] is bool value
                ? value
                : throw new ArgumentException(
                    $"RegisterWeaponDisplay 的 {parameterName} 必须是 bool。",
                    nameof(args)
                );
        }
    }
}
