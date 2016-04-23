using UnityEngine;
using System.Collections;

public class skill 
{
    public static skill instance = new skill();

    public delegate void skillstart(int skillid);
    public delegate void skillfinish(int skillid);
    public delegate void casttime(float time);
    public delegate void cdtime(int id, float time);

    public static skillstart del_skillstart;
    public static skillfinish del_skillfinish;
    public static casttime del_casttime;
    public static cdtime del_cdtime;

    private int m_public_cd = 0;
    protected float m_speedrate = 0f; //施法速率

    public int public_cd
    {
        get
        {
            return m_public_cd;
        }
    }

    //公共CD
    public IEnumerator PublicCDCo(float public_cd)
    {
        m_public_cd = 1;
		delegates.delpubcd(public_cd);
        yield return new WaitForSeconds(public_cd);
        m_public_cd = 0;
    }

    //技能CD
    public IEnumerator CDTimeCo(skilldata skilldata)
    {
        del_cdtime(skilldata.m_id, skilldata.m_cd);
        yield return new WaitForSeconds(skilldata.m_cd);
	}

    //cast time
    public IEnumerator CastTimeCo(float time)
    {
        del_casttime(time);
        yield return new WaitForSeconds(time);
    }

    //buff持续时间
    public IEnumerator BuffSpeedCo(float rate, float time)
    {
        m_speedrate = rate;
        yield return new WaitForSeconds(time);
        m_speedrate = 1f;
    }

    public virtual IEnumerator skilllogic(skilldata skilldata, GameObject skillbtn, string cokey)
    {
        int coid = coctrl.instance.coid_Dic[cokey];

        if (public_cd == 0)
        {
            del_skillstart(skilldata.m_id);

            coctrl.instance.StartCoroutine(PublicCDCo(skilldata.m_pubcd));

            yield return coctrl.instance.StartCoroutine(CastTimeCo(skilldata.m_spendtime * m_speedrate));

            if (coid == coctrl.instance.coid_Dic[cokey])
            {
                delegates.deldamage(skilldata.m_damage);

                yield return coctrl.instance.StartCoroutine(CDTimeCo(skilldata));
            }

            del_skillfinish(skilldata.m_id);
        }
    }

    public virtual skilldata getskilldata(int index)
    {
        return null;
    }

    public virtual void skill1(GameObject skillbtn){}

    public virtual void skill2(GameObject skillbtn){}

    public virtual void skill3(GameObject skillbtn){}

    public virtual void skill4(GameObject skillbtn){}
    
    public virtual void skill5(GameObject skillbtn){}
    
    public virtual void skill6(GameObject skillbtn){}
    
    public virtual void skill7(GameObject skillbtn){}
    
    public virtual void skill8(GameObject skillbtn){}
    
    public virtual void skill9(GameObject skillbtn){}


}
