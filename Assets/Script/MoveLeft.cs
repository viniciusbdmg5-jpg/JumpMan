using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        if (!PlayerController.instance.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        }

}
