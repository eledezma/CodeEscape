#pragma strict
internal var animate: Animator;
var walking:float;


function Start () {

animate= GetComponent(Animator);
}

function Update () {
if(Input.GetKeyDown("w")||Input.GetKeyDown("up")){
		walking+=1;
	
	}
	if(Input.GetKeyUp("w")||Input.GetKeyUp("up")){
		walking-=1;
	
	}
	if(Input.GetKeyDown("s")||Input.GetKeyDown("down")){
		walking+=1;
	
	}
	if(Input.GetKeyUp("s")||Input.GetKeyUp("down")){
		walking-=1;
	
	}
	if(Input.GetKeyDown("a")||Input.GetKeyDown("left")){
		walking+=1;
	
	}
	if(Input.GetKeyUp("a")||Input.GetKeyUp("left")){
		walking-=1;
	
	}
    if(Input.GetKeyDown("d")||Input.GetKeyDown("right")){
		walking+=1;
	
	}
	if(Input.GetKeyUp("d")||Input.GetKeyUp("right")){
		walking-=1;
	
	}
}
function FixedUpdate(){
animate.SetFloat("walking", walking);
}