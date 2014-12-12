using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    const float edgeBoundMax = 0.95f;
    const float edgeBoundMin = 1 - edgeBoundMax;
    float scrollSpeed = 3f;

    const float minOrthoSize = 2.0f;
    const float maxOrthoSize = 24.0f;
    const float zoomSpeed = 3f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        CheckCameraScroll();
	}

    private void CheckCameraScroll()
    {
        CameraPan1();
        OrthoZoom1();
    }

    private void OrthoZoom1()
    {
        float f = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(f) > 0.01f)
        {
            Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.orthographicSize += zoomSpeed * f;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minOrthoSize, maxOrthoSize);
            v3 = v3 - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += v3;
        }
    }

    private void CameraPan1()
    {
        if (Input.mousePosition.y >= Screen.height * edgeBoundMax)
        {
            Camera.main.transform.position += new Vector3(0, 0, scrollSpeed / Camera.main.orthographicSize);
        }
        if (Input.mousePosition.y <= Screen.height * edgeBoundMin)
        {
            Camera.main.transform.position += new Vector3(0, 0, -scrollSpeed / Camera.main.orthographicSize);
        }
        if (Input.mousePosition.x >= Screen.width * edgeBoundMax)
        {
            Camera.main.transform.position += new Vector3(scrollSpeed / Camera.main.orthographicSize, 0, 0);
        }
        if (Input.mousePosition.x <= Screen.width * edgeBoundMin)
        {
            Camera.main.transform.position += new Vector3(-scrollSpeed / Camera.main.orthographicSize, 0, 0);
        }
    }

   
}
