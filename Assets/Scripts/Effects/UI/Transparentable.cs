using System.Collections;
using UnityEngine;

namespace Effects.UI {
	public class Transparentable : MonoBehaviour {
		private IEnumerator alphaCoroutine;

		private CanvasGroup _canvasGroup;
		public CanvasGroup canvasGroup {
			get {
				if(_canvasGroup == null) {
					_canvasGroup = this.gameObject.GetOrAddComponent<CanvasGroup>();
				}
				return _canvasGroup;
			}
		}

		public void StopAll() {
			if(alphaCoroutine != null) {
				TweenManager.Instance.StopCoroutine(alphaCoroutine);
			}
		}

		public void SetAlpha(float alphaTo, float duration = 0, float delay = 0) {
			TweenManager.Instance.StartCoroutine(DelayedSetAlphaCoroutine(alphaTo, duration, delay));
		}

		private IEnumerator DelayedSetAlphaCoroutine(float alphaTo, float duration, float delay) {
			if(delay > 0) {
				yield return new WaitForSeconds(delay);
			}
			if(alphaCoroutine != null) {
				TweenManager.Instance.StopCoroutine(alphaCoroutine);
			}
			alphaCoroutine = SetAlphaCoroutine(alphaTo, duration);
			TweenManager.Instance.StartCoroutine(alphaCoroutine);
		}

		private IEnumerator SetAlphaCoroutine(float alphaTo, float duration) {
			if(canvasGroup.alpha != alphaTo) {
				float actualTime = 0;
				float percentage = 0;
				float alphaFrom = canvasGroup.alpha;

				while(actualTime < duration) {
					actualTime += Time.deltaTime;
					percentage = actualTime / duration;
					canvasGroup.alpha = Mathf.Lerp(alphaFrom, alphaTo, percentage);
					yield return null;
				}
				canvasGroup.alpha = alphaTo;
			}
		}
	}
}