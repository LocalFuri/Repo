using UnityEngine;

public class QuitApp : MonoBehaviour
{  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse1)) //right mouse butt
    {
      Application.Quit();
    }
  }
}