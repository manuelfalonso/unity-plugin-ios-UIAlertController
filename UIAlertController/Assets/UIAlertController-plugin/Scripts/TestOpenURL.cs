using UnityEngine;

public class TestOpenURL : MonoBehaviour
{
    private string cordX = "-34.601041195050115";
    private string cordY = "-58.383082222289104";

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void OnGUI()
    {
        if (GUILayout.Button("First", GUILayout.MinWidth(200), GUILayout.MinHeight(100)))
        {
            iOSNativeAlert.ShowDialog("Choose Application", string.Empty, Callback, "Maps", "Google Maps", "Waze");
        }
    }


    private void Callback(string result)
    {
        if (result == "Maps")
        {
            Debug.Log("Maps button pressed");
            Application.OpenURL($"http://maps.apple.com/place?ll={cordX},{cordY}");
        }
        else if (result == "Google Maps")
        {
            Debug.Log("Google Maps button pressed");
            Application.OpenURL($"http://maps.google.com/?q={cordX},{cordY}");
        }
        else if (result == "Waze")
        {
            Debug.Log("Waze button pressed");
            Application.OpenURL($"http://www.waze.com/ul?ll={cordX}%2C{cordY}&navigate=yes");
        }
        else if (result == "Cancel")
        {
            Debug.Log("Cancel button pressed");
        }
    }
}
