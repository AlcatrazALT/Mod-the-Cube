using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer material;
    private Vector3 newPosition = new Vector3(1, 1, 1);
    private readonly float newSize = 2;
    private float rotationSpeed;
    private float timeSinceChange = 0f;

    [SerializeField]
    private float timeToChange = 1f;

    private void Start()
    {
        rotationSpeed = Random.Range(100, 500);
        Debug.Log(rotationSpeed);
        transform.position = newPosition;
        transform.localScale = Vector3.one * newSize;

        material = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
        timeSinceChange += Time.deltaTime;
        if (material != null && timeSinceChange >= timeToChange)
        {
            var newColor = new Color(Random.value, Random.value, Random.value);
            material.material.color = newColor;
            timeSinceChange = 0;
        }
    }
}