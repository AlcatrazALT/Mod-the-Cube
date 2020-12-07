using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer material;
    private Color color;
    private Vector3 newPosition = new Vector3(1, 1, 1);
    private readonly float newSize = 2;
    private float rotationSpeed;
    private float timeSinceChange = 0f;

    [SerializeField]
    private bool canChangeColor = true;

    [SerializeField]
    private float timeToChange = 1f;

    private void Start()
    {
        rotationSpeed = Random.Range(100, 500);
        Debug.Log(rotationSpeed);
        transform.position = newPosition;
        transform.localScale = Vector3.one * newSize;

        material = GetComponent<MeshRenderer>();
        StartCoroutine("ChangeRandomColorWithCoroutine");
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
        //ChangeRandomColor();
    }

    private void ChangeRandomColor()
    {
        timeSinceChange += Time.deltaTime;
        if (material != null && timeSinceChange >= timeToChange)
        {
            var newColor = new Color(Random.value, Random.value, Random.value);
            material.material.color = newColor;
            timeSinceChange = 0;
        }
    }

    private IEnumerator ChangeRandomColorWithCoroutine()
    {
        color = material.material.color;

        float r = Random.Range(0, 1.0f);
        float g = Random.Range(0, 1.0f);
        float b = Random.Range(0, 1.0f);

        Color newColor = new Color(r, g, b);

        float t = 0;

        while (t < 1)
        {
            material.material.color = Color.Lerp(color, newColor, t);
            t += Time.deltaTime / timeToChange;
            yield return null;
        }
        yield return new WaitForSeconds(timeToChange);

        StartCoroutine("ChangeRandomColorWithCoroutine");
    }
}