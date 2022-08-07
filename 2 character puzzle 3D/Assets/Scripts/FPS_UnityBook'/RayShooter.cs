using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    private GUIStyle guiStyle = new GUIStyle();

    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if(target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(BulletIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator BulletIndicator(Vector3 pos)
    {
        GameObject bulletHole = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bulletHole.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(bulletHole);
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        guiStyle.fontSize = 50;
        GUI.Label(new Rect(posX, posY, size, size), "*",guiStyle);
    }
}
