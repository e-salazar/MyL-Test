using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Scene3.Components {
    public class UIComment : MonoBehaviour, IPoolable<UIComment> {
        public Text postIDText;
        public Text commentIDText;
        public Text nameText;
        public Text emailText;
        public Text bodyText;

        public void Load(API.JSONPlaceHolder.Comment commentData) {
            this.postIDText.text = "<b>Post ID:</b> " + commentData.postId;
            this.commentIDText.text = "<b>Comment ID:</b> " + commentData.id;
            this.nameText.text = "<b>Name:</b> " + commentData.name;
            this.emailText.text = "<b>E-Mail:</b> " + commentData.email;
            this.bodyText.text = "<b>Body:</b> " + commentData.body;
        }

        //Pooling
        public ObjectPool<UIComment> parentPool { get; set; }

        public void Reset() { }
        public void Store() {
            this.parentPool.Store(this);
        }
    }
}