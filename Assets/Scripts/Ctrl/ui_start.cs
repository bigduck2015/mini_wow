using UnityEngine;
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

    void OnFight()
    {
        viewctrl.instance.loadlevel("MainView");
    }

    void LoadCfg()
    {
        loadCSV reader = new loadCSV();
        reader.LoadCSV("");

        for(int row=2; row<11; row++)
        {
            for(int col=1; col<9; col++)
            {
                switch(col)
                {
                    case 1:
                        reader.GetInt(row, col);
                        break;
                    case 2:
                        reader.GetString(row, col);
                        break;
                    case 3:
                        reader.GetFloat(row, col);
                        break;
                    case 4:
                        reader.GetFloat(row, col);
                        break;
                    case 5:
                        reader.GetFloat(row, col);
                        break;
                    case 6:
                        reader.GetFloat(row, col);
                        break;
                    case 7:
                        reader.GetFloat(row, col);
                        break;
                    case 8:
                        reader.GetString(row, col);
                        break;
                }
            }
        }
    }
}
