using _Scripts.Controllers;
using _Scripts.Views;
using Models;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerView;
        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle();
            Container.Bind<PlayerController>().AsSingle().NonLazy();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
        }
    }
}