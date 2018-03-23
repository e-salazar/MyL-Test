using UnityEngine;

namespace DesignPatterns {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        /* Be aware this will not prevent a non singleton constructor such as `T myT = new T();`.
         * To prevent that, add `protected T () {}` to your singleton class.*/
        private static object _lock = new object();
        private static bool _applicationIsQuitting = false;

        private static T _instance;
        public static T Instance {
            get {
                if(_applicationIsQuitting) {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed on application quit. Won't create again - returning null.");
                    return null;
                }

                lock(_lock) {
                    if(_instance == null) {
                        _instance = FindObjectOfType<T>();

                        if(FindObjectsOfType<T>().Length > 1) {
                            Debug.LogError("[Singleton] Something went really wrong - there should never be more than 1 singleton! Reopenning the scene might fix it.");
                            return _instance;
                        }

                        if(_instance == null) {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "(Singleton) " + typeof(T).ToString();

                            DontDestroyOnLoad(singleton);

                            //Debug.Log("[Singleton] An instance of " + typeof(T) + " created.");
                        }
                        else {
                            _instance.name = "(Singleton) " + typeof(T).ToString();
                            DontDestroyOnLoad(_instance);

                            //Debug.Log("[Singleton] Using instance already created of " + typeof(T));
                        }
                    }

                    return _instance;
                }
            }
        }

        public virtual void Awake() {
            if(Instance.name == "") { }//Sólo para llamar a Instance al inicio a los que están ya en escena
        }
        public void OnDestroy() {
            /* When Unity quits, it destroys objects in a random order.
             * In principle, a Singleton is only destroyed when application quits.
             * If any script calls Instance after it have been destroyed, 
             * it will create a buggy ghost object that will stay on the Editor scene
             * even after stopping playing the Application. Really bad!
             * So, this was made to be sure we're not creating that buggy ghost object.*/
            _applicationIsQuitting = true;
        }
    }
}