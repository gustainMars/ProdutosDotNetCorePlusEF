import axios from 'axios'
import type { Produto } from '../interface/produto'
import { PRODUTO_ENDPOINT } from '../constants'

export async function cadastrarProduto(produto: Produto): Promise<void> {
    try {
        await axios.post(PRODUTO_ENDPOINT, produto)
    } catch (error) {
        console.error('Erro ao salvar produto:', error)
    }
}

export async function carregarProdutos(): Promise<Produto[]> {
    try {
      const response = await axios.get<Produto[]>(PRODUTO_ENDPOINT)
      return response.data
    } catch (error) {
      console.error('Erro ao buscar produtos:', error)
      return []
    }
}