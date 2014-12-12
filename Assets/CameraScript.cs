using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    Vector3 minCamera;
    Vector3 maxCamera;
    float heightTilemap;
    float widthTilemap;
    const float offset = 0.2f;
    // Use this for initialization
    void Start()
    {
        camera.ResetAspect();
        ResetBounds();
    }

    // Update is called once per frame
    void Update()
    {
        float heightRaw = heightTilemap - 2f * camera.orthographicSize;
        float height = (heightRaw / 2) - offset;
        float width = ((widthTilemap / 2) - camera.aspect * camera.orthographicSize) - offset;

        minCamera = new Vector3(-width, -10f, -height);
        maxCamera = new Vector3(width, 10f, height);

        //Make sure camera panning doesn't go out of bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamera.x, maxCamera.x),

        Mathf.Clamp(transform.position.y, minCamera.y, maxCamera.y),

        Mathf.Clamp(transform.position.z, minCamera.z, maxCamera.z));

    }

    public void ResetBounds() {
        TileMap tileMap = GameObject.Find("TileMap").GetComponent<TileMap>();
        heightTilemap = tileMap.size_z;
        widthTilemap = tileMap.size_x;
    }
}
