using UnityEngine;

public class UIback : MonoBehaviour
{
    public Animator anime; // 背景のAnimator

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anime.ResetTrigger("PlayOut"); // 念のためリセット
            anime.SetBool("isOnStart", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anime.SetBool("isOnStart", false);
            anime.SetTrigger("PlayOut");
        }
    }
}
