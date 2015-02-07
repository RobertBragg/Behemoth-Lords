using UnityEngine;
using System.Collections;

public class PlayerAttacks : MonoBehaviour {
	public float radius = 5.0f;
	private bool launch = false;

	Vector3 newRad;
	Vector3 oldRad;

	// Use this for initialization
	void Start () {
		
		newRad = new Vector3(radius, radius, radius);
		oldRad = new Vector3(1,1,1);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Player-AOE"))
		{
			LaunchAOE();
			ExplosionDamage();
		}


		if(launch)
		{
			Transform AOE;
			foreach(Transform child in transform)
			{
				if(child.name == "AOE")
				{
					AOE = child;
					AOE.gameObject.SetActive(true);
					

					AOE.localScale = Vector3.Slerp (AOE.localScale,  newRad * 2.5f, Time.deltaTime * 5);


					if(AOE.localScale.x >= newRad.x * 2.2f)
					{
						Debug.Log ("false");
						launch = false;
						AOE.localScale = oldRad;
						AOE.gameObject.SetActive(false);
					}
				}

			}
		}
	}

	void ExplosionDamage() {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
		
		foreach (Collider enemy in hitColliders)
		{
			if(enemy.gameObject.tag == "Enemy-Minions")
			{
				Debug.Log (enemy.name);
			}
		}
	}

	void LaunchAOE()
	{
		launch = true;
	}
}
