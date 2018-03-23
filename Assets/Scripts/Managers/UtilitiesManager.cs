using DesignPatterns;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UtilitiesManager : Singleton<UtilitiesManager> {
    public void DelayedFunction(UnityAction function, float delay) {
        StartCoroutine(CorrutinaDelayedFunction(function, delay));
    }
    public void DelayedFunction(UnityAction<bool> function, float delay, bool param1) {
        StartCoroutine(CorrutinaDelayedFunction(function, delay, param1));
    }
    public void DelayedFunction(UnityAction<float> function, float delay, float param1) {
        StartCoroutine(CorrutinaDelayedFunction(function, delay, param1));
    }
    public void DelayedFunction(UnityAction<string> function, float delay, string param1) {
        StartCoroutine(CorrutinaDelayedFunction(function, delay, param1));
    }
    public void DelayedFunction(UnityAction<float, float> function, float delay, float param1, float param2) {
        StartCoroutine(CorrutinaDelayedFunction(function, delay, param1, param2));
    }

    private IEnumerator CorrutinaDelayedFunction(UnityAction function, float delay) {
        yield return new WaitForSeconds(delay);
        function();
    }
    private IEnumerator CorrutinaDelayedFunction(UnityAction<bool> function, float delay, bool param1) {
        if(delay > 0) {
            yield return new WaitForSeconds(delay);
        }
        function(param1);
    }
    private IEnumerator CorrutinaDelayedFunction(UnityAction<float> function, float delay, float param1) {
        if(delay > 0) {
            yield return new WaitForSeconds(delay);
        }
        function(param1);
    }
    private IEnumerator CorrutinaDelayedFunction(UnityAction<string> function, float delay, string param1) {
        if(delay > 0) {
            yield return new WaitForSeconds(delay);
        }
        function(param1);
    }
    private IEnumerator CorrutinaDelayedFunction(UnityAction<float, float> function, float delay, float param1, float param2) {
        if(delay > 0) {
            yield return new WaitForSeconds(delay);
        }
        function(param1, param2);
    }
}