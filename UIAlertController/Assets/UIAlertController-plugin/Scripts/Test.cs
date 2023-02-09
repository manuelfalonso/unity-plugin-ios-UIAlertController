using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void OnGUI()
    {
        if (GUILayout.Button("First", GUILayout.MinWidth(200), GUILayout.MinHeight(100)))
        {
            iOSNativeAlert.ShowDialog("AlertTitle", "Alert message", Callback, "Ok Bt");
        }
        if (GUILayout.Button("Second", GUILayout.MinWidth(200), GUILayout.MinHeight(100)))
        {
            iOSNativeAlert.ShowDialog("AlertTitle", "Alert message", Callback);
        }
        if (GUILayout.Button("Third", GUILayout.MinWidth(200), GUILayout.MinHeight(100)))
        {
            iOSNativeAlert.ShowDialog("AlertTitle", "Alert message", CallbackOther, "Ok Button", "Else", "Cancel");
        }
    }


    private void Callback(string result)
    {
        Debug.Log("Ok button was pressed so it works just fine");
    }

    private void CallbackOther(string result)
    {
        if (result == "Ok Button")
        {
            Debug.Log("Ok button is surely pressed so it works just fine");
        }
        else if (result == "Cancel")
        {
            Debug.Log("CancelBtn pressed most likely resumed");
        }
    }
}
