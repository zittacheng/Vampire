using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class Retry : MonoBehaviour {
        public float ProtectedTime;
        public string TargetSceneName;
        public bool AlreadyLoaded;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ProtectedTime -= Time.deltaTime;
            if (ProtectedTime <= 0 && Input.anyKeyDown && !AlreadyLoaded)
            {
                AlreadyLoaded = true;
                if (SaveControl.Main)
                    Destroy(SaveControl.Main.gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(TargetSceneName);
            }
        }
    }
}