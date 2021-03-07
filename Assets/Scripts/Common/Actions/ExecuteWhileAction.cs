using System;

namespace Assets.Scrips.Common.Actions
{
	public class ExecuteWhileAction: BaseAction
	{
		private readonly Func<ActionStatus> _callback;
		
		public ExecuteWhileAction(Func<ActionStatus> callback)
		{
			_callback = callback;
		}
		
		public override void Update()
		{
			var result = _callback?.Invoke();
			if (result == ActionStatus.Finished)
			{
				Status = ActionStatus.Finished;
			}
		}

		protected override void OnExecute()
		{
			if (_callback == null)
			{
				Status = ActionStatus.Finished;
			}
		}
	}
}
