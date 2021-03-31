/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;

/**
 *
 * @author hugotavares
 */
@Entity
public class CotacaoProduto {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    @ManyToOne()
    private Cotacao cotacao;
    @ManyToOne()
    private Produto produto;
    private Double valorProuto;

    public CotacaoProduto() {
    }

    public CotacaoProduto(Cotacao cotacao, Produto produto, Double valorProuto) {
        this.cotacao = cotacao;
        this.produto = produto;
        this.valorProuto = valorProuto;
    }
    
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Cotacao getCotacao() {
        return cotacao;
    }

    public void setCotacao(Cotacao cotacao) {
        this.cotacao = cotacao;
    }

    public Produto getProduto() {
        return produto;
    }

    public void setProduto(Produto produto) {
        this.produto = produto;
    }

    public Double getValorProuto() {
        return valorProuto;
    }

    public void setValorProuto(Double valorProuto) {
        this.valorProuto = valorProuto;
    }
}
