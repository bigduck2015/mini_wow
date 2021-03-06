﻿using UnityEngine;
using System.Collections;

public class ui_start : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void init () 
    {
        GameObject Global = GameObject.Find("Global");

        player.instance = Global.AddComponent<player>();
        coctrl.instance = Global.AddComponent<coctrl>();

        skill.instance = new magic();

        boss.instance.sethp(100000f);
        boss.instance.init();
    }

    void OnFight()
    {
        LoadSkillCfg();
        init();
        viewctrl.instance.loadlevel("MainView");
    }

    void LoadSkillCfg()
    {
        string cfgpath_skill = System.IO.Path.Combine(mode_file.instance.initSystemPath(), "Data/技能表.csv");

        loadCSV reader = new loadCSV();
        reader.LoadCSV(cfgpath_skill);

        for(int row=2; row<=reader.rowCount; row++)
        {
            skilldata data = new skilldata();

            var buff1 = new skilldata.skillbuff();
            var buff2 = new skilldata.skillbuff();

            for(int col=1; col<=14; col++)
            {
                switch(col)
                {
                    case 1:
                        data.m_id = reader.GetInt(row, col);
                        break;
                    case 2:
                        data.m_name = reader.GetString(row, col);
                        break;
                    case 3:
                        data.m_spendtime = reader.GetFloat(row, col);
                        break;
                    case 4:
                        data.m_damage = reader.GetFloat(row, col);
                        break;
                    case 5:
                        data.m_bufftime = reader.GetFloat(row, col);
                        break;
                    case 6:
                        data.m_pubcd = reader.GetFloat(row, col);
                        break;
                    case 7:
                        data.m_cd = reader.GetFloat(row, col);
                        break;
                    case 8:
                        buff1.m_id = reader.GetInt(row, col);
                        break;
                    case 9:
                        buff1.m_rate = reader.GetFloat(row, col);
                        break;
                    case 10:
                        buff1.m_dottime = reader.GetFloat(row, col);
                        break;
                    case 11:
                        buff2.m_id = reader.GetInt(row, col);
                        break;
                    case 12:
                        buff2.m_rate = reader.GetFloat(row, col);
                        break;
                    case 13:
                        buff2.m_dottime = reader.GetFloat(row, col);
                        break;
                    case 14:
                        data.m_description = reader.GetString(row, col);
                        break;
                }
            }

            data.m_buffdic[buff1.m_id] = buff1;
            data.m_buffdic[buff2.m_id] = buff2;

            cfgData.instance.m_dic_skilldata[data.m_id] = data;
        }
    }

    void LoadBuffCfg()
    {
        string cfgpath_buff = System.IO.Path.Combine(mode_file.instance.initSystemPath(), "Data/效果表.csv");

        loadCSV reader = new loadCSV();
        reader.LoadCSV(cfgpath_buff);

        for(int row=2; row<=reader.rowCount; row++)
        {
            skilldata data = new skilldata();

            for(int col=1; col<=3; col++)
            {
                switch(col)
                {
                    case 1:
                        data.m_id = reader.GetInt(row, col);
                        break;
                    case 2:
                        data.m_name = reader.GetString(row, col);
                        break;
                    case 3:
                        data.m_spendtime = reader.GetFloat(row, col);
                        break;
                    case 4:
                        data.m_damage = reader.GetFloat(row, col);
                        break;
                    case 5:
                        data.m_bufftime = reader.GetFloat(row, col);
                        break;
                    case 6:
                        data.m_pubcd = reader.GetFloat(row, col);
                        break;
                    case 7:
                        data.m_cd = reader.GetFloat(row, col);
                        break;
                    case 8:
                        data.m_description = reader.GetString(row, col);
                        break;
                }
            }

            cfgData.instance.m_dic_skilldata[data.m_id] = data;
        }
    }
}
