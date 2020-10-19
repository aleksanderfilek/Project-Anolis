using UnityEngine;

namespace Logistics
{
    public abstract class Showable : MonoBehaviour
    {
        [SerializeField] protected GameObject Ui;

        public virtual void Show()
        {
            Ui.SetActive(true);
        }

        public virtual void Hide()
        {
            Ui.SetActive(false);
        }
    }
}