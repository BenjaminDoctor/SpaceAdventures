using SpaceAdventure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceAdventure.Common;

namespace SpaceAdventure.Sprite
{
    public class FullRowCharacterFactory<T> : ISpriteFactory<T>
    {
        private readonly int NumberOfFrames = 2;

        public ISpriteImage<T> Get(CharacterType sprite, CharacterState state)
        {
            return (ISpriteImage<T>) new CharacterSprite<int>((int)sprite, (int)state * NumberOfFrames);
        }

        public ISpriteImage<T> Get(CharacterType sprite, ItemNames item)
        {
            return this.Get(sprite, convertItemToState(item));
        }

        private CharacterState convertItemToState(ItemNames item)
        {
            IDictionary<ItemNames, CharacterState> stateMapper = new Dictionary<ItemNames, CharacterState>();
            stateMapper.Add(ItemNames.Empty, CharacterState.NoWeapon);
            stateMapper.Add(ItemNames.Rifle, CharacterState.Rifle);
            stateMapper.Add(ItemNames.Shotgun, CharacterState.Shotgun);
            stateMapper.Add(ItemNames.Pistol, CharacterState.Pistol);
            stateMapper.Add(ItemNames.Sword, CharacterState.Sword);
            stateMapper.Add(ItemNames.Bazooka, CharacterState.Bazooka);
            stateMapper.Add(ItemNames.Flamethrower, CharacterState.Flamethrower);
            stateMapper.Add(ItemNames.SubMachineGun, CharacterState.SubmachineGun);
            stateMapper.Add(ItemNames.Shield, CharacterState.PistolAndShield);
            stateMapper.Add(ItemNames.RedFlag, CharacterState.PistolAndRedFlag);
            stateMapper.Add(ItemNames.BlueFlag, CharacterState.PistolAndBlueFlag);
            stateMapper.Add(ItemNames.BlueSword, CharacterState.BlueSword);
            stateMapper.Add(ItemNames.RedSword, CharacterState.RedSword);

            return stateMapper[item];
        }


    }
}
