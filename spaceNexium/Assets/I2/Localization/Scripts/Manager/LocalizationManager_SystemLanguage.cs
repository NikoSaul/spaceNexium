﻿using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using System.Collections;

namespace I2.Loc
{
    public static partial class LocalizationManager
    {
        static string mCurrentDeviceLanguage;

        public static string GetCurrentDeviceLanguage()
        {
            if (string.IsNullOrEmpty(mCurrentDeviceLanguage))
                DetectDeviceLanguage();

            return mCurrentDeviceLanguage;
        }

        static void DetectDeviceLanguage()
        {
            #if UNITY_ANDROID && !UNITY_EDITOR
            try { 
                        AndroidJavaObject locale = new AndroidJavaClass("java/util/Locale").CallStatic<AndroidJavaObject>("getDefault");
                        mCurrentDeviceLanguage = locale.Call<string>("getDisplayName");
                        //https://stackoverflow.com/questions/4212320/get-the-current-language-in-device

                        if (!string.IsNullOrEmpty(mCurrentDeviceLanguage))
                            return;
            }
            catch (System.Exception)
            { 
            }
            #endif

            mCurrentDeviceLanguage = Application.systemLanguage.ToString();
        }
    }
}