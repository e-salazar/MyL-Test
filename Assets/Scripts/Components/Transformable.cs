using System.Collections;
using UnityEngine;

namespace Components {
    public class Transformable : MonoBehaviour {
        private IEnumerator positionCoroutine;
        private IEnumerator rotationCoroutine;
        private IEnumerator scaleCoroutine;

        public void StopAll() {
            if(this.positionCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.positionCoroutine);
            }
            if(this.rotationCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.rotationCoroutine);
            }
            if(this.scaleCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.scaleCoroutine);
            }
        }

        public bool SetLocalPosition(Vector3 positionTo, float duration = 0, float delay = 0) {//Retorna si la carta es necesario moverla o no
            if(this.positionCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.positionCoroutine);
            }

            if(duration == 0 && delay == 0) { this.transform.localPosition = positionTo; return true; }
            if(this.transform.localPosition == positionTo) { return false; }

            this.positionCoroutine = DelayedSetLocalPositionCoroutine(positionTo, duration, delay);
            GameManager.Instance.StartCoroutine(this.positionCoroutine);
            return true;
        }
        public bool SetGlobalPosition(Vector3 positionTo, float duration = 0, float delay = 0) {//Retorna si la carta es necesario moverla o no
            if(this.positionCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.positionCoroutine);
            }

            if(duration == 0 && delay == 0) { this.transform.position = positionTo; return true; }
            if(this.transform.position == positionTo) { return false; }

            this.positionCoroutine = DelayedSetGlobalPositionCoroutine(positionTo, duration, delay);
            GameManager.Instance.StartCoroutine(this.positionCoroutine);
            return true;
        }
        public bool SetLocalRotation(Quaternion rotationTo, float duration = 0, float delay = 0) {
            if(this.rotationCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.rotationCoroutine);
            }

            if(duration == 0 && delay == 0) { this.transform.localRotation = rotationTo; return true; }
            if(this.transform.localRotation == rotationTo) { return false; }

            this.rotationCoroutine = DelayedSetLocalRotationCoroutine(rotationTo, duration, delay);
            GameManager.Instance.StartCoroutine(this.rotationCoroutine);
            return true;
        }
        public bool SetGlobalRotation(Quaternion rotationTo, float duration = 0, float delay = 0) {
            if(this.rotationCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.rotationCoroutine);
            }

            if(duration == 0 && delay == 0) { this.transform.rotation = rotationTo; return true; }
            if(this.transform.rotation == rotationTo) { return false; }

            this.rotationCoroutine = DelayedSetGlobalRotationCoroutine(rotationTo, duration, delay);
            GameManager.Instance.StartCoroutine(this.rotationCoroutine);
            return true;
        }
        public bool SetLocalScale(Vector3 scaleTo, float duration = 0, float delay = 0) {
            if(this.scaleCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.scaleCoroutine);
            }

            if(duration == 0 && delay == 0) { this.transform.localScale = scaleTo; return true; }
            if(this.transform.localScale == scaleTo) { return false; }

            this.scaleCoroutine = DelayedSetLocalScaleCoroutine(scaleTo, duration, delay);
            GameManager.Instance.StartCoroutine(this.scaleCoroutine);
            return true;
        }

        private IEnumerator DelayedSetLocalPositionCoroutine(Vector3 positionTo, float duration, float delay) {
            if(delay > 0) {
                yield return new WaitForSeconds(delay);
            }
            if(this.positionCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.positionCoroutine);
            }
            this.positionCoroutine = SetLocalPositionCoroutine(positionTo, duration);
            GameManager.Instance.StartCoroutine(this.positionCoroutine);
        }
        private IEnumerator DelayedSetGlobalPositionCoroutine(Vector3 positionTo, float duration, float delay) {
            if(delay > 0) {
                yield return new WaitForSeconds(delay);
            }
            if(this.positionCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.positionCoroutine);
            }
            this.positionCoroutine = SetGlobalPositionCoroutine(positionTo, duration);
            GameManager.Instance.StartCoroutine(this.positionCoroutine);
        }
        private IEnumerator DelayedSetLocalRotationCoroutine(Quaternion rotationTo, float duration, float delay) {
            if(delay > 0) {
                yield return new WaitForSeconds(delay);
            }
            if(this.rotationCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.rotationCoroutine);
            }
            this.rotationCoroutine = SetLocalRotationCoroutine(rotationTo, duration);
            GameManager.Instance.StartCoroutine(this.rotationCoroutine);
        }
        private IEnumerator DelayedSetGlobalRotationCoroutine(Quaternion rotationTo, float duration, float delay) {
            if(delay > 0) {
                yield return new WaitForSeconds(delay);
            }
            if(this.rotationCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.rotationCoroutine);
            }
            this.rotationCoroutine = SetGlobalRotationCoroutine(rotationTo, duration);
            GameManager.Instance.StartCoroutine(this.rotationCoroutine);
        }
        private IEnumerator DelayedSetLocalScaleCoroutine(Vector3 scaleTo, float duration, float delay) {
            if(delay > 0) {
                yield return new WaitForSeconds(delay);
            }
            if(this.scaleCoroutine != null) {
                GameManager.Instance.StopCoroutine(this.scaleCoroutine);
            }
            this.scaleCoroutine = SetLocalScaleCoroutine(scaleTo, duration);
            GameManager.Instance.StartCoroutine(this.scaleCoroutine);
        }

        private IEnumerator SetLocalPositionCoroutine(Vector3 positionTo, float duration) {
            if(this.transform.localPosition != positionTo) {
                float actualTime = 0;
                float percentage = 0;
                Vector3 positionFrom = this.transform.localPosition;

                while(actualTime < duration) {
                    actualTime += Time.deltaTime;
                    percentage = actualTime / duration;
                    this.transform.localPosition = Vector3.Lerp(positionFrom, positionTo, percentage);
                    yield return null;
                }
                this.transform.localPosition = positionTo;
            }
        }
        private IEnumerator SetGlobalPositionCoroutine(Vector3 positionTo, float duration) {
            if(this.transform.position != positionTo) {
                float actualTime = 0;
                float percentage = 0;
                Vector3 positionFrom = this.transform.position;

                while(actualTime < duration) {
                    actualTime += Time.deltaTime;
                    percentage = actualTime / duration;
                    this.transform.position = Vector3.Lerp(positionFrom, positionTo, percentage);
                    yield return null;
                }
                this.transform.position = positionTo;
            }
        }
        private IEnumerator SetLocalRotationCoroutine(Quaternion rotationTo, float duration) {
            if(this.transform.localRotation != rotationTo) {
                float actualTime = 0;
                float percentage = 0;
                Quaternion rotationFrom = this.transform.localRotation;

                while(actualTime < duration) {
                    actualTime += Time.deltaTime;
                    percentage = actualTime / duration;
                    this.transform.localRotation = Quaternion.Lerp(rotationFrom, rotationTo, percentage);
                    yield return null;
                }
                this.transform.localRotation = rotationTo;
            }
        }
        private IEnumerator SetGlobalRotationCoroutine(Quaternion rotationTo, float duration) {
            if(this.transform.rotation != rotationTo) {
                float actualTime = 0;
                float percentage = 0;
                Quaternion rotationFrom = this.transform.rotation;

                while(actualTime < duration) {
                    actualTime += Time.deltaTime;
                    percentage = actualTime / duration;
                    this.transform.rotation = Quaternion.Lerp(rotationFrom, rotationTo, percentage);
                    yield return null;
                }
                this.transform.rotation = rotationTo;
            }
        }
        private IEnumerator SetLocalScaleCoroutine(Vector3 scaleTo, float duration) {
            if(this.transform.localScale != scaleTo) {
                float actualTime = 0;
                float percentage = 0;
                Vector3 scaleFrom = this.transform.localScale;

                while(actualTime < duration) {
                    actualTime += Time.deltaTime;
                    percentage = actualTime / duration;
                    this.transform.localScale = Vector3.Lerp(scaleFrom, scaleTo, percentage);
                    yield return null;
                }
                this.transform.localScale = scaleTo;
            }
        }
    }
}