using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/" + nameof(TextSource), fileName = nameof(TextSource))]
public class TextSource : ScriptableObjectSource {
    public string text;
}