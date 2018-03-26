using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.Events {
    public class GameEventListener : MonoBehaviour {
        [Tooltip("Event to register with.")]
        public GameEvent gameEvent;
        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent onInvoked;

        private void OnEnable() {
            this.gameEvent.AddListener(this);
        }
        private void OnDisable() {
            this.gameEvent.RemoveListener(this);
        }

        public void OnEventRaised() {
            this.onInvoked.Invoke();
        }
    }
}