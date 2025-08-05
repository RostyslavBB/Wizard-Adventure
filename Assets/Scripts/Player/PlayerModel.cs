using Game.Interfaces.Player;
using System;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerModel : IPlayerModel
    {
        [Inject] public PlayerSettings PlayerSetting {  get; private set; }

        [Serializable]
        public class PlayerSettings
        {
            [field: SerializeField] public float MoveSpeed { get; private set; }
            [field: SerializeField] public float JumpHeight { get; private set; }
        }
    }
}
