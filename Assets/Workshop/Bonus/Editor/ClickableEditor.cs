using UnityEditor;
using System.Collections;

public class ClickableEditor : Editor
{

    [CustomEditor(typeof(Clickable))]
    public class TouchableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // nothing
        }
    }
}
