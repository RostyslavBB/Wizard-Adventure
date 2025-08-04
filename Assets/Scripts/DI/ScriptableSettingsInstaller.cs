using Game.Camera;
using Game.Player;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Game.DI
{
    [CreateAssetMenu(fileName = "ScriptableSettingsInstaller", menuName = "Installers/ScriptableSettingsInstaller")]
    public class ScriptableSettingsInstaller : ScriptableObjectInstaller<ScriptableSettingsInstaller>
    {
        [Foldout("Player"), SerializeField] private PlayerModel.PlayerSettings _playerModelSettings;
        [Foldout("Player"), SerializeField] private PlayerView.ViewSettings _viewSettings;
        [Foldout("Player"), SerializeField] private PlayerMovement.GravitySettings _gravitySettings;

        [SerializeField] private CameraRotator.CameraSettings _cameraSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerModelSettings).IfNotBound();
            Container.BindInstance(_viewSettings).IfNotBound();
            Container.BindInstance(_gravitySettings).IfNotBound();

            Container.BindInstance(_cameraSettings).IfNotBound();
        }
    }
}