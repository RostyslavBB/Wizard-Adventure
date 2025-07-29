using Game.Handlers;
using Game.Interfaces;
using Game.Player;
using NaughtyAttributes;
using Zenject;
using UnityEngine;

namespace Game.DI
{
    public class GameInstaller : MonoInstaller
    {
        [Required, SerializeField] private PlayerView _playerView;
        [Required, SerializeField] private CharacterController _characterController;

        public override void InstallBindings()
        {
            PlayerBinds();
        }

        private void PlayerBinds()
        {
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerView>().FromInstance(_playerView).AsSingle();

            Container.Bind<CharacterController>().FromInstance(_characterController).AsSingle();

            Container.Bind<IPlayerInputHandler>().To<PlayerInputHandler>().AsSingle();

            Container.Bind<IPlayerPresenter>().To<PlayerPresenter>().AsSingle().NonLazy();
        }
    }
}
