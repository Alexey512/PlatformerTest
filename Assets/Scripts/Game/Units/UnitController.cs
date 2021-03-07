using System;
using Assets.Scrips.Common.FSM;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Units
{
	public class UnitController<TModel>: MonoBehaviour, IUnit where TModel: UnitModel, new()
	{
		public TModel Model { get; protected set; } = new TModel();
		
		public KinematicObject Owner => _owner;

		[SerializeField]
		private KinematicObject _owner;

		protected IStateMachine StateMachine { get; private set; }

		public void StartMove()
		{
			StateMachine?.Start();
		}

		public T GetModel<T>() where T : UnitModel
		{
			return Model as T;
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
