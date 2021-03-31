/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.repository;

import com.tbp.model.CotacaoProduto;
import java.util.List;
import org.springframework.data.repository.CrudRepository;

/**
 *
 * @author hugotavares
 */
public interface CotacaoProdutoRepository extends CrudRepository<CotacaoProduto, Integer> {
    List<CotacaoProduto> findByCotacaoId(int codigo);
    
    CotacaoProduto findByCotacaoIdAndProdutoId(int cotacao, Integer produto);
}
