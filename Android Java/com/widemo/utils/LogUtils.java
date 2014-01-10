/**************************************************************************
 * Filename : AccountUtils.java
 * Copyright : Copyright 2005 - 2013 WiSTONE. All Rights Reserved.
 **************************************************************************/
package com.widemo.utils;

/**
 * @author isUseful ? TanJian : Unknown
 */
public class LogUtils
{

	public static void LogError(String tag, String message)
	{
		android.util.Log.e(tag, message);
	}

	public static void Log(String tag, String message)
	{
		android.util.Log.i(tag, message);
	}

	public static void LogWarning(String tag, String message)
	{
		android.util.Log.w(tag, message);
	}

}
