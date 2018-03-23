using UnityEngine;
using System;
using System.Reflection;
using System.ComponentModel;

public static class Extensions {
    /*GameObject*/
    public static void SetVisible(this GameObject gameObject) {
        gameObject.SetActive(true);
    }
    public static void SetInvisible(this GameObject gameObject) {
        gameObject.SetActive(false);
    }
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : UnityEngine.Component {
        T result = gameObject.GetComponent<T>();
        if(result == null) {
            result = gameObject.AddComponent<T>();
        }
        return result;
    }
    /*Transform*/
    public static void SetVisible(this Transform transform) {
        transform.gameObject.SetVisible();
    }
    public static void SetInvisible(this Transform transform) {
        transform.gameObject.SetInvisible();
    }
    public static T GetOrAddComponent<T>(this Transform transform) where T : UnityEngine.Component {
        T result = transform.GetComponent<T>();
        if(result == null) {
            result = transform.gameObject.AddComponent<T>();
        }
        return result;
    }
    /*int*/
    public static string ToStringInt(this int integer) {
        return string.Format("{0:n0}", integer);
    }
}