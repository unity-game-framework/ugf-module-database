using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Database.Runtime;
using UnityEditor;

namespace UGF.Module.Database.Editor
{
    [CustomEditor(typeof(DatabaseModuleAsset), true)]
    internal class DatabaseModuleEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyScript;
        private ReorderableListDrawer m_databasesList;

        private void OnEnable()
        {
            m_propertyScript = serializedObject.FindProperty("m_Script");
            m_databasesList = new ReorderableListDrawer(serializedObject.FindProperty("m_databases"));
            m_databasesList.Enable();
        }

        private void OnDisable()
        {
            m_databasesList.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(m_propertyScript);
                }

                m_databasesList.DrawGUILayout();
            }
        }
    }
}
