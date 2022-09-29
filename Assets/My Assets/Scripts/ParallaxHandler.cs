using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class ParallaxHandler : MonoBehaviour
    {
        [Tooltip("Length and start position of the sprites")]
        private float length, startPosition;
        [Tooltip("Camera Reference")]
        public GameObject mainCamera;
        [Tooltip("How much parallex effect is gonna be applied")]
        public float parallaxEffect;

        private void Start()
        {
            startPosition = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void Update()
        {
            float temp = mainCamera.transform.position.x * (1 - parallaxEffect);
            float distance = mainCamera.transform.position.x * parallaxEffect;

            transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

            if (temp > startPosition + length)
                startPosition += length;
            else if (temp < startPosition - length)
                startPosition -= length;
        }
    }
}
