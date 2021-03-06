using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.Utils;
using Assets.Scrips.Common.Visual;
using Assets.Scrips.Game.Player;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Common.Visual
{
	public class ControllerFactory<TView, TController>: IFactory<TController> where TView : MonoBehaviour where TController : class, IController<TView>
	{
		private readonly DiContainer _container;

		private readonly IPrefabsFactory _prefabsFactory;

		public ControllerFactory(IPrefabsFactory prefabsFactory, DiContainer container)
		{
			_prefabsFactory = prefabsFactory;
			_container = container;
		}		
		
		public virtual TController Create()
		{
			var nameAttribute = typeof(TController).GetAttribute<ViewNameAttribute>();
			if (nameAttribute == null)
			{
				Debug.LogAssertion($"Not find ViewName attribute in type {typeof(TController)}");
				return null;
			}

			var view = _prefabsFactory.Create<TView>(nameAttribute.Name);
			if (view == null)
			{
				Debug.LogAssertion($"Not find view {nameAttribute.Name}");
				return null;
			}

			var controller = _container.Instantiate<TController>();
			if (controller == null)
			{
				return null;
			}

			controller.View = view;
			
			return controller;
		}
	}
}
