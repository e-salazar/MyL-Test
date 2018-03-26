using UnityEngine;

namespace Utilities {
    public static class Extensions {
        /*GameObject*/
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component {
            T result = gameObject.GetComponent<T>();
            if(result == null) {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }

        /*MonoBehaviour*/
        public static T GetOrAddComponent<T>(this MonoBehaviour monoBehaviour) where T : Component {
            return monoBehaviour.gameObject.GetOrAddComponent<T>();
        }

        /*Transform*/
        public static T GetOrAddComponent<T>(this Transform transform) where T : Component {
            return transform.gameObject.GetOrAddComponent<T>();
        }
        /*int*/
        public static string ToStringInt(this int integer) {
            return string.Format("{0:n0}", integer);
        }
    }
}