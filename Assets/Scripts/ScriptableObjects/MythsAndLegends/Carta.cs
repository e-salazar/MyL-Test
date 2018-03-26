using Attributes;
using System;
using UnityEngine;

namespace ScriptableObjects.MythsAndLegends {
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

        public string nombre;
        public Sprite imagen;
        public int idEnLaEdicion;
        [TextArea] public string textoEpico;
        public int coste;
        public int fuerza;
        public Cards.Tipo tipo;
        public Cards.Raza raza;
        public Cards.Frecuencia frecuencia;
        public Edicion edicion;
        [EnumFlag(2)] public Formato formato;
        [EnumFlag(3)] public Habilidad habilidades = 0;
        [TextArea] public string efecto;
        public Sprite reverso;
    }
}