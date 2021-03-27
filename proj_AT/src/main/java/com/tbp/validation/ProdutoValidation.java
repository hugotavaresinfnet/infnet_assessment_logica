/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.validation;

import com.tbp.exception.ProdutoInvalidoException;
import com.tbp.repository.ProdutoRepository;
import com.tbp.model.Produto;
import org.springframework.stereotype.Component;

/**
 *
 * @author hugot
 */
@Component
public class ProdutoValidation {
        
        
    public void validar(Produto produto) throws ProdutoInvalidoException, Exception
    {
        if(("").equals(produto.getDescricao()))
            throw new ProdutoInvalidoException("Descrição do produto não informada.");
        
        if(("").equals(produto.getSituacao()))
            throw new ProdutoInvalidoException("Situação do produto não informada.");
    }
}
