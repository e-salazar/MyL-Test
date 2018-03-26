using UnityEngine;

namespace ScriptableObjects.MythsAndLegends {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Formato), fileName = nameof(Formato))]
    public class Formato : ScriptableObjectSource {
        public string nombre;
    }
}