# Tower defense 2D

## Scene1: 

### Step 1: TowerPlacement
#### POI
- GetMouseButtonDown
- Camera.main
- ScreenToWorldPoint
- Input.mousePosition
- RaycastHit2D
- Array.IndexOf

#### Text tutorial
- Create a new Empty gameobject and rename it to "TowerPlacement".
- Create a new C# script called "TowerPlacement" and add it to the TowerPlacement gameobject.
- Create a prefab out of the tower gameobject.
- Add a new variable to the TowerPlacement script and store the tower prefab into it: `[SerializeField] private GameObject towerPrefab;`.
- Create a new variable `towerSlots`: `[SerializeField] private GameObject[] towerSlots;`.
- Create 2 new "2D Object" -> "Sprites" -> "Hexagon Flat-Top" and rename them to "TowerSlot (0..1)", add them as children to the TowerPlacement gameobject.
- Put the 2 newly created tower slots gameobjects into the `towerSlots` variable via the Unity Inspector.
- Add a PolygonCollider2D to the 2 tower slots.
- In the TowerPlacement script add the Unity `Update` function.
- In the `Update` function we are gonna check if we clicked on one of the `towerSlots` gameobjects and place an Tower on it.
- First check if we clicked the left mouse button: `if (Input.GetMouseButtonDown(0)) { }`.
- Then we shoot a raycast from the mousePosition to the world.
`
Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
`
- Then we check if the raycast hit something in the scene: `if(hit.collider != null) { }`.
- We will create a new function called `PlaceTower` with the parameter `int towerSlotIndex`.
- In this function `Instantiate` the `towerPrefab` and set the instantiated tower to the position of the given `towerSlots[towerSlotIndex]` its position.
- Now we need to know if what the raycast hit is actually a towerSlot and whats its index is.
- We can get the index of the clicked towerSlot by using `Array.IndexOf`.
- We check if the `hit.collider.gameObject` is present in the `towerSlots` array: `int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.gameObject);`.
- This function will return `-1` if what we clicked is not present in the `towerSlots` array.
- So check if the towerSlotIndex is not `-1` and call the `PlaceTower` with the `towerSlotIndex`: `if (towerSlotIndex != -1) { PlaceTower(towerSlotIndex); }`.

By now we can place 2 towers on the towerSlots in the scene by clicking these slots. The towers however will both start targeting the first enemy. We can fix this by making the tower shoot at the closest enemy to the tower.

### Step 2: Tower
#### POI

#### Text tutorial
- Go into the Tower script, to the place where we set the `target` variable to the `targets[0]`.
- Here we wanna change the `targets[0]` to the enemy closest to the tower his position.

### Step 3:
#### POI

#### Text tutorial