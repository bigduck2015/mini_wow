using UnityEngine;
using System.Collections;

public class ui_skill : MonoBehaviour 
{
    private Coroutine m_skill1Co = null;
    private GameObject m_slidebar = null;

    void Awake()
    {
        delegates.delcurskill = OnSkill;
    }

	// Use this for initialization
	void Start () 
    {
        m_slidebar = GameObject.Find("slidebar");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnSkill(skilldata data)
    {
        Debug.Log("OnCast");
        coctrl.instance.StartCoroutine("co_slidebar", slidebarCo(data.m_spendtime));
    }

    IEnumerator OnSkill1()
    {
        if (m_skill1Co == null)
        {
            m_skill1Co = coctrl.instance.StartCoroutine("co_skill1", player.instance.career.skill1());

            yield return m_skill1Co;

            m_skill1Co = null;
        }
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
        int id = coctrl.instance.coid_Dic["co_slidebar"];

        UISlider slider = m_slidebar.GetComponent<UISlider>();
        slider.sliderValue = 0;

        while (true)
        {
            yield return new WaitForSeconds(0.01f);

            if (id != coctrl.instance.coid_Dic["co_slidebar"])
            {
                break;
            }

			slider.sliderValue += (1 / time) * 0.01f;

			if (slider.sliderValue == 1) 
			{
				break;
			}
        }
    }
    
}
