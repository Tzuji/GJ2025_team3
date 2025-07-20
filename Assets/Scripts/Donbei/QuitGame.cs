using UnityEditor;
using UnityEngine;

namespace donbei
{
    public class QuitGame : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            EndGame();
        }

        public void EndGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false; //ゲームプレイ終了
#else
            Application.Quit();//ゲームプレイ終了
#endif
        }
    }
}