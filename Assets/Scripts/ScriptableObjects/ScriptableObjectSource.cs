using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableObjectSource : ScriptableObject {
    protected readonly List<ScriptableObjectListener> _listeners = new List<ScriptableObjectListener>();

    public void AddListener(ScriptableObjectListener listener) {
        if(!this._listeners.Contains(listener)) {
            this._listeners.Add(listener);
        }
        //Debug.Log(this.name + ": AddListener (" + this._listeners.Count + " listeners)");
    }
    public void RemoveListener(ScriptableObjectListener listener) {
        if(this._listeners.Contains(listener)) {
            this._listeners.Remove(listener);
        }
        //Debug.Log(this.name + ": RemoveListener (" + this._listeners.Count + " listeners)");
    }

    private void OnValidate() {
        OnScriptableObjectChange();
    }
    protected void OnScriptableObjectChange() {
        //Debug.Log(this.name + ": OnValidate (" + this._listeners.Count + " listeners)");
        for(int i = this._listeners.Count - 1; i >= 0; i--) {
            this._listeners[i].OnScriptableObjectChange();
        }
    }
}