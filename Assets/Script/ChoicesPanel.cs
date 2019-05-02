using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoicesPanel : MonoBehaviour {
        public InterObject IO;
        public List<Choice> Choices;
        public bool AlreadyDead;

        public void Awake()
        {
            if (IO)
                Choices = IO.GetActiveChoices();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (IO)
                Choices = IO.GetActiveChoices();
            else
                Choices = new List<Choice>();
        }

        public void Remove()
        {
            AlreadyDead = true;
            Destroy(gameObject);
        }
    }
}