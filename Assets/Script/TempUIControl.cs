using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Knight
{
    public class TempUIControl : MonoBehaviour {
        [HideInInspector]
        public static TempUIControl Main;
        public Camera UICamera;
        public Animator ClueAnim;
        public TextMeshProUGUI ClueText;
        [Space]
        public GameObject ChoicesPanelPrefab;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayClueAnim(string Content)
        {
            StartCoroutine("PlayClueAnimIE");
            ClueText.text = Content;
        }

        public IEnumerator PlayClueAnimIE()
        {
            ClueAnim.SetBool("Play", true);
            yield return 0;
            ClueAnim.SetBool("Play", false);
        }

        public void CreateChoicesPanel(InterObject IO)
        {
            GameObject G = Instantiate(ChoicesPanelPrefab, IO.GetPanelTransform());
            G.transform.position = IO.GetPanelPosition();
            G.GetComponent<ChoicesPanel>().IO = IO;
            IO.CP = G.GetComponent<ChoicesPanel>();
        }

        public void RemoveChoicesPanel(ChoicesPanel CP)
        {
            CP.Remove();
        }
    }
}