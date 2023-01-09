programa
{	
	inclua biblioteca Tipos

	funcao inteiro validaValorInteiro(cadeia valor)
	{
		se (nao Tipos.cadeia_e_inteiro(valor, 10)) {
			escreva("Entre com um valor válido\n")

			retorne -1
		}
		
		inteiro valorConvertido = Tipos.cadeia_para_inteiro(valor,10)

		se (valorConvertido >= 0) {
			retorne valorConvertido
		}

		senao {
			escreva("Entre com um valor válido\n")

			retorne -1
		}	
	}

	funcao real validaValorReal(cadeia valor)
	{
		se (nao Tipos.cadeia_e_inteiro(valor, 10) e nao Tipos.cadeia_e_real(valor)) {
			escreva("Entre com um valor válido\n")

			retorne -1.0
		}
		
		real valorConvertido = Tipos.cadeia_para_real(valor)

		se (valorConvertido > 0) {
			retorne valorConvertido
		}

		senao {
			escreva("Entre com um valor válido\n")

			retorne -1.0
		}	
	}
	
	funcao inicio()
	{
		escreva("Programa para calcular o lucro sobre venda de um produto\n\n")
		
		cadeia produto
		logico parada = falso
		cadeia valorString
		inteiro quantidade
		real precoCompra
		real precoVenda
		inteiro opcao
		real lucro
		
		enquanto (nao parada) {
			escreva("Entre com o nome do produto: ")
			leia(produto)

			escreva("\nEntre com a quantidade do produto: ")
			leia(valorString)

			quantidade = validaValorInteiro(valorString)
			se (quantidade < 0) {
				retorne
			}

			escreva("\nEntre com o preço de compra do produto: ")
			leia(valorString)

			precoCompra = validaValorReal(valorString)
			se (precoCompra < 0) {
				retorne
			}

			escreva("\nEntre com o preço de venda do produto: ")
			leia(valorString)

			precoVenda = validaValorReal(valorString)
			se (precoVenda < 0) {
				retorne
			}
			// calcula o lucro considerando 20% de imposto por isso 0.8, pois o imposto equivale a 0.2
			lucro = ((precoVenda * quantidade) - (precoCompra * quantidade)) * 0.8
			se (lucro > 0) {		// se houver lucro
				escreva("\n\nO lucro sobre o produto ", produto, " é: ", lucro, " R$\n")
			}
			senao se (lucro == 0) {		// caso seja 0 o lucro
				escreva("\n\nNão houve lucro sobre o produto ", produto, "\n")
			}
			senao {		// caso o lucro seja menor que 0
				escreva("\n\nHouve um prejuízo sobre o produto ", produto, " de ", lucro, "R$\n")
			}
			
			escreva("\n\nAdicionar mais produtos?\n0-Não\n1-Sim\n")
			leia(valorString)

			opcao = validaValorInteiro(valorString)
			se (opcao == 0) {
				parada = verdadeiro
			}
			senao se (opcao < 0) {
				retorne
			}
		}
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 2089; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */