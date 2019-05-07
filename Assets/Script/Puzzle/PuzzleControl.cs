using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Knight
{
    public class PuzzleControl : MonoBehaviour {
        [HideInInspector]
        public static PuzzleControl Main;
        public List<int> CurrentNumbers;
        public List<int> TargetNumbers;
        public List<TextMeshProUGUI> TEXTs;
        public Vector2Int ValueLimit;

        public void Awake()
        {
            Main = this;
            LoadNumbers();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RenderNumbers();
        }

        public void ChangeNumber(int Index, int Value)
        {
            CurrentNumbers[Index] += Value;
            if (CurrentNumbers[Index] < ValueLimit.x)
                CurrentNumbers[Index] = ValueLimit.y;
            else if (CurrentNumbers[Index] > ValueLimit.y)
                CurrentNumbers[Index] = ValueLimit.x;
            SaveNumbers();
        }

        public void SaveNumbers()
        {
            for (int i = 0; i < CurrentNumbers.Count; i++)
                SaveControl.SetInt("Number" + i, CurrentNumbers[i]);
        }

        public void LoadNumbers()
        {
            for (int i = 0; i < CurrentNumbers.Count; i++)
                CurrentNumbers[i] = SaveControl.GetInt("Number" + i);
        }

        public void RenderNumbers()
        {
            for (int i = 0; i < CurrentNumbers.Count; i++)
                TEXTs[i].text = CurrentNumbers[i].ToString();
        }

        public bool NumbersCheck()
        {
            for (int i = 0; i < CurrentNumbers.Count; i++)
            {
                if (CurrentNumbers[i] != TargetNumbers[i])
                    return false;
            }
            return true;
        }
    }
}