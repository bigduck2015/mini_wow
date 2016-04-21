using UnityEngine;
using System.Collections;

public class skill 
{
    public static skill instance = new skill();

    public delegate void skillstart(skilldata data, GameObject obj);
    public delegate void skillfinish(skilldata data, GameObject obj);

    public static skillstart del_skillstart;
    public static skillfinish del_skillfinish;

    private int m_public_cd = 0;

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
	public IEnumerator CDTimeCo(float cd)
    {
        yield return new WaitForSeconds(cd);
	}

    //cast time
    public IEnumerator CastTimeCo(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public virtual IEnumerator skilllogic(skilldata skilldata, GameObject skillbtn, string cokey)
    {
        int coid = coctrl.instance.coid_Dic[cokey];

        if (public_cd == 0)
        {
            del_skillstart(skilldata, skillbtn);

            coctrl.instance.StartCoroutine(PublicCDCo(skilldata.m_pubcd));

            yield return coctrl.instance.StartCoroutine(CastTimeCo(skilldata.m_spendtime));

            if (coid == coctrl.instance.coid_Dic[cokey])
            {
                delegates.deldamage(skilldata.m_damage);
                yield return coctrl.instance.StartCoroutine(CDTimeCo(skilldata.m_cd));
            }

            del_skillfinish(skilldata, skillbtn);
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
