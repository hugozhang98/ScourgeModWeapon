using ScourgeModWeapon.Helper;
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

            Instance = null;
        }
    }
}
