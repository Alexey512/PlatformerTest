
namespace Assets.Scrips.Common.Actions
{
	public enum ActionStatus
	{
		Inactive,
		Active,
		Finished,
	}
	
	public interface IAction
	{
		ActionStatus Status { get; }

		void Execute();

		void Update();

		void Finish();
	}
}
