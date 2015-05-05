using UnityEngine;
using UnityEditor;

public class WaveClassAsset
{
	[MenuItem("Assets/Create/Wave")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<Wave> ();
	}
}