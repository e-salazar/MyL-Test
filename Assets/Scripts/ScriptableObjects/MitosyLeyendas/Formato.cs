using UnityEngine;

namespace ScriptableObjects.MitosyLeyendas {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Formato), fileName = nameof(Formato))]
    public class Formato : ScriptableObjectSource {
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