using AOT;
using System;
using System.Runtime.InteropServices;

public static class iOSNativeAlert
{
    public delegate void AlertDelegate(string str);
    [DllImport("__Internal")]
    
    private static extern void _showDialog(
        string title, 
        string msg, 
        string actionFirst, 
        string actionSecond, 
        string actionThird,
        AlertDelegate onCompletion);

    static Action<string> callback = null;

    [MonoPInvokeCallback(typeof(AlertDelegate))]
    private static void OnCompletionCallback(string str)
    {
        if (callback != null) callback(str);
        callback = null;
    }

    public static void ShowDialog(
        string title, 
        string msg,
        Action<string> onCompletion, 
        string actionFirst = "Ok",
        string actionSecond = null, 
        string actionThird = null)
    {
        callback = onCompletion;
        _showDialog(title, msg, actionFirst, actionSecond, actionThird, OnCompletionCallback);
    }
}