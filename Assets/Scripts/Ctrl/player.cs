using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour 
{
    public static player instance = null;

    private float m_hp;
    private float m_mana;
    private int m_public_cd = 0;
    private career m_career = null;

    void Awake()
    {

    }

	void Start () 
	{
        m_career = new magic();
	}
	
	void FixedUpdate () 
	{
	
	}

    public career career
    {
        get
        {
            return m_career;
        }
    }

    public int public_cd
    {
        get
        {
            return m_public_cd;
        }
    }

    public void SetPubCDState(int state)
    {
        m_public_cd = state;
    }


}
