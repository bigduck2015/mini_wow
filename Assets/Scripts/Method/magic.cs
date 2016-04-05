using UnityEngine;
using System.Collections;

public class magic : career 
{
    
    //cast寒冰箭
    public IEnumerator skill1(skilldata data)
    {
        int coid = coctrl.instance.coid_Dic["co_skill1"];

        if (player.instance.public_cd == 0)
        {
            coctrl.instance.StartCoroutine(skill.PublicCDCo(data.m_pubcd));

            yield return coctrl.instance.StartCoroutine(skill.CastTimeCo(data.m_spendtime));

            if (coid == coctrl.instance.coid_Dic["co_skill1"])
            {
                yield return coctrl.instance.StartCoroutine(skill.CDTimeCo(data.m_cd));
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
