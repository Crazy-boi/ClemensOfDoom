using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClemensOfDoom.Items
{
    class ClemensSpawnItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesson Starter");
            Tooltip.SetDefault("\"Zeit für PoWi, Kinder!\"\nSummons The Clemens");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 64;
            item.maxStack = 999;

            item.value = 1000;
            item.rare = 1;

            item.useAnimation = 30;
            item.useTime = 30;

            item.useStyle = ItemUseStyleID.HoldingUp; //4
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TheClemens"));
            Main.PlaySound(15, player.position, 0);  //boss spawn grunt

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddIngredient(ItemID.MudBlock, 5);
            recipe.AddTile(TileID.Anvils);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
