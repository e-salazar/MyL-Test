using UnityEngine;

namespace ScriptableObjects.MitosyLeyendas {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Edicion), fileName = nameof(Edicion))]
    public class Edicion : ScriptableObjectSource {
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

        [SerializeField]
        private string _codigo;
        public string codigo {
            get {
                return this._codigo;
            }
            set {
                this._codigo = value;
                OnScriptableObjectChange();
            }
        }
    }
}