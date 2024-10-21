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
        private NDMFMeshSimplifier _target;
        private TogglablePreviewNode m_toggleNode;
        private void OnEnable()
        {
            m_toggleNode = NDMF.PreviewNDMFMeshSimplifier.ToggleNode;
            _target = target as NDMFMeshSimplifier;
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
            
            if (m_toggleNode.IsEnabled.Value)
            {
                EditorGUILayout.LabelField($"Triangles", $"{_target.Triangles.Item2}/{_target.Triangles.Item1}");
            }
            else
            {
                EditorGUILayout.LabelField($"Triangles", $"- / - (works during only Preview)");
            }
        }
    }
}
