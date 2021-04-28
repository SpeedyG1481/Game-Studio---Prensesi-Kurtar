using UnityEngine;
using UnityEngine.UI;

namespace Entity
{
    public class Princess : MonoBehaviour
    {
        public Parent.Entity[] mustBeDead;
        public GameObject completeGameGUI;
        public Image background;

        void Start()
        {
            background.canvasRenderer.SetAlpha(0.0F);
        }

        void Update()
        {
            CheckGameEnd();
        }

        private void CheckGameEnd()
        {
            var collides = Physics2D.OverlapCircleAll(this.transform.position, 7.6F, 1);
            foreach (var other in collides)
            {
                if (other.CompareTag("Player"))
                {
                    if (MustBeDeadIterator())
                    {
                        GameController.GameStatus = false;
                        completeGameGUI.SetActive(true);
                        background.CrossFadeAlpha(1.0F, 2.75F, false);
                    }
                }
            }
        }

        private bool MustBeDeadIterator()
        {
            if (mustBeDead != null)
                foreach (var e in mustBeDead)
                {
                    if (!e.IsDead())
                    {
                        return false;
                    }
                }

            return true;
        }
    }
}