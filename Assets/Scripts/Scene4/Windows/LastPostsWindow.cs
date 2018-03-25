using Newtonsoft.Json;
using Scene3.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LastPostsWindow : MonoBehaviour {
    public GameObject loadingPosts;
    public Transform postsContainerTransform;
    public List<UIPost> uiPosts = new List<UIPost>();

    public void OnClickButton() {
        Search();
    }

    public void Search() {
        StartCoroutine(JSONPlaceHolderAPIRequest());
    }
    private IEnumerator JSONPlaceHolderAPIRequest() {
        this.loadingPosts.SetActive(true);

        foreach(UIPost uiPost in uiPosts) {
            uiPost.Store();
        }
        this.uiPosts = new List<UIPost>();

        string url = Uri.EscapeUriString("https://jsonplaceholder.typicode.com/posts/");

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
        yield return unityWebRequest.SendWebRequest();

        if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError) {
            Debug.Log(unityWebRequest.error);
        }
        else {
            List<Scene3.API.JSONPlaceHolder.Post> response = JsonConvert.DeserializeObject<List<Scene3.API.JSONPlaceHolder.Post>>(unityWebRequest.downloadHandler.text);

            //Para evitar problemas de rendimiento, se reutilizarán los post ya creados anteriormente
            foreach(Scene3.API.JSONPlaceHolder.Post post in response) {
                UIPost uiPost = PoolingManager.Instance.New<UIPost>();
                uiPost.transform.SetParent(postsContainerTransform);
                uiPost.gameObject.SetActive(true);
                uiPost.Load(post);
                this.uiPosts.Add(uiPost);
                yield return null;
            }
        }
        loadingPosts.SetActive(false);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }
    public void Hide() {
        this.gameObject.SetActive(false);
        foreach(UIPost uiPost in uiPosts) {
            uiPost.Store();
        }
        this.uiPosts = new List<UIPost>();
    }
}
/*FULL POOLING

using Newtonsoft.Json;
using Scene3.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LastPostsWindow : MonoBehaviour {
    public GameObject loadingPosts;
    public Transform postsContainerTransform;
    public GameObject postGameObject;
    public List<UIPost> uiPosts = new List<UIPost>();

    public void OnClickButton() {
        Search();
    }

    public void Search() {
        StartCoroutine(JSONPlaceHolderAPIRequest());
    }
    private IEnumerator JSONPlaceHolderAPIRequest() {
        this.loadingPosts.SetActive(true);

        foreach(UIPost uiPost in uiPosts) {
            uiPost.Store();
        }
        this.uiPosts = new List<UIPost>();

        string url = Uri.EscapeUriString("https://jsonplaceholder.typicode.com/posts/");

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
        yield return unityWebRequest.SendWebRequest();

        if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError) {
            Debug.Log(unityWebRequest.error);
        }
        else {
            List<Scene3.API.JSONPlaceHolder.Post> response = JsonConvert.DeserializeObject<List<Scene3.API.JSONPlaceHolder.Post>>(unityWebRequest.downloadHandler.text);

            //Para evitar problemas de rendimiento, se reutilizarán los post ya creados anteriormente
            foreach(Scene3.API.JSONPlaceHolder.Post post in response) {
                UIPost uiPost = PoolingManager.Instance.New<UIPost>();
                uiPost.transform.SetParent(postsContainerTransform);
                uiPost.gameObject.SetActive(true);
                uiPost.Load(post);
                this.uiPosts.Add(uiPost);
            }
        }
        loadingPosts.SetActive(false);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }
    public void Hide() {
        this.gameObject.SetActive(false);
        foreach(UIPost uiPost in uiPosts) {
            uiPost.Store();
        }
        this.uiPosts = new List<UIPost>();
    }
}*/
/* PARTIAL POOLING

using Newtonsoft.Json;
using Scene3.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LastPostsWindow : MonoBehaviour {
    public GameObject loadingPosts;
    public Transform postsContainerTransform;
    public GameObject postGameObject;
    public List<UIPost> uiPosts = new List<UIPost>();

    private void Start() {
        //Creamos un pool inicial de objetos a reutilizar
        for(int i = 0; i < 100; i++) {
            UIPost uiPost = PoolingManager.Instance.New<UIPost>();
            uiPost.transform.SetParent(postsContainerTransform);
            uiPosts.Add(uiPost);
        }
    }

    public void OnClickButton() {
        Search();
    }

    public void Search() {
        StartCoroutine(JSONPlaceHolderAPIRequest());
    }
    private IEnumerator JSONPlaceHolderAPIRequest() {
        this.loadingPosts.SetActive(true);

        string url = Uri.EscapeUriString("https://jsonplaceholder.typicode.com/posts/");

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
        yield return unityWebRequest.SendWebRequest();

        if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError) {
            Debug.Log(unityWebRequest.error);
        }
        else {
            List<Scene3.API.JSONPlaceHolder.Post> response = JsonConvert.DeserializeObject<List<Scene3.API.JSONPlaceHolder.Post>>(unityWebRequest.downloadHandler.text);

            //Para evitar problemas de rendimiento, se reutilizarán los post ya creados anteriormente
            for(int i = 0; i < response.Count; i++) {
                if(i >= uiPosts.Count) {
                    UIPost uiPost = PoolingManager.Instance.New<UIPost>();
                    uiPost.transform.SetParent(postsContainerTransform);
                    uiPosts.Add(uiPost);
                }
                uiPosts[i].gameObject.SetActive(true);
                uiPosts[i].Load(response[i]);
            }

            for(int i = response.Count; i < uiPosts.Count; i++) {
                uiPosts[i].gameObject.SetActive(false);
            }
        }
        loadingPosts.SetActive(false);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }
    public void Hide() {
        this.gameObject.SetActive(false);
    }
}*/