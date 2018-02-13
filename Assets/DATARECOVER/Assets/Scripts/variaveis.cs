using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class variaveis : MonoBehaviour {

	//CHAMANDO AS CLASSES
	zumbi z;
	zumbi_filho zf;



	void Start () {

		//CRIAÇÃO DE OBJETOS
		/*z = new zumbi ();
		zf = new zumbi_filho ();
		print (z.cor);
		print (z.forca);
		print (z.vida);
		z.andar ();
		zf.andar();
*/

		// ARRAY(vetor) DE STRING
		//string[] array = { "a","b", "c", "d"};
			//print (array[0]);
		//for (int x = 0; x < 11; x++) {
		//	print (x);
		//}


		//LISTA
		List<int> lista = new List<int> ();
		for (int i = 0; i < 11; i++) {
			lista.Add (i);
		}

		foreach (int valor in lista) {
			print (valor);
		}
	}
	
	
	void Update () {
		
	}
}
class zumbi : MonoBehaviour {
	public string cor = "preto";
	public int forca = 3;
	public int vida = 100;

	public virtual void andar()
	{
		print ("o zumbi está andando");
	}
}

class zumbi_filho : zumbi {

	public override void andar ()
	{
		print ("o zumbi filho está andando");
	}
}