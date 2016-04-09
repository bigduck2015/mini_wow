using UnityEngine;
using System.Collections;

public class skill 
{

    //公共CD
    public static IEnumerator PublicCDCo(float public_cd)
    {
        player.instance.SetPubCDState(1);
		delegates.delpubcd(public_cd);
        yield return new WaitForSeconds(public_cd);
        player.instance.SetPubCDState(0);
    }

    //技能CD
	public static IEnumerator CDTimeCo(float cd)
    {
        yield return new WaitForSeconds(cd);
	}

    //cast time
    public static IEnumerator CastTimeCo(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
