using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FruitDiet
{
    public class DataManager : MonoBehaviour
    {
        [Header("References")]
        public Score score;
        public PointsReference scoreText;

        private void Update()
        {
            if(scoreText == null)
            {
                scoreText = FindObjectOfType<PointsReference>();
            }
            else
            {
                scoreText.GetComponent<TextMeshProUGUI>().text = score.currentCalories.ToString();
            }
        }
    }
}

