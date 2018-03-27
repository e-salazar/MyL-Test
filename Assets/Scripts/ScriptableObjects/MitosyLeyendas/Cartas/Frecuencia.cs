using UnityEngine;

namespace ScriptableObjects.MitosyLeyendas.Cartas {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Frecuencia), fileName = nameof(Frecuencia))]
    public class Frecuencia : ScriptableObjectSource {
        [SerializeField]
        private string _nombre;
        public string nombre {
            get {
                return this._nombre;
            }
            set {
                this._nombre = value;
                OnScriptableObjectChange();
            }
        }
    }
}