using Terraria;
using Terraria.ModLoader;

namespace ClemensOfDoom.Items
{
    class DeepVoiceSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("");
            Tooltip.SetDefault("Makes a deep sound\nReminds of Clemens");
        }

        public override void SetDefaults()
        {
            item.width = 40; //idk, hitbox seems to depend on image size, work also if these are 0...
            item.height = 40;
            //item.maxStack = 1; not needed 
            item.rare = 4;
            item.value = Item.buyPrice(0, 5, 0, 0); //Add using Terraria
            
            item.useStyle = 1; //1=swing 2=drink etc.
            item.useTime = 30;
            item.useAnimation = 30; //best to keep the same as useTime
            item.useTurn = true;
            item.autoReuse = true;

            item.melee = true;
            item.damage = 55;
            item.crit = 7;
            item.knockBack = 6.0f;

            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/DeepVoiceSwordSwing1.0");
        }
    }
}
