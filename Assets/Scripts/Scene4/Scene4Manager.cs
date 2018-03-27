using Scene4;
using Scene4.Windows;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Manager : MonoBehaviour {
    private Card cardInZoom;
    public Transform zoomTransform;
    public Transform tableTransform;
    public CardInfoWindow cardWindow;
    public GameObject cardGameObject;
    public List<ScriptableObjects.MitosyLeyendas.Carta> cartasData = new List<ScriptableObjects.MitosyLeyendas.Carta>();

    public void OnClickCreateButton() {
        foreach(ScriptableObjects.MitosyLeyendas.Carta cartaData in cartasData) {
            CreateCard(cartaData);
        }
    }
    public void OnClickCard(Card card) {
        if(this.cardInZoom == card) {
            this.cardInZoom = null;

            MoveCardToTable(card);
            cardWindow.Hide();
        }
        else {
            if(this.cardInZoom != null) {
                MoveCardToTable(this.cardInZoom);
            }
            this.cardInZoom = card;
            MoveCardToZoom(card);
            cardWindow.Show();
        }
    }
    public void OnClickClose() {
        MoveCardToTable(this.cardInZoom);
        this.cardInZoom = null;
        cardWindow.Hide();
    }

    public void CreateCard(ScriptableObjects.MitosyLeyendas.Carta cartaData) {
        Card card = Instantiate(cardGameObject).GetComponent<Card>();
        card.Load(cartaData);
        card.gameObject.SetActive(true);
        MoveCardToTable(card);
    }

    private void MoveCardToZoom(Card card) {
        card.transform.SetParent(this.zoomTransform, true);
        card.rigidbody.isKinematic = true;
        card.transformable.SetLocalPosition(Vector3.zero, 0.25f);
        card.transformable.SetLocalRotation(Quaternion.identity, 0.25f);

        cardWindow.Load(card);
    }
    private void MoveCardToTable(Card card) {
        card.transform.SetParent(this.tableTransform, true);
        card.rigidbody.isKinematic = false;
        card.transformable.SetLocalPosition(new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30)), 0.25f);
        card.transformable.SetLocalRotation(
            Quaternion.Euler(
                Random.Range(70, 110),
                Random.Range(0, 0),
                Random.Range(0, 0)), 0.25f);
    }
}