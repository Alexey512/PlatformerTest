
namespace Assets.Scrips.Common.Actions
{
	public class ParallelAction: CompositeAction
	{
		public override void Update()
		{
			if (Status != ActionStatus.Active)
				return;
			
			Status = ActionStatus.Finished;
			
			foreach (var child in Childs)
			{
				child.Update();
				if (child.Status != ActionStatus.Finished)
				{
					Status = ActionStatus.Active;
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
