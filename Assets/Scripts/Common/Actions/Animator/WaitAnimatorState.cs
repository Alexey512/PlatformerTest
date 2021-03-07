namespace Assets.Scrips.Common.Actions.Animator
{
	public class WaitAnimatorState: BaseAction
	{
		private readonly UnityEngine.Animator _animator;
		
		private readonly string _tagName;

		public WaitAnimatorState(UnityEngine.Animator animator, string tagName)
		{
			_animator = animator;
			_tagName = tagName;
		}
		public override void Update()
		{
			CheckState();
		}
		
		protected override void OnExecute()
		{
			if (_animator == null)
			{
				Status = ActionStatus.Finished;
				return;
			}

			CheckState();
		}

		private void CheckState()
		{
			if (_animator == null)
				return;

			if (_animator.GetCurrentAnimatorStateInfo(0).IsTag(_tagName))
			{
				Status = ActionStatus.Finished;
			}
		}
	}
}
