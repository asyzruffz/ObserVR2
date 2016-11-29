using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
public class ShowOnlyDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		/*string valueStr;

		switch (property.propertyType) {
		case SerializedPropertyType.Integer:
			valueStr = property.intValue.ToString();
			break;
		case SerializedPropertyType.Boolean:
			valueStr = property.boolValue.ToString();
			break;
		case SerializedPropertyType.Float:
			valueStr = property.floatValue.ToString("0.00000");
			break;
		case SerializedPropertyType.String:
			valueStr = property.stringValue;
			break;
        case SerializedPropertyType.Vector3:
            valueStr = prop.vector3Value.ToString();
            break;
        case SerializedPropertyType.ObjectReference:
            valueStr = prop.objectReferenceValue.name;
            break;
        default:
			valueStr = "(not supported)";
			break;
		}*/

		bool wasEnabled = GUI.enabled;
		GUI.enabled = false;
		EditorGUI.PropertyField(position, property, label, true);
		GUI.enabled = wasEnabled;
		//EditorGUI.LabelField(position,label.text, valueStr);
	}
}