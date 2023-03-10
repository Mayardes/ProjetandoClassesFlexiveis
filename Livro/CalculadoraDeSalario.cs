namespace Livro
{
    public interface IFuncionario
    {
        IFuncionario GetCargo();
        Guid Id { get; set; }
        string Nome { get; set; }
        double Salario { get; set; }
        double GetSalarioBase();
    }
    public class Desenvolvedor : IFuncionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }
        public IFuncionario GetCargo()
        {
            return new Desenvolvedor();
        }
        public double GetSalarioBase()
        {
            return Salario;
        }
    }
    public class Tester : IFuncionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }
        public double GetSalarioBase()
        {
            return Salario;
        }
        public IFuncionario GetCargo()
        {
            return new Desenvolvedor();
        }
    }
    public class Funcionario : IFuncionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }

        public double GetSalarioBase()
        {
            return Salario;
        }
        public IFuncionario GetCargo()
        {
            return new Funcionario();
        }
    }
    public class Dba : IFuncionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }
        public double GetSalarioBase()
        {
            return Salario;
        }
        public IFuncionario GetCargo()
        {
            return new Dba();
        }
    }
    public interface IRegraDeCalculo
    {
        double Calcula(Funcionario funcionario);
    }
    public class CalculaDezOuVintePorCento : IRegraDeCalculo
    {
        public double Calcula(Funcionario funcionario)
        {
            return funcionario.GetSalarioBase() * 0.8;
        }
    }
    public class CalculaQuinzeOuVinteCincoPorCento : IRegraDeCalculo
    {
        public double Calcula(Funcionario funcionario)
        {
            return funcionario.GetSalarioBase() * 0.9;
        }
    }

    public class CalculadoraDeSalario
    {
        IFuncionario desenvolvedor = new Desenvolvedor();
        IFuncionario dba = new Dba();
        public double Calcula(Funcionario funcionario)
        {
            try
            {
                if (desenvolvedor.Equals(funcionario.GetCargo()))
                {
                    return new CalculaDezOuVintePorCento().Calcula(funcionario);
                }
                if (dba.Equals(funcionario.GetCargo()))
                {
                    return new CalculaQuinzeOuVinteCincoPorCento().Calcula(funcionario);
                }

                return 0;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
