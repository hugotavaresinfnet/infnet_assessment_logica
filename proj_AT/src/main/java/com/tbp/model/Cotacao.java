/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.model;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

/**
 *
 * @author hugot
 */
@Entity
@Table(name = "cotacao")
public class Cotacao {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    @Column(name = "data")
    private Date data;
    @Column(name = "validade")
    private Date validade;
    @Column(name = "fornecedor")
    private String fornecedor;
    @ManyToOne()
    @JoinColumn(name = "id_produto")
    private Produto produto;
    @Column(name="valor_produto")
    private Double valorProduto;

    public Cotacao() {
    }

    public Cotacao(Date data, Date validade, String fornecedor, Produto produto, Double valorProduto) {
        this.data = data;
        this.validade = validade;
        this.fornecedor = fornecedor;
        this.produto = produto;
        this.valorProduto = valorProduto;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Date getData() {
        return data;
    }

    public void setData(Date data) {
        this.data = data;
    }

    public Date getValidade() {
        return validade;
    }

    public void setValidade(Date validade) {
        this.validade = validade;
    }

    public String getFornecedor() {
        return fornecedor;
    }

    public void setFornecedor(String fornecedor) {
        this.fornecedor = fornecedor;
    }

    public Produto getProduto() {
        return produto;
    }

    public void setProduto(Produto produto) {
        this.produto = produto;
    }

    public Double getValorProduto() {
        return valorProduto;
    }

    public void setValorProduto(Double valorProduto) {
        this.valorProduto = valorProduto;
    }
    
    
}
