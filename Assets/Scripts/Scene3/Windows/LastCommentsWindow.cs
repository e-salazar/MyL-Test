using Newtonsoft.Json;
using Scene3.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LastCommentsWindow : MonoBehaviour {
    public GameObject loadingComments;
    public Transform commentsContainerTransform;
    public List<UIComment> uiComments = new List<UIComment>();

    public void OnEndEdit(InputField inputField) {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            Search(inputField.text);
        }
    }
    public void OnClickButton(InputField inputField) {
        Search(inputField.text);
    }

    public void Search(string input) {
        if(input == "") { return; }

        int postId = 0;
        if(!int.TryParse(input, out postId)) {
            Debug.Log("Ingresa un entero.");
            return;
        }

        StartCoroutine(JSONPlaceHolderAPIRequest(postId));
    }
    private IEnumerator JSONPlaceHolderAPIRequest(int postId) {
        this.loadingComments.SetActive(true);

        foreach(UIComment uiComment in uiComments) {
            uiComment.Store();
        }
        this.uiComments = new List<UIComment>();

        string url = Uri.EscapeUriString("https://jsonplaceholder.typicode.com/posts/" + postId + "/comments");

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
        yield return unityWebRequest.SendWebRequest();

        if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError) {
            Debug.Log(unityWebRequest.error);
        }
        else {
            List<Scene3.API.JSONPlaceHolder.Comment> response = JsonConvert.DeserializeObject<List<Scene3.API.JSONPlaceHolder.Comment>>(unityWebRequest.downloadHandler.text);

            //Para evitar problemas de rendimiento, se reutilizarán los post ya creados anteriormente
            foreach(Scene3.API.JSONPlaceHolder.Comment comment in response) {
                UIComment uiComment = PoolingManager.Instance.New<UIComment>();
                uiComment.transform.SetParent(commentsContainerTransform);
                uiComment.gameObject.SetActive(true);
                uiComment.Load(comment);
                this.uiComments.Add(uiComment);
                yield return null;
            }
        }
        loadingComments.SetActive(false);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }
    public void Hide() {
        this.gameObject.SetActive(false);
        foreach(UIComment uiComment in uiComments) {
            uiComment.Store();
        }
        this.uiComments = new List<UIComment>();
    }
}