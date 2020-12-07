using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private Vector3 newPosition = new Vector3(1, 1, 1);
    private readonly float newSize = 2;

    [SerializeField]
    private float rotationSpeed = 15.0f;

    private void Start()
    {
        transform.position = newPosition;
        transform.localScale = Vector3.one * newSize;

        Material material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }

    private void Update()
    {
        transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
    }
}