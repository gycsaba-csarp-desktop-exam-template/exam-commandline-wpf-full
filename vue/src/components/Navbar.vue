<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <router-link to="/" class="navbar-brand">Kréta</router-link>
      <div class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link to="/subject/index" class="nav-link">Tantárgyak</router-link>
        </li>
      </div>
    </nav>
  </div>
</template>

<script>
  export default {
    name: 'Navbar'
  };
</script>