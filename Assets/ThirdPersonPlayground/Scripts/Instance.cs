
using UnityEngine;

namespace ThirdPersonPlayground
{
	public class Instance : MonoBehaviour
	{
		public void Start()
		{
			Debug.Log("ThirdPersonPlayground instance started");
			QualitySettings.vSyncCount = 1;
		}
	}
}