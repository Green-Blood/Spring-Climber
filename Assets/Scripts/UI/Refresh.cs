 
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Refresh : MonoBehaviour
    {
        public void OnRefreshBtnClick()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    
    }
}
