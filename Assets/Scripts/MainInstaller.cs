using System;
using Assets.Scrips.Common.Actions;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Assets.Scrips.Common.Storage;
using Assets.Scrips.Common.Visual;
using Assets.Scrips.Game.Config;
using Assets.Scrips.Game.Player;
using Assets.Scrips.Game.Scenes;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Game.Player;
using UnityEngine;
using Zenject;

namespace Assets.Scrips
{
    public class MainInstaller : MonoInstaller
	{
		[SerializeField]
		private PlayerConfig _playerConfig;
		
		[SerializeField]
		private WindowRoot _windowRoot;

		[SerializeField]
		private GameObject _visualRoot;

		[SerializeField]
		private TextAsset _gameConfig;

        [SerializeField]
        private VisualFactory _visualFactory;
        
        [SerializeField]
        private PrefabsFactory _prefabsFactory;
        
        [SerializeField]
        private WindowFactory _windowFactory;

		public override void InstallBindings()
		{
			Container.Bind<PlayerConfig>().FromInstance(_playerConfig);
			
			Container.Bind<StateMachineFactory>().AsSingle();

			Container.Bind<IInputManager>().To<InputManager>().FromNewComponentOnRoot().AsSingle();

            Container.Bind<IDataStorage>().To<DataStorage>().AsSingle();
			Container.Bind<IGameConfig>().FromInstance(new GameConfig(_gameConfig));

			Container.Bind(typeof(IActionsSequencer), typeof(ITickable)).To<ActionsSequencer>().AsSingle();

            Container.Bind<IUIManager>().To<UIManager>().AsSingle();
            Container.Bind<IWindowRoot>().To<WindowRoot>().FromInstance(_windowRoot);
            Container.Bind<VisualRoot>().FromNewComponentOn(_visualRoot).AsSingle();

            Container.Bind<IVisualFactory>().To<VisualFactory>().FromInstance(_visualFactory).AsSingle();
            Container.Bind<IPrefabsFactory>().To<PrefabsFactory>().FromInstance(_prefabsFactory).AsSingle();
            Container.Bind<IWindowFactory>().To<WindowFactory>().FromInstance(_windowFactory).AsSingle();
	        Container.QueueForInject(_visualFactory);
            Container.QueueForInject(_prefabsFactory);
            Container.QueueForInject(_windowFactory);

            Container.Bind<PlayerFactory>().AsSingle();

            Container.Bind(typeof(GameStatesManager), typeof(ITickable)).To<GameStatesManager>().AsSingle();

            Container.Resolve<GameStatesManager>().Start();
		}
	}
}
