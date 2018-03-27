using UnityEditor;
using UnityEngine;

namespace Attributes.Editor {
    [CustomPropertyDrawer(typeof(EnumFlagAttribute))]
    public class EnumFlagAttributeDrawer : PropertyDrawer {
        private int _columnCount = 0;
        private int _rowCount = 0;
        private int _extraRows = 1;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            int buttonsIntValue = 0;
            int enumLength = property.enumNames.Length;
            bool[] buttonPressed = new bool[enumLength];

            EditorGUI.LabelField(new Rect(position.x, position.y, position.width, position.height), label);

            EditorGUI.BeginChangeCheck();

            float buttonWidth = (position.width) / this._columnCount;
            float buttonHeight = position.height / (this._rowCount + this._extraRows);
            for(int i = 0; i < enumLength; i++) {
                if((property.intValue & (1 << i)) == 1 << i) {
                    buttonPressed[i] = true;
                }

                Rect buttonPos = new Rect(
                    position.x + (i % this._columnCount) * buttonWidth,
                    position.y + (Mathf.FloorToInt(i / this._columnCount) + 1) * buttonHeight,
                    buttonWidth,
                    buttonHeight);

                buttonPressed[i] = GUI.Toggle(buttonPos, buttonPressed[i], property.enumNames[i], "Button");

                if(buttonPressed[i])
                    buttonsIntValue += 1 << i;
            }

            //GUI.Toggle(new Rect(position.x, position.y + position.height - buttonHeight, position.width / 2f, buttonHeight), false, "None", "Button");
            //GUI.Toggle(new Rect(position.x + position.width / 2f, position.y + position.height - buttonHeight, position.width / 2f, buttonHeight), false, "All", "Button");

            if(EditorGUI.EndChangeCheck()) {
                property.intValue = buttonsIntValue;
            }
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            this._columnCount = (attribute as EnumFlagAttribute).columnCount;
            this._rowCount = Mathf.CeilToInt((float) property.enumNames.Length / this._columnCount);
            return base.GetPropertyHeight(property, label) * (this._rowCount + this._extraRows);
        }
    }
}