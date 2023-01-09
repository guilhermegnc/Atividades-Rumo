programa
{
	inclua biblioteca Tipos

	funcao inteiro validaValor(cadeia valor)
	{
		se (nao Tipos.cadeia_e_inteiro(valor, 10)) {
			escreva("Entre com um valor válido\n")

			retorne -1
		}
		
		inteiro valorConvertido = Tipos.cadeia_para_inteiro(valor,10)

		se (valorConvertido > 0) {
			retorne valorConvertido
		}

		senao {
			escreva("Entre com um valor válido\n")

			retorne -1
		}	
	}
	
	funcao inicio()
	{
		escreva("Programa para mostrar o mais velho\n\n")

		cadeia nomes[10]
		inteiro idades[10]
		inteiro maiorIdade = 0	//variável com a maior idade entrada pelo usuario

		cadeia entradaUsuario

		para(inteiro contador = 0; contador < 10; contador++) {
			escreva("Entre com o ", contador+1 , "º nome: ")
			leia(nomes[contador])

			escreva("Entre com a ", contador+1 , "ª idade em anos: ")
			leia(entradaUsuario)

			idades[contador] = validaValor(entradaUsuario)

			se (idades[contador] < 0) {
				retorne
			}

			se (maiorIdade < idades[contador]) {	// se a idade entrada pelo usuario for maior do que a que está na variavel maiorIdade
				maiorIdade = idades[contador]
			}
		}

		escreva("\n\nOs mais velhos serão listados abaixo\n")

		para (inteiro contador = 0; contador < 10; contador++) {
			se (idades[contador] == maiorIdade) {		// se a idade na posição do vetor for igual a idade na variável maiorIdade
				escreva("Nome: ", nomes[contador], "\tIdade: ", idades[contador], " anos\n")
			}
		}
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 1340; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */