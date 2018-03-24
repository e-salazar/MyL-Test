using System.Collections.Generic;
using UnityEngine;

public class Scene2Manager : MonoBehaviour {
    public Animator animator;
    public List<GameObject> vehicles;
    public int actualVehicleIndex = 0;

    public void OnClickLeftButton() {
        this.vehicles[actualVehicleIndex].SetActive(false);
        this.actualVehicleIndex = (this.actualVehicleIndex + this.vehicles.Count - 1) % this.vehicles.Count;
        this.vehicles[this.actualVehicleIndex].SetActive(true);
    }
    public void OnClickRightButton() {
        this.vehicles[actualVehicleIndex].SetActive(false);
        this.actualVehicleIndex = (this.actualVehicleIndex + 1) % this.vehicles.Count;
        this.vehicles[this.actualVehicleIndex].SetActive(true);
    }
    public void OnClickMiddleButton() {
        this.animator.SetTrigger("Atmosphere");
    }
}