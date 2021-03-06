using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Game.Player;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Units
{
	public class UnitController: MonoBehaviour
	{
		public KinematicObject Owner => _owner;

		[SerializeField]
		private KinematicObject _owner;

		protected IStateMachine StateMachine { get; private set; }

		public void StartMove()
		{
			StateMachine?.Start();
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		[Inject]
		private void Construct(StateMachineFactory fsm)
		{
			StateMachine = fsm.Create();

			OnInitialize();
		}

		private void Update()
		{
			StateMachine?.Update();

			OnUpdate();
		}
	}
}
