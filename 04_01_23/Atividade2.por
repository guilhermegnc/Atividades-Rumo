programa
{
	inclua biblioteca Tipos
	
	funcao inicio()
	{
		escreva("Programa para exibição de numeros positivos\n\n")

		cadeia valorString
		inteiro valores[15]

		para (inteiro contador = 0; contador < 15; contador++) {
			escreva("Entre com o ", contador+1 ,"º valor: ")
			leia(valorString)

			se (nao Tipos.cadeia_e_inteiro(valorString, 10)) { //se não for um valor válido
				
				escreva("Entre com um valor válido\n")
				retorne
			}

			valores[contador] = Tipos.cadeia_para_inteiro(valorString, 10) //converte para inteiro
		}

		escreva("\n\nNúmeros positivos abaixo\n\n")
		
		para (inteiro contador = 0; contador < 15; contador++) { //mostra os números positivos
			se (valores[contador] > 0) {
				escreva("Número: ", valores[contador], "\n")
			}
		}
		
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 684; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */