using UnityEngine;

public class CameraFitHorizontal : MonoBehaviour
{
	[SerializeField] private bool test;

	private Camera cam;

	[Space(10)]
	[SerializeField] private Vector2 size = Vector2.one;
	[SerializeField] private Vector2 offset;

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
		Camera.main.orthographicSize = bounds.size.y / 2;
	}

	public void FitToCameraBounds()
	{
		cam = GetComponent<Camera>();
		bounds = cam.OrthographicBounds();
	}
}
