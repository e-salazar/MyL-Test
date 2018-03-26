using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/" + nameof(IntegerSource), fileName = nameof(IntegerSource))]
public class IntegerSource : ScriptableObjectSource {
    public int integer;
}