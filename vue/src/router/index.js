import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import Home from '@/components/Home'
import NotFound from '@/components/error-pages/NotFound'
import SubjectsList from '@/components/subjects/SubjectList'
import EditSubject from '@/components/subjects/EditSubject'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '*',
      name: 'NotFound',
      component: NotFound
    },
    {
      path: "/subject/index",
      name: "Subjects",
      component: SubjectsList
    },
    {
      path: "/subject/:id",
      name: "EditSubject",
      component: EditSubject
    }
  ]
})
