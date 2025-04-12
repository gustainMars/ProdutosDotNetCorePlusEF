<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type { Produto } from './interface/produto'
import FormProduto from './components/FormProduto.vue'
import { carregarProdutos } from './services/produtoService'

const produtos = ref<Produto[]>([])

const buscarProdutos = async () => {
  produtos.value = await carregarProdutos()
  console.log('Produtos carregados:', produtos.value)
}

onMounted(() => {
  buscarProdutos()
})
</script>

<template>
  <div class="bg-white p-6 rounded-2xl shadow-md w-full max-w-xl mx-auto">   
    <FormProduto @produtoSalvo="buscarProdutos" />
    
    <h2 class="text-xl font-bold mb-4">Produtos cadastrados</h2>
    <ul>
      <li v-for="produto in produtos" :key="produto.id">
        {{ produto.nome }} - R$ {{ produto.preco }} (Estoque: {{ produto.quantidadeEmEstoque }})
      </li>
    </ul>
  </div>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
