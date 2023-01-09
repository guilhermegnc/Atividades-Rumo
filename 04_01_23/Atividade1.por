programa
{
	inclua biblioteca Tipos

	
	funcao real validaValor(cadeia valor)
	{
		se (nao Tipos.cadeia_e_inteiro(valor, 10) e nao Tipos.cadeia_e_real(valor)) {
			escreva("Entre com um valor válido\n")

			retorne -2.0
		}
		
		real valorConvertido = Tipos.cadeia_para_real(valor)

		retorne valorConvertido
		
	}
	
	funcao inicio()
	{
		escreva("Calculadora média da prova\n\n")

		escreva("Entre com as notas uma por vez. Para parar o programa entre com -1\n")

		logico parada = falso	//flag para parada do loop
		inteiro contador = 0	//contador de notas
		real somaNotas = 0.0
		real nota
		cadeia notaString
		real mediaNotas

		enquanto (nao parada) {
			escreva("Nota ", contador++, ": ")
			leia(notaString)
			nota = validaValor(notaString)
			
			se (nota == -1.0) {			// -1.0 é a condição de parada do loop
				parada = verdadeiro		// para o loop
				
				se(contador-1 == 0) {					//caso pare o programa sem ter inserido nenhuma nota
					escreva("Não foram inseridas notas\n")
				}
				senao {
					mediaNotas = somaNotas / (contador-1)		//contador-1 porque ao entrar com -1 o contador aumenta 1
					escreva("A média da turma foi: ", mediaNotas, "\n")
				}
			} 
			
			senao se (nota == -2.0) {
				contador--		// caso entre com um valor invalido como uma letra por exemplo
			}
			
			senao {
				somaNotas += nota		// entrou com a nota corretamente soma a nota a variavel somaNotas
			}
		}

		
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 1422; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */