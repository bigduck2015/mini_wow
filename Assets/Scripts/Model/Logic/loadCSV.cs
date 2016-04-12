using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class loadCSV 
{
	
	private ArrayList rowAL;         //行链表,CSV文件的每一行就是一个链
	
	// Use this for initialization
	
	public loadCSV() 
	{
		rowAL = new ArrayList();
	}
	
	public void LoadCSV(string path)
	{
		string FilePath = path;
		StreamReader sr = new StreamReader(FilePath);
		if(sr == null)
			return;
		
		while(true)
		{
			string fileDataLine;
			fileDataLine = sr.ReadLine();
			//Debug.Log(fileDataLine);
			if (fileDataLine == null)
	        	break;
           
            AddNewDataLine(fileDataLine);
        }
		
        sr.Close();
	}
	
	/// <summary>
    /// 加入新的数据行

    /// </summary>
    /// <param name=newDataLine>新的数据行</param>
    
    private void AddNewDataLine(string newDataLine)
    {
        string[] dataArray = newDataLine.Split('\t');
		this.rowAL.Add(dataArray);
    }
	
	public int GetInt(int row,int col)
	{
		int integer;
		
		if(int.TryParse(GetString(row,col),out integer))
			return integer;
		else
		{
			Debug.LogError("Can not parse to intiger!");
			return -1;
		}
	}
	
	public string GetString(int row,int col)
	{
		try
		{
			if(row > rowAL.Count)
			{
				return null;
			}
			
			string[] strArray = rowAL[row-1] as string[];
			
			if(col > strArray.Length)
			{
				return null;
			}
			
			string IndexValue = strArray[col-1];
			
			return IndexValue;
		}
		catch(Exception e)
		{
			Debug.LogException(e);
			return null;
		}
	}
	
	public float GetFloat(int row,int col)
	{
		float fValue;
		
		if(float.TryParse(GetString(row,col),out fValue))
			return fValue;
		else
		{
			Debug.LogError("Can not parse to float!");
			return -1;
		}
	}
	
}
