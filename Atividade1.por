programa
{
	
	funcao inicio()
	{
		//declaração de variáveis
		real quilometrosRodados
		real litrosAbastecidos
		real consumoVeiculo
		logico valorNegativo

		//entrada de valores
		escreva("\nQuantos litros foram abastecidos no veículo? ")
		leia(litrosAbastecidos)
		
		escreva("\nQuantos quilômetros foram rodados? ")
		leia(quilometrosRodados)

		//verifica se o valor entrado é negativo
		valorNegativo = validacaoValores (litrosAbastecidos, quilometrosRodados)

		//se algum valor for negativo encerra o programa
		se (valorNegativo) {
			escreva("\nUm dos valores ou ambos os valores entrados é negativo.\n")
		}
		senao {
			//calculo do consumo
			consumoVeiculo = quilometrosRodados / litrosAbastecidos

			//mostrar resultados
			escreva("\nO consumo do veículo é ", consumoVeiculo, " litro(s) por quilômetro.\n\n")
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
 * @POSICAO-CURSOR = 714; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */