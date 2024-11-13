using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHand : MonoBehaviour
{
  [SerializeField] ParticleSystem crashVFX;

  MeshRenderer starSparrowCoreRenderer;
  MeshRenderer starSparrowPlasmaoneRenderer;
  MeshRenderer starSparrowPlasmatwoRenderer;
  MeshRenderer starSparrowPlasmathreeRenderer;
  MeshRenderer starSparrowPlasmafourRenderer;
  MeshRenderer starSparrowTailRenderer;
  MeshRenderer starSparrowThrusterRenderer;
  MeshRenderer starSparrowWeapononeRenderer;
  MeshRenderer starSparrowWeapontwoRenderer;
  MeshRenderer starSparrowWingoneRenderer;
  MeshRenderer starSparrowWingtwoRenderer;
  MeshRenderer starSparrowWingthreeRenderer;
  MeshRenderer starSparrowWingfourRenderer;
  
  void OnTriggerEnter(Collider other)
  {
    FindingMeshRendererOfSpacShip();
    StartCrashProcess();
  }

  void StartCrashProcess()
  {
    crashVFX.Play();
    DisableMeshRenderesOfSpaceShip();
    GetComponent<PlayerControl>().enabled = false;
    GetComponent<BoxCollider>().enabled = false;
    Invoke(nameof(ReloadLevel), 1f);
  }
  
  void ReloadLevel() 
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }

  void FindingMeshRendererOfSpacShip()
  {
    starSparrowCoreRenderer = transform.Find("StarSparrow_Core").GetComponent<MeshRenderer>();
    starSparrowPlasmaoneRenderer = transform.Find("StarSparrow_Plasma1").GetComponent<MeshRenderer>();
    starSparrowPlasmatwoRenderer = transform.Find("StarSparrow_Plasma2").GetComponent<MeshRenderer>();
    starSparrowPlasmathreeRenderer = transform.Find("StarSparrow_Plasma3").GetComponent<MeshRenderer>();
    starSparrowPlasmafourRenderer = transform.Find("StarSparrow_Plasma4").GetComponent<MeshRenderer>();
    starSparrowTailRenderer = transform.Find("StarSparrow_Tail").GetComponent<MeshRenderer>();
    starSparrowThrusterRenderer = transform.Find("StarSparrow_Thruster").GetComponent<MeshRenderer>();
    starSparrowWeapononeRenderer = transform.Find("StarSparrow_Weapon1").GetComponent<MeshRenderer>();
    starSparrowWeapontwoRenderer = transform.Find("StarSparrow_Weapon2").GetComponent<MeshRenderer>();
    starSparrowWingoneRenderer = transform.Find("StarSparrow_Wing1").GetComponent<MeshRenderer>();
    starSparrowWingtwoRenderer = transform.Find("StarSparrow_Wing2").GetComponent<MeshRenderer>();
    starSparrowWingthreeRenderer = transform.Find("StarSparrow_Wing3").GetComponent<MeshRenderer>();
    starSparrowWingfourRenderer = transform.Find("StarSparrow_Wing4").GetComponent<MeshRenderer>();
      
  }

  void DisableMeshRenderesOfSpaceShip()
  {
    starSparrowCoreRenderer.enabled = false;
    starSparrowPlasmaoneRenderer.enabled = false;
    starSparrowPlasmatwoRenderer.enabled = false;
    starSparrowPlasmathreeRenderer.enabled = false;
    starSparrowPlasmafourRenderer.enabled = false;
    starSparrowTailRenderer.enabled = false;
    starSparrowThrusterRenderer.enabled = false;
    starSparrowWeapononeRenderer.enabled = false;
    starSparrowWeapontwoRenderer.enabled = false;
    starSparrowWingoneRenderer.enabled = false;
    starSparrowWingtwoRenderer.enabled = false;
    starSparrowWingthreeRenderer.enabled = false;
    starSparrowWingfourRenderer.enabled = false;
  }
}
