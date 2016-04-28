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
        skill.del_casttime = OnCast;
        skill.del_cdtime = OnCD;

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

        initskillbtn();
	}
	
    void initskillbtn()
    {
        var SkillBtns = this.gameObject.transform.Find("SkillBtns");

        skilldata data1 = skill.instance.getskilldata(1);
        m_dic_skillbtn[0] = SkillBtns.Find("Grid1/Btn1").gameObject;
        SkillBtns.Find("Grid1/Btn1/name").GetComponent<UILabel>().text = data1.m_name;

        skilldata data2 = skill.instance.getskilldata(2);
        m_dic_skillbtn[1] = SkillBtns.Find("Grid1/Btn2").gameObject;
        SkillBtns.Find("Grid1/Btn2/name").GetComponent<UILabel>().text = data2.m_name;

        skilldata data3 = skill.instance.getskilldata(3);
        m_dic_skillbtn[2] = SkillBtns.Find("Grid1/Btn3").gameObject;
        SkillBtns.Find("Grid1/Btn3/name").GetComponent<UILabel>().text = data3.m_name;

        skilldata data4 = skill.instance.getskilldata(4);
        m_dic_skillbtn[3] = SkillBtns.Find("Grid2/Btn1").gameObject;
        SkillBtns.Find("Grid2/Btn1/name").GetComponent<UILabel>().text = data4.m_name;

        skilldata data5 = skill.instance.getskilldata(5);
        m_dic_skillbtn[4] = SkillBtns.Find("Grid2/Btn2").gameObject;
        SkillBtns.Find("Grid2/Btn2/name").GetComponent<UILabel>().text = data5.m_name;

        skilldata data6 = skill.instance.getskilldata(6);
        m_dic_skillbtn[5] = SkillBtns.Find("Grid2/Btn3").gameObject;
        SkillBtns.Find("Grid2/Btn3/name").GetComponent<UILabel>().text = data6.m_name;

        skilldata data7 = skill.instance.getskilldata(7);
        m_dic_skillbtn[6] = SkillBtns.Find("Grid3/Btn1").gameObject;
        SkillBtns.Find("Grid3/Btn1/name").GetComponent<UILabel>().text = data7.m_name;

        skilldata data8 = skill.instance.getskilldata(8);
        m_dic_skillbtn[7] = SkillBtns.Find("Grid3/Btn2").gameObject;
        SkillBtns.Find("Grid3/Btn2/name").GetComponent<UILabel>().text = data8.m_name;

        skilldata data9 = skill.instance.getskilldata(9);
        m_dic_skillbtn[8] = SkillBtns.Find("Grid3/Btn3").gameObject;
        SkillBtns.Find("Grid3/Btn3/name").GetComponent<UILabel>().text = data9.m_name;
    }

	// Update is called once per frame
	void Update () 
    {
	
	}
    
    void OnCD(int id, float time)
    {
        coctrl.instance.StartCoroutine(skillCDCo(id, time));
    }

    void OnCast(float time)
    {
        Debug.LogError("OnCast.time = " + time);
        coctrl.instance.StartCoroutine("CastCo", CastCo(time));
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

    void OnSkillStart(int id)
    {
        m_dic_skillbtn[id].GetComponent<UIButtonMessage>().enabled = false;
    }

    void OnSkillFinished(int id)
    {
        m_dic_skillbtn[id].GetComponent<UIButtonMessage>().enabled = true;
    }

    void OnSkill1()
    {
        skill.instance.skill1(m_dic_skillbtn[0]);
    }
    
    void OnSkill2()
    {
        skill.instance.skill2(m_dic_skillbtn[1]);
    }

    void OnSkill3()
    {
        skill.instance.skill3(m_dic_skillbtn[2]);
    }

    void OnSkill4()
    {
        skill.instance.skill4(m_dic_skillbtn[3]);
    }

    void OnSkill5()
    {
        skill.instance.skill5(m_dic_skillbtn[4]);
    }

    void OnSkill6()
    {
        skill.instance.skill6(m_dic_skillbtn[5]);
    }

    void OnSkill7()
    {
        skill.instance.skill7(m_dic_skillbtn[6]);
    }

    void OnSkill8()
    {
        skill.instance.skill8(m_dic_skillbtn[7]);
    }

    void OnSkill9()
    {
        skill.instance.skill9(m_dic_skillbtn[8]);
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

    IEnumerator skillCDCo(int id, float time)
    {
        //int coid = coctrl.instance.coid_Dic["co_skillcd"];
        GameObject btn = m_dic_skillbtn[id];

        float curCD = time;

        UILabel label = btn.transform.Find("cd").GetComponent<UILabel>();
Debug.Log("time = " + time);
        while (true)
        {
Debug.Log("curCD = " + curCD);
            label.text = curCD.ToString("F2");

            yield return null;

//            if (coid != coctrl.instance.coid_Dic["co_skillcd"])
//            {
//                break;
//            }

			curCD -= Time.deltaTime;

            if(curCD <= 0)
                break;
        }
    }

    public IEnumerator CastCo(float time)
    {
        int coid = coctrl.instance.coid_Dic["CastCo"];

        float totaltime = 0f;
        UISlider slider = m_slidebar.GetComponent<UISlider>();
        slider.sliderValue = 0;

        var SpendTime = GameObject.Find("SpendTime/value");
        UILabel label_SpendTime = SpendTime.GetComponent<UILabel>();

        while (true)
        {
            yield return null;
 
            if (coid != coctrl.instance.coid_Dic["CastCo"])
            {
                break;
            }

            totaltime += Time.deltaTime;

            label_SpendTime.text = totaltime.ToString("F2");

            slider.sliderValue += Time.deltaTime/time;

            if (totaltime >= time)
            {
                break;
            }
        }
    }
    
}
