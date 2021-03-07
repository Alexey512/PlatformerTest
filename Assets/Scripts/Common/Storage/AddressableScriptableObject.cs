using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Assets.Scrips.Common.Storage
{
	public class AddressableScriptableObject<T>: IAddressableScriptableObject where T: ScriptableObject
	{
		public float Progress => _handle.PercentComplete;

		public bool IsComplete => _handle.IsDone;

		public T Data => _data;
		

		[SerializeField]
		private AssetReference _asset;

		private T _data;

		private readonly DiContainer _container;

		private AsyncOperationHandle<T> _handle;

		public AddressableScriptableObject(DiContainer container)
		{
			_container = container;
		}

		public async void Load()
		{
			if (_asset == null || _handle.IsValid())
				return;
		
			_handle = _asset.LoadAssetAsync<T>();
			await _handle.Task;

			if (_handle.Status == AsyncOperationStatus.Succeeded)
			{
				_data = _handle.Result;
			}
		}
	}
}
