using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Widemo.Utils
{
    public class DeviceUtils
    {

        private const string CLASS_UNITYPLAYER_ACTIVITY = "com.unity3d.player.UnityPlayer";
        private const string CLASS_DEVICES_UTILS = "com.widemo.utils.DeviceUtils";

        private static string _deviceName = null;
        private static string _mac = null;
        private static string _deviceID = null;
        private static string _networkType = null;
        private static string _osName = null;
        private static string _osVersion = null;
        private static string _resolution = null;
        private static string _imei = null;
        private static string _imsi = null;
        private static string _networkOperator = null;
        private static string _externalStorageDirectory = null;
        private static string _simSerialNumber = null;

        //初始化标记 所有数据只取一次
        private static bool _deviceNameInitialized = false;
        private static bool _macInitialized = false;
        private static bool _deviceIDInitialized = false;
        private static bool _networkTypeInitialized = false;
        private static bool _osNameInitialized = false;
        private static bool _osVersionInitialized = false;
        private static bool _resolutionInitialized = false;
        private static bool _imeiInitialized = false;
        private static bool _imsiInitialized = false;
        private static bool _networkOperatorInitialized = false;
        private static bool _externalStorageDirectoryInitialized = false;
        private static bool _simSerialNumberInitialized = false;

        /// <summary>
        /// 获取设备名称
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceName()
        {
            if (_deviceNameInitialized)
            {
                return _deviceName;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

            _deviceName = SystemInfo.deviceName;

#elif UNITY_ANDROID

            using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
            {
                _deviceName = deviceUtils.CallStatic<string>("GetDeviceName");
                deviceUtils.Dispose();
            }

#elif UNITY_IPHONE

            //_deviceName = _IOS_GetDeviceName();

#endif
            _deviceNameInitialized = true;
            return _deviceName;
        }

        /// <summary>
        /// 获取Mac地址
        /// </summary>
        /// <returns></returns>
        public static string GetMac()
        {
            if (_macInitialized)
            {
                return _mac;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID

            using (AndroidJavaClass unityClass = new AndroidJavaClass(CLASS_UNITYPLAYER_ACTIVITY))
            {
                using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
                    {
                        _mac = deviceUtils.CallStatic<string>("GetMac", activity);
                        deviceUtils.Dispose();
                    }
                    activity.Dispose();
                }
                unityClass.Dispose();
            }

#elif UNITY_IPHONE

            //_mac = _IOS_GetMac();

#endif
            _macInitialized = true;
            return _mac;
        }

        /// <summary>
        /// 获取设备ID
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceID()
        {
            if (_deviceIDInitialized)
            {
                return _deviceID;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID
            using (AndroidJavaClass unityClass = new AndroidJavaClass(CLASS_UNITYPLAYER_ACTIVITY))
            {
                using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
                    {
                        _deviceID = deviceUtils.CallStatic<string>("GetAndroidID", activity);
                        deviceUtils.Dispose();
                    }
                    activity.Dispose();
                }
                unityClass.Dispose();
            }
#elif UNITY_IPHONE

            //_deviceID = _IOS_GetDeviceID();

#endif
            _deviceIDInitialized = true;
            return _deviceID;
        }

        /// <summary>
        /// 获取网络类型，如3G、WIFI
        /// </summary>
        /// <returns></returns>
        public static string GetNetworkType()
        {
            if (_networkTypeInitialized)
            {
                return _networkType;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID
            using (AndroidJavaClass unityClass = new AndroidJavaClass(CLASS_UNITYPLAYER_ACTIVITY))
            {
                using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
                    {
                        _networkType = deviceUtils.CallStatic<string>("GetNetworkType", activity);
                        deviceUtils.Dispose();
                    }
                    activity.Dispose();
                }
                unityClass.Dispose();
            }
#elif UNITY_IPHONE

             //_networkType = _IOS_GetNetworkType();

#endif
            _networkTypeInitialized = true;
            return _networkType;
        }


        /// <summary>
        /// 获取系统名称
        /// </summary>
        /// <returns></returns>
        public static string GetOSName()
        {
            if (_osNameInitialized)
            {
                return _osName;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
#elif UNITY_ANDROID

            using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
            {
                _osName = deviceUtils.CallStatic<string>("GetSDKName");
                deviceUtils.Dispose();
            }

#elif UNITY_IPHONE

            //_osName = _IOS_GetOSName();

#endif

            _osNameInitialized = true;
            return _osName;
        }

        /// <summary>
        /// 获取系统版本
        /// </summary>
        /// <returns></returns>
        public static string GetOSVersion()
        {
            if (_osVersionInitialized)
            {
                return _osVersion;
            }


#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID
            using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
            {
                _osVersion = deviceUtils.CallStatic<string>("GetAPIVersion");
                deviceUtils.Dispose();
            }
#elif UNITY_IPHONE

            //_osVersion = _IOS_GetOSVersion();

#endif
            _osVersionInitialized = true;
            return _osVersion;
        }

        /// <summary>
        /// 获取分辨率
        /// </summary>
        /// <returns></returns>
        public static string GetResolution()
        {
            if (_resolutionInitialized)
            {
                return _resolution;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID
            using (AndroidJavaClass unityClass = new AndroidJavaClass(CLASS_UNITYPLAYER_ACTIVITY))
            {
                using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
                    {
                        _resolution = deviceUtils.CallStatic<string>("GetResolution", activity);
                        deviceUtils.Dispose();
                    }
                    activity.Dispose();
                }
                unityClass.Dispose();
            }
#elif UNITY_IPHONE

            //_resolution = _IOS_GetResolution();

#endif
            _resolutionInitialized = true;
            return _resolution;
        }

        /// <summary>
        /// 获取IMEI
        /// </summary>
        /// <returns></returns>
        public static string GetIMEI()
        {
            if (_imeiInitialized)
            {
                return _imei;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID
            using (AndroidJavaClass unityClass = new AndroidJavaClass(CLASS_UNITYPLAYER_ACTIVITY))
            {
                using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
                    {
                        _imei = deviceUtils.CallStatic<string>("GetIMEI", activity);
                        deviceUtils.Dispose();
                    }
                    activity.Dispose();
                }
                unityClass.Dispose();
            }
#elif UNITY_IPHONE

            //_imei = _IOS_GetIMEI();

#endif
            _imeiInitialized = true;
            return _imei;
        }

        /// <summary>
        /// 获取IMSI
        /// </summary>
        /// <returns></returns>
        public static string GetIMSI()
        {
            if (_imsiInitialized)
            {
                return _imsi;
            }


#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID
            using (AndroidJavaClass unityClass = new AndroidJavaClass(CLASS_UNITYPLAYER_ACTIVITY))
            {
                using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
                    {
                        _imsi = deviceUtils.CallStatic<string>("GetIMSI", activity);
                        deviceUtils.Dispose();
                    }
                    activity.Dispose();
                }
                unityClass.Dispose();
            }
#elif UNITY_IPHONE

             //_imsi = _IOS_GetIMSI();

#endif
            _imsiInitialized = true;
            return _imsi;
        }

        /// <summary>
        /// 获取国家运营商代码
        /// </summary>
        /// <returns></returns>
        public static string GetNetworkOperator()
        {
            if (_networkOperatorInitialized)
            {
                return _networkOperator;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID
            using (AndroidJavaClass unityClass = new AndroidJavaClass(CLASS_UNITYPLAYER_ACTIVITY))
            {
                using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
                    {
                        _networkOperator = deviceUtils.CallStatic<string>("GetNetworkOperator", activity);
                        deviceUtils.Dispose();
                    }
                    activity.Dispose();
                }
                unityClass.Dispose();
            }
#elif UNITY_IPHONE

            //_networkOperator = _IOS_GetNetworkOperator();

#endif
            _networkOperatorInitialized = true;
            return _networkOperator;
        }

        /// <summary>
        /// 获取外置储存路径
        /// </summary>
        /// <returns>返回外置储存目录路径，没有则返回null</returns>
        public static string GetExternalStorageDirectory()
        {
            if (_externalStorageDirectoryInitialized)
            {
                return _externalStorageDirectory;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

            _externalStorageDirectory = Application.dataPath;

#elif UNITY_ANDROID

            using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
            {
                _externalStorageDirectory = deviceUtils.CallStatic<string>("GetExternalStorageDirectory");
                deviceUtils.Dispose();
            }

#elif UNITY_IPHONE

            //_externalStorageDirectory = _IOS_GetExternalStorageDirectory();

#endif

            _externalStorageDirectoryInitialized = true;
            return _externalStorageDirectory;

        }

        /// <summary>
        /// 获取SIM卡序列号
        /// </summary>
        /// <returns></returns>
        public static string GetSimSerialNumber()
        {
            if (_simSerialNumberInitialized)
            {
                return _simSerialNumber;
            }

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR

#elif UNITY_ANDROID
            using (AndroidJavaClass unityClass = new AndroidJavaClass(CLASS_UNITYPLAYER_ACTIVITY))
            {
                using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaClass deviceUtils = new AndroidJavaClass(CLASS_DEVICES_UTILS))
                    {
                        _simSerialNumber = deviceUtils.CallStatic<string>("GetSimSerialNumber", activity);
                        deviceUtils.Dispose();
                    }
                    activity.Dispose();
                }
                unityClass.Dispose();
            }
#elif UNITY_IPHONE

            //_simSerialNumber = _IOS_GetSimSerialNumber();

#endif
            _simSerialNumberInitialized = true;
            return _simSerialNumber;
        }
    }
}
