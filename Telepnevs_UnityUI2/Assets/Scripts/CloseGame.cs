using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();

#if UNITY_EDITOR
        Debug.Log("Application.Quit()");
#endif
    }
}