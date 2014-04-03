#pragma strict
	
	var levelToLoad : String = "level2";		
    function OnTriggerEnter (other : Collider) {   
    Application.LoadLevel ("level2");
    }