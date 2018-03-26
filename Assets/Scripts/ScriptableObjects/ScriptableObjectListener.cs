using UnityEngine;
using UnityEngine.Events;

public class ScriptableObjectListener : MonoBehaviour {
    [SerializeField]
    private ScriptableObjectSource _scriptableObjectSource;
    public ScriptableObjectSource scriptableObjectSource {
        get {
            return this._scriptableObjectSource;
        }
        set {
            if(this._scriptableObjectSource != value) {
                if(this._scriptableObjectSource != null) {
                    this._scriptableObjectSource.RemoveListener(this);
                }
                this._scriptableObjectSource = value;
                if(this.isActiveAndEnabled) {
                    this._scriptableObjectSource.AddListener(this);
                    OnScriptableObjectChange();
                }
            }
        }
    }

    public UnityEvent onScriptableObjectChanged;

    public void OnEnable() {
        if(this.scriptableObjectSource != null) {
            OnScriptableObjectChange();
            this.scriptableObjectSource.AddListener(this);
        }
    }
    public void OnDisable() {
        if(this.scriptableObjectSource != null) {
            this.scriptableObjectSource.RemoveListener(this);
        }
    }

    public void OnScriptableObjectChange() {
        this.onScriptableObjectChanged.Invoke();
    }
}