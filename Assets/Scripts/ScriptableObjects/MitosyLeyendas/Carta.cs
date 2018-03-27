using Attributes;
using System;
using UnityEngine;

namespace ScriptableObjects.MitosyLeyendas {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(Carta), fileName = nameof(Carta))]
    public class Carta : ScriptableObjectSource {
        [Flags]
        public enum Habilidad {
            Única = 1 << 0,
            Furia = 1 << 1,
            Errante = 1 << 2,
            Mercenario = 1 << 3,
            Espectral = 1 << 4,
            Retador = 1 << 5,
            Imbloqueable = 1 << 6,
            Exhumar = 1 << 7,
            Guardián = 1 << 8,
            Luz = 1 << 9,
            Oscuridad = 1 << 10,
            Indestructible = 1 << 11,
            Indesterrable = 1 << 12,
            Alimentar = 1 << 13,
            Traición = 1 << 14,
        }
        [Flags]
        public enum Formato {
            Unificado = 1 << 0,
            UnificadoInfantería = 1 << 1,
            UnificadoÚnico = 1 << 2,
            Imperio = 1 << 3,
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

        [SerializeField]
        private Sprite _imagen;
        public Sprite imagen {
            get {
                return this._imagen;
            }
            set {
                this._imagen = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField]
        private int _idEnLaEdicion;
        public int idEnLaEdicion {
            get {
                return this._idEnLaEdicion;
            }
            set {
                this._idEnLaEdicion = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField][TextArea]
        private string _textoEpico;
        public string textoEpico {
            get {
                return this._textoEpico;
            }
            set {
                this._textoEpico = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField]
        private int _coste;
        public int coste {
            get {
                return this._coste;
            }
            set {
                this._coste = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField]
        private int _fuerza;
        public int fuerza {
            get {
                return this._fuerza;
            }
            set {
                this._fuerza = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField]
        private Cartas.Tipo _tipo;
        public Cartas.Tipo tipo {
            get {
                return this._tipo;
            }
            set {
                this._tipo = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField]
        private Cartas.Raza _raza;
        public Cartas.Raza raza {
            get {
                return this._raza;
            }
            set {
                this._raza = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField]
        private Cartas.Frecuencia _frecuencia;
        public Cartas.Frecuencia frecuencia {
            get {
                return this._frecuencia;
            }
            set {
                this._frecuencia = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField]
        private Edicion _edicion;
        public Edicion edicion {
            get {
                return this._edicion;
            }
            set {
                this._edicion = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField][EnumFlag(2)]
        private Formato _formato;
        public Formato formato {
            get {
                return this._formato;
            }
            set {
                this._formato = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField][EnumFlag(3)]
        private Habilidad _habilidades = 0;
        public Habilidad habilidades {
            get {
                return this._habilidades;
            }
            set {
                this._habilidades = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField][TextArea]
        private string _efecto;
        public string efecto {
            get {
                return this._efecto;
            }
            set {
                this._efecto = value;
                OnScriptableObjectChange();
            }
        }

        [SerializeField]
        private Sprite _reverso;
        public Sprite reverso {
            get {
                return this._reverso;
            }
            set {
                this._reverso = value;
                OnScriptableObjectChange();
            }
        }
    }
}