using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class OutlinersControl : MonoBehaviour {
        [HideInInspector]
        public static OutlinersControl Main;
        public Room CurrentRoom;
        public string CurrentSceneName;
        public Animator FadeOutAnim;

        public void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetRoom(Room R)
        {
            CurrentRoom = R;
        }

        public void ChangeLevel()
        {
            StartCoroutine("ChangeLevelIE");
        }

        public IEnumerator ChangeLevelIE()
        {
            FadeOutAnim.SetBool("Play", true);
            yield return new WaitForSeconds(0.5f);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(CurrentSceneName);
        }
    }
}