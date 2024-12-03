using UnityEngine;

public class GeneratePosition : MonoBehaviour
{
    public Transform FemaleTransform;

    private Vector2[] validPositions = new Vector2[]
    {
        new Vector2(163f, -205f),
        new Vector2(327f, -125f),
        new Vector2(239f, 113f),
        new Vector2(168f, 55f),
        new Vector2(142f, 134f),
        new Vector2(-181f, 184f),
    };

    private Vector3 currentFemalePosition;

    void Start()
    {
        int index = Random.Range(0, validPositions.Length);

        currentFemalePosition = validPositions[index];

        FemaleTransform.transform.position = currentFemalePosition;
    }
}
