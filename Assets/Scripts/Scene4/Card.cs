using Components;
using ScriptableObjects.MitosyLeyendas.Cartas;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Utilities;

namespace Scene4 {
    public class Card : MonoBehaviour, IPointerClickHandler {
        public ScriptableObjects.MitosyLeyendas.Carta cartaScriptableObject;
        public MeshRenderer frontMeshRenderer;
        public MeshRenderer backMeshRenderer;
        public new Rigidbody rigidbody;
        public TextMesh costeTextMesh1;
        public TextMesh costeTextMesh2;
        public TextMesh fuerzaTextMesh;
        public Transform fuerzaTransform;
        public Tipo aliadoTipo;
        public Tipo oroTipo;

        public UnityEvent onClick = new UnityEvent();

        private Transformable _transformable;
        public Transformable transformable {
            get {
                if(this._transformable == null) {
                    this._transformable = this.GetOrAddComponent<Transformable>();
                }
                return this._transformable;
            }
        }

        private ScriptableObjectListener _scriptableObjectListener;
        public ScriptableObjectListener scriptableObjectListener {
            get {
                if(this._scriptableObjectListener == null) {
                    this._scriptableObjectListener = GetComponent<ScriptableObjectListener>();
                }
                return this._scriptableObjectListener;
            }
        }

        public void Load(ScriptableObjects.MitosyLeyendas.Carta cartaScriptableObject) {
            this.cartaScriptableObject = cartaScriptableObject;
            this.scriptableObjectListener.scriptableObjectSource = cartaScriptableObject;
        }

        public void OnPointerClick(PointerEventData eventData) {
            this.onClick.Invoke();
        }
        public void OnScriptableObjectChange() {
            this.frontMeshRenderer.material.mainTexture = cartaScriptableObject.imagen.texture;
            this.backMeshRenderer.material.mainTexture = cartaScriptableObject.reverso.texture;

            if(this.cartaScriptableObject.tipo != oroTipo) {
                this.costeTextMesh1.text = this.cartaScriptableObject.coste.ToString();
                this.costeTextMesh2.text = this.cartaScriptableObject.coste.ToString();
            }
            else {
                this.costeTextMesh1.text = "";
                this.costeTextMesh2.text = "";
            }

            if(this.cartaScriptableObject.tipo == aliadoTipo) {
                this.fuerzaTransform.gameObject.SetActive(true);
                this.fuerzaTextMesh.text = this.cartaScriptableObject.fuerza.ToString();
            }
            else {
                this.fuerzaTransform.gameObject.SetActive(false);
                this.fuerzaTextMesh.text = "";
            }
        }

        private void OnValidate() {
            //Editor only
            //Para depurar en modo editor con sólo arrastrar un ScriptableObject "Carta" (en la carpeta Assets/ScriptableObjects/Cartas), lanza una advertencia, pero es sólo para depurar
            /*if(this.cartaScriptableObject != null) {
                this.frontMeshRenderer.material.mainTexture = cartaScriptableObject.imagen.texture;
                this.backMeshRenderer.material.mainTexture = cartaScriptableObject.reverso.texture;
            }*/
        }
        private void OnBecameInvisible() {
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}