using System;
using UnityEngine;

public class mode_file
{
    public static mode_file instance = new mode_file();

    public string initSystemPath()
    {
        try
        {
            string systemPath;

            switch(Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    // IOS
                    systemPath = Application.persistentDataPath;
                    break;
                case RuntimePlatform.Android:
                    // android
                    systemPath = Application.persistentDataPath;
                    //UnityEngine.Debug.Log("Android");
                    break;
                case RuntimePlatform.WindowsPlayer:
                    // windows
                    systemPath = Application.temporaryCachePath;
                    //UnityEngine.Debug.Log("WindowsPlayer");
                    break;
                case RuntimePlatform.WindowsWebPlayer:
                    // windows web
                    systemPath = Application.temporaryCachePath;
                    //UnityEngine.Debug.Log("WindowsWebPlayer");
                    break;
                case RuntimePlatform.WindowsEditor:
                    // WindowsEditor
                    systemPath = Application.dataPath;  
                    //UnityEngine.Debug.Log("WindowsEditor");
                    break;
                case RuntimePlatform.OSXEditor:
                    // OSXEditor
                    systemPath = Application.dataPath;
                    //UnityEngine.Debug.Log("OSXEditor");
                    break;
                case RuntimePlatform.OSXPlayer:
                    // OSXPlayer
                    systemPath = Application.persistentDataPath;
                    //UnityEngine.Debug.Log("OSXPlayer");
                    break;
                default:
                    // Not
                    systemPath = Application.temporaryCachePath;
                //UnityEngine.Debug.Log("Not platform");
                    break;
            }
            
            return systemPath;
            
        }
        catch(Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }
}

