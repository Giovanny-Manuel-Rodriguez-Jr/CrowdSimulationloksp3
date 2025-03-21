﻿using UnityEngine;

public class DropCylinder : MonoBehaviour {

    public GameObject obstacle;
    GameObject[] agents;

    void Start() {

        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0)) {

            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) {

                Instantiate(obstacle, hitInfo.point, obstacle.transform.rotation);
                foreach (GameObject a in agents) {

                    a.GetComponent<AIControl>().DetectNewObstacle(hitInfo.point);
                }
            }
        }
    }
}
