using UnityEngine;

namespace ScriptableObjects.MitosyLeyendas.Cartas {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Tipo), fileName = nameof(Tipo))]
    public class Tipo : ScriptableObjectSource {
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