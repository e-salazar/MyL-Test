using DesignPatterns;
using UnityEngine;

namespace Interfaces {
    public interface IPoolable<T> where T : MonoBehaviour, IPoolable<T> {
        ObjectPool<T> parentPool { get; set; }
        void Reset();
        void Store();
    }
}