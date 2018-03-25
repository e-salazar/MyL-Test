using UnityEngine;
using UnityEngine.UI;

public class Atmosphere : MonoBehaviour {
    private AudioSource _audioSource;
    public AudioSource audioSource {
        get {
            if(this._audioSource == null) {
                this._audioSource = this.gameObject.GetOrAddComponent<AudioSource>();
            }
            return this._audioSource;
        }
    }
    public Text atmosphereText;
    public VolumetricLightRenderer volumetricLightRenderer;

    public void SetAtmosphereName(string name) {
        this.atmosphereText.text = name;
    }
    public void SetVolumetricLight(int flag) {
        this.volumetricLightRenderer.enabled = flag == 1 ? true : false;
    }
    public void PlayAudio(AudioClip audioClip) {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}