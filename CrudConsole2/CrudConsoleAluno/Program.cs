using System;
using System.Data.SqlClient;

namespace CrudConsoleAluno
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection c = new Connection();
            SqlConnection con = c.Conectar();
            Curso curso = new Curso();
            Aluno aluno = new Aluno();
            DadosCurso dadosCurso = new DadosCurso();
            DadosAluno dadosAluno = new DadosAluno();

            int op = 0;
            string resp = "S";

            while (resp == "S" || resp == "s")
            {
                Console.WriteLine("MENU\n1- CURSOS\n2- MATRICULAS\n3- SAIR");
                op = int.Parse(Console.ReadLine());
                Console.ReadLine();
                Console.Clear();
                switch (op)
                {
                    case 1:
                        Console.WriteLine("///// CURSOS /////");
                        Console.WriteLine("1- INSERIR CURSO\n2- ALTERAR CURSO\n3- CONSULTAR CURSO\n4- EXCLUIR CURSO\n5- SAIR");
                        op = int.Parse(Console.ReadLine());
                        Console.ReadLine();
                        Console.Clear();
                        switch (op)
                        {
                            case 1:
                                {
                                    dadosCurso.SetIdCurso(0);
                                    dadosCurso.SetDescCurso(null);
                                    dadosCurso.SetDuracaoCurso(0);
                                    dadosCurso.SetValorCurso(0);

                                    Console.WriteLine("///// INSERIR CURSO /////");
                                    
                                    Console.WriteLine("Digite o ID do curso:");
                                    dadosCurso.SetIdCurso(int.Parse(Console.ReadLine()));
                                    if (dadosCurso.GetDescCurso() == null)
                                    {
                                        Console.WriteLine("Curso com Nº já registrado");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Digite o nome do curso");
                                        dadosCurso.SetDescCurso(Console.ReadLine());

                                        Console.WriteLine("Digite a duração do curso");
                                        dadosCurso.SetDuracaoCurso(int.Parse(Console.ReadLine()));

                                        Console.WriteLine("Digite o valor do curso");
                                        dadosCurso.SetValorCurso(int.Parse(Console.ReadLine()));

                                        curso.InserirCurso(con, dadosCurso.GetIdCurso(), dadosCurso.GetDescCurso(), dadosCurso.GetDuracaoCurso(), dadosCurso.GetValorCurso());
                                    }
                                    break; 
                                }     
                            case 2:
                                {
                                    Console.WriteLine("///// ALTERAR CURSO /////");

                                    Console.WriteLine("Digite o ID do curso que deseja alterar:");
                                    dadosCurso.SetIdCurso(int.Parse(Console.ReadLine()));

                                    Console.WriteLine("///NOVOS DADOS DO CURSO///");

                                    Console.WriteLine("Nome:");
                                    dadosCurso.SetDescCurso(Console.ReadLine());

                                    Console.WriteLine("Duração:");
                                    dadosCurso.SetDuracaoCurso(int.Parse(Console.ReadLine()));

                                    Console.WriteLine("Valor:");
                                    dadosCurso.SetValorCurso(double.Parse(Console.ReadLine()));

                                    curso.AlterarCurso(con, dadosCurso.GetDescCurso(), dadosCurso.GetDuracaoCurso(), dadosCurso.GetValorCurso(), dadosCurso.GetIdCurso());
                                    break;
                                }
                            case 3:
                                {
                                    dadosCurso.SetIdCurso(0);
                                    dadosCurso.SetDescCurso(null);
                                    dadosCurso.SetDuracaoCurso(0);
                                    dadosCurso.SetValorCurso(0);

                                    Console.WriteLine("///// CONSULTAR CURSO /////");

                                    Console.WriteLine("Digite o ID do curso que deseja consultar:");
                                    dadosCurso.SetIdCurso(int.Parse(Console.ReadLine()));
                                    dadosCurso = curso.ConsultarCurso(con, dadosCurso.GetIdCurso(), dadosCurso);

                                    if (dadosCurso.GetDescCurso() == null)
                                    {
                                        Console.WriteLine("Curso não encontrado!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("INFORMAÇÕES DO CURSO");
                                        Console.WriteLine("Nº: " + dadosCurso.GetIdCurso());
                                        Console.WriteLine("Nome: " + dadosCurso.GetDescCurso());
                                        Console.WriteLine("Duração: " + dadosCurso.GetDuracaoCurso());
                                        Console.WriteLine("Valor: " + dadosCurso.GetValorCurso());
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("///// EXCLUIR CURSO /////");

                                    Console.WriteLine("Digite o ID do curso que deseja EXCLUIR:");
                                    dadosCurso.SetIdCurso(int.Parse(Console.ReadLine()));
                                    curso.ExcluirCurso(con, dadosCurso.GetIdCurso());
                                    break;
                                }

                            case 5:
                                c.Fechar();
                                break;
                        }
                        break;
                    
                    case 2:
                        Console.WriteLine("///// MATRÍCULA /////");
                        Console.WriteLine("1- REGISTRAR MATRÍCULA\n2- ALTERAR MATRICULA\n3- CONSULTAR MATRICULA\n4- EXCLUIR MATRICULA\n5- SAIR");
                        op = int.Parse(Console.ReadLine());
                        Console.ReadLine();
                        Console.Clear();
                        switch (op)
                        {
                            case 1:
                                {
                                    dadosAluno.SetMat(0);
                                    dadosAluno.SetNome(null);
                                    dadosAluno.SetCPF(null);
                                    dadosAluno.SetEmail(null);
                                    dadosAluno.SetTelefone(null);
                                    dadosAluno.SetCidade(null);
                                    dadosAluno.SetUf(null);
                                    dadosAluno.SetIdCurso(0);
                                    
                                    Console.WriteLine("///// MATRICULAR ALUNO /////");
                                    Console.WriteLine("Digite o Nº da matrícula: ");
                                    dadosAluno.SetMat(int.Parse(Console.ReadLine()));
                                    dadosAluno = aluno.ConsultarMatricula(con, dadosAluno.GetMat(), dadosAluno);

                                    if (dadosAluno.GetNome() != null)
                                    {
                                        Console.WriteLine("Nº de matrícula já registrada");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nome:");
                                        dadosAluno.SetNome(Console.ReadLine());

                                        Console.WriteLine("CPF: ");
                                        dadosAluno.SetCPF(Console.ReadLine());

                                        Console.WriteLine("Email: ");
                                        dadosAluno.SetEmail(Console.ReadLine());

                                        Console.WriteLine("Telefone: ");
                                        dadosAluno.SetTelefone(Console.ReadLine());

                                        Console.WriteLine("Cidade: ");
                                        dadosAluno.SetCidade(Console.ReadLine());

                                        Console.WriteLine("UF: ");
                                        dadosAluno.SetUf(Console.ReadLine());

                                        Console.WriteLine("Nº do curso: ");
                                        dadosAluno.SetIdCurso(int.Parse(Console.ReadLine()));

                                        aluno.Matricula(con, dadosAluno.GetMat(), dadosAluno.GetNome(), dadosAluno.GetCPF(), dadosAluno.GetEmail(),
                                                        dadosAluno.GetTelefone(), dadosAluno.GetCidade(), dadosAluno.GetUf(), dadosAluno.GetIdCurso());

                                    }

                                    break;
                                }

                            case 2:
                                {
                                    Console.WriteLine("///// ALTERAR MATRÍCULA /////");
                                    
                                    Console.WriteLine("Digite o Nº da matrícula que deseja alterar: ");
                                    dadosAluno.SetMat(int.Parse(Console.ReadLine()));

                                    Console.WriteLine("/// NOVOS DADOS DA MATRÍCULA ///");

                                    Console.WriteLine("Nome: ");
                                    dadosAluno.SetNome(Console.ReadLine());

                                    Console.WriteLine("CPF: ");
                                    dadosAluno.SetCPF(Console.ReadLine());

                                    Console.WriteLine("Email: ");
                                    dadosAluno.SetEmail(Console.ReadLine());

                                    Console.WriteLine("Telefone: ");
                                    dadosAluno.SetTelefone(Console.ReadLine());

                                    Console.WriteLine("Cidade: ");
                                    dadosAluno.SetCidade(Console.ReadLine());

                                    Console.WriteLine("UF: ");
                                    dadosAluno.SetUf(Console.ReadLine());

                                    Console.WriteLine("Codigo do curso: ");
                                    dadosAluno.SetIdCurso(int.Parse(Console.ReadLine()));

                                    aluno.AlterarMatricula(con, dadosAluno.GetNome(), dadosAluno.GetCPF(), dadosAluno.GetEmail(), dadosAluno.GetTelefone(),
                                                           dadosAluno.GetCidade(), dadosAluno.GetUf(), dadosAluno.GetIdCurso(), dadosAluno.GetMat());
                                    
                                }
                                break;

                            case 3:
                                {
                                    dadosAluno.SetMat(0);
                                    dadosAluno.SetNome(null);
                                    dadosAluno.SetCPF(null);
                                    dadosAluno.SetEmail(null);
                                    dadosAluno.SetTelefone(null);
                                    dadosAluno.SetCidade(null);
                                    dadosAluno.SetUf(null);
                                    dadosAluno.SetIdCurso(0);

                                    Console.WriteLine("///// CONSULTAR MATRÍCULA /////");
                                    Console.WriteLine("Digite o Nº da matrícula que deseja consultar:");
                                    dadosAluno.SetMat(int.Parse(Console.ReadLine()));
                                    dadosAluno = aluno.ConsultarMatricula(con, dadosAluno.GetMat(), dadosAluno);
                                    
                                    if(dadosAluno.GetNome() == null)
                                    {
                                        Console.WriteLine("Matrícula não encontrada");
                                    }
                                    else
                                    {
                                        Console.WriteLine("INFORMAÇÕES DA MATRÍCULA");
                                        Console.WriteLine("Nº: " + dadosAluno.GetMat());
                                        Console.WriteLine("Nome: " + dadosAluno.GetNome());
                                        Console.WriteLine("CPF: " + dadosAluno.GetCPF());
                                        Console.WriteLine("Email: " + dadosAluno.GetEmail());
                                        Console.WriteLine("Telefone: " + dadosAluno.GetTelefone());
                                        Console.WriteLine("Cidade: " + dadosAluno.GetCidade());
                                        Console.WriteLine("UF: " + dadosAluno.GetUf());
                                        Console.WriteLine("Nº do curso: " + dadosAluno.GetIdCurso());
                                    }
                                }
                                break;

                            case 4:
                                {
                                    Console.WriteLine("///// EXCLUIR MATRÍCULA /////");
                                    Console.WriteLine("Digite o Nº da matrícula que deseja excluir");
                                    dadosAluno.SetMat(int.Parse(Console.ReadLine()));
                                    aluno.ExcluirMatricula(con, dadosAluno.GetMat());
                                }
                                break;

                            case 5:
                                c.Fechar();
                                break;
                        }
                        break;

                    case 3:
                        resp = "N";
                        c.Fechar();
                        break;
                }
                Console.ReadLine();
                Console.Clear();
                if (op != 3)
                {
                    Console.WriteLine("Deseja continuar ? S - Sim /// N - Não");
                    resp = Console.ReadLine();
                }
            }
            Console.WriteLine("Fim do programa!");
            Console.ReadKey();
        }
    }
}
