﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using VoidArsenal.Content.Projectiles;

namespace VoidArsenal.Content.Items.Weapons.Melee.Swords
{
    public class Maiden : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Maiden");
        }
        public override void SetDefaults()
        {
            Item.width = 80;
            Item.height = 80;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 14;
            Item.damage = 30;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            Vector2 randPosition = player.Center + Utils.RandomVector2(Main.rand, -1f, 1f);

            Projectile.NewProjectile(new EntitySource_OnHit(target,player),randPosition,target.position - randPosition,ModContent.ProjectileType<MaidenProj>(),10,4, player.whoAmI);
        }
    }
}
