using UnityEngine;

namespace ScriptableObjects.MythsAndLegends.Cards {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Raza))]
    public class Raza : ScriptableObject {
        public string nombre;
    }
}