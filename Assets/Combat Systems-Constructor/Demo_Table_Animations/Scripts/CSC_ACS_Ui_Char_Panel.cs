﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//creates the buttons on panel of animations
public class CSC_ACS_Ui_Char_Panel : MonoBehaviour {

	public GameObject character;
	public Transform acts_table;
	public Transform weap_table;
    public Button buttonPrefab;

    Button sel_btm;

	CSC_ACS_Actions actions;


	void Start () {
 
		actions = character.GetComponent<CSC_ACS_Actions> ();
 


		CreateActionButton("Idle");
		CreateActionButton("Idle2");
		CreateActionButton("WalkForwad");
		CreateActionButton("WalkForwad2");
		CreateActionButton("WalkBack");
		CreateActionButton("TurnLeft");
		CreateActionButton("TurnRight");
		CreateActionButton("StrafeLeft");
		CreateActionButton("StrafeRight");

		CreateActionButton("ChangeToWeels");
		CreateActionButton("MoveWeelsForwad");
		CreateActionButton("MoveWeelsForwad2");
		CreateActionButton("MoveWeelsBack");
		CreateActionButton("ChangeToWalk");

		CreateActionButton("Dead1");
		CreateActionButton("Dead2");
		CreateActionButton("Dead3");
		CreateActionButton("Dead4");

 
		CreateWeapButton("Fire","Fire");
	//	CreateWeapButton("stopFire","stopFire");

 
    }

 

    void CreateActionButton(string name) {
		CreateActionButton(name, name);
	}

	void CreateWeapButton(string name, string message) {
 
		Button button = CreateButton (name, weap_table);
		if (name == "Fire")
			button.GetComponentInChildren<Image>().color = new Color(1f, .0f, .0f);
		button.GetComponentInChildren<Text>().fontSize = 16;
		button.onClick.AddListener(()  => actions.SendMessage(message, SendMessageOptions.DontRequireReceiver));
	 

	}
	void CreateActionButton(string name, string message) {

		Button button = CreateButton (name, acts_table);

		if (name == "Idle")
		{
			sel_btm = button;
			button.GetComponentInChildren<Image>().color = new Color(.5f, .5f, .5f);
		}
		button.GetComponentInChildren<Text>().fontSize = 12;
		button.onClick.AddListener(()  => actions.SendMessage(message, SendMessageOptions.DontRequireReceiver));
		button.onClick.AddListener(() => select_btm(button)  );


	}
    void select_btm(Button btm)
    {
		sel_btm.GetComponentInChildren<Image>().color = new Color(.345f, .345f, .345f);
		btm.GetComponentInChildren<Image>().color = new Color(.5f, .5f, .5f);
        sel_btm = btm;
    }

 
    Button CreateButton(string name, Transform group) {
		GameObject obj = (GameObject) Instantiate (buttonPrefab.gameObject);
		obj.name = name;
		obj.transform.SetParent(group);
		obj.transform.localScale = Vector3.one;
		Text text = obj.transform.GetChild (0).GetComponent<Text> ();
		text.text = name;
		return obj.GetComponent<Button> ();
	}




	public void OpenPublisherPage() {
		Application.OpenURL ("https://connect.unity.com/u/58c9250f32b30600230f64fa");
	}

 
}
