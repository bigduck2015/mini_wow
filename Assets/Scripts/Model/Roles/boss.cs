using UnityEngine;
using System.Collections;

public class boss
{
    public static boss instance = new boss();

    private float m_maxhp = 0f;
    private float m_curhp = 0;
 
    private boss()
    {
        delegates.deldamage = OnDamage; 
    }

    public void init()
    {
        m_curhp = m_maxhp;
        coctrl.instance.StartCoroutine("DPSCo", DPSCo());
    }

    public float curhp
    {
        get
        {
            return m_curhp;
        }
    }

    void OnDamage(float damage)
    {
        m_curhp -= damage;
    }

    public void sethp(float hp)
    {
        m_maxhp = hp;
    }

    IEnumerator DPSCo()
    {
        int coid = coctrl.instance.coid_Dic["DPSCo"];
        int seconds = 0;
        float oldtime = Time.time;

        while (true)
        {
            yield return null;

            if(coid != coctrl.instance.coid_Dic["DPSCo"])
            {
                break;
            }

            if((Time.time - oldtime) >=1)
            {
                var dps = (m_maxhp - m_curhp)/++seconds;
                delegates.deldps(dps);
                delegates.delfighttime(seconds);
                oldtime = Time.time;
            }
        }
    }
}
