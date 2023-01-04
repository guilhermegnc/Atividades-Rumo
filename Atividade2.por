programa
{
	
	funcao inicio()
	{
		//declaração de variaveis
		real litrosAbastecidos
		real consumoVeiculo
		real distanciaMaxima
		logico valorNegativo

		//entrada de valores
		escreva("\nQual o consumo do veículo em litros por quilômetro? ")
		leia(consumoVeiculo)

		escreva("\nQuantos litros foram abastecidos? ")
		leia(litrosAbastecidos)

		//verifica se alguma entrada é negativa
		valorNegativo = validacaoValores(consumoVeiculo, litrosAbastecidos)

		se (valorNegativo) {
			escreva("\nUm dos valores ou ambos os valores entrados é negativo.\n")
		}
		senao {
			//calculo distância máxima ue pode ser percorrida
			distanciaMaxima = consumoVeiculo * litrosAbastecidos

			//mostrar resultados
			escreva("\nA distância máxima que este veículo pode percorrer é ", distanciaMaxima, " Km\n\n")
		}
		
	}

	//funcao que retorna se o valor é negativo ou não
	funcao logico validacaoValores (real valor1, real valor2)
	{
		//se o valor for negativo retorna verdadeiro
		se (valor1 < 0 ou valor2 < 0) {			
			retorne verdadeiro
		}
		senao {
			retorne falso
		}
	}
	
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 811; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */