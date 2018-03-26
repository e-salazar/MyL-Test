using Components;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Utilities;

namespace Scene4 {
    public class Card : MonoBehaviour, IPointerClickHandler {
        public ScriptableObjects.MythsAndLegends.Carta cartaScriptableObject;
        public MeshRenderer frontMeshRenderer;
        public MeshRenderer backMeshRenderer;
        public new Rigidbody rigidbody;
        public TextMesh costeTextMesh1;
        public TextMesh costeTextMesh2;

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

        public void Load(ScriptableObjects.MythsAndLegends.Carta cartaScriptableObject) {
            this.cartaScriptableObject = cartaScriptableObject;
            //this.scriptableObjectListener.scriptableObjectSource = cartaScriptableObject;
        }

        public void OnPointerClick(PointerEventData eventData) {
            this.onClick.Invoke();
        }
        public void OnScriptableObjectChange() {
            this.frontMeshRenderer.material.mainTexture = cartaScriptableObject.imagen.texture;
            this.backMeshRenderer.material.mainTexture = cartaScriptableObject.reverso.texture;

            this.costeTextMesh1.text = this.cartaScriptableObject.coste.ToString();
            this.costeTextMesh2.text = this.cartaScriptableObject.coste.ToString();
        }

        private void OnValidate() {
            //Editor only
            //Para depurar en modo editor con sólo arrastrar un ScriptableObject "Carta" (en la carpeta Assets/ScriptableObjects/Cartas), lanza una advertencia, pero es sólo para depurar
            if(this.cartaScriptableObject == null) { return; }

            this.frontMeshRenderer.material.mainTexture = cartaScriptableObject.imagen.texture;
            this.backMeshRenderer.material.mainTexture = cartaScriptableObject.reverso.texture;
        }
        private void OnBecameInvisible() {
            this.gameObject.SetActive(false);
        }
    }
}