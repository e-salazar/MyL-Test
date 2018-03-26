using UnityEngine.UI;
using Utilities;

public class TextListener : ScriptableObjectListener {
    public string format = "{0}";

    private Text _text;
    public Text text {
        get {
            if(this._text == null) {
                this._text = this.GetOrAddComponent<Text>();
            }
            return this._text;
        }
    }

    private void Awake() {
        this.onScriptableObjectChanged.AddListener(OnTextChange);
    }

    public void OnTextChange() {
        this.text.text = string.Format(format, ((TextSource) scriptableObjectSource).text);
    }
}