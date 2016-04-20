using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ui_main : MonoBehaviour 
{
    private GameObject m_slidebar = null;
    private GameObject m_fighttime = null;
    private Dictionary<int, GameObject> m_dic_skillbtn = new Dictionary<int, GameObject>();
    private GameObject m_dps = null;

    void Awake()
    {
        skill.del_skillstart = OnSkillStart;
        skill.del_skillfinish = OnSkillFinished;

		delegates.delpubcd = OnPubCD;
        delegates.deldps = OnDPS;
        delegates.delfighttime = OnFightTime;
    }

	// Use this for initialization
	void Start () 
    {
        m_slidebar = GameObject.Find("slidebar");
        m_dps = GameObject.Find("DPS");
        m_fighttime = GameObject.Find("Time");
        m_dic_skillbtn[0] = GameObject.Find("Btn1");

        //main.init();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    
    void OnFightTime(int time)
    {
        int min = time / 60;
        int sec = time - 60 * min;

        m_fighttime.transform.Find("value").GetComponent<UILabel>().text = min + "." + sec;
    }

    void OnDPS(float dps)
    {
        m_dps.transform.Find("value").GetComponent<UILabel>().text = dps.ToString("F2");
    }

	void OnPubCD (float time)
	{
		coctrl.instance.StartCoroutine("co_OnPubCD", publicCDCo(time));
	}

    void OnSkillFinished(skilldata data, GameObject skillbtn)
    {
        skillbtn.GetComponent<UIButtonMessage>().enabled = true;
    }

    void OnSkillStart(skilldata data, GameObject skillbtn)
    {
        skillbtn.GetComponent<UIButtonMessage>().enabled = false;
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

    void OnSkill1()
    {
//Debug.LogError("OnSkill1.1");
        var btn = m_dic_skillbtn[0];
//Debug.LogError("OnSkill1.2");
        var itor = skill.instance.skill1(btn);
//Debug.LogError("OnSkill1.3");
        coctrl.instance.StartCoroutine("co_skill1", itor);
//Debug.LogError("OnSkill1.4");
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

	IEnumerator publicCDCo(float time)
    {
        int coid = coctrl.instance.coid_Dic["co_OnPubCD"];
        var pubcd = GameObject.Find("PubCD/value").GetComponent<UILabel>();
        float curcd = time;
Debug.Log("curcd = " + curcd);
        pubcd.text = curcd.ToString("F2");

        while (true)
        {
            yield return null;

            if (coid != coctrl.instance.coid_Dic["co_OnPubCD"])
            {
                break;
            }

			curcd -= Time.deltaTime;
Debug.Log("curcd = " + curcd);
			pubcd.text = curcd.ToString ("F2");
			if (curcd <= 0) 
			{
				break;
			}
		}
		
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
            label.text = curCD.ToString("F2");

            yield return null;

            if (coid != coctrl.instance.coid_Dic["co_skillcd"])
            {
                break;
            }

			curCD -= Time.deltaTime;

            if(curCD <= 0)
                break;
        }
    }

    IEnumerator slidebarCo(float time)
    {
Debug.Log("slidebarCo.time = " + time);
        int id = coctrl.instance.coid_Dic["co_slidebar"];

        UISlider slider = m_slidebar.GetComponent<UISlider>();
        slider.sliderValue = 0;

		var SpendTime = GameObject.Find("SpendTime/value");
		UILabel label_SpendTime = SpendTime.GetComponent<UILabel>();
		float sptime = 0f;

        while (true)
        {
			label_SpendTime.text = sptime.ToString("F2");

            yield return null;

			sptime += Time.deltaTime; 

            if (id != coctrl.instance.coid_Dic["co_slidebar"])
            {
                break;
            }

			slider.sliderValue += (1 / time) * Time.deltaTime;

			if (slider.sliderValue == 1) 
			{
				break;
			}
        }
    }
    
}
