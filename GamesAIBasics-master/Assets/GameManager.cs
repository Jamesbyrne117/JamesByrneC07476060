using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//I created an array for the bots
	public GameObject [] Bots;
	public GameObject [] Ammo;

	//public GameObject [] Enemies;
	// Use this for initialization
	void Start () 
	{
		// I asked it to find every object called bot and put it in the array
		Bots = GameObject.FindGameObjectsWithTag ("bot");
		Ammo = GameObject.FindGameObjectsWithTag ("ammo");
		//do the same for ammo




//        leader.GetComponent<StateMachine>().SwitchState(new IdleState(leader, teaser));
      //  teaser.GetComponent<StateMachine>().SwitchState(new TeaseState(teaser, leader));
		for (int i = 0; i < 5; i++)
		
		{
			Bots[i].GetComponent<StateMachine>().SwitchState (new PatrolState (Bots[i]));
			Bots[i].renderer.material.color = Color.blue;

			Ammo[i].transform.position = UnityEngine.Random.insideUnitCircle * 25f;
			Ammo[i].GetComponent<StateMachine>().SwitchState (new AmmoPatrol (Ammo[i]));
			Ammo[i].renderer .material.color = Color.red;
		}





		//Bot.GetComponent<StateMachine>().SwitchState (new PatrolState (Bot, Enemy, Ammo));

        //leader.renderer.material.color = Color.red;
      //  teaser.renderer.material.color = Color.blue;
		//Bot.renderer.material.color = Color.blue;

        
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
