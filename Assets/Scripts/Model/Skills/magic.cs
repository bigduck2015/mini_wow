﻿using UnityEngine;
using System.Collections;

public class magic : skill 
{
    
    //cast寒冰箭
    public override IEnumerator skill1(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[0];

        int coid = coctrl.instance.coid_Dic["co_skill1"];

        if (public_cd == 0)
        {
            delegates.delcurskill(skilldata, skillbtn);

            coctrl.instance.StartCoroutine(player.instance.skill.PublicCDCo(skilldata.m_pubcd));

            yield return coctrl.instance.StartCoroutine(player.instance.skill.CastTimeCo(skilldata.m_spendtime));

            if (coid == coctrl.instance.coid_Dic["co_skill1"])
            {
                delegates.deldamage(skilldata.m_damage);
                yield return coctrl.instance.StartCoroutine(player.instance.skill.CDTimeCo(skilldata.m_cd));
            }
        }
    }

    public override IEnumerator skill2(GameObject skillbtn)
    {
        return null;
    }

    public override IEnumerator skill3(GameObject skillbtn)
    {
        return null;
    }
}