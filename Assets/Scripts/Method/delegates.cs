using System;
using UnityEngine;

public class delegates
{
    public delegate void del_curskill(skilldata data, GameObject obj);
	public delegate void del_pubcd(float time);

    public static del_curskill delcurskill;
	public static del_pubcd delpubcd;

}

