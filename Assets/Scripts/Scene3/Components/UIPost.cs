using DesignPatterns;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Scene3.Components {
    public class UIPost : MonoBehaviour, IPoolable<UIPost> {
        public Text userIDText;
        public Text postIDText;
        public Text titleText;
        public Text bodyText;

        public void Load(API.JSONPlaceHolder.Post postData) {
            this.userIDText.text = "<b>User ID:</b> " + postData.userId;
            this.postIDText.text = "<b>Post ID:</b> " + postData.id;
            this.titleText.text = "<b>Title:</b> " + postData.title;
            this.bodyText.text = "<b>Body:</b> " + postData.body;
        }

        //Pooling
        public ObjectPool<UIPost> parentPool { get; set; }

        public void Reset() { }
        public void Store() {
            this.parentPool.Store(this);
        }
    }
}