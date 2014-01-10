package com.widemo.utils;

import android.content.ContentResolver;
import android.content.Context;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.Build;
import android.os.Environment;
import android.provider.Settings;
import android.telephony.TelephonyManager;
import android.util.DisplayMetrics;

public class DeviceUtils
{

	private static TelephonyManager	_telephonyManager;
	private static Location			_location;

	public static String GetDeviceName()
	{
		return Build.MANUFACTURER + "  " + Build.MODEL;
	}

	public static String GetMac(Context context)
	{

		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		WifiManager wifi = (WifiManager) context.getSystemService(Context.WIFI_SERVICE);
		WifiInfo info = wifi.getConnectionInfo();
		String mac = info.getMacAddress();
		return mac;
	}

	public static String GetAndroidID(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		ContentResolver contentResolver = context.getContentResolver();
		String androidID = Settings.Secure.getString(contentResolver, Settings.Secure.ANDROID_ID);
		return androidID;
	}

	public static String GetNetworkType(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		ConnectivityManager connectivityManager = (ConnectivityManager) context.getSystemService(Context.CONNECTIVITY_SERVICE);
		NetworkInfo info = connectivityManager.getActiveNetworkInfo();
		String typeName;
		if (info != null && info.isAvailable())
		{
			typeName = info.getTypeName();
		}
		else
		{
			typeName = UtilsConst.NOT_AVAILABLE;
		}
		return typeName;
	}

	public static String GetSDKName()
	{
		return Build.VERSION.RELEASE;
	}

	public static String GetAPIVersion()
	{
		return Integer.toString(Build.VERSION.SDK_INT);
	}

	public static String GetResolution(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		DisplayMetrics displayMetrics = context.getResources().getDisplayMetrics();
		return displayMetrics.widthPixels + " * " + displayMetrics.heightPixels;
	}

	public static String GetIMEI(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}

		return GetTelephonyManager(context).getDeviceId();
	}

	public static String GetIMSI(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		return GetTelephonyManager(context).getSubscriberId();
	}

	public static String GetNetworkOperator(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		return GetTelephonyManager(context).getNetworkOperator();
	}

	public static String GetLongitude(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		return Double.toString(GetLastKnownLocation(context).getLongitude());
	}

	public static String GetLatitude(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		return Double.toString(GetLastKnownLocation(context).getLatitude());
	}

	public static String GetExternalStorageDirectory()
	{
		String path = null;
		if (Environment.MEDIA_MOUNTED.equals(Environment.getExternalStorageState()))
		{
			path = Environment.getExternalStorageDirectory().toString();
			// path.intern();
		}

		return path;
	}

	public static String GetSimSerialNumber(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		return GetTelephonyManager(context).getSimSerialNumber();
	}

	private static Location GetLastKnownLocation(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		if (_location == null)
		{
			LocationManager loctionManager;
			String contextService = Context.LOCATION_SERVICE;
			loctionManager = (LocationManager) context.getSystemService(contextService);

			Criteria criteria = new Criteria();
			criteria.setAccuracy(Criteria.ACCURACY_FINE);// 高精度
			criteria.setAltitudeRequired(false);// 不要求海拔
			criteria.setBearingRequired(false);// 不要求方位
			criteria.setCostAllowed(true);// 允许有花费
			criteria.setPowerRequirement(Criteria.POWER_LOW);// 低功耗
			// 从可用的位置提供器中，匹配以上标准的最佳提供器
			String provider = loctionManager.getBestProvider(criteria, true);

			// 获得最后一次变化的位置
			_location = loctionManager.getLastKnownLocation(provider);
		}
		return _location;
	}

	private static TelephonyManager GetTelephonyManager(Context context)
	{
		if (context == null)
		{
			throw new NullPointerException(UtilsConst.EXCEPTION_CONTEXT_NULL);
		}
		if (_telephonyManager == null)
		{
			_telephonyManager = (TelephonyManager) context.getSystemService(Context.TELEPHONY_SERVICE);
		}
		return _telephonyManager;
	}
}
