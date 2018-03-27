using UnityEngine;

namespace ScriptableObjects.MitosyLeyendas.Cartas {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Habilidad), fileName = nameof(Habilidad))]
    public class Habilidad : ScriptableObjectSource {
        [SerializeField]
        private Carta.Habilidad _tipo;
        public Carta.Habilidad tipo {
            get {
                return this._tipo;
            }
            set {
                this._tipo = value;
                OnScriptableObjectChange();
            }
        }

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

        [SerializeField][TextArea]
        private string _descripcion;
        public string descripcion {
            get {
                return this._descripcion;
            }
            set {
                this._descripcion = value;
                OnScriptableObjectChange();
            }
        }
    }
}