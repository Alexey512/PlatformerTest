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
		[SerializeField]
		private AssetReference _asset;

		public float Progress => _handle.PercentComplete;

		public bool IsComplete => _handle.IsDone;

		public T Data => _data;

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

		/*
		public IEnumerator Initialize(AssetReference assetRef, Action<float> progressCallback = null, Action completeCallback = null)
		{
			_progress = 0f;
			
			var handle = assetRef.LoadAssetAsync<T>();
			yield return null;
 
			while (!handle.IsDone)
			{
				_progress = handle.PercentComplete;
				progressCallback?.Invoke(handle.PercentComplete);
				
				yield return null;
			}

			if (handle.Status == AsyncOperationStatus.Succeeded)
			{
				_progress = 1f;
				_container.Inject(handle.Result);
				Owner = handle.Result;
			}

			completeCallback?.Invoke();
		}*/
	}
}
