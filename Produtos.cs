using System;

public class Produtos{
    private int cod;
    private string nome;
    private double preco;
    private int quantidade;

public Produtos(int cod, string nome, double preco, int quantidade){
    this.cod=cod;
    this.nome=nome;
    this.preco=preco;
    this.quantidade=quantidade;

}
public void setCod(int cod){
    this.cod=cod;
    }
public void setNome(string nome){
    this.nome=nome;
    }
public void setPreco(double preco){
    this.preco=preco;
    }   
public void setQuantidade(int quantidade){
    this.quantidade=quantidade;
    }   
public string GetNome(){
    return nome;
    }
public double GetPreco(){
    return preco;
    }
public int GetQuantidade(){
    return quantidade;
    }
public int GetCod(){
    return cod;
    }
}
