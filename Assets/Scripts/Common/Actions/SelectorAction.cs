
namespace Assets.Scrips.Common.Actions
{
	public class SelectorAction: CompositeAction
	{
		public override void Update()
		{
			if (Status != ActionStatus.Active)
				return;
			
			foreach (var child in Childs)
			{
				child.Update();
				if (child.Status == ActionStatus.Finished)
				{
					Status = ActionStatus.Finished;
					return;
				}
			}
		}		

		protected override void OnExecute()
		{
			foreach (var child in Childs)
			{
				child.Execute();
			}

			Status = ActionStatus.Active;
		}
	}
}
