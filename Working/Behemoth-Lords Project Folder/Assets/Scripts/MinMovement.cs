using UnityEngine;
using System.Collections;

enum MoveType {ATTACK, FOLLOW, HOLD};

public class MinMovement : MinNatural {

	public int moveSpeed = 3;
	public int rotationSpeed = 3;
	public float attackTime = 1;
	public int attackDamage = 1;

	private float lastAttack = 0f;
	private MoveType mType;
	private Transform leadPos;

	protected GameObject[] enemys;

	void Start () {
		mType = MoveType.HOLD;
		enemys = GameObject.FindGameObjectsWithTag("Enemy-Minions");
	}

	/*void Awake() {		
		enemys = GameObject.FindGameObjectsWithTag("Enemy-Minions");
	}*/
	
	// Update is called once per frame
	void Update () {
		lastAttack += Time.deltaTime;

		if(gameObject.tag == "Allied-Minions")
		{

			if(mType == MoveType.ATTACK)
			{
				leadPos = GameObject.FindGameObjectsWithTag("Enemy-Minions")[0].transform;
				leadPos.position.Set(leadPos.position.x, transform.position.y, leadPos.position.z);
				
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leadPos.position - transform.position), rotationSpeed*Time.deltaTime);
				
				if(Vector3.Distance(leadPos.position, transform.position) > 4)
				{
					transform.position += transform.forward * moveSpeed * Time.deltaTime;

				}
				else
				{
					if (lastAttack > attackTime)
					{
						enemys[0].GetComponent<MinionStats>().Damage(attackDamage);
					}
				}
			}

			if(mType == MoveType.FOLLOW)
			{
				Debug.Log (leader.name);
				leadPos = leader.transform;
				leadPos.position.Set(leader.transform.position.x, transform.position.y, leader.transform.position.z);

				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leadPos.position - transform.position), rotationSpeed*Time.deltaTime);

				if(Vector3.Distance(leadPos.position, transform.position) > 4)
				{
					transform.position += transform.forward * moveSpeed * Time.deltaTime;
				}
			}
			if (mType == MoveType.HOLD)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leader.transform.position - transform.position), rotationSpeed*Time.deltaTime);
			}
		}
	}
	
	public void MoveTypeAttack()
	{
		Debug.Log("Attack");
		mType = MoveType.ATTACK;
	}

	public void MoveTypeFollow()
	{
		Debug.Log("Follow");
		mType = MoveType.FOLLOW;
	}

	public void MoveTypeHold()
	{
		Debug.Log("Hold");
		mType = MoveType.HOLD;
	}
}