using UnityEngine;

namespace Editor
{
    [UnityEditor.CustomEditor(typeof(PlayerPrefCleaner))]
    public class PlayerPrefCleanerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();


            if (GUILayout.Button("Delete PlayerPref"))
            {
                DeletePlayerPref();
            }
        }

        private void DeletePlayerPref()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
