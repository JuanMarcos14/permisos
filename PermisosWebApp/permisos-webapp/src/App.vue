<template>
  <div id="app">
    <Header />
    <permisos />
  </div>
</template>

<script>
import Header from './components/Header.vue'
import Permisos from './components/Permisos.vue'

export default {
  name: 'App',
  components: {
    Header,
    Permisos
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
