
namespace Assets.Scrips.Common.Visual
{
	public interface IFactory
	{
		float Progress { get; }

		bool IsComplete { get; }
		
		void Load();
	}
}
