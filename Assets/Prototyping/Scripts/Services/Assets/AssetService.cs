using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace PinBallRunner.Prototyping.Scripts.Services.Assets
{
    public class AssetService : IAssetService
    {
        private readonly Dictionary<string, AsyncOperationHandle> _loadedCashe = new();

        public async Task<T> Load<T>(string address) where T : class
        {
            if (_loadedCashe.TryGetValue(address, out AsyncOperationHandle cashe))
                return cashe.Result as T;

            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);

            handle.Completed += completeHandle => { _loadedCashe[address] = completeHandle; };

            return await handle.Task;
        }

        public async Task<T> Load<T>(AssetReference assetReference) where T : class
        {
            return await Load<T>(assetReference.AssetGUID);
        }

        public async Task<GameObject> InstantiateAsync(GameObject gameObject, Vector3 position) 
            => await Addressables.InstantiateAsync(gameObject, position, Quaternion.identity, null, false).Task;

        public async Task<GameObject> InstantiateAsync(GameObject gameObject, Transform parent) 
            => await Addressables.InstantiateAsync(gameObject, parent, false).Task;

        public async Task<GameObject> InstantiateAsync(string address, Vector3 position)
        {
            GameObject gameObject = await Load<GameObject>(address);
            return await InstantiateToPosition(gameObject, position).Task;
        }

        public async Task<GameObject> InstantiateAsync(string address, Transform parent)
        {
            GameObject gameObject = await Load<GameObject>(address);
            return await IntantiateToParent(gameObject, parent).Task;
        }

        public async Task<GameObject> InstantiateAsync(AssetReference assetReference, Vector3 position)
        {
            GameObject gameObject = await Load<GameObject>(assetReference);
            return await InstantiateToPosition(gameObject, position).Task;
        }

        public async Task<GameObject> InstantiateAsync(AssetReference assetReference, Transform parent)
        {
            GameObject gameObject = await Load<GameObject>(assetReference);
            return await IntantiateToParent(gameObject, parent).Task;
        }
        public void RealeaseInstance(GameObject gameObject)
        {
            Addressables.ReleaseInstance(gameObject);
        }

        public void CleanUp()
        {
            foreach(AsyncOperationHandle handle in _loadedCashe.Values)
            {
                Addressables.Release(handle);
            }

            _loadedCashe.Clear();
        }

        private static AsyncOperationHandle<GameObject> IntantiateToParent(GameObject gameObject, Transform parent) 
            => Addressables.InstantiateAsync(gameObject, parent);

        private static AsyncOperationHandle<GameObject> InstantiateToPosition(GameObject gameObject, Vector3 position) 
            => Addressables.InstantiateAsync(gameObject, position, Quaternion.identity);
    }
}
