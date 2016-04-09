using UnityEngine;
using System.Collections;

public class magic : career 
{
    
    //cast寒冰箭
    public IEnumerator skill1(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[0];

        int coid = coctrl.instance.coid_Dic["co_skill1"];

        if (player.instance.public_cd == 0)
        {
            delegates.delcurskill(skilldata, skillbtn);

            coctrl.instance.StartCoroutine(skill.PublicCDCo(skilldata.m_pubcd));

            yield return coctrl.instance.StartCoroutine(skill.CastTimeCo(skilldata.m_spendtime));

            if (coid == coctrl.instance.coid_Dic["co_skill1"])
            {
                yield return coctrl.instance.StartCoroutine(skill.CDTimeCo(skilldata.m_cd));
            }
        }
    }

    public IEnumerator skill2()
    {
        return null;
    }

    public IEnumerator skill3()
    {
        return null;
    }
}
