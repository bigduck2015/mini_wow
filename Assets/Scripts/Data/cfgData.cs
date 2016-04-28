using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cfgData 
{
    public static cfgData instance = new cfgData();

    public Dictionary<int,skilldata> m_dic_skilldata = new Dictionary<int, skilldata>();
    public Dictionary<int,buffdata> m_dic_buffdata = new Dictionary<int, buffdata>();
}

public class skilldata
{
    public int m_id; //技能id
    public float m_pubcd; //技能公共cd
    public float m_cd; //cd
    public float m_damage; //伤害
    public string m_name; //技能名
    public float m_spendtime; //施放时长
    public float m_bufftime; //持续时间
    public string m_description; //效果描述
    public Dictionary<int, skillbuff> m_buffdic = new Dictionary<int, skillbuff>();

    public struct skillbuff
    {
        public int m_id;
        public float m_rate;
        public float m_dottime;
    }
}

public class buffdata
{
    public int m_id; //buff id
    public string m_name; //技能名
    public float m_dottime; //持续时间
    public string m_description; //效果描述
}