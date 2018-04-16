using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(SpawnConfiguration))]
public class SpawnConfigurationEditor : Editor
{
    private SerializedObject m_Object;
    private SerializedProperty m_SpawnRadius;
    private SerializedProperty m_SpawnWait;
    private SerializedProperty m_WaveTypesCount;

    int[]   waveWait;
    float[] waveRate;
    int[]   waveAmount;
    int[]   waveSpread;
    int[]   wavedirection;

    private Wave[] waveTypes;

    private static string sArraySizePath = "waveTypes.Array.size";
    private static string sArrayData = "waveTypes.Array.data[{0}]";
    private static string sWaitData = "waveTypes.Array.data[{0}].wait";

    public void OnEnable()
    {
        m_Object = new SerializedObject(target);
        m_SpawnRadius = m_Object.FindProperty("spawnRadius");
        m_SpawnWait = m_Object.FindProperty("spawnWait");
        m_WaveTypesCount = m_Object.FindProperty(sArraySizePath);
    }

	public override void OnInspectorGUI ()
	{
        base.OnInspectorGUI();
        /*
        GUILayout.MaxHeight(3000);

        GUILayout.Label("Waves", EditorStyles.boldLabel);

        int size = m_Object.FindProperty("waveTypes.Array.size").intValue;

        GUIStyle gUIStyle = GUIStyle.none;
        gUIStyle.padding = new RectOffset(20,20,0,0);
        
        int newSize = EditorGUILayout.IntField(name + " Size", size);
        for (int i = 0; i < newSize; i++)
        {
            GUILayout.Label("Waves", EditorStyles.boldLabel);
            GUILayout.BeginArea(new Rect(120,300+100*i,200,200));
            waveWait[i] = EditorGUILayout.IntField("Wait", m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("wait").intValue, gUIStyle);
            waveRate[i] = EditorGUILayout.FloatField("Rate", m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("rate").floatValue);
            waveAmount[i] = EditorGUILayout.IntField("Amount", m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("amount").intValue);
            waveSpread[i] = EditorGUILayout.IntField("Spread", m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("spread").intValue);
            wavedirection[i] = EditorGUILayout.IntField("Direction", m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("direction").intValue);
            GUILayout.EndArea();

            m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("wait").intValue = waveWait[i];
            m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("rate").floatValue = waveRate[i];
            m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("amount").intValue = waveAmount[i];
            m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("spread").intValue = waveSpread[i];
            m_Object.FindProperty("waveTypes.Array").GetArrayElementAtIndex(i).FindPropertyRelative("direction").intValue = wavedirection[i];

        if (newSize != size)
            {

                m_Object.FindProperty("waveTypes.Array.size").intValue = newSize;

                EditorGUI.indentLevel = 3;
                GUILayout.Label("Waves", EditorStyles.boldLabel);

            }
        }
        if (m_SpawnWait.floatValue < 0) m_SpawnWait.floatValue = 0;
        var waves = waveTypes;

        for (int i = 0; i < waves.Length; i++)
        {
            GUILayout.BeginHorizontal();
            SerializedProperty m_WaveWait = m_Object.FindProperty(string.Format(sWaitData, i));
            Debug.Log(m_Object.FindProperty(string.Format("waveTypes.Array.data[{0}]", i)));
            
            var waveTypeWait = EditorGUILayout.IntField(m_WaveWait.intValue);


            if (GUI.changed)
            {
                //SetWaveType(i, result);
            }

            if (GUILayout.Button("-", GUILayout.Width(20f))) ;
                
            GUILayout.EndHorizontal();
        }

        if(GUILayout.Button("Add WaveType"))
        {
            m_WaveTypesCount.intValue++;
            //SetWaveType(m_WaveTypesCount.intValue - 1, null);
        }
        
        m_Object.ApplyModifiedProperties();
        */
	}
}
