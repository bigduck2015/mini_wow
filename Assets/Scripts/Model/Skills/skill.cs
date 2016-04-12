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

    public virtual IEnumerator skill1(GameObject skillbtn)
    {
        return null;
    }

    public virtual IEnumerator skill2(GameObject skillbtn)
    {
        return null;
    }

    public virtual IEnumerator skill3(GameObject skillbtn)
    {
        return null;
    }


}
