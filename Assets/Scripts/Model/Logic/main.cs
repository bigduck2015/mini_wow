using UnityEngine;
using System.Collections;

public class main 
{

	// Use this for initialization
	public static void init () 
    {
        GameObject Global = GameObject.Find("Global");

        player.instance = Global.AddComponent<player>();
        coctrl.instance = Global.AddComponent<coctrl>();

        player.instance.SetSkill(new magic());

        boss.instance.sethp(100000f);
        boss.instance.init();

        skilldata skill1 = new skilldata();

        skill1.m_id = 0;
        skill1.m_cd = 3;
        skill1.m_pubcd = 1;
        skill1.m_name = "寒冰箭";
        skill1.m_damage = 5086f;
        skill1.m_spendtime = 2f;
        skill1.m_dottime = 0;
        skill1.m_description = "15%的几率让敌人处于冻结效果，10%的几率令你下一个霜火箭顺发";

        cfgData.instance.m_dic_skilldata[0] = skill1;
    }
	
}
