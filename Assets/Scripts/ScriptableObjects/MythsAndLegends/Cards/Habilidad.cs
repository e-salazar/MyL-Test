using UnityEngine;

namespace ScriptableObjects.MythsAndLegends.Cards {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Habilidad))]
    public class Habilidad : ScriptableObject {
        public Carta.Habilidad tipo;
        public string nombre;
        [TextArea] public string descripcion;
    }
}