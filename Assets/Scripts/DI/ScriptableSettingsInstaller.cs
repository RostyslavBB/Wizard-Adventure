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

        public override void InstallBindings()
        {
            Container.BindInstance(_playerModelSettings).IfNotBound();
        }
    }
}