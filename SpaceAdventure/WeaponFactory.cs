using SpaceAdventure.Abstractions;
using SpaceAdventure.Common;
using SpaceAdventure.Common.Enums;
using SpaceAdventure.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class WeaponFactory
    {
        IDictionary<WeaponType, Lazy<IWeapon>> weapons;

        private ItemSpriteFactory itemFactory;
        private DirectionalEffectsFactory directionalFactor;
        private EffectsFactory effects;


        public WeaponFactory()
        {
            itemFactory = new ItemSpriteFactory();
            directionalFactor = new DirectionalEffectsFactory();
            effects = new EffectsFactory();

            weapons = new Dictionary<WeaponType, Lazy<IWeapon>>();
            //weapons.Add(WeaponType.NoWeapon, new Lazy<IWeapon>(() => new Weapon(ItemNames.Empty,))
            weapons.Add(WeaponType.Rifle, new Lazy<IWeapon>(() => new Weapon(ItemNames.Rifle, (IItemSprite)itemFactory.Get(ItemNames.Rifle), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.Shotgun, new Lazy<IWeapon>(() => new Weapon(ItemNames.Shotgun, (IItemSprite)itemFactory.Get(ItemNames.Shotgun), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.Pistol, new Lazy<IWeapon>(() => new Weapon(ItemNames.Pistol, (IItemSprite)itemFactory.Get(ItemNames.Pistol), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.Sword, new Lazy<IWeapon>(() => new Weapon(ItemNames.Sword, (IItemSprite)itemFactory.Get(ItemNames.Sword), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.Bazooka, new Lazy<IWeapon>(() => new Weapon(ItemNames.Bazooka, (IItemSprite)itemFactory.Get(ItemNames.Bazooka), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.Flamethrower, new Lazy<IWeapon>(() => new Weapon(ItemNames.Flamethrower, (IItemSprite)itemFactory.Get(ItemNames.Flamethrower), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.SubMachineGun, new Lazy<IWeapon>(() => new Weapon(ItemNames.SubMachineGun, (IItemSprite)itemFactory.Get(ItemNames.SubMachineGun), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.SmallElectric), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.PistolAndShield, new Lazy<IWeapon>(() => new Weapon(ItemNames.Shield, (IItemSprite)itemFactory.Get(ItemNames.Shield), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.PistolAndRedFlag, new Lazy<IWeapon>(() => new Weapon(ItemNames.RedFlag, (IItemSprite)itemFactory.Get(ItemNames.RedFlag), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.PistolAndBlueFlag, new Lazy<IWeapon>(() => new Weapon(ItemNames.BlueFlag, (IItemSprite)itemFactory.Get(ItemNames.BlueFlag), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.BlueSword, new Lazy<IWeapon>(() => new Weapon(ItemNames.BlueSword, (IItemSprite)itemFactory.Get(ItemNames.BlueSword), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.RedSword, new Lazy<IWeapon>(() => new Weapon(ItemNames.RedSword, (IItemSprite)itemFactory.Get(ItemNames.RedSword), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.NoWeaponBlue, new Lazy<IWeapon>(() => new Weapon(ItemNames.Empty, (IItemSprite)itemFactory.Get(ItemNames.Empty), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.NoWeaponGrey, new Lazy<IWeapon>(() => new Weapon(ItemNames.Empty, (IItemSprite)itemFactory.Get(ItemNames.Empty), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
            weapons.Add(WeaponType.NoWeaponRed, new Lazy<IWeapon>(() => new Weapon(ItemNames.Empty, (IItemSprite)itemFactory.Get(ItemNames.Empty), (IDirectionalSpriteImage)directionalFactor.Get(Effects.BlueProjectile), (IItemSprite)effects.Get(Effects.BlueExplosion), Properties.Resources._175267__jonccox__gun_plasma, Properties.Resources._317748__jalastram__sfx_explosion_03, 4)));
        
        }

        public IWeapon Get(WeaponType weapon)
        {
            return weapons[weapon].Value;
        }
    }
}
