#pragma strict
internal var animate: Animator;
var walking:float;
var jackn:float;

var run:float;



function Start () {

animate= GetComponent(Animator);
}

function Update () {
//if(walking<-1||walking>1){walking=0.0;}
if(Input.GetKeyDown(KeyCode.LeftShift)){
run++;

}
if(Input.GetKeyUp(KeyCode.LeftShift)){
run--;
}
if(Input.GetKeyDown("e")){
jackn++;
}
if(Input.GetKeyUp("e")){
jackn--;
}

if(Input.GetKeyDown("w")||Input.GetKeyDown("up")){
		walking++;
	
	}
	if(Input.GetKeyUp("w")||Input.GetKeyUp("up")){
		walking--;
	
	}
	if(Input.GetKeyDown("s")||Input.GetKeyDown("down")){
		walking++;
	
	}
	if(Input.GetKeyUp("s")||Input.GetKeyUp("down")){
		walking--;
	
	}
	if(Input.GetKeyDown("a")||Input.GetKeyDown("left")){
		walking++;
	
	}
	if(Input.GetKeyUp("a")||Input.GetKeyUp("left")){
		walking--;
	
	}
    if(Input.GetKeyDown("d")||Input.GetKeyDown("right")){
		walking++;
	
	}
	if(Input.GetKeyUp("d")||Input.GetKeyUp("right")){
		walking--;
	
	}
}
function FixedUpdate(){
animate.SetFloat("walking", walking);
animate.SetFloat("run", run);
animate.SetFloat("jackn",jackn);
}