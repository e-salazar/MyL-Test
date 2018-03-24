using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Effects.UI {
    public class Colorable : MonoBehaviour {
        private IEnumerator colorCoroutine;

        private Image _image;
        public Image image {
            get {
                if(_image == null) {
                    _image = this.gameObject.GetOrAddComponent<Image>();
                }
                return _image;
            }
        }
		
		public void StopAll() {
            if(colorCoroutine != null) {
                TweenManager.Instance.StopCoroutine(colorCoroutine);
            }
        }

        public void SetColor(Color colorTo, float duration = 0, float delay = 0) {
            TweenManager.Instance.StartCoroutine(DelayedSetColorCoroutine(colorTo, duration, delay));
        }

        private IEnumerator DelayedSetColorCoroutine(Color colorTo, float duration, float delay) {
            if(delay > 0) {
                yield return new WaitForSeconds(delay);
            }
            if(colorCoroutine != null) {
                TweenManager.Instance.StopCoroutine(colorCoroutine);
            }
            colorCoroutine = SetColorCoroutine(colorTo, duration);
            TweenManager.Instance.StartCoroutine(colorCoroutine);
        }

        private IEnumerator SetColorCoroutine(Color colorTo, float duration) {
            if(image.color != colorTo) {
                float actualTime = 0;
                float percentage = 0;
                Color colorFrom = image.color;

                while(actualTime < duration) {
                    actualTime += Time.deltaTime;
                    percentage = actualTime / duration;
                    image.color = Color.Lerp(colorFrom, colorTo, percentage);
                    yield return null;
                }
                image.color = colorTo;
            }
        }
    }
}