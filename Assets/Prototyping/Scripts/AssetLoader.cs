using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

namespace PinBallRunner.Prototyping.Scripts
{
    public static class AssetLoader
    {
        public static async Task<T> LoadAsync<T>(string address) where T : Object
        {
            UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);
            return await handle.Task;
        }

        public static void Unload<T>(T obj)
        {
            Addressables.Release<T>(obj);
        }
    }
}
