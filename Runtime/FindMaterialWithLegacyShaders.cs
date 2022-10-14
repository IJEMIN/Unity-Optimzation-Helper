using UnityEditor;
using UnityEngine;

namespace OmiyaGames.Template
{
    public static class FindMaterialWithLegacyShaders
    {
        /// <summary>
        /// URP에서 사용하기 힘든 Legacy Shader들을 사용하는 머티리얼들을 찾음
        /// </summary>
        [MenuItem("Tools/retr0/Find Material with Legacy Shaders")]
        public static void FindMaterialsWithLegacyShaders()
        {
            // get all materials in the project
            var guids = AssetDatabase.FindAssets("t:Material", new string[] {"Assets", "Packages"});

            // loop through all materials
            foreach (var guid in guids)
            {
                // get the path to the material
                var path = AssetDatabase.GUIDToAssetPath(guid);

                // load the material
                var material = AssetDatabase.LoadAssetAtPath<Material>(path);

                // check if the material uses a legacy shader
                if (material.shader.name.Contains("Legacy Shaders"))
                {
                    // print the path to the material
                    Debug.LogWarning($"{path} use Legacy material {material.shader.name}", material);
                }
            }
        }
    }
}