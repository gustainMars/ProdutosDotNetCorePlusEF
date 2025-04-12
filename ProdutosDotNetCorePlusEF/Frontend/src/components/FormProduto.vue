<script setup lang="ts">
import { ref } from 'vue'
import type { Produto } from '../interface/produto'
import { cadastrarProduto } from '../services/produtoService'
import { EVENT_PRODUTO_SALVO } from '../constants'

const emit = defineEmits([EVENT_PRODUTO_SALVO])

const produtoVazio = (): Produto => ({
  id: 0,
  nome: '',
  preco: 0,
  quantidadeEmEstoque: 0,
  rowVersion: ''
})

const produto = ref<Produto>(produtoVazio())

const salvar = async () => {
    await cadastrarProduto(produto.value)
    emit(EVENT_PRODUTO_SALVO)
    produto.value = produtoVazio()    
}
</script>

<template>
    <form @submit.prevent="salvar" class="space-y-6 max-w-md mx-auto p-6 bg-gray-800 rounded-lg shadow-lg">
      <h2 class="text-2xl font-bold text-center text-white mb-6">Cadastro de Produto</h2>
  
      <div>
        <label class="block text-white font-medium mb-2" for="nome">Nome</label>
        <input
          v-model="produto.nome"
          type="text"
          id="nome"
          class="w-full border border-gray-600 rounded-lg p-2 bg-gray-900 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
          required
        />
      </div>
  
      <div>
        <label class="block text-white font-medium mb-2" for="preco">Preço</label>
        <input
          v-model="produto.preco"
          type="number"
          step="0.01"
          id="preco"
          class="w-full border border-gray-600 rounded-lg p-2 bg-gray-900 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
          required
        />
      </div>
  
      <div>
        <label class="block text-white font-medium mb-2" for="estoque">Quantidade em Estoque</label>
        <input
          v-model="produto.quantidadeEmEstoque"
          type="number"
          id="estoque"
          class="w-full border border-gray-600 rounded-lg p-2 bg-gray-900 text-white focus:outline-none focus:ring-2 focus:ring-blue-500"
          required
        />
      </div>
  
      <div class="mt-6 flex justify-end">
        <button
          type="submit"
          class="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition">
          Salvar
        </button>
      </div>
    </form>
  </template>
  