using UnityEngine;

namespace ScriptableObjects.MitosyLeyendas.Cartas {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Raza), fileName = nameof(Raza))]
    public class Raza : ScriptableObjectSource {
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