//The will be the bots starting patroling state

using System;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPatrol:State
{
	static Vector3 initialPos = Vector3.zero;

	
	GameObject [] Enemies;
	GameObject Ammo;
	float Charge = 10;
	
	
	
	public override string Description()
	{
		
		return "Patrol State" ;
	}
	
	public AmmoPatrol(GameObject myGameObject)
		: base(myGameObject)
	{
		//this.enemyGameObject = enemyGameObject;
		//this.Ammo = Ammo;
		Enemies = GameObject.FindGameObjectsWithTag ("bot");
	}
	
	public override void Enter()
	{
		
		

		
		
		
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(0, 0, -20));
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-30, 0, 0));
		  myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(0, 0, 20));
		  myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(30, 0, 0));
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

		//In the lines below I was trying to make it so that the Charge variable would diminish when charge reached zero the sphere would have vanished. I ran out of time at this point and wasn't able to correct the errors.



//		float distance = 1;
//		for (int i = 0; i < 4; i++) 
//		{
//			if (Enemies [i]. Transform .position - myGameObject.Transform.position)
//			{
//						Charge --;
//			}

			
		//}
		
	}
}