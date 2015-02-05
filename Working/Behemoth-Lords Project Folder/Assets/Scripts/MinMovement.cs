using UnityEngine;
using System.Collections;

enum MoveType {ATTACK, FOLLOW, HOLD};

public class MinMovement : MinNatural {
	public int moveSpeed = 3;
	public int rotationSpeed = 3;
	private MoveType mType;
	// Use this for initialization
	void Start () {
		mType = MoveType.HOLD;
	}
	
	// Update is called once per frame
	void Update () {
		Transform leadPos = leader.transform;
		leadPos.position.Set(leadPos.position.x, transform.position.y, leadPos.position.z);

		if(mType == MoveType.FOLLOW)
		{

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leadPos.position - transform.position), rotationSpeed*Time.deltaTime);

			if(Vector3.Distance(leadPos.position, transform.position) > 4)
			{
				transform.position += transform.forward * moveSpeed * Time.deltaTime;
			}
		}
		if (mType == MoveType.HOLD)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leadPos.position - transform.position), rotationSpeed*Time.deltaTime);
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