using UnityEngine;

namespace ScriptableObjects.MythsAndLegends.Cards {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Frecuencia))]
    public class Frecuencia : ScriptableObject {
        public string nombre;
    }
}