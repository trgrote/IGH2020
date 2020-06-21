using UnityEditor;
using so_events;
using UnityEngine;

namespace so_events
{
    [CustomEditor(typeof(Event))]
    public class EventButton : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Event myScript = (Event)target;
            if(GUILayout.Button("Raise"))
            {
                myScript.Raise();
            }
        }
    }
}