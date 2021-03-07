using System;
using Assets.Scrips.Common.Actions;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;
using Assets.Scrips.Game.Player;
using UnityEngine;
using Zenject;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scripts.Game.Player
{
	public class DeathState: PlayerState
	{
		[Inject]
		private IActionsSequencer _actionsSequencer;

		public DeathState(PlayerController unit) : base(PlayerStateType.Death, unit)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			Unit.Owner.Velocity = Vector2.zero;
			
			PlayDeathEffect(() =>
			{
				Owner.SwitchState(PlayerStateType.Idle);
			});
		}

		private void PlayDeathEffect(Action complete)
		{
			var deathEffect = new SequenceAction();
			for (int i = 0; i < 3; i++)
			{
				deathEffect.Add(new ScaleToAction(Unit.transform, Vector3.one * 1.5f, 0.15f));
				deathEffect.Add(new ScaleToAction(Unit.transform, Vector3.one, 0.15f));
			}
			_actionsSequencer.Execute(deathEffect, action =>
			{
				complete?.Invoke();
			});
		}
	}
}
