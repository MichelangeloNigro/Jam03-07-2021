using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject tileSample;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    public void ChangeLevel()
    {
        StartCoroutine(Slide());
    }
    public IEnumerator Slide()
    {
        var XPos = transform.position.x;
        while (transform.position.x < XPos + tileSample.GetComponent<BoxCollider2D>().size.x)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
