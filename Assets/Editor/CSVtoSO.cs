using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEditorInternal;

namespace TrafficInfinity
{
    public class CSVtoSO : MonoBehaviour
    {
        private static string autoCSVPath = "/Editor/ItemDatabase.csv";

        [MenuItem("Utilities/Generate Auto")]

        public static void GenerateAuto()
        {
            string[] alllines = File.ReadAllLines(Application.dataPath + autoCSVPath);

            foreach (string s in alllines)
            {
                string[] splitData = s.Split(',');

                Auto auto = ScriptableObject.CreateInstance<Auto>();
                auto.id = int.Parse(splitData[0]);
                auto.autoName = splitData[1];
                auto.speed = int.Parse(splitData[2]);
                auto.boost = int.Parse(splitData[3]);

                AssetDatabase.CreateAsset(auto, $"Assets/Auto/{auto.autoName}.asset");


            }

            AssetDatabase.SaveAssets();
           
        }

    }
}
