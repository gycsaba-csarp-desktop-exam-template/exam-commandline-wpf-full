<template>
    <p class="homeText">
      Üdvözöljük a Kreta - iskolai adminisztráció - gykaorló kód weboldalon
    </p>
  </template>
  
  <script>
  export default {
    name: 'Home',
    computed: {
      console: () => console,
      window: () => window,
    },
    methods: {
        mounted() {
          console.log("Nyitóoldal...")
        },
    }
  };
  </script>
  
  <style scoped>
  .homeText{
      font-size: 35px;
      color: gray;
      text-align: center;
      position: relative;
      top:30px;
      text-shadow: 2px 2px 2px gray;
  }
  </style>