using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour 
{
    public static player instance = null;

    private float m_hp;
    private float m_mana;
    private skill m_skill = null;

    void Awake()
    {

    }

	void Start () 
	{

	}
	
	void FixedUpdate () 
	{
	
	}

    public skill skill
    {
        get
        {
            return m_skill;
        }
    }

    public void SetSkill(skill skill)
    {
        m_skill = skill;
    }

}
