using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeables : MonoBehaviour
{
	[System.Serializable]
	public class _upgrade {
		[SerializeField] public string upgName;
		[SerializeField] public int upgLevel;
		[SerializeField] public int upgPrice;
	}

	[SerializeField] public _upgrade[] upgrades;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void test() {
		Debug.Log("Test worked");
	}
}
