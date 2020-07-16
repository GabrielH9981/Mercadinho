public class Cliente{
    private int cod;
    private string nomeCliente;
    private string cpf;
    private int idade;
 

public Cliente(int cod, string nomeCliente, string cpf, int idade){
    this.cod=cod;
    this.nomeCliente=nomeCliente;
    this.cpf=cpf;
    this.idade=idade;
}
public void SetNomeCliente(string nomeCliente){
    this.nomeCliente=nomeCliente;
    }
public void SetCpf(string cpf){
    this.cpf=cpf;
    }
public void SetIdade(int idade){
    this.idade=idade;
    }
public string GetNomeCliente(){
    return nomeCliente;
    }
public string GetCpf(){
    return cpf;
    }
public int GetIdade(){
    return idade;
    }
public int GetCodCliente(){
    return cod;
    }
}