using Game.Handlers;
using Game.Interfaces;
using Game.Player;
using NaughtyAttributes;
using Zenject;
using UnityEngine;
using Game.Camera;
using Game.Coin;

namespace Game.DI
{
    public class GameInstaller : MonoInstaller
    {
        [Required, SerializeField] private PlayerView _playerView;
        [Required, SerializeField] private CharacterController _characterController;
        [Required, SerializeField] private Transform _camera;
        [Required, SerializeField] private CoinManager _coinController;

        public override void InstallBindings()
        {
            PlayerBinds();

            CoinBinds();
        }

        private void PlayerBinds()
        {
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerView>().FromInstance(_playerView).AsSingle();

            Container.Bind<CharacterController>().FromInstance(_characterController).AsSingle();

            Container.Bind<Transform>().WithId("Camera").FromInstance(_camera).AsSingle();

            Container.Bind<IPlayerInputHandler>().To<PlayerInputHandler>().AsSingle();

            Container.Bind<IPlayerPresenter>().To<PlayerPresenter>().AsSingle().NonLazy();

            Container.Bind<IPlayerMovement>().To<PlayerMovement>().AsSingle().NonLazy();

            Container.Bind<ICameraRotator>().To<CameraRotator>().AsSingle().NonLazy();
        }

        private void CoinBinds()
        {
            Container.BindInterfacesAndSelfTo<CoinPresenter>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CoinModel>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CoinUI>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CoinParticle>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CoinObject>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CoinManager>().FromInstance(_coinController).AsSingle();
        }
    }
}
