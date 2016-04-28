using System;
using System.Collections;
using UnityEngine;

public class buff
{
    public static buff instance = new buff();

    private int m_freeze = 0;

    public buff()
    {
    }

    //冻结持续时间
    public IEnumerator FreezeCo(float time)
    {
        int coid = coctrl.instance.coid_Dic["FreezeCo"];

        m_freeze = 1;
        yield return new WaitForSeconds(time);

        if (coid == coctrl.instance.coid_Dic["FreezeCo"])
        {
            m_freeze = 0;
        }
    }

    //急速持续时间
    public IEnumerator SpeedCo(float rate, float time)
    {
        int coid = coctrl.instance.coid_Dic["SpeedCo"];        

        skill.instance.Setspeedrate(rate);
        yield return new WaitForSeconds(time);

        if (coid == coctrl.instance.coid_Dic["SpeedCo"])
        {
            skill.instance.Setspeedrate(1f);
        }
    }
}

