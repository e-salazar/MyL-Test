using UnityEngine;

namespace ScriptableObjects.MythsAndLegends.Cards {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Tipo))]
    public class Tipo : ScriptableObject {
        public string nombre;
    }
}