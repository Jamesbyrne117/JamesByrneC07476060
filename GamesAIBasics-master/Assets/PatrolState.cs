//The will be the bots starting patroling state

using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState:State
{
	static Vector3 initialPos = Vector3.zero;
	
	GameObject [] Enemies;
	GameObject Ammo;


	
	public override string Description()
	{

		return "Patrol State" ;
	}
	
	public PatrolState(GameObject myGameObject)
		: base(myGameObject)
	{
		//this.enemyGameObject = enemyGameObject;
		//this.Ammo = Ammo;
		Enemies = GameObject.FindGameObjectsWithTag ("bot");
	}
	
	public override void Enter()
	{


		// picks a random place for our bots to patrol between.
		Vector3 Pos1 = UnityEngine.Random.insideUnitCircle * 25f;
		Vector3 Pos2 = UnityEngine.Random.insideUnitCircle * 25f;



		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(Pos1);
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(Pos2);
		myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
		myGameObject.GetComponent<SteeringBehaviours>().path.draw = true;
		myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
		myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
	}
	public override void Exit()
	{
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Clear();
	}
	
	public override void Update()
	{
		for (int i = 0; i < 4; i++) 
		{
						//check if there is an enemy in the field of view
						float fov = Mathf.PI / 4.0f;

						float angle;
						Vector3 toEnemy = (Enemies[i].transform.position - myGameObject.transform.position);
						toEnemy.Normalize ();
						angle = (float)Math.Acos (Vector3.Dot (toEnemy, myGameObject.transform.forward));
						if (angle < fov) {
								myGameObject.GetComponent<StateMachine> ().SwitchState (new AttackingState (myGameObject, Enemies[i]));
						}


		}

	}
}