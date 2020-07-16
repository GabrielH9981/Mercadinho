using System;
using Figgle;

namespace mercado
{
    class Program
    {
    public static void listaProdutos(int nElem, Produtos[] arrayProduto){
    //percorre um for com todas as posições usadas do vetor e printa
    for (int i=0; i<nElem-1; i++){
        Console.WriteLine("\nCód: "+(arrayProduto[i].GetCod())+"\nNome do Produto: "+arrayProduto[i].GetNome()+"\nPreço: R$"+arrayProduto[i].GetPreco()+"\nQuantidade em Estoque: "+arrayProduto[i].GetQuantidade());
        }
    }
    public static void listaClientes(int nCliente, Cliente[] arrayCliente){
    //percorre um for com todas as posições usadas do vetor e printa
    for (int i=0; i<nCliente-1; i++){
        Console.WriteLine("\nCód: "+(arrayCliente[i].GetCodCliente()+1)+"\nNome do Cliente: "+arrayCliente[i].GetNomeCliente()+"\nCPF: "+arrayCliente[i].GetCpf()+"\nIdade: "+arrayCliente[i].GetIdade());
    }
}
        static void Main(string[] args)
        {       
            string c;
            int compra=1;
            string aux;
            int nElem=1;
            string nome;
            double preco;
            int quantidade;
            string categoria="w";
            string nomeCliente;
            string cpf;
            int idade;
            int nCliente=1;
            double carrinho=0;
            int auxiliar=0;
            int qntd;
            bool valido = false;
            string[] arrayCarrinho = new string[100];
            int contador=0;
            int codCliente=0;
            bool encontrou=false;

            Produtos[] arrayProduto = new Produtos[100];
            Cliente[] arrayCliente = new Cliente[100];

            Console.WriteLine(FiggleFonts.Slant.Render("M E R C A D I N H O"));

            while(categoria!="s"){
                Console.WriteLine("\nDigite a operação que deseja: (a = Cadastro de Produtos, b = Consulta de Produtos c = Lista de Produtos, d = Lista de Clientes, e =  Nova Venda, f= Alterar Preço dos Produtos, g= Lançamento de Mercadoria Nova, s = Sair): ");
                categoria = (Console.ReadLine().ToLower());

            switch(categoria){
                case "a":                  
                //CADASTRO PRODUTO
                    Console.WriteLine("\nDigite o nome do produto: ");
                    nome = (Console.ReadLine());
                    Console.WriteLine("\nDigite o preço do produto: ");
                    preco = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nDigite a quantidade do produto em estoque: ");
                    quantidade = Convert.ToInt32(Console.ReadLine());
                    
                    //Chamada do construtor passando os parametros do cadastro
                    arrayProduto[nElem-1] = new Produtos(nElem,nome,preco,quantidade);
//OBS: professor não sei se você vai ler isso, mas se ler esse negócio de passar nElem-1 é pq eu não queria
//perder a primeira posição do vetor, e eu quis começar com 1 a variável e não com 0, pq na hora de printar
//ia ficar tipo: Cod Produto = 0, ai ia ficar estranho eu poderia ter somado um na hora de printar mas ai de
//qualquer jeito ia ter que tirar fazer -1, só queria explicar mesmo o por que dessa gambiarra kkkk
//OBS2: eu fiz essa mesma gambiarra com cliente pra n ficar como cod 0 tb kkkk
                    nElem++;
                break;

                case "b":
                //CONSULTA PRODUTOS
                    Console.WriteLine("\nDigite o nome do produto que deseja buscar: ");
                    aux = Console.ReadLine();
                    for (int i=0; i<nElem-1; i++){
                        //Comparação do nome digitado com todos os nomes de produtos cadastrados
                        if (string.Equals(aux,arrayProduto[i].GetNome())){
                            //retorna o produto caso ele encontre
                            Console.WriteLine("\nCód: "+arrayProduto[i].GetCod()+"\nNome do Produto: "+arrayProduto[i].GetNome()+"\nPreço: R$"+arrayProduto[i].GetPreco()+"\nQuantidade em Estoque: "+arrayProduto[i].GetQuantidade());
                            encontrou=true;
                    }
                }
                if (encontrou==false){
                    Console.WriteLine("Produto não encontrado :( \n Tente Cadastrá-lo antes :v");
                }
                encontrou=false;
                break;

                case "c":
                //LISTA PRODUTOS
                   listaProdutos(nElem, arrayProduto); 
                break;

                case "e":
                //NOVA VENDA
                if(nElem==1){
                    Console.WriteLine("Nenhum produto cadastrado :( \n Cadastre um produto e depois volte, te aguardo :D");
                    break;
                }
                    //IF COM VARIÁVEL AUXILIAR PRA SÓ RODAR UMA VEZ PARA FAZER O PRIMEIRO CADASTRO DE CLIENTE
                    if(auxiliar==0){
                            Console.WriteLine("Nenhum cliente cadastrado, cadastre agora:");
                            Console.WriteLine("\nDigite o nome do cliente: ");
                            nomeCliente = (Console.ReadLine());
                            Console.WriteLine("Digite o cpf do cliente: ");
                            cpf = Console.ReadLine();
                            Console.WriteLine("Digite a idade do cliente: ");
                            idade = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n Cliente Cadastrado com Sucesso !");

                            //Chamada do construtor passando os parametros do cadastro
                            arrayCliente[nCliente-1] = new Cliente (nCliente-1,nomeCliente,cpf,idade);
                            nCliente++;  
                            auxiliar++;                      
                    }
                    
                    Console.WriteLine("\nDigite o nome do cliente para entrar: ");
                    c = Console.ReadLine();

                    for (int i=0; i<nCliente-1; i++){
                        //validar se existe algum cliente com o nome digitado
                        if (string.Equals(c,arrayCliente[i].GetNomeCliente())==true){
                            valido=true;
                            //pegar cod dele e guardar em uma variavel pra printar no relatorio do pedido final
                            codCliente=arrayCliente[i].GetCodCliente();
                            //quando encontrar o cliente sai do laço
                            break;
                        }
                        else{
                            valido=false;
                        }
                    }
                        //caso tenha o cliente começa a venda
                        if (valido==true){
                            while(compra!=0){
                                Console.WriteLine("\nLISTA DE PRODUTOS DO MERCADO");
                                //função para listar todos os produtos
                                listaProdutos(nElem, arrayProduto);  
                                    
                                Console.WriteLine("\nDigite o código do produto que deseja adicionar ao carrinho (Para finalizar a compra digite 0): ");
                                compra = Convert.ToInt32(Console.ReadLine());

                            //caso o código não esteja cadastrado ele pede até digitar um cod válido ou finalizar compra
                            while (compra>nElem-1){
                                Console.WriteLine("\nCódigo Inválido !");
                                listaProdutos(nElem, arrayProduto);
                                Console.WriteLine("\nDigite o código do produto que deseja adicionar ao carrinho (Para finalizar a compra digite 0): ");
                                compra = Convert.ToInt32(Console.ReadLine());
                            }
                            //finaliza compra, caso tenha digitado 0 dentro do while acima 
                            if(compra==0){
                                break;
                            }
                                Console.WriteLine("\nDigite a quantidade do produto que deseja (para não incluir no carrinho digite 0):");
                                qntd = Convert.ToInt32(Console.ReadLine());

                                //passa a quantidade em estoque para uma variavel
                                quantidade = arrayProduto[compra-1].GetQuantidade(); 

                            //caso a quantidade seja inválida pede até digitar uma quantidade válida ou desistir do item  
                            while(qntd>quantidade){
                                Console.WriteLine("Quantidade disponível é de apenas "+quantidade+". Digite uma quantidade válida (para não incluir item no carrinho digite 0):");
                                qntd = Convert.ToInt32(Console.ReadLine());
                            }
                                
                            //carrinho de compras
                            if (qntd!=0){
                                arrayCarrinho[contador]=arrayProduto[compra-1].GetNome();
                                contador++;
                                arrayCarrinho[contador]=Convert.ToString(arrayProduto[compra-1].GetPreco());
                                contador++;
                                arrayCarrinho[contador]=Convert.ToString(qntd);
                                contador++;
                                
                                //soma dos produtos
                                carrinho+=(arrayProduto[compra-1].GetPreco()*qntd);
                                //retira a quantidade do estoque
                                arrayProduto[compra-1].setQuantidade(quantidade-qntd);
                                //printa soma parcial
                                Console.WriteLine("\nValor Parcial do Carrinho: R$"+carrinho);
                            }     
                        }

                        //print dos dados do cliente
                        Console.WriteLine("Nome do Cliente: "+arrayCliente[codCliente].GetNomeCliente()+" | CPF: "+arrayCliente[codCliente].GetCpf());
                        
                        //print do carrinho com seus respectivos itens, preços e quantidades
                        for (int i=0; i<contador-1; i+=3){
                                Console.WriteLine("Item: " + arrayCarrinho[i] + " | Preço: R$" + arrayCarrinho[i+1] + " | Quantidade: "+ arrayCarrinho[i+2]);
                                arrayCarrinho[i]=null;
                                arrayCarrinho[i+1]=null;
                                arrayCarrinho[i+2]=null;
                            }
                        Console.WriteLine("Valor Total: R$"+carrinho);

                        //reset de variavéis auxiliares
                        contador=0;
                        compra=1;
                        carrinho=0;
                        }

                        //caso cliente n cadastrado, faz o cadastro
                        else{
                            Console.WriteLine("Cliente não cadastrado, cadastre agora:");
                            Console.WriteLine("\nDigite o nome do cliente: ");
                            nomeCliente = (Console.ReadLine());
                            Console.WriteLine("Digite o cpf do cliente: ");
                            cpf = Console.ReadLine();
                            Console.WriteLine("Digite a idade do cliente: ");
                            idade = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n Cliente Cadastrado com Sucesso !");

                            arrayCliente[nCliente-1] = new Cliente (nCliente-1,nomeCliente,cpf,idade);
                            nCliente++;
                            valido=true;
                        }
                break;

                case "d":
                //chama função lista 
                    listaClientes(nCliente, arrayCliente);
                break;

                case "f":
                //Ajuste de Preço
                    Console.WriteLine("\nDigite o nome do produto que deseja alterar: ");
                    aux = Console.ReadLine();
                    for (int i=0; i<nElem-1; i++){
                        //Comparação do nome digitado com todos os nomes de produtos cadastrados
                        if (string.Equals(aux,arrayProduto[i].GetNome())){
                            Console.WriteLine("Digite o novo preço: ");
                            //eu jurava que isso aq embaixo de chamar uma função dentro de uma função que ta
                            //dentro de outra função não ia dar certo mas arrisquei e deu kkk
                            arrayProduto[i].setPreco(Convert.ToInt32(Console.ReadLine()));
                            Console.WriteLine("Preço Atualizado com Sucesso :D");
                            encontrou=true;
                    }
                }
                if(encontrou==false){
                    Console.WriteLine("Produto não encontrado :( \n Tente Cadastrá-lo antes :v");
                }
                encontrou=false;

                break;

                case "g":
                //MERCADORIA NOVA
                    Console.WriteLine("\nDigite o nome do produto que deseja buscar: ");
                    aux = Console.ReadLine();
                    for (int i=0; i<nElem-1; i++){
                        //Comparação do nome digitado com todos os nomes de produtos cadastrados
                        if (string.Equals(aux,arrayProduto[i].GetNome())){
                            Console.WriteLine("\nDigite a quantidade de itens que chegou desse produto: ");
                            //eu nem ia fazer essa requisição de adicionar mercadoria só que me deu a ideia 
                            //depois da alteração de preço que tinha uma 3 funções dentro da outra que eu
                            //tive a ideia de tentar um nível a mais com 4 e deu certo kkk são 04h da manhã
                            //não sei mais oq estou fazendo da vida, mas é isso funcionou pelo menos.
                            arrayProduto[i].setQuantidade(Convert.ToInt32((Console.ReadLine()))+arrayProduto[i].GetQuantidade());
                            Console.WriteLine("\nOs itens que chegaram foram adicionados em seu estoque :D");
                            encontrou=true;
                    }
                }
                if(encontrou==false){
                    Console.WriteLine("\nProduto não encontrado :( \n Tente Cadastrá-lo antes :v");
                }
                encontrou=false;

                break;

                 }
            }
        }
    }
}