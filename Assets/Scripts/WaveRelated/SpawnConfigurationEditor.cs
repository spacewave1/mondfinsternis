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

    private Wave[] waveTypes;

    private static string sArraySizePath = "waves.Array.size";
    private static string sArrayData = "waves.Array.data[{0}]";
    private static string sWaitData = "waves.Array.data[{0}].wait";

    public void OnEnable()
    {
        m_Object = new SerializedObject(target);
        m_SpawnRadius = m_Object.FindProperty("spawnRadius");
        m_SpawnWait = m_Object.FindProperty("spawnWait");
        m_WaveTypesCount = m_Object.FindProperty(sArraySizePath);
    }

    private Wave[] GetWaveTypesArray()
    {
        var arrayCount = m_Object.FindProperty(sArraySizePath).intValue;
        var wavesArray = new Wave[arrayCount];

        for( var i = 0; i < arrayCount; i++)
        {
           // wavesArray[i] = (Wave) m_Object.FindProperty(string.Format(sArrayData, i)).objectReferenceValue;
        }

        return wavesArray;
    }

    private void SetWaveType (int index, Wave wave)
    {
     //   m_Object.FindProperty(string.Format(sArrayData, index)).objectReferenceValue = wave;
    }

    private Wave GetWaveTypeAtIndex(int index)
    {
        return null;// m_Object.FindProperty(string.Format(sArrayData,index)).objectReferenceValue as Wave;
    }

    private void RemoveWaveTypeAtIndex(int index)
    {
        for(int i = index; i < m_WaveTypesCount.intValue - 1; i++)
            SetWaveType(i, GetWaveTypeAtIndex(i + 1));

        m_WaveTypesCount.intValue--;
    }

	public override void OnInspectorGUI ()
	{
        base.OnInspectorGUI();

        GUILayout.Label("Waves", EditorStyles.boldLabel);
        if (m_SpawnWait.floatValue < 0) m_SpawnWait.floatValue = 0;
        var waves = GetWaveTypesArray();

        for (int i = 0; i < waves.Length; i++)
        {
            GUILayout.BeginHorizontal();
            //var result = EditorGUILayout.ObjectField(waves[i], typeof(Wave), true);
            SerializedProperty m_WaveWait = m_Object.FindProperty(string.Format(sWaitData, i));
            Debug.Log(m_Object.FindProperty(string.Format("waves.Array.data[{0}]",i)));
            
            var waveTypeWait = EditorGUILayout.IntField(m_WaveWait.intValue);


            if (GUI.changed)
            {
                //SetWaveType(i, result);
            }

            if (GUILayout.Button("-", GUILayout.Width(20f)))
                RemoveWaveTypeAtIndex(i);
            GUILayout.EndHorizontal();
        }

        if(GUILayout.Button("Add WaveType"))
        {
            m_WaveTypesCount.intValue++;
            SetWaveType(m_WaveTypesCount.intValue - 1, null);
        }

        m_Object.ApplyModifiedProperties();
	}
}
