using UnityEngine;

public class DestroyingDown : MonoBehaviour
{
    [SerializeField]
    private float _yBound = -5;
    private void Update()
    {
        if(transform.position.y < _yBound)
            Destroy(gameObject);
    }
}