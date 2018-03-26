using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleMapsWindow : MonoBehaviour {
    public const string GoogleMapsGeocodingAPIKey = "AIzaSyCkJpsDVuo-xCDgvdmJe5JGjZxvSdBKgcY";
    public const string GoogleStaticMapsAPIKey = "AIzaSyCfw6ztPaqHS0mC1w8yc0H6Bo5oQ5aenNo";

    public Text coordsText;
    public Image mapImage;
    public GameObject loadingCoords;
    public GameObject loadingMap;

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

        StartCoroutine(GoogleMapsGeocodingAPIRequest(input));
    }
    private IEnumerator GoogleMapsGeocodingAPIRequest(string address) {
        this.loadingCoords.SetActive(true);
        this.mapImage.enabled = false;
        this.coordsText.text = "";

        string url = Uri.EscapeUriString(
            "https://maps.googleapis.com/maps/api/geocode/json?" +
            "address=" + address +
            "&key=" + GoogleMapsGeocodingAPIKey);

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
        yield return unityWebRequest.SendWebRequest();

        if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError) {
            Debug.Log(unityWebRequest.error);
            this.coordsText.text = "Error.";
        }
        else {
            Scene3.API.GoogleMapsGeocode.Response response = JsonConvert.DeserializeObject<Scene3.API.GoogleMapsGeocode.Response>(unityWebRequest.downloadHandler.text);
            if(response.results.Count > 0) {
                this.coordsText.text =
                    "Lat\t: " + response.results[0].geometry.location.lat.ToString() +
                    "\nLng\t: " + response.results[0].geometry.location.lng.ToString();
                StartCoroutine(GoogleStaticMapsAPIRequest(response.results[0].geometry.location.lat, response.results[0].geometry.location.lng));
            }
            else {
                this.coordsText.text = "No encontrado.";
            }
        }
        loadingCoords.SetActive(false);
    }
    private IEnumerator GoogleStaticMapsAPIRequest(double lat, double lng) {
        if(lat != 0 || lng != 0) {
            loadingMap.SetActive(true);
            Vector2 parentSize = mapImage.transform.parent.GetComponent<RectTransform>().sizeDelta;
            Vector2 sizeDelta = mapImage.GetComponent<RectTransform>().sizeDelta;
            Vector2 canvasScale = new Vector2(mapImage.canvas.transform.localScale.x, mapImage.canvas.transform.localScale.y);
            Vector2 finalScale = new Vector2(sizeDelta.x * canvasScale.x, sizeDelta.y * canvasScale.y);

            Vector2 imageSize = parentSize + finalScale;
            if(imageSize.x > 640) {//Limitación de Google Maps, las cuentas gratuitas pueden solicitar máximo de una resolución de 640x640
                imageSize.y = 640 * imageSize.y / imageSize.x;
                imageSize.x = 640;
            }
            if(imageSize.y > 640) {//Limitación de Google Maps, las cuentas gratuitas pueden solicitar máximo de una resolución de 640x640
                imageSize.x = 640 * imageSize.x / imageSize.y;
                imageSize.y = 640;
            }
            if(imageSize.x < 32 || imageSize.y < 32) {
                imageSize.x = 32;
                imageSize.y = 32;
            }

            string url = Uri.EscapeUriString(
                "https://maps.googleapis.com/maps/api/staticmap?" +
                "size=" + Mathf.RoundToInt(imageSize.x) + "x" + Mathf.RoundToInt(imageSize.y) +
                "&maptype=roadmap" +
                "&markers=color:red|label:A|" + lat + "," + lng +
                "&key=" + GoogleMapsGeocodingAPIKey);

            using(WWW www = new WWW(url)) {
                yield return www;

                Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
                www.LoadImageIntoTexture(texture);

                mapImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
                mapImage.preserveAspect = true;
            }
            this.mapImage.enabled = true;
        }

        loadingMap.SetActive(false);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }
    public void Hide() {
        this.gameObject.SetActive(false);
    }
}