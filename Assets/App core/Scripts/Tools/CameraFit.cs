using UnityEngine;

public enum CameraFitAnchorHorizontal { Center, Right,Left}
public enum CameraFitAnchorVertical { Center, Bottom, Up}


[DefaultExecutionOrder(-10)]
public class CameraFit : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private bool test;

    [Space(10)]
    [SerializeField] private CameraFitAnchorVertical anchorHorizontal = CameraFitAnchorVertical.Center;

    [Space(10)]
    [SerializeField] private Vector2 size = Vector2.one;
    private Vector2 offset;

    public Bounds bounds
    { 
        get 
        {
            m_Bounds = new Bounds(offset, size);
            return m_Bounds; 
        } 
        
        set 
        {
            size = value.size;
            offset = value.center;

            m_Bounds = new Bounds(offset, size); 
        } 
    }
    private Bounds m_Bounds = new Bounds(Vector3.zero, Vector3.one);

    //[Space(10)]

    private void Awake()
    {
        cam = GetComponent<Camera>();
        SetCameraBounds();
    }

#if UNITY_EDITOR

    private void Update()
    {
        if (test) SetCameraBounds();
    }

#endif

    private void SetCameraBounds()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = size.x / size.y;
        //float targetRatio = m_Bounds.size.x / m_Bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            cam.orthographicSize = size.y / 2;  
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            cam.orthographicSize = size.y / 2 * differenceInSize;
        }

        float offsetVertical = cam.OrthographicBounds().size.y - bounds.size.y;

        switch (anchorHorizontal)
        {
            case CameraFitAnchorVertical.Center:
                cam.transform.SetLocalPosY(0);
                break;
            case CameraFitAnchorVertical.Bottom:
                cam.transform.SetLocalPosY((cam.transform.position.y + offsetVertical)/2);
                break;
            case CameraFitAnchorVertical.Up:
                cam.transform.SetLocalPosY((cam.transform.position.y - offsetVertical)/2);
                break;
            default:
                cam.transform.SetLocalPosY(0);
                break;
        }
    }
    public void FitToCameraBounds()
    {
        cam = GetComponent<Camera>();
        bounds = cam.OrthographicBounds();
    }
}
