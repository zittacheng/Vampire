﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class NPC : MonoBehaviour {
        public string KillKey;
        public Animator Anim;
        public GameObject AnimBase;
        public GameObject TargetPoint;
        public Collider2D C2D;
        public InterObject KillIO;
        public float KillDelay = 0.2f;

        public void Awake()
        {
            if (SaveControl.GetInt(KillKey) == 1)
            {
                AnimBase.SetActive(false);
                C2D.enabled = false;
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Kill()
        {
            /*
            Anim.SetBool("Kill", true);
            Destroy(gameObject, 10);*/

            C2D.enabled = false;
            SaveControl.SetInt(KillKey, 1);
            Character.Main.StartKill();
            OutlinersControl.Main.CreateKillEffect(TargetPoint.transform.position);
            Destroy(gameObject, KillDelay);
        }
    }
}