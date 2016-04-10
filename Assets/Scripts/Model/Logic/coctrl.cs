using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class coctrl : MonoBehaviour
{
    public static coctrl instance = null;

    private Dictionary<string,int> m_coid_Dic = new Dictionary<string, int>();

    public Coroutine StartCoroutine(string key, IEnumerator itor)
    {
        if (m_coid_Dic.ContainsKey(key) == false)
        {
            m_coid_Dic[key] = 0;
        }
        else
        {
            m_coid_Dic[key]++;
        }

        return StartCoroutine(itor);
    }

    public Dictionary<string,int> coid_Dic
    {
        get
        {
            return m_coid_Dic;
        }
    }
}

