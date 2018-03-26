using UnityEngine;
using UnityEngine.UI;

namespace Scene4.Windows {
    public class CardInfoWindow : MonoBehaviour {
        private Card _card;
        public Text nombreText;
        public Text edicionText;
        public Text idEnLaEdicionText;
        public Text textoEpicoText;
        public Text efectoText;
        public Text tipoText;
        public Text frecuenciaText;
        public Text formatoText;
        public Text habilidadesText;
        public Text razaText;
        public Text costeText;
        public Text fuerzaText;
        public Image frontalImage;
        public Image reversoImage;

        public ScriptableObjects.MythsAndLegends.Cards.Tipo tipoAliado;
        public ScriptableObjects.MythsAndLegends.Cards.Tipo tipoOro;

        public void Load(Card card) {
            this._card = card;
            this.nombreText.text = "<b>Nombre</b>: " + this._card.cartaScriptableObject.nombre;
            this.edicionText.text = "<b>Edición</b>: " + this._card.cartaScriptableObject.edicion.nombre;
            this.idEnLaEdicionText.text = "<b>ID en la Edición</b>: " + this._card.cartaScriptableObject.idEnLaEdicion;
            this.textoEpicoText.text = "<b>Texto épico</b>: " + this._card.cartaScriptableObject.textoEpico;
            this.efectoText.text = "<b>Efecto</b>: " + this._card.cartaScriptableObject.efecto;
            this.tipoText.text = "<b>Tipo</b>: " + this._card.cartaScriptableObject.tipo.nombre;
            this.frecuenciaText.text = "<b>Frecuencia</b>: " + this._card.cartaScriptableObject.frecuencia.nombre;
            this.formatoText.text = "<b>Formato</b>: " + this._card.cartaScriptableObject.formato;
            this.habilidadesText.text = "<b>Habilidades</b>: " + (this._card.cartaScriptableObject.habilidades == 0 ? "-" : this._card.cartaScriptableObject.habilidades.ToString());

            if(this._card.cartaScriptableObject.tipo == this.tipoAliado) {
                this.razaText.gameObject.SetActive(true);
                this.fuerzaText.gameObject.SetActive(true);
                this.razaText.text = "<b>Raza</b>: " + this._card.cartaScriptableObject.raza.nombre;
                this.fuerzaText.text = "<b>Fuerza</b>: " + this._card.cartaScriptableObject.fuerza;
            }
            else {
                this.razaText.gameObject.SetActive(false);
                this.fuerzaText.gameObject.SetActive(false);
                this.razaText.text = "";
                this.fuerzaText.text = "";
            }

            if(this._card.cartaScriptableObject.tipo == this.tipoOro) {
                this.costeText.gameObject.SetActive(false);
                this.costeText.text = "";
            }
            else {
                this.costeText.gameObject.SetActive(true);
                this.costeText.text = "<b>Coste</b>: " + this._card.cartaScriptableObject.coste;
            }

            this.frontalImage.sprite = this._card.cartaScriptableObject.imagen;
            this.reversoImage.sprite = this._card.cartaScriptableObject.reverso;
        }

        public void OnClick1MasCosteButton() {
            this._card.cartaScriptableObject.coste++;
            Load(this._card);
        }
        public void OnClick1MenosCosteButton() {
            this._card.cartaScriptableObject.coste--;
            Load(this._card);
        }
        public void OnClick1MasFuerzaButton() {
            this._card.cartaScriptableObject.fuerza++;
            Load(this._card);
        }
        public void OnClick1MenosFuerzaButton() {
            this._card.cartaScriptableObject.fuerza--;
            Load(this._card);
        }

        public void Show() {
            this.gameObject.SetActive(true);
        }
        public void Hide() {
            this.gameObject.SetActive(false);
        }
    }
}