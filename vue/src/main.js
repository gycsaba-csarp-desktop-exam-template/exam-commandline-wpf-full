// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
// https://www.bezkoder.com/vue-3-crud
// https://madewithvuejs.com/vuejs-crud
// https://github.com/waseembarcha/vuejs-crud
// https://codersdiaries.com/blog/vue-axios
// https://spring.io/guides/gs/rest-service-cors/
import Vue from 'vue'
import App from './App'
import router from './router'

import {BootstrapVue,BootstrapVueIcons} from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.config.productionTip = false
Vue.use(BootstrapVue);
Vue.use(BootstrapVueIcons);

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
