using System;
using UnityEngine;

public class delegates
{
    public delegate void del_curskill(skilldata data, GameObject obj);
	public delegate void del_pubcd(float time);
    public delegate void del_damage(float damage);
    public delegate void del_dps(float dps);
    public delegate void del_fighttime(int time);

    public static del_curskill delcurskill;
	public static del_pubcd delpubcd;
    public static del_pubcd deldamage;
    public static del_pubcd deldps;
    public static del_fighttime delfighttime;
}

