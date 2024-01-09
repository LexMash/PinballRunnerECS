using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace PinBallRunner.Prototyping.Scripts.Services.Assets
{
    public interface IAssetService : IService
    {
        Task<T> Load<T>(string address) where T : class;
        Task<T> Load<T>(AssetReference assetReference) where T : class; 
        Task<GameObject> InstantiateAsync(GameObject gameObject, Vector3 position);
        Task<GameObject> InstantiateAsync(GameObject gameObject, Transform parent);
        Task<GameObject> InstantiateAsync(string address, Vector3 position);
        Task<GameObject> InstantiateAsync(string address, Transform parent);
        Task<GameObject> InstantiateAsync(AssetReference assetReference, Vector3 postion);
        Task<GameObject> InstantiateAsync(AssetReference assetReference, Transform parent);
        void RealeaseInstance(GameObject gameObject);
        void CleanUp();
    }
}
