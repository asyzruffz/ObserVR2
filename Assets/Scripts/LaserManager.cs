using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserManager : MonoBehaviour
{
    private List<int> satelliteList = new List<int>();
    private List<int> meteorList = new List<int>();

    void Update() {
        if (Director.Instance.inGame) {
            LinkSatellites();
            ObtainSelectedSatellitesAndMeteors();
            UpdateShootingSatellites();
        }
    }

    void LinkSatellites() {
        Transform first = null;
        Transform prev = null;
        foreach (var obj in SelectionManager.Instance.nodes) {
			// Only concern the Satellite (has SatelliteController component)
			if (obj.GetComponent<SatelliteController>() != null) {
                // Set the first to wrap up later
                if (first == null) {
                    first = obj.transform;
                    prev = first;
					continue;
                }

				prev.GetComponent<SatelliteController>().FacingTowards(obj.transform);
				obj.GetComponent<SatelliteController>().FacingTowards(first);
                prev = obj.transform;
            }
        }
    }

    void ObtainSelectedSatellitesAndMeteors() {
        satelliteList.Clear();
        meteorList.Clear();

        for (int i = 0; i < SelectionManager.Instance.nodes.Count; i++) {
            GameObject obj = SelectionManager.Instance.nodes[i];

            if (obj.name.Equals("Satellite")) {
                satelliteList.Add(i);
            }
            else if (obj.name.Equals("Meteor")) {
                meteorList.Add(i);
            }
        }
    }

    void UpdateShootingSatellites() {
        for (int satIndex = 0; satIndex < satelliteList.Count; satIndex++) {
            GameObject satellite = SelectionManager.Instance.nodes[satelliteList[satIndex]];

            for (int meteIndex = 0; meteIndex < meteorList.Count; meteIndex++) {
                GameObject meteor = SelectionManager.Instance.nodes[meteorList[meteIndex]];

                LaserContainer laserSatellite = satellite.GetComponent<LaserContainer>();
                if (!laserSatellite.IsShooting(meteor)) {
                    laserSatellite.StartShooting(meteor);
                }
            }
        }
    }
}
