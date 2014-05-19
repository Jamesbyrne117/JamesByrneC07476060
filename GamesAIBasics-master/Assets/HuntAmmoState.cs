using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HuntAmmoState:State
{
	GameObject AmmoSphere;
	GameObject Me;
	
	public override string Description()
	{
		return "Tease State";
	}
	
	public HuntAmmoState(GameObject Me, GameObject AmmoSphere):base(Me)
	{
		this.AmmoSphere = AmmoSphere;
	}
	
	public override void Enter()
	{


		myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
		myGameObject.GetComponent<SteeringBehaviours>().PursuitEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours>().pursueTarget = AmmoSphere;
	}
	
	public override void Update()
	{
		float distance = 5.0f;
		if (Vector3.Distance(myGameObject.transform.position, AmmoSphere.transform.position) < distance)
		{
			myGameObject.GetComponent<StateMachine>().SwitchState(new PatrolState (Me));
		}
	}
	
	public override void Exit()
	{
		myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();            
	}
}