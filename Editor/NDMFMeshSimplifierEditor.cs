using jp.lilxyzw.ndmfmeshsimplifier.runtime;
using UnityEditor;
using UnityEngine;
using nadena.dev.ndmf.preview;

namespace jp.lilxyzw.ndmfmeshsimplifier
{
    [CustomEditor(typeof(NDMFMeshSimplifier))]
    [CanEditMultipleObjects]
    internal class NDMFMeshSimplifierEditor : Editor
    {
        private TogglablePreviewNode m_toggleNode;
        private void OnEnable()
        {
            m_toggleNode = NDMF.PreviewNDMFMeshSimplifier.ToggleNode;
        }

        public sealed override void OnInspectorGUI()
        {
            L10n.SelectLanguageGUI();
            serializedObject.UpdateIfRequiredOrScript();
            SerializedProperty iterator = serializedObject.GetIterator();
            iterator.NextVisible(true); // m_Script
            while(iterator.NextVisible(false))
            {
                if(iterator.name == "options") iterator.NextVisible(true);
                EditorGUILayout.PropertyField(iterator, L10n.G(iterator));
            }
            serializedObject.ApplyModifiedProperties();
            if (GUILayout.Button(m_toggleNode.IsEnabled.Value ? "Stop Preview" : "Preview"))
            {
                m_toggleNode.IsEnabled.Value = !m_toggleNode.IsEnabled.Value;
            }
        }
    }
}
