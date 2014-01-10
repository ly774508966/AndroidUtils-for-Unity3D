using System.IO;
using UnityEngine;

namespace Widemo.Utils
{
    public class LogUtils
    {
        private const int LOG_TYPE_INFO = 0;
        private const int LOG_TYPE_WARNING = 1;
        private const int LOG_TYPE_ERROR = 2;

        private const string CLASS_LOG_UTILS = "com.widemo.utils.LogUtils";

        public static void LogError(string tag, string message)
        {
            OutLog(LOG_TYPE_ERROR, tag, message);
        }

        public static void Log(string tag, string message)
        {
            OutLog(LOG_TYPE_INFO, tag, message);
        }

        public static void LogWarning(string tag, string message)
        {
            OutLog(LOG_TYPE_WARNING, tag, message);
        }

        private static void OutLog(int type, string tag, string message)
        {
#if UNITY_EDITOR
            switch (type)
            {
                case LOG_TYPE_INFO:
                    Debug.Log(tag + ": " + message);
                    break;
                case LOG_TYPE_WARNING:
                    Debug.LogWarning(tag + ": " + message);
                    break;
                case LOG_TYPE_ERROR:
                    Debug.LogError(tag + ": " + message);
                    break;
            }

#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
            OutputLogToFile(type,tag,message);
#elif UNITY_ANDROID
            OutputLogToAndroid(type,tag,message);
#endif
        }

        private static void OutputLogToFile(int type, string tag, string message)
        {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
            switch (type)
            {
                case LOG_TYPE_INFO:
                    tag = "I: " + tag;
                    break;
                case LOG_TYPE_WARNING:
                    tag = "W: " + tag;
                    break;
                case LOG_TYPE_ERROR:
                    tag = "E: " + tag;
                    break;
            }
            StreamWriter sw;
            FileInfo t = new FileInfo(Application.dataPath + "//Log.txt");
            if (!t.Exists)
            {
                sw = t.CreateText();
            }
            else
            {
                sw = t.AppendText();
            }
            sw.WriteLine(tag + message);
            sw.Close();
            sw.Dispose();
#endif
        }

        private static void OutputLogToAndroid(int type, string tag, string message)
        {
#if UNITY_ANDROID
            using (AndroidJavaClass logClass = new AndroidJavaClass(CLASS_LOG_UTILS))
            {
                switch (type)
                {
                    case LOG_TYPE_INFO:
                        logClass.CallStatic("Log", tag, message);
                        break;
                    case LOG_TYPE_WARNING:
                        logClass.CallStatic("LogWarning", tag, message);
                        break;
                    case LOG_TYPE_ERROR:
                        logClass.CallStatic("LogError", tag, message);
                        break;
                }
            }
#endif
        }
    }
}
