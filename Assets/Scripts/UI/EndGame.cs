using UnityEngine;

namespace UI
{
    public class EndGame : MonoBehaviour
    {
        public void ToggleEndPanel(bool value) => gameObject.SetActive(value);
    }
}
