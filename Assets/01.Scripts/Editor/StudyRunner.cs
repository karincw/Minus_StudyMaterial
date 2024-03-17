using UnityEditor;
using UnityEngine;

namespace Studys
{
    [CustomEditor(typeof(StudyAction))]
    public class StudyRunner : Editor
    {
        private StudyAction _target;

        private void OnEnable()
        {
            _target = target as StudyAction;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Ãâ·Â"))
            {
                _target.TestMethod();
            }
            EditorGUILayout.EndHorizontal();
        }
    }

}