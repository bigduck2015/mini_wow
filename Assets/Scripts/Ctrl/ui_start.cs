using UnityEngine;
using System.Collections;

public class ui_start : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnFight()
    {
        viewctrl.instance.loadlevel("MainView");
    }
}
