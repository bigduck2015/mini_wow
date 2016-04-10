using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class viewctrl
{
    public static viewctrl instance = new viewctrl();

    private GameObject m_curpanel = GameObject.Find("StartView");

    public void loadlevel(string name)
    {
        MonoBehaviour.Destroy(m_curpanel);
        var prefab = Resources.Load("Prefab/" + name);
        GameObject view = GameObject.Instantiate(prefab) as GameObject;
        view.transform.parent = GameObject.Find("UI Root (2D)/Camera/Anchor").transform;
        view.transform.localScale = new Vector3(1,1,1);
        view.name = name;
        m_curpanel = view;
    }
}

