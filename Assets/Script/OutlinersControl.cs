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
        public bool GhostControl;
        public Animator GhostFormEffectAnim;
        public GameObject KillEffect;
        [HideInInspector]
        public float KillProtectTime;
        [HideInInspector]
        public bool AlreadyDead;

        public void Awake()
        {
            if (SaveControl.GetInt("GhostForm") == 1)
                DirectGhostForm();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (SaveControl.GetInt("GhostForm") != 1)
            {
                SaveControl.SetFloat("GhostTime", SaveControl.GetFloat("GhostTime") - Time.deltaTime);
                if (SaveControl.GetFloat("GhostTime") <= 0)
                    GhostForm();
            }
            else
            {
                SaveControl.SetFloat("GhostTimeII", SaveControl.GetFloat("GhostTimeII") - Time.deltaTime);
                if (SaveControl.GetFloat("GhostTimeII") <= 0 && !AlreadyDead)
                {
                    AlreadyDead = true;
                    ChangeScene("Defeat");
                }
            }
            KillProtectTime -= Time.deltaTime;
        }

        public void CreateKillEffect(Vector3 Position)
        {
            GameObject G = Instantiate(KillEffect, Position, KillEffect.transform.rotation);
            Destroy(G, 5);
        }

        public void GhostForm()
        {
            if (!GhostControl)
                return;
            SaveControl.SetInt("GhostForm", 1);
            Character.Main.SetGhostForm(true);
            GhostFormEffectAnim.SetTrigger("GhostForm");
            KillProtectTime = 1.5f;
        }

        public void DirectGhostForm()
        {
            if (!GhostControl)
                return;
            Character.Main.SetGhostForm(true);
            GhostFormEffectAnim.SetTrigger("DirectGhostForm");
        }

        public void ChangeBack()
        {
            SaveControl.SetInt("GhostForm", 0);
            Character.Main.SetGhostForm(false);
            GhostFormEffectAnim.SetTrigger("ChangeBack");
            if (SaveControl.GetFloat("MaxGhostTime") > 60)
            {
                SaveControl.SetFloat("MaxGhostTime", SaveControl.GetFloat("MaxGhostTime") - 30);
                SaveControl.SetFloat("MaxGhostTimeII", SaveControl.GetFloat("MaxGhostTimeII") - 10);
            }
            SaveControl.SetFloat("GhostTime", SaveControl.GetFloat("MaxGhostTime"));
            SaveControl.SetFloat("GhostTimeII", SaveControl.GetFloat("MaxGhostTimeII"));
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

        public void ChangeScene(string Key)
        {
            StartCoroutine(ChangeSceneIE(Key));
        }

        public IEnumerator ChangeSceneIE(string Key)
        {
            FadeOutAnim.SetBool("Play", true);
            yield return new WaitForSeconds(0.5f);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(Key);
        }
    }
}