using UnityEngine;

namespace Systems {
    public class PhotonConnector : MonoBehaviour {
        private void Start() {
            PhotonNetwork.ConnectUsingSettings(null);
        }

        void OnJoinedLobby() {
            ScrollLogger.Log("join lobby");
            PhotonNetwork.JoinRandomRoom();
        }
        
        void OnCreatedRoom() {
            ScrollLogger.Log("created room");
        }

        void OnJoinedRoom() {
            ScrollLogger.Log("join room. my id is "+PhotonNetwork.player.ID);
        }

        void OnPhotonRandomJoinFailed() {
            ScrollLogger.Log("failed join room");
            PhotonNetwork.CreateRoom("myRoom");
        }
    }
}