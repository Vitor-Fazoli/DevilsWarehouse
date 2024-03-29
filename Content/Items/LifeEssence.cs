﻿using DevilsWarehouse.Common.Systems.VampireSystem;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DevilsWarehouse.Content.Items
{
    public class LifeEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Essence");

            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 4;
            Item.height = 4;
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            if (Main.rand.NextBool(2))
            {
                int dust = Dust.NewDust(Item.position - new Vector2(2f, 2f), Item.width, Item.height, DustID.Blood, Item.velocity.X, Item.velocity.Y, 100, Color.White, 1.2f);
                Main.dust[dust].noGravity = true;
            }
            Lighting.AddLight(Item.position, 1f, 0.09f, 0.09f);


            if(Item.timeSinceItemSpawned > Helper.Ticks(10))
            {
                Item.active = false;
            }
        }
        public override bool OnPickup(Player player)
        {
            int amount = 1 + Main.rand.Next(4);

            player.GetModPlayer<Vampire>().blood += amount;
            CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, 10, 10), new Color(200, 0, 255), amount);
            SoundEngine.PlaySound(SoundID.AbigailUpgrade,player.position);
            Item.active = false;
            return false;
        }
    }
}
