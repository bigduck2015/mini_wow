using UnityEngine;
using System.Collections;

public class ui_skill : MonoBehaviour 
{
    private Coroutine m_cur_skillco = null;
    private GameObject m_slidebar = null;

	// Use this for initialization
	void Start () 
    {
        m_slidebar = GameObject.Find("slidebar");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnSpace()
    {
        
    }

    void OnSkill1()
    {
            var skilldata = cfgData.instance.m_dic_skilldata[0];

            coctrl.instance.StartCoroutine("co_skill1", player.instance.career.skill1(skilldata) );

            StartCoroutine(slidebarCo(skilldata.m_spendtime));
    }
    
    void OnSkill2()
    {
        
    }

    void OnSkill3()
    {
        
    }

    void OnSkill4()
    {
        
    }

    void OnSkill5()
    {
        
    }

    void OnSkill6()
    {
        
    }

    void OnSkill7()
    {
        
    }

    void OnSkill8()
    {
        
    }

    void OnSkill9()
    {
        
    }

    void OnSkill10()
    {
        
    }

    IEnumerator slidebarCo(float time)
    {
        UISlider slider = m_slidebar.GetComponent<UISlider>();
        slider.sliderValue = 0;

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            slider.sliderValue += (1/time)*0.01f;
        }
    }
    
}
