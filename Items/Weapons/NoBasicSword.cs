using Terraria.ID;
using Terraria.ModLoader;

namespace ClemensOfDoom.Items
{
	public class NoBasicSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("NoBasicSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is NOT a basic modded sword.\nIt swings and deals damage.\nWOW!");
		}

		public override void SetDefaults() 
		{
			item.damage = 40;
			item.melee = true;
			item.width = 120;
			item.height = 120;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 12;
			item.value = 10000;
			item.rare = 1;
			item.autoReuse = true;

			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/Loerritz1.1");
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.AddIngredient(ItemID.MythrilBar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}