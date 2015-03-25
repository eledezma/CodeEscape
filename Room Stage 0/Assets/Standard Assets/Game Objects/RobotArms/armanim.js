#pragma strict
internal var animate: Animator;
var walking:float;

var run:float;



function Start () {

animate= GetComponent(Animator);
}

function Update () {
if(Input.GetKeyDown("r")){
run=0.1;
}
if(Input.GetKeyUp("r")){
run=0.0;
}
if(Input.GetKeyDown("w")||Input.GetKeyDown("up")){
		walking=0.1;
	
	}
	if(Input.GetKeyUp("w")||Input.GetKeyUp("up")){
		walking=0.0;
	
	}
	if(Input.GetKeyDown("s")||Input.GetKeyDown("down")){
		walking=0.1;
	
	}
	if(Input.GetKeyUp("s")||Input.GetKeyUp("down")){
		walking=0.0;
	
	}
	if(Input.GetKeyDown("a")||Input.GetKeyDown("left")){
		walking=0.1;
	
	}
	if(Input.GetKeyUp("a")||Input.GetKeyUp("left")){
		walking=0.0;
	
	}
    if(Input.GetKeyDown("d")||Input.GetKeyDown("right")){
		walking=0.1;
	
	}
	if(Input.GetKeyUp("d")||Input.GetKeyUp("right")){
		walking=0.0;
	
	}
}
function FixedUpdate(){
animate.SetFloat("walking", walking);
animate.SetFloat("run", run);
}