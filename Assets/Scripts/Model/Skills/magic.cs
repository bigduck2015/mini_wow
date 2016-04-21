using UnityEngine;
using System.Collections;

public class magic : skill 
{
    public override skilldata getskilldata(int index)
    {
        return cfgData.instance.m_dic_skilldata[index-1];
    }

    //cast寒冰箭
    public override void skill1(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[0];
        coctrl.instance.StartCoroutine("co_skill1", skilllogic(skilldata, skillbtn, "co_skill1"));
    }

    public override void skill2(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[1];
        coctrl.instance.StartCoroutine("co_skill2", skilllogic(skilldata, skillbtn, "co_skill2"));
    }

    public override void skill3(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[2];
        coctrl.instance.StartCoroutine("co_skill3", skilllogic(skilldata, skillbtn, "co_skill3"));
    }

    public override void skill4(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[3];
        coctrl.instance.StartCoroutine("co_skill4", skilllogic(skilldata, skillbtn, "co_skill4"));
    }

    public override void skill5(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[4];
        coctrl.instance.StartCoroutine("co_skill5", skilllogic(skilldata, skillbtn, "co_skill5"));
    }

    public override void skill6(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[5];
        coctrl.instance.StartCoroutine("co_skill6", skilllogic(skilldata, skillbtn, "co_skill6"));
    }

    public override void skill7(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[6];
        coctrl.instance.StartCoroutine("co_skill7", skilllogic(skilldata, skillbtn, "co_skill7"));
    }

    public override void skill8(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[7];
        coctrl.instance.StartCoroutine("co_skill8", skilllogic(skilldata, skillbtn, "co_skill8"));
    }

    public override void skill9(GameObject skillbtn)
    {
        var skilldata = cfgData.instance.m_dic_skilldata[8];
        coctrl.instance.StartCoroutine("co_skill9", skilllogic(skilldata, skillbtn, "co_skill9"));
    }
}
