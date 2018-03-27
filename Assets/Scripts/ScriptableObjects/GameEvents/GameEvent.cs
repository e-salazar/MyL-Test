using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Events {
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(GameEvent), fileName = nameof(GameEvent))]
    public class GameEvent : ScriptableObject {
        private readonly List<GameEventListener> _eventListeners = new List<GameEventListener>();

        public void Invoke() {
            for(int i = this._eventListeners.Count - 1; i >= 0; i--) {
                this._eventListeners[i].OnEventRaised();
            }
        }

        public void AddListener(GameEventListener listener) {
            if(!this._eventListeners.Contains(listener)) {
                this._eventListeners.Add(listener);
            }
        }
        public void RemoveListener(GameEventListener listener) {
            if(this._eventListeners.Contains(listener)) {
                this._eventListeners.Remove(listener);
            }
        }
    }
}