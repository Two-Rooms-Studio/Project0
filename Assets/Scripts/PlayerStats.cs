using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class player{
	static string name;
	static string className;
	static int level = 1;
	static float health;
	static float exp = 0;
	static float energy = 100;
	static float energyCap = 100;
	static float mana;
	static bool DrainingEnergy = false;

	public static void setName(string p_name){
		name = p_name;
	}

	public static void setDefaultStats(string p_className){
		className = p_className;
		//set energy and mana based off of className
	}

	public static void setEnergy(float p_energy){
		energy = p_energy;
	}

	public static string getClassName(){
		return className;
	}

	public static float getHealth(){
		return health;
	}

	public static float getEnergy(){
		return energy;
	}

	public static float getMana(){
		return mana;
	}

	public static void isDrainingEnergy(){
		DrainingEnergy = true;
	}

	public static void isNotDrainingEnergy(){
		DrainingEnergy = false;
	}

	public static void RegenerateEnergy(){
		if ((DrainingEnergy == false) && ((energy + .04f) < energyCap)) { //use .04f since we regenerate .04f energy per tick
			energy = energy + .04f;
		} 
		else if ((DrainingEnergy == false) && ((energy + .04f) > energyCap)) {
			energy = energyCap;
		}
	}
};

public class PlayerStats : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		player.RegenerateEnergy ();
	}
}