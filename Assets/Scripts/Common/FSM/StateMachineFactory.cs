using Zenject;

namespace Assets.Scrips.Common.FSM
{
	public class StateMachineFactory: IFactory<IStateMachine>
	{
		private readonly DiContainer _container;
		
		public StateMachineFactory(DiContainer container)
		{
			_container = container;
		}
		
		public IStateMachine Create()
		{
			return _container.Instantiate<DiStateMachine>();
		}
	}
}
