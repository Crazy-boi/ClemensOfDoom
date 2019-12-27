using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClemensOfDoom.NPCs.Bosses
{
    [AutoloadBossHead]
    class TheClemens : ModNPC
    {
        /*public override string Texture
        {
            get { return "ClemensOfDoom/NPCs/Bosses/TheClemens"; }
        }*/

        /*public override string HeadTexture
        {
            get { return "ClemensOfDoom/NPCs/Bosses/TheClemens_Head"; }
        }*/

        public override bool Autoload(ref string name)
        {
            name = "TheClemens";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Clemens");
            Main.npcFrameCount[npc.type] = 2;

            music = MusicID.Boss1;
        }

        public override void SetDefaults()
        {
            npc.boss = true;

            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.aiStyle = 4;
            animationType = NPCID.DemonEye;
            
            npc.lifeMax = 11000;
            npc.damage = 40;
            npc.defense = 20;
            npc.knockBackResist = 0f;

            npc.buffImmune[BuffID.Confused] = true;

            npc.width = 80;
            npc.height = 68;

            //npc.HitSound = mod.GetLegacySoundSlot(SoundType.NPCHit, "Sounds/Bosses/TheClemensHit");
            //npc.DeathSound = mod.GetLegacySoundSlot(SoundType.NPCKilled, "Sounds/Bosses/TheClemensKilled");
            
            npc.HitSound = SoundID.NPCHit1;
            //npc.DeathSound = SoundID.NPCDeath10;

            npc.value = Item.buyPrice(0, 10, 0, 0);

            npc.npcSlots = 1f;
            //npc.netAlways = true;
        }

        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            base.OnHitByItem(player, item, damage, knockback, crit);
            PlayLegacySound("Sounds/Bosses/TheClemensHit1.1", 2f, 0f);
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            base.OnHitByProjectile(projectile, damage, knockback, crit);
            PlayLegacySound("Sounds/Bosses/TheClemensHit1.1", 2f, 0f);
        }

        public override bool CheckDead()
        {
            bool b = base.CheckDead();
            if (b)
                PlayLegacySound("Sounds/Bosses/TheClemensDeath1.0", 5f, 0f);
            return b;
        }

        private void PlayLegacySound(string wavfile, float volume, float pitchvar)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, wavfile).WithVolume(volume).WithPitchVariance(pitchvar));
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
            Item.NewItem(npc.position, mod.ItemType("DeepVoiceSword"));
        }
    }
}
