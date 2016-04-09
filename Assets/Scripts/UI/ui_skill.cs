using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ui_skill : MonoBehaviour 
{
    private Coroutine m_skill1Co = null;
    private GameObject m_slidebar = null;
    private Dictionary<int, GameObject> m_dic_skillbtn = new Dictionary<int, GameObject>();

    void Awake()
    {
        delegates.delcurskill = OnSkill;
    }

	// Use this for initialization
	void Start () 
    {
        m_slidebar = GameObject.Find("slidebar");

        m_dic_skillbtn[0] = GameObject.Find("Btn1");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnSkill(skilldata data, GameObject skillbtn)
    {
        coctrl.instance.StartCoroutine("co_OnSkill", OnSkillCo(data,skillbtn));
    }

    IEnumerator OnSkillCo(skilldata data, GameObject skillbtn)
    {
        int coid = coctrl.instance.coid_Dic["co_OnSkill"];

        yield return coctrl.instance.StartCoroutine("co_slidebar", slidebarCo(data.m_spendtime));

        if (coid == coctrl.instance.coid_Dic["co_OnSkill"])
        {
            coctrl.instance.StartCoroutine("co_skillcd", skillCDCo(data.m_cd, skillbtn));
        }
    }

    IEnumerator OnSkill1()
    {
        if (m_skill1Co == null)
        {
            m_skill1Co = coctrl.instance.StartCoroutine("co_skill1", player.instance.career.skill1(m_dic_skillbtn[0]));

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

    IEnumerator skillCDCo(float time, GameObject btn)
    {
        int coid = coctrl.instance.coid_Dic["co_skillcd"];
        float curCD = time;
        UILabel label = btn.transform.Find("cd").GetComponent<UILabel>();
Debug.Log("time = " + time);
        while (true)
        {
Debug.Log("curCD = " + curCD);
            label.text = curCD.ToString();

            yield return new WaitForSeconds(1f);

            if (coid != coctrl.instance.coid_Dic["co_skillcd"])
            {
                break;
            }

            curCD--;

            if(curCD < 0)
                break;
        }
    }

    IEnumerator slidebarCo(float time)
    {
Debug.Log("slidebarCo.time = " + time);
        int id = coctrl.instance.coid_Dic["co_slidebar"];

        UISlider slider = m_slidebar.GetComponent<UISlider>();
        slider.sliderValue = 0;

        while (true)
        {
            yield return new WaitForSeconds(0.02f);

            if (id != coctrl.instance.coid_Dic["co_slidebar"])
            {
                break;
            }

			slider.sliderValue += (1 / 1) * 0.02f;

			if (slider.sliderValue == 1) 
			{
				break;
			}
        }
    }
    
}
