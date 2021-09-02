using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoDoUsuario = ObterOpcaoUsuario();
            while(opcaoDoUsuario.ToUpper() != "X")
            {
                switch(opcaoDoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    
                    case "2":
                        InserirSerie();
                        break;
                    
                    case "3":
                        AtualizarSerie();
                        break;
                    
                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        //visualizarSerie();
                        break;

                    case "c":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }
                opcaoDoUsuario = ObterOpcaoUsuario();
            }
        }

        //Listar Séries
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                //Console.WriteLine(serie.retornaId());
                Console.WriteLine("ID{0} - {1}", serie.retornaId(), serie.retornaTitulo() );
            }
        }

        //INSERIR SÉRIE
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de início da série: ");
            int entradaAno =  int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }

        //Atualizar série

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = (Console.ReadLine());

            Console.WriteLine("Digite o Ano de início da série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = (Console.ReadLine());

            Series atualizaSerie = new Series(  id: indiceSerie,
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);           
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
           
            var list = repositorio.RetornaTituloPorId(indiceSerie);
            Console.WriteLine("Deseja mesmo excluir a Série: "+ list);
            Console.WriteLine("1 - Sim! ");
            Console.WriteLine("2 - Não! ");

            
            int opcaoUsuario = int.Parse(Console.ReadLine());
            if(opcaoUsuario == 1)
            {
            repositorio.Exclui(indiceSerie);
            Console.WriteLine("Série excluida com sucesso");
            ObterOpcaoUsuario();
            }else
            {
                ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries ao seu dispor");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoDoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoDoUsuario;
        }

    }
}
