using Godot;
using System;

public class mundo : Node2D
{
	float velocidade=0.02f;
	Sprite a;
	Sprite b;
	public override void _Ready() {
		a=GetNode<Sprite>("a");
		b=GetNode<Sprite>("b");
	}
	public override async void _Process(float delta){
		Vector2 posicao_inicial_A=new Vector2(112,180);//esse vector guarda posicao 112,180
		await ToSignal(GetTree().CreateTimer(3),"timeout");//cria um temporizador de 3 segundo
		mover_sprite();//comando executado apo o temporizador
		if(Input.IsActionPressed("ui_right")){//se tecla ui rigth ficar pressionada 
			a.Position=new Vector2(posicao_inicial_A);//teleporta o sprite A para posicao 112,180
		}
	}
	private void mover_sprite(){
		var b_posicaox=b.GetGlobalPosition().x;
		var b_posicaoy=b.GetGlobalPosition().y;
		 a.Position=a.Position.LinearInterpolate(new Vector2(b_posicaox,b_posicaoy),velocidade); 
	}
}
