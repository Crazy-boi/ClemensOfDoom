using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClemensOfDoom.NPCs.Enemies
{
    class MiniClemens : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clemens' Servant");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 60;

            npc.lifeMax = 250;

            npc.damage = 1;
            npc.defense = 15;

            npc.HitSound = SoundID.NPCHit1;
            //npc.DeathSound = SoundID.NPCDeath59;

            npc.value = 100f;

            npc.knockBackResist = 3f;

            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;

            banner = Item.NPCtoBanner(NPCID.Zombie);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
        }

        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            base.OnHitByItem(player, item, damage, knockback, crit);
            PlayLegacySound("Sounds/Bosses/TheClemensHit1.1", 0.5f, 1f);
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            base.OnHitByProjectile(projectile, damage, knockback, crit);
            PlayLegacySound("Sounds/Bosses/TheClemensHit1.1", 0.5f, 1f);
        }

        public override bool CheckDead()
        {
            bool b = base.CheckDead();
            if (b)
                PlayLegacySound("Sounds/Enemies/MiniClemensDeath1.0", 1f, 0f);
            return b;
        }

        private void PlayLegacySound(string wavfile, float volume, float pitchvar)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, wavfile).WithVolume(volume).WithPitchVariance(pitchvar));
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(5) == 0)
            {
                Item.NewItem(npc.position, mod.ItemType("ClemensSpawnItem"));
            }
            if (Main.rand.Next(5) == 0)
            {
                Item.NewItem(npc.position, ItemID.WhoopieCushion);
            }
        }
    }
}
