using UnityEngine;

namespace ScriptableObjects.MythsAndLegends {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Edicion))]
    public class Edicion : ScriptableObject {
        public string nombre;
        public string código;
        public int totalCartas;
    }
}