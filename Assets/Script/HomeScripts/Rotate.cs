using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotationVal;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "BackGround")
            DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, RotationVal), Space.Self);
    }
}
